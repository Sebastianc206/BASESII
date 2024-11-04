--PROCEDIMIENTO CREAR PELICULA
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
        BEGIN TRANSACTION;

        -- Verificar que la duración sea válida
        IF @duracion <= 0
        BEGIN
            SET @mensajeError = 'ERROR: La película no cuenta con una duración correcta, debe ser mayor que 0';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Verificar que la película no esté ya registrada
        IF EXISTS (
            SELECT 1
            FROM Pelicula
            WHERE LOWER(Nombre) = LOWER(@nombre) AND Clasificacion = @clasificacion
        )
        BEGIN
            SET @mensajeError = 'ERROR: La película ya existe en el sistema';
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Insertar la película si no existe
        INSERT INTO Pelicula (Nombre, Clasificacion, Duracion, Descripcion)
        VALUES (@nombre, @clasificacion, @duracion, @descripcion);

        -- Confirmar la transacción si no hubo errores
        COMMIT TRANSACTION;
        SET @mensajeError = 'La operación fue exitosa.';
    END TRY
    BEGIN CATCH
        -- Capturar y mostrar el error
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @mensajeError = ERROR_MESSAGE();
    END CATCH
END;



go
--PRUEBAS DEL SP:
DECLARE @mensaje NVARCHAR(MAX);
exec sp_CrearPelicula 'LOS SIM2', 'Clase C', 100, 'prueba', @mensajeError = @mensaje OUTPUT --CON ESTA SI DEJA, SI SE INTENTA EJECUTAR 2 VECES DEBE LANZAR ERROR
print @mensaje
exec sp_CrearPelicula 'Pruebadepeli', 'Clase B', 00, 'pruebis pruebis 2' --ESTA PRUEBA ES PARA VER QUE NO ACEPTE LAS PELICULAS CON DURACION MENOR A 0
select * from pelicula

go

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

select * from Usuarios

go
select * from Log_Transaccion
select * from Transaccion
select * from Pelicula
select * from Sesion
go

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

        -- Variables
        DECLARE @duracion INT;
        SELECT @duracion = duracion FROM Pelicula WHERE id_pelicula = @idPelicula;

        -- Fecha fin
        DECLARE @fechaFin DATETIME2;
        SET @fechaFin = DATEADD(MINUTE, @duracion, @fechaInicio);

        -- Verificar si la película existe
        IF NOT EXISTS (
            SELECT 1 
            FROM Pelicula 
            WHERE ID_pelicula = @idPelicula
        )
        BEGIN
            SET @mensajeError = 'ERROR: La película NO existe en el sistema';
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        -- Verificar si la sala existe
        IF NOT EXISTS (
            SELECT 1 
            FROM Sala
            WHERE ID_sala = @idSala
        )
        BEGIN
            SET @mensajeError = 'ERROR: La sala NO existe en el sistema';
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        -- Verificar que no se traslapen las sesiones
        IF EXISTS(
            SELECT 1
            FROM Sesion
            WHERE id_sala = @idSala AND Estado = 'Activa'
            AND (
                (@fechaInicio BETWEEN fecha_inicio AND fecha_fin OR @fechaFin BETWEEN fecha_inicio AND fecha_fin)
                OR 
                (fecha_inicio BETWEEN @fechaInicio AND @fechaFin OR fecha_fin BETWEEN @fechaInicio AND @fechaFin)
            )
        )
        BEGIN
            SET @mensajeError = 'ERROR: La sesión se traslapa';
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        -- Verificar que haya un espacio de 15 minutos entre las sesiones
        IF EXISTS(
            SELECT 1
            FROM Sesion
            WHERE id_sala = @idSala AND estado = 'Activa'
            AND (
                ABS(DATEDIFF(MINUTE, fecha_fin, @fechaInicio)) < 15 OR ABS(DATEDIFF(MINUTE, @fechaFin, fecha_inicio)) < 15
            )
        )
        BEGIN
            SET @mensajeError = 'ERROR: Entre sesiones deben haber 15 minutos de por medio para usar la misma sala.';
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        -- Insertar la sesión
        INSERT INTO Sesion (Fecha_Inicio, Fecha_Fin, Estado, ID_Sala, ID_Pelicula)
        VALUES (@fechaInicio, @fechaFin, 'Activa', @idSala, @idPelicula);
    
        -- Confirmar la transacción si no hubo errores
        COMMIT TRANSACTION;
        SET @mensajeError = 'La sesión fue registrada exitosamente.';
    END TRY
    BEGIN CATCH
        -- Capturar y mostrar el error
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @mensajeError = ERROR_MESSAGE();
    END CATCH
END;

go
DECLARE @MensajeErrorPrueba NVARCHAR(MAX);

EXEC sp_CrearSesion
    @fechaInicio = '2024-10-10T16:20:00',
    @idSala = 3,
    @idPelicula = 15,
    @mensajeError = @MensajeErrorPrueba OUTPUT;
print @MensajeErrorPrueba

go
select * from Sesion
select * from Transaccion
select * from Transaccion_Asiento
select * from Log_Transaccion
go

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
            FROM sesion
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
                FROM Transaccion_Asiento trans
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



