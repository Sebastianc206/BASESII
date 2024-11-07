
--TRIGGER PARA EL LOG TRANSACCION DE PELICULA ---------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER TRIGGER trg_AfterInsertPelicula
ON Pelicula
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Operacion VARCHAR(20), @DatosAnteriores NVARCHAR(MAX), @DatosNuevos NVARCHAR(MAX);
    DECLARE @ID_Operacion INT;

    -- Obtener el usuario del contexto de la sesión
    DECLARE @Usuario VARCHAR(50) = CAST(SESSION_CONTEXT(N'Usuario') AS VARCHAR(50));

    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        SET @Operacion = 'Insert';
        SELECT @ID_Operacion = ID_Pelicula FROM inserted;  -- Para inserciones, tomamos el ID de inserted
        SELECT @DatosNuevos = (SELECT * FROM inserted FOR JSON AUTO);
        SET @DatosAnteriores = NULL;
    END

    -- Insertar en la tabla de logs
    INSERT INTO Log_Transaccion (
        Fecha_Hora, 
        Usuario, 
        Accion, 
        ID_Operacion, 
        Tabla_Cambio, 
        Datos_Anteriores, 
        Datos_Nuevos, 
        Descripcion
    )
    VALUES (
        GETDATE(), 
        @Usuario, 
        @Operacion, 
        @ID_Operacion, 
        'Pelicula', 
        @DatosAnteriores, 
        @DatosNuevos, 
        'Cambio en la tabla Pelicula'
    );
END;

--Pruebis
EXEC sp_set_session_context 'Usuario', 'admin';
update Sesion set Estado= 'Inactiva' where ID_Sesion = 2 
SELECT * FROM Log_Transaccion
select * from Usuarios
select * from Sesion
select * from Transaccion


go


--TRIGGER PARA LOG TRANSACCION DE LAS SESIONES ---------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER TRIGGER trg_AfterInsertUpdateSesion
ON Sesion
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Operacion VARCHAR(20), @DatosAnteriores NVARCHAR(MAX), @DatosNuevos NVARCHAR(MAX);
    DECLARE @ID_Operacion INT, @Descripcion NVARCHAR(MAX);

    -- Obtener el usuario del contexto de la sesión
    DECLARE @Usuario VARCHAR(50) = CAST(SESSION_CONTEXT(N'Usuario') AS VARCHAR(50));

    -- Identificar si es una inserción (creación de sesión) o una actualización
    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        -- Inserción: Creación de una nueva sesión
        SET @Operacion = 'Insert';
        SELECT @ID_Operacion = ID_Sesion FROM inserted;
        SELECT @DatosNuevos = (SELECT * FROM inserted FOR JSON AUTO);
        SET @DatosAnteriores = NULL;
        SET @Descripcion = 'Creación de una nueva sesión';
    END
    ELSE IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        -- Actualización: Estado de la sesión (por ejemplo, de 'Activa' a 'Inactiva')
        SET @Operacion = 'Update';
        SELECT @ID_Operacion = ID_Sesion FROM inserted;
        SELECT @DatosAnteriores = (SELECT * FROM deleted FOR JSON AUTO);
        SELECT @DatosNuevos = (SELECT * FROM inserted FOR JSON AUTO);
        SET @Descripcion = 'Actualización de sesión';
    END

    -- Insertar en la tabla de logs
    INSERT INTO Log_Transaccion (
        Fecha_Hora, 
        Usuario, 
        Accion, 
        ID_Operacion, 
        Tabla_Cambio, 
        Datos_Anteriores, 
        Datos_Nuevos, 
        Descripcion
    )
    VALUES (
        GETDATE(), 
        @Usuario, 
        @Operacion, 
        @ID_Operacion, 
        'Sesion', 
        @DatosAnteriores, 
        @DatosNuevos, 
        @Descripcion
    );
END;
GO



