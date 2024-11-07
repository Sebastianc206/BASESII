
-- SP PARA CAMBIO DE BOLETOS ---------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_CambiarBoletos
    @idTransaccion INT,
    @idSesion INT,
    @asientosAntiguos NVARCHAR(MAX),
    @nuevosAsientos NVARCHAR(MAX),
    @mensajeError NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Convertir los asientos antiguos y nuevos en tablas temporales
        DECLARE @asientosAntiguosTemp TABLE (fila CHAR(1), numero INT);
        DECLARE @nuevosAsientosTemp TABLE (fila CHAR(1), numero INT);

        INSERT INTO @asientosAntiguosTemp (fila, numero)
        SELECT SUBSTRING(s.value, 1, 1), CAST(SUBSTRING(s.value, 2, LEN(s.value) - 1) AS INT)
        FROM STRING_SPLIT(@asientosAntiguos, ',') AS s;

        INSERT INTO @nuevosAsientosTemp (fila, numero)
        SELECT SUBSTRING(s.value, 1, 1), CAST(SUBSTRING(s.value, 2, LEN(s.value) - 1) AS INT)
        FROM STRING_SPLIT(@nuevosAsientos, ',') AS s;

        -- Verificar que la cantidad de asientos coincida
        IF (SELECT COUNT(*) FROM @asientosAntiguosTemp) != (SELECT COUNT(*) FROM @nuevosAsientosTemp)
        BEGIN
            SET @mensajeError = 'ERROR: La cantidad de asientos antiguos no coincide con la cantidad de asientos nuevos.';
            ROLLBACK TRAN;
            RETURN;
        END;

        -- Liberar los asientos anteriores específicos
        UPDATE ta
        SET ta.Estado_Asignacion = 'Liberado', ta.Fecha_Hora_Asignacion = SYSDATETIME()
        FROM Transaccion_Asiento ta
        JOIN @asientosAntiguosTemp ant ON ta.Fila = ant.fila AND ta.Numero = ant.numero
        WHERE ta.ID_Transaccion = @idTransaccion AND ta.Estado_Asignacion = 'Asignado';

        -- Obtener ID de sala con bloqueo compartido para evitar actualizaciones concurrentes
        DECLARE @idSala INT;
        SELECT @idSala = ID_Sala 
        FROM Sesion WITH (HOLDLOCK, UPDLOCK)
        WHERE ID_Sesion = @idSesion;

        -- Insertar en Transaccion_Asiento los nuevos asientos (el trigger valida)
        INSERT INTO Transaccion_Asiento (Estado_Asignacion, Fecha_Hora_Asignacion, ID_Transaccion, Fila, Numero, ID_Sala, ID_Sesion)
        SELECT 'Asignado', SYSDATETIME(), @idTransaccion, fila, numero, @idSala, @idSesion
        FROM @nuevosAsientosTemp;

        -- Registrar el cambio en la tabla Transaccion
        INSERT INTO Transaccion (Fecha_Hora, Tipo_Transaccion, Cantidad_Asientos, Estado, ID_Usuario, ID_Tipo_Asignacion)
        VALUES (
            SYSDATETIME(), 
            'Cambio', 
            (SELECT COUNT(*) FROM @nuevosAsientosTemp), 
            'Completada', 
            (SELECT ID_Usuario FROM Transaccion WHERE ID_Transaccion = @idTransaccion), 
            (SELECT ID_Tipo_Asignacion FROM Transaccion WHERE ID_Transaccion = @idTransaccion)
        );

        -- Confirmar la transacción
        COMMIT TRANSACTION;
        SET @mensajeError = 'El cambio de asientos se ha realizado exitosamente.';

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @mensajeError = ERROR_MESSAGE();
    END CATCH
END;


--pruebi
--id transaccion, idsesion, lugares viejos, lugares nuevos
DECLARE @mensaje NVARCHAR(MAX)
EXEC sp_CambiarBoletos 59, 2, 'F9', 'A7', @mensajeError = @mensaje OUTPUT  --CHI
print @mensaje
select * from Transaccion_Asiento
SELECT * from Transaccion
select * from sesion
select * from pelicula 


go

-- SP PARA CREAR PELICULAS ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_CrearPelicula 
    @nombre VARCHAR(100), 
    @clasificacion VARCHAR(10), 
    @duracion INT, 
    @descripcion NVARCHAR(MAX),
    @mensajeError NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Iniciar transacción
        BEGIN TRANSACTION;

        -- Intentar insertar la película
        INSERT INTO Pelicula (Nombre, Clasificacion, Duracion, Descripcion)
        VALUES (@nombre, @clasificacion, @duracion, @descripcion);

        -- Confirmar la transacción si no hubo errores
        COMMIT TRANSACTION;
        SET @mensajeError = 'La operación fue exitosa.';
    END TRY
    BEGIN CATCH
        -- Manejar errores y deshacer la transacción
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Capturar el mensaje de error
        SET @mensajeError = ERROR_MESSAGE();
    END CATCH