--pruebis
DECLARE @mensaje NVARCHAR(MAX)
EXEC sp_VentaBoletos @idSesion = 14, @idUsuario = 1, @cantAsientos = 2, @idTipoAsignacion = 1, @mensajeError = @mensaje OUTPUT --auto, si sirve y las pone por separadas, inserta en transaccion_asiento y en transaccion
DECLARE @mensajeprueba NVARCHAR(MAX)
EXEC sp_VentaBoletos @idSesion = 12, @nombreUsuario = 'admin', @cantAsientos = 3, @idTipoAsignacion = 2, @asientosTipoManual = 'B1,B2,B3', @mensajeError = @mensajeprueba OUTPUT --manual
print @mensajeprueba

EXEC sp_VentaBoletos @idSesion = 5, @idUsuario = 1, @cantAsientos = 2, @idTipoAsignacion = 1; --sirve para ver que no acepta en sesiones inactivas
EXEC sp_VentaBoletos @idSesion = 1, @idUsuario = 1, @cantAsientos = 1, @idTipoAsignacion = 1;

EXEC sp_VentaBoletos @idSesion = 11, @idUsuario = 1, @cantAsientos = 1, @idTipoAsignacion = 1;

select * from Transaccion_Asiento --53 47venta
select * from sesion
select * from Pelicula
SELECT * FROM Usuarios
select * from Transaccion
select * from Log_Transaccion 



go

--SP PARA ANULAR TRANSACCIONES
CREATE OR ALTER PROCEDURE sp_AnularTransaccion
    @idTransaccion INT,
    @mensajeError NVARCHAR(MAX) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Verificar si la transacción existe
        IF NOT EXISTS (
            SELECT 1
            FROM Transaccion
            WHERE ID_Transaccion = @idTransaccion
        )
        BEGIN
            SET @mensajeError = 'ERROR: La transacción no existe en el sistema';
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        -- Verificar si la transacción ya está anulada
        IF EXISTS (
            SELECT 1
            FROM Transaccion
            WHERE ID_Transaccion = @idTransaccion AND Estado = 'Cancelada'
        )
        BEGIN
            SET @mensajeError = 'ERROR: La transacción ya ha sido anulada';
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        -- Verificar si la sesión ya ha comenzado
        IF EXISTS (
            SELECT 1
            FROM Transaccion_Asiento TA
            JOIN Sesion S ON TA.ID_Sesion = S.ID_Sesion
            WHERE TA.ID_Transaccion = @idTransaccion AND S.Fecha_Inicio <= GETDATE()
        )
        BEGIN
            SET @mensajeError = 'ERROR: No se puede anular la transacción porque la película ya ha comenzado';
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        -- Anular la transacción
        UPDATE Transaccion
        SET Estado = 'Cancelada'
        WHERE ID_Transaccion = @idTransaccion;

        -- Liberar los asientos asociados a la transacción anulada
        UPDATE Transaccion_Asiento
        SET Estado_Asignacion = 'Liberado'
        WHERE ID_Transaccion = @idTransaccion;

        -- Confirmar la transacción si no hubo errores
        COMMIT TRANSACTION;
        SET @mensajeError = 'La transacción ha sido anulada exitosamente y los asientos han sido liberados.';
    END TRY
    BEGIN CATCH
        -- Capturar y mostrar el error
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @mensajeError = ERROR_MESSAGE();
    END CATCH
END;

-- Prueba para el procedimiento almacenado sp_AnularTransaccion
DECLARE @MensajeErrorPrueba NVARCHAR(MAX);

EXEC sp_AnularTransaccion
    @idTransaccion = 43,
    @mensajeError = @MensajeErrorPrueba OUTPUT;

PRINT @MensajeErrorPrueba
go
--SP PARA PODE VER OBTENER LAS ASIGNACIONES
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


-- Prueba para el procedimiento almacenado sp_ObtenerAsignaciones
DECLARE @idTransaccionPrueba INT = 2;
EXEC sp_ObtenerAsignaciones @idTransaccion = @idTransaccionPrueba;


GO
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
EXEC sp_ObtenerAsientosDisponibles @ID_Sala = 1, @ID_Sesion = 1

select * from Transaccion_Asiento

go
select * from Sesion
go
--SP PARA DESACTIVAR LA SESION -------------------------------------------------------------------------------------------------------------------------------
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
			from Sesion
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
END


--pruebis
DECLARE @mensaje NVARCHAR(MAX)
exec sp_desactivarSesion 13, @mensajeError = @mensaje OUTPUT --solo cambia el estado a inactivada 
exec sp_desactivarSesion 9 --deberia dar error
select * from sesion 
GO

--SP VER SESIONES
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

-- Prueba para el procedimiento almacenado sp_ObtenerSesionPorPeliculaYSala
DECLARE @idPeliculaPrueba INT = 2;
DECLARE @idSalaPrueba INT = 1;
EXEC sp_ObtenerSesionPorPeliculaYSala @idPelicula = @idPeliculaPrueba, @idSala = @idSalaPrueba;