--TRIGGER PARA LOG TRANSACCION DE ANULAR TRANSACCIONES ---------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER TRIGGER trg_AfterUpdateTransaccionAnulacion
ON Transaccion
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Operacion VARCHAR(20) = 'Anulacion', @DatosAnteriores NVARCHAR(MAX), @DatosNuevos NVARCHAR(MAX), @Descripcion NVARCHAR(MAX);
    DECLARE @Usuario VARCHAR(50) = CAST(SESSION_CONTEXT(N'Usuario') AS VARCHAR(50));

    -- Verificar y registrar cada transacción que cambió a 'Cancelada'
    IF EXISTS (SELECT 1 FROM inserted i JOIN deleted d ON i.ID_Transaccion = d.ID_Transaccion WHERE d.Estado <> 'Cancelada' AND i.Estado = 'Cancelada')
    BEGIN
        SELECT 
            @DatosAnteriores = (SELECT * FROM deleted d WHERE d.Estado <> 'Cancelada' AND (SELECT Estado FROM inserted i WHERE i.ID_Transaccion = d.ID_Transaccion) = 'Cancelada' FOR JSON AUTO),
            @DatosNuevos = (SELECT * FROM inserted i WHERE i.Estado = 'Cancelada' FOR JSON AUTO),
            @Descripcion = 'Anulación de la transacción en la tabla Transaccion';

        -- Insertar en la tabla Log_Transaccion
        INSERT INTO Log_Transaccion (
            Fecha_Hora, 
            Usuario, 
            Accion, 
            ID_Operacion, 
            Tabla_Cambio, 
            Datos_Anteriores, 
            Datos_Nuevos, 
            Descripcion
        )
        SELECT
            GETDATE(), 
            @Usuario, 
            @Operacion, 
            i.ID_Transaccion, 
            'Transaccion', 
            @DatosAnteriores, 
            @DatosNuevos, 
            @Descripcion
        FROM inserted i
        JOIN deleted d ON i.ID_Transaccion = d.ID_Transaccion
        WHERE d.Estado <> 'Cancelada' AND i.Estado = 'Cancelada';
    END
END;
go




--TRIGGER PARA LOG TRANSACCION DE VENTA DE BOLETOS ---------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER TRIGGER trg_AfterInsertTransaccionVenta
ON Transaccion
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Operacion VARCHAR(20), @DatosNuevos NVARCHAR(MAX), @Descripcion NVARCHAR(MAX);
    DECLARE @ID_Operacion INT, @Usuario VARCHAR(50), @TipoTransaccion VARCHAR(20);
    DECLARE @CantidadAsientos INT;

    -- Obtener el usuario y tipo de transacción desde el contexto de la sesión o inserción
    SELECT 
        @ID_Operacion = ID_Transaccion, 
        @Usuario = CAST(SESSION_CONTEXT(N'Usuario') AS VARCHAR(50)),
        @TipoTransaccion = Tipo_Transaccion,
        @CantidadAsientos = Cantidad_Asientos
    FROM inserted;

    -- Verificar que la transacción sea una venta de boletos
    IF @TipoTransaccion = 'Venta'
    BEGIN
        SET @Operacion = 'Venta';
        SET @DatosNuevos = (SELECT * FROM inserted FOR JSON AUTO);
        SET @Descripcion = CONCAT('Venta de boletos: ', @CantidadAsientos, ' asientos.');

        -- Insertar en la tabla Log_Transaccion para registrar la venta de boletos
        INSERT INTO Log_Transaccion (
            Fecha_Hora, 
            Usuario, 
            Accion, 
            ID_Operacion, 
            Tabla_Cambio, 
            Datos_Anteriores, 
            Datos_Nuevos, 
            Descripcion
        )
        VALUES (
            GETDATE(), 
            @Usuario, 
            @Operacion, 
            @ID_Operacion, 
            'Transaccion', 
            NULL, 
            @DatosNuevos, 
            @Descripcion
        );
    END
END;



go

