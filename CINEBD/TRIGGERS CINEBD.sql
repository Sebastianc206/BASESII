CREATE OR ALTER TRIGGER trg_AfterInsertUpdateDeletePelicula
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



SELECT * FROM Log_Transaccion
select * from Transaccion
go
--PARA LAS SESIONES

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
--TRIGGER PARA ANULAR TRANSACCION
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
--TRIGGER DE VENTA