END;
go

--pruebi
DECLARE @mensaje NVARCHAR(MAX)
EXEC sp_CrearPelicula 'mequieromorir', 'clasi', 111, 'descripcion', @mensajeError = @mensaje OUTPUT  
select * from Pelicula


go

-- SP PARA VERIFICAR USURAIO ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE VerificaUsuario
    @Nombre VARCHAR(50),
    @Contraseña VARCHAR(255),
    @Rol VARCHAR(50) OUTPUT,  -- Parámetro de salida para devolver el rol
    @mensajeError NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON

    BEGIN TRY
        BEGIN TRAN

        DECLARE @ContraDsc VARBINARY(64);
        SET @ContraDsc = HASHBYTES('SHA2_256', @Contraseña)

        -- Verificar si el usuario existe
        IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = @Nombre)
        BEGIN
            SET @mensajeError = 'ERROR: El usuario no existe en el sistema'
            ROLLBACK TRAN
            RETURN
        END

        -- Verificar si la contraseña es correcta
        IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Nombre = @Nombre AND Contraseña = @ContraDsc)
        BEGIN
            SET @mensajeError = 'ERROR: Contraseña incorrecta'
            ROLLBACK TRAN
            RETURN
        END

        -- Obtener el rol del usuario
        SELECT @Rol = Rol FROM Usuarios WHERE Nombre = @Nombre

        -- Confirmar la transacción si no hubo errores
        COMMIT TRAN
        SET @mensajeError = 'Usuario y contraseña correctos'
    END TRY
    BEGIN CATCH
        -- Capturar y mostrar el error
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN

        SET @mensajeError = ERROR_MESSAGE()
        SET @Rol = NULL
    END CATCH
END

--PRUEBIS
DECLARE @RolPrueba VARCHAR(50);
DECLARE @MensajeErrorPrueba NVARCHAR(MAX);
EXEC VerificaUsuario
    @Nombre = 'admin',
    @Contraseña = 'admin123',
    @Rol = @RolPrueba OUTPUT,
    @mensajeError = @MensajeErrorPrueba OUTPUT;

print @RolPrueba
print @MensajeErrorPrueba

go


-- SP PARA CREAR SESIONES ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_CrearSesion
    @fechaInicio DATETIME2, 
    @idSala INT,
    @idPelicula INT,
    @mensajeError NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insertar la sesión, el *trigger* realizará las validaciones
        INSERT INTO Sesion (Fecha_Inicio, Estado, ID_Sala, ID_Pelicula)
        VALUES (@fechaInicio, 'Activa', @idSala, @idPelicula);

        -- Confirmar la transacción si no hubo errores
        COMMIT TRANSACTION;
        SET @mensajeError = 'La sesión fue registrada exitosamente.';
    END TRY
    BEGIN CATCH
        -- Manejar errores y deshacer la transacción
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Capturar el mensaje de error lanzado desde el *trigger*
        SET @mensajeError = ERROR_MESSAGE();
    END CATCH
END;
GO

--pruebi
DECLARE @mensaje NVARCHAR(MAX)
EXEC sp_crearsesion '2024-11-30', 4, 9, @mensajeError = @mensaje OUTPUT  --

select * from sesion
select * from pelicula

go