-- TRIGGER PARA CREAR PELICULAS ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER TRIGGER trg_ValidarCreacionPelicula
ON Pelicula
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @nombre VARCHAR(100), 
            @clasificacion VARCHAR(10), 
            @duracion INT, 
            @descripcion NVARCHAR(MAX),
            @mensajeError NVARCHAR(MAX) = NULL;

    -- Obtener los valores de la nueva película
    SELECT 
        @nombre = Nombre, 
        @clasificacion = Clasificacion, 
        @duracion = Duracion,
        @descripcion = Descripcion
    FROM inserted;

    -- Verificar que la duración sea válida
    IF @duracion <= 0
    BEGIN
        SET @mensajeError = 'ERROR: La película no cuenta con una duración correcta, debe ser mayor que 0';
        RAISERROR (@mensajeError, 16, 1);
        RETURN;
    END;

    -- Verificar que la película no esté ya registrada
    IF EXISTS (
        SELECT 1
        FROM Pelicula WITH (UPDLOCK, HOLDLOCK)
        WHERE LOWER(Nombre) = LOWER(@nombre) AND Clasificacion = @clasificacion
    )
    BEGIN
        SET @mensajeError = 'ERROR: La película ya existe en el sistema';
        RAISERROR (@mensajeError, 16, 1);
        RETURN;
    END;

    -- Si todas las validaciones se cumplen, insertar la película
    INSERT INTO Pelicula (Nombre, Clasificacion, Duracion, Descripcion)
    VALUES (@nombre, @clasificacion, @duracion, @descripcion);
END;


go

-- TRIGGER PARA CREAR SESIONES ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER TRIGGER trg_ValidarCrearSesion
ON Sesion
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @idSala INT, @idPelicula INT, @fechaInicio DATETIME2, @fechaFin DATETIME2, @duracion INT;
    DECLARE @mensajeError NVARCHAR(MAX) = NULL;

    -- Asignación de valores desde `inserted`
    SELECT @idSala = ID_Sala, @idPelicula = ID_Pelicula, @fechaInicio = Fecha_Inicio FROM inserted;

    -- Verificar si la película existe y obtener duración
    IF NOT EXISTS (SELECT 1 FROM Pelicula WHERE ID_Pelicula = @idPelicula)
    BEGIN
        SET @mensajeError = 'ERROR: La película NO existe en el sistema';
        THROW 50001, @mensajeError, 1;
        RETURN;
    END;
    SELECT @duracion = Duracion FROM Pelicula WHERE ID_Pelicula = @idPelicula;

    -- Calcular la fecha de fin
    SET @fechaFin = DATEADD(MINUTE, @duracion, @fechaInicio);

    -- Verificar si la sala existe
    IF NOT EXISTS (SELECT 1 FROM Sala WHERE ID_Sala = @idSala)
    BEGIN
        SET @mensajeError = 'ERROR: La sala NO existe en el sistema';
        THROW 50002, @mensajeError, 1;
        RETURN;
    END;

    -- Verificar solapamiento de sesiones
    IF EXISTS (
        SELECT 1
        FROM Sesion
        WHERE ID_Sala = @idSala AND Estado = 'Activa'
        AND (
            (@fechaInicio BETWEEN Fecha_Inicio AND Fecha_Fin OR @fechaFin BETWEEN Fecha_Inicio AND Fecha_Fin)
            OR 
            (Fecha_Inicio BETWEEN @fechaInicio AND @fechaFin OR Fecha_Fin BETWEEN @fechaInicio AND @fechaFin)
        )
    )
    BEGIN
        SET @mensajeError = 'ERROR: La sesión se traslapa';
        THROW 50003, @mensajeError, 1;
        RETURN;
    END;

    -- Verificar el intervalo de 15 minutos entre sesiones
    IF EXISTS (
        SELECT 1
        FROM Sesion
        WHERE ID_Sala = @idSala AND Estado = 'Activa'
        AND (
            ABS(DATEDIFF(MINUTE, Fecha_Fin, @fechaInicio)) < 15 OR ABS(DATEDIFF(MINUTE, @fechaFin, Fecha_Inicio)) < 15
        )
    )
    BEGIN
        SET @mensajeError = 'ERROR: Entre sesiones deben haber 15 minutos de por medio para usar la misma sala.';
        THROW 50004, @mensajeError, 1;
        RETURN;
    END;

    -- Si pasa todas las validaciones, realizar la inserción
    INSERT INTO Sesion (Fecha_Inicio, Fecha_Fin, Estado, ID_Sala, ID_Pelicula)
    SELECT Fecha_Inicio, @fechaFin, Estado, ID_Sala, ID_Pelicula
    FROM inserted;