-- SP PARA LA VENTA DE BOLETOS  ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_VentaBoletos
    @idSesion INT,
    @nombreUsuario VARCHAR(100),
    @cantAsientos INT,
    @idTipoAsignacion INT,
    @asientosTipoManual NVARCHAR(MAX) = NULL, --no siempre se usa
    @mensajeError NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN
        
        DECLARE @idUsuario INT;
        
        -- Obtener el ID del usuario a partir del nombre de usuario
        SELECT @idUsuario = ID_Usuario FROM Usuarios WHERE Nombre = @nombreUsuario;
        
        IF @idUsuario IS NULL
        BEGIN
            SET @mensajeError = 'ERROR: El usuario no existe.'
            ROLLBACK TRAN
            RETURN
        END
        
        -- Verificar que exista la sesión y tenga estado de activa
        IF NOT EXISTS (
            SELECT 1 
            FROM sesion with (UPDLOCK, HOLDLOCK)
            WHERE ID_Sesion = @idSesion AND Estado = 'Activa'
        )
        BEGIN
            SET @mensajeError = 'ERROR: La sesión no existe o está inactiva.'
            ROLLBACK TRAN
            RETURN
        END

        -- Verificar que la cantidad de asientos sea válida
        IF @cantAsientos <= 0
        BEGIN
            SET @mensajeError = 'ERROR: debe seleccionar al menos 1 asiento.'
            ROLLBACK TRAN
            RETURN
        END

        -- Insertar la transacción en la tabla Transaccion y obtener el ID generado
        INSERT INTO Transaccion (Fecha_Hora, Tipo_Transaccion, Cantidad_Asientos, Estado, ID_Usuario, ID_Tipo_Asignacion)
        VALUES (SYSDATETIME(), 'Venta', @cantAsientos, 'Completada', @idUsuario, @idTipoAsignacion);
        DECLARE @ID_Transaccion INT = SCOPE_IDENTITY();

        -- Asignación automática de asientos
        IF @idTipoAsignacion = 1
        BEGIN
            DECLARE @asientosDisponibles TABLE (fila CHAR(1), numero INT, id_sala INT);

            -- Seleccionar asientos libres
            INSERT INTO @asientosDisponibles (fila, numero, id_sala)
            SELECT fila, numero, id_sala
            FROM asiento 
            WHERE id_sala = (SELECT id_sala FROM sesion WHERE id_sesion = @idSesion)
            AND NOT EXISTS (
                SELECT 1 
                FROM Transaccion_Asiento trans WITH (UPDLOCK, HOLDLOCK)
                WHERE trans.ID_Sesion = @idSesion AND trans.Fila = asiento.Fila AND trans.Numero = asiento.Numero AND trans.ID_Sala = asiento.ID_Sala
            )
            ORDER BY Fila, Numero
            OFFSET 0 ROWS FETCH NEXT @cantAsientos ROWS ONLY;

            -- Verificar que haya suficientes asientos disponibles
            IF (SELECT COUNT(*) FROM @asientosDisponibles) < @cantAsientos
            BEGIN
                SET @mensajeError = 'ERROR: No hay asientos disponibles.'
                ROLLBACK TRAN
                RETURN
            END    

            -- Insertar los asientos asignados en la tabla Transaccion_Asiento
            INSERT INTO Transaccion_Asiento (Estado_Asignacion, Fecha_Hora_Asignacion, ID_Transaccion, Fila, Numero, ID_Sala, ID_Sesion)
            SELECT 'Asignado', SYSDATETIME(), @ID_Transaccion, fila, numero, id_sala, @idSesion
            FROM @asientosDisponibles;
        END

        -- Asignación manual de asientos
        ELSE IF @idTipoAsignacion = 2
        BEGIN
            DECLARE @asientostemp TABLE (fila CHAR(1), num INT);
            INSERT INTO @asientostemp (fila, num)
            SELECT SUBSTRING(s.value, 1, 1), CAST(SUBSTRING(s.value, 2, LEN(s.value) - 1) AS INT)
            FROM string_split(@asientosTipoManual, ',') AS s;

            -- Verificar que la cantidad de asientos ingresados coincida con @cantAsientos
            IF (SELECT COUNT(*) FROM @asientostemp) != @cantAsientos
            BEGIN
                SET @mensajeError = 'ERROR: La cantidad de asientos ingresados no coincide con la cantidad solicitada.'
                ROLLBACK TRAN
                RETURN
            END

            -- Verificar si alguno de los asientos ingresados ya está ocupado
            IF EXISTS(
                SELECT 1
                FROM @asientostemp AS astemp
                JOIN Transaccion_Asiento ta ON (ta.ID_Sesion = @idSesion AND ta.Estado_Asignacion = 'Asignado' AND ta.Fila = astemp.fila AND ta.Numero = astemp.num)
            )
            BEGIN
                SET @mensajeError = 'ERROR: Los asientos no se encuentran disponibles.'
                ROLLBACK TRAN
                RETURN
            END    

            INSERT INTO Transaccion_Asiento (Estado_Asignacion, Fecha_Hora_Asignacion, ID_Transaccion, fila, numero, ID_Sala, ID_Sesion)
            SELECT 'Asignado', SYSDATETIME(), @ID_Transaccion, fila, num, (SELECT id_sala FROM sesion WHERE id_sesion = @idSesion), @idSesion
            FROM @asientostemp;
        END

        COMMIT TRAN
        SET @mensajeError = 'Se ha realizado la venta exitosamente.'
        
    END TRY

    BEGIN CATCH
        -- Capturar y mostrar el error
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN

        SET @mensajeError = ERROR_MESSAGE();
    END CATCH
END;

go


-- SP PARA LA ANULACION DE TRANSACCIONES ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_AnularTransaccion
    @idTransaccion INT,
    @mensajeError NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Intentar actualizar el estado de la transacción a 'Cancelada'
        UPDATE Transaccion WITH (ROWLOCK, UPDLOCK)
        SET Estado = 'Cancelada'
        WHERE ID_Transaccion = @idTransaccion;

        -- Si el trigger permite la anulación, la transacción se completa
        COMMIT TRANSACTION;
        SET @mensajeError = 'La transacción ha sido anulada exitosamente y los asientos han sido liberados.';
    END TRY
    BEGIN CATCH
        -- Manejar errores del trigger o del proceso de actualización
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @mensajeError = ERROR_MESSAGE();
    END CATCH
END;

--pruebi
DECLARE @mensaje NVARCHAR(MAX)
EXEC sp_AnularTransaccion 51, @mensajeError = @mensaje OUTPUT

select * from Transaccion
select * from Transaccion_Asiento
select * from sesion

go

-- SP PARA OBTENER ASIGNACIONES ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ObtenerAsignaciones
    @idTransaccion INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
		TA.ID_Transaccion,
        TA.Estado_Asignacion,
        TA.Fecha_Hora_Asignacion,
        TA.Fila,
        TA.Numero,
        TA.ID_Sala,
        U.Nombre AS Usuario
    FROM Transaccion_Asiento TA
    JOIN Transaccion T ON TA.ID_Transaccion = T.ID_Transaccion
    JOIN Usuarios U ON T.ID_Usuario = U.ID_Usuario
    WHERE TA.ID_Transaccion = @idTransaccion;
END;

go


-- SP PARA OBTENER ASIENTOS DISPONIBLES ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ObtenerAsientosDisponibles
    @ID_Sala INT,
    @ID_Sesion INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Seleccionamos los asientos que NO estén asignados en una transacción completada
    SELECT A.ID_Sala, A.Fila, A.Numero
    FROM Asiento A
    LEFT JOIN Transaccion_Asiento TA
        ON A.Fila = TA.Fila
        AND A.Numero = TA.Numero
        AND A.ID_Sala = TA.ID_Sala
        AND TA.ID_Sesion = @ID_Sesion
        AND TA.Estado_Asignacion = 'Asignado'
    WHERE A.ID_Sala = @ID_Sala
        AND TA.Fila IS NULL; -- Solo aquellos que no estén asignados en la sesión actual
END;


go

-- SP PARA DESACTIVAR SESION ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
create or alter procedure sp_desactivarSesion
	@idSesion int,
	@mensajeError NVARCHAR(MAX) OUTPUT
as
BEGIN
	SET NOCOUNT ON;

	BEGIN TRY
	 BEGIN TRAN

		if not exists (
			select 1 
			from Sesion with (UPDLOCK, HOLDLOCK)
			where ID_Sesion = @idSesion and Estado = 'Activa'
		 )
		BEGIN
			SET @mensajeError = 'ERROR: La sesión ya se encuentra inactiva o no está registrada.'
			rollback TRAN
			RETURN
		END

		--se actualiza y hace commit 
		update Sesion
		set Estado = 'Inactiva'
		where ID_Sesion = @idSesion
		--
		COMMIT TRAN
		SET @mensajeError = 'La sesión fue desactivada.'
	END TRY

	BEGIN CATCH
		-- Capturar y mostrar el error
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN

        SET @mensajeError = ERROR_MESSAGE()
	END CATCH
END;

--pruebis
DECLARE @mensaje NVARCHAR(MAX)
EXEC sp_desactivarSesion 12, @mensajeError = @mensaje OUTPUT

select * from sesion

go

-- SP PARA VER SESIONES ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE sp_ObtenerSesionPorPeliculaYSala
    @idPelicula INT,
    @idSala INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        S.ID_Sesion,
        S.Fecha_Inicio,
        S.Fecha_Fin,
        S.Estado,
        S.ID_Sala,
        P.Nombre AS NombrePelicula,
        P.Clasificacion,
        P.Duracion,
        P.Descripcion
    FROM Sesion S
    JOIN Pelicula P ON S.ID_Pelicula = P.ID_Pelicula
    WHERE S.ID_Pelicula = @idPelicula AND S.ID_Sala = @idSala;
END;
--SP OBTENER ASIENTOS POR SESION Y TRANSACCION
go
CREATE OR ALTER PROCEDURE sp_ObtenerAsientosPorSesionYTransaccion
    @idSesion INT,
    @idTransaccion INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ta.Fila,
        ta.Numero,
        ta.ID_Sala,
        ta.Estado_Asignacion,
        ta.Fecha_Hora_Asignacion
    FROM Transaccion_Asiento ta
    WHERE ta.ID_Sesion = @idSesion AND ta.ID_Transaccion = @idTransaccion;
END;