END;


go

-- TRIGGER PARA ANULAR TRANSACCION ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE OR ALTER TRIGGER trg_ValidarAnulacionTransaccion
ON Transaccion
INSTEAD OF UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @idTransaccion INT, @estadoActual NVARCHAR(20), @fechaInicio DATETIME2;
    DECLARE @mensajeError NVARCHAR(MAX);

    -- Obtener el ID de la transacción y su estado actual de la tabla original (no de inserted)
    SELECT @idTransaccion = ID_Transaccion, @estadoActual = Estado
    FROM Transaccion
    WHERE ID_Transaccion = (SELECT ID_Transaccion FROM inserted);

    -- Verificar si la transacción ya está anulada
    IF @estadoActual = 'Cancelada'
    BEGIN
        SET @mensajeError = 'ERROR: La transacción ya ha sido anulada.';
        THROW 50001, @mensajeError, 1;
        RETURN;
    END;

    -- Verificar si la sesión ya ha comenzado
    SELECT @fechaInicio = S.Fecha_Inicio
    FROM Transaccion_Asiento TA
    JOIN Sesion S ON TA.ID_Sesion = S.ID_Sesion
    WHERE TA.ID_Transaccion = @idTransaccion;

    IF @fechaInicio <= GETDATE()
    BEGIN
        SET @mensajeError = 'ERROR: No se puede anular la transacción porque la sesión ya ha comenzado.';
        THROW 50002, @mensajeError, 1;
        RETURN;
    END;

    -- Si todas las validaciones son exitosas, actualizar el estado a 'Cancelada' y liberar los asientos
    UPDATE Transaccion WITH (ROWLOCK, UPDLOCK)
    SET Estado = 'Cancelada'
    WHERE ID_Transaccion = @idTransaccion;

    UPDATE Transaccion_Asiento WITH (ROWLOCK, UPDLOCK)
    SET Estado_Asignacion = 'Liberado'
    WHERE ID_Transaccion = @idTransaccion;
END;

go
--TRIGGER PARA CAMBIO DE BOLETOS
CREATE OR ALTER TRIGGER trg_ValidarCambioBoletos
ON Transaccion_Asiento
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @idTransaccion INT, @idSesion INT, @fechaInicioNuevaSesion DATETIME, @fechaInicioSesionActual DATETIME, @estadoSesion NVARCHAR(20);
    DECLARE @mensajeError NVARCHAR(MAX);

    -- Asignación de valores de la nueva inserción
    SELECT TOP 1 @idTransaccion = ID_Transaccion, @idSesion = ID_Sesion FROM inserted;

    -- Verificar que la sesión de destino esté activa
    SELECT @estadoSesion = Estado, @fechaInicioNuevaSesion = Fecha_Inicio 
    FROM Sesion 
    WHERE ID_Sesion = @idSesion;

    IF @estadoSesion <> 'Activa'
    BEGIN
        SET @mensajeError = 'ERROR: La sesión de destino no está activa.';
        THROW 50006, @mensajeError, 1;
        RETURN;
    END;

    -- Obtener la fecha de inicio de la sesión actual de los asientos originales
    SELECT @fechaInicioSesionActual = S.Fecha_Inicio
    FROM Transaccion_Asiento TA
    JOIN Sesion S ON TA.ID_Sesion = S.ID_Sesion
    WHERE TA.ID_Transaccion = @idTransaccion AND TA.Estado_Asignacion = 'Asignado';

    -- Verificar duplicados en los nuevos asientos
    IF EXISTS (
        SELECT Fila, Numero
        FROM inserted
        GROUP BY Fila, Numero
        HAVING COUNT(*) > 1
    )
    BEGIN
        SET @mensajeError = 'ERROR: Los nuevos asientos contienen duplicados.';
        THROW 50001, @mensajeError, 1;
        RETURN;
    END;

    -- Verificar disponibilidad de los nuevos asientos en la nueva sesión
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Transaccion_Asiento ta WITH (UPDLOCK, HOLDLOCK) ON ta.ID_Sesion = @idSesion
            AND ta.Fila = i.Fila
            AND ta.Numero = i.Numero
            AND ta.Estado_Asignacion = 'Asignado'
    )
    BEGIN
        SET @mensajeError = 'ERROR: Estos asientos no están disponibles en la nueva sesión.';
        THROW 50002, @mensajeError, 1;
        RETURN;
    END;

    -- Verificar si se está intentando cambiar al mismo asiento actual
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Transaccion_Asiento ta ON ta.ID_Transaccion = @idTransaccion
        WHERE ta.Fila = i.Fila AND ta.Numero = i.Numero AND ta.Estado_Asignacion = 'Asignado'
    )
    BEGIN
        SET @mensajeError = 'ERROR: No puede cambiar al mismo asiento en el que ya está.';
        THROW 50003, @mensajeError, 1;
        RETURN;
    END;

    -- Verificar que la sesión nueva no haya comenzado
    IF @fechaInicioNuevaSesion <= GETDATE()
    BEGIN
        SET @mensajeError = 'ERROR: No se puede cambiar a la nueva sesión porque ya ha comenzado.';
        THROW 50004, @mensajeError, 1;
        RETURN;
    END;

    -- Verificar que la sesión actual no haya comenzado
    IF @fechaInicioSesionActual <= GETDATE()
    BEGIN
        SET @mensajeError = 'ERROR: No se puede cambiar de la sesión actual porque ya ha comenzado.';
        THROW 50005, @mensajeError, 1;
        RETURN;
    END;

    -- Si todas las condiciones se cumplen, realizar la inserción
    INSERT INTO Transaccion_Asiento (Estado_Asignacion, Fecha_Hora_Asignacion, ID_Transaccion, Fila, Numero, ID_Sala, ID_Sesion)
    SELECT Estado_Asignacion, Fecha_Hora_Asignacion, ID_Transaccion, Fila, Numero, ID_Sala, ID_Sesion
    FROM inserted;
END;
GO

--TRIGGER REGISTRAR TABLA LOGS CAMBIO DE ASIENTO
CREATE OR ALTER TRIGGER trg_AfterUpdateTransaccionCambio
ON Transaccion_Asiento
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Operacion VARCHAR(20), @DatosAnteriores NVARCHAR(MAX), @DatosNuevos NVARCHAR(MAX), @Descripcion NVARCHAR(MAX);
    DECLARE @ID_Operacion INT, @Usuario VARCHAR(50);
    DECLARE @EstadoAnterior VARCHAR(20), @EstadoNuevo VARCHAR(20);

    -- Obtener el usuario del contexto de la sesión
    SET @Usuario = CAST(SESSION_CONTEXT(N'Usuario') AS VARCHAR(50));

    -- Identificar el cambio de asignación de asiento
    SELECT 
        @ID_Operacion = i.ID_Transaccion, 
        @EstadoAnterior = d.Estado_Asignacion,
        @EstadoNuevo = i.Estado_Asignacion
    FROM inserted i
    JOIN deleted d ON i.ID_AsientoTransaccion = d.ID_AsientoTransaccion;

    -- Verificar que el estado haya cambiado, lo cual implica un cambio de asiento
    IF @EstadoAnterior <> @EstadoNuevo
    BEGIN
        SET @Operacion = 'CambioAsiento';
        SET @DatosAnteriores = (SELECT * FROM deleted FOR JSON AUTO);
        SET @DatosNuevos = (SELECT * FROM inserted FOR JSON AUTO);
        SET @Descripcion = CONCAT('Cambio de asiento de ', @EstadoAnterior, ' a ', @EstadoNuevo);

        -- Insertar en Log_Transaccion para registrar el cambio de asiento
        INSERT INTO Log_Transaccion (
            Fecha_Hora, 
            Usuario, 
            Accion, 
            ID_Operacion, 
            Tabla_Cambio, 
            Datos_Anteriores, 
            Datos_Nuevos, 
            Descripcion
        )
        VALUES (
            GETDATE(), 
            @Usuario, 
            @Operacion, 
            @ID_Operacion, 
            'Transaccion_Asiento', 
            @DatosAnteriores, 
            @DatosNuevos, 
            @Descripcion
        );
    END
END;