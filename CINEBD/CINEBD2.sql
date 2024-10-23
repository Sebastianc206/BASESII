-- Tabla para las salas del cine
CREATE TABLE SALA (
  ID_Sala INT NOT NULL IDENTITY(1,1),
  Capacidad INT NOT NULL CHECK (Capacidad > 0),
  PRIMARY KEY (ID_Sala)
);

-- Tabla para los asientos
CREATE TABLE Asiento (
  Fila CHAR(1) NOT NULL, -- Asumimos filas etiquetadas por letras
  Numero INT NOT NULL, CHECK (Numero > 0),
  ID_Sala INT NOT NULL,
  PRIMARY KEY (Fila,Numero,ID_Sala),
  FOREIGN KEY (ID_Sala) REFERENCES SALA(ID_Sala) ON DELETE NO ACTION
);

-- Tabla para las películas
CREATE TABLE Pelicula (
  ID_Pelicula INT NOT NULL IDENTITY(1,1),
  Nombre VARCHAR(100) NOT NULL,
  Clasificacion VARCHAR(10) NOT NULL, -- Clasificación de la película (por ejemplo, PG-13)
  Duracion INT NOT NULL CHECK (Duracion > 0), -- Duración en minutos
  Descripcion NVARCHAR(MAX),
  PRIMARY KEY (ID_Pelicula)
);

-- Tabla para las sesiones
CREATE TABLE Sesion (
  ID_Sesion INT NOT NULL IDENTITY(1,1),
  Fecha_Inicio DATETIME2 NOT NULL,
  Fecha_Fin DATETIME2 NOT NULL, -- Se calcula con base en la duración de la película
  Estado VARCHAR(20) NOT NULL CHECK (Estado IN ('Activa', 'Inactiva')),
  ID_Sala INT NOT NULL,
  ID_Pelicula INT NOT NULL,
  PRIMARY KEY (ID_Sesion),
  FOREIGN KEY (ID_Sala) REFERENCES SALA(ID_Sala) ON DELETE NO ACTION,
  FOREIGN KEY (ID_Pelicula) REFERENCES Pelicula(ID_Pelicula) ON DELETE NO ACTION
);

-- Tabla para el log de transacciones
CREATE TABLE Log_Transaccion (
  ID_Log INT NOT NULL IDENTITY(1,1),
  Fecha_Hora DATETIME2 NOT NULL,
  Usuario VARCHAR(50) NOT NULL,
  Accion VARCHAR(50) NOT NULL, -- Tipo de acción (venta, cambio, anulación)
  ID_Operacion INT NOT NULL, -- ID relacionado a la operación (ej. transacción o sesión)
  Tabla_Cambio VARCHAR(50) NOT NULL, -- Tabla donde ocurrió el cambio
  Datos_Anteriores NVARCHAR(MAX),
  Datos_Nuevos NVARCHAR(MAX),
  Descripcion NVARCHAR(MAX),
  PRIMARY KEY (ID_Log)
);

-- Tabla para los usuarios del sistema
CREATE TABLE Usuarios (
  ID_Usuario INT NOT NULL IDENTITY(1,1),
  Nombre VARCHAR(100) NOT NULL,
  Rol VARCHAR(20) NOT NULL CHECK (Rol IN ('Admin', 'Operador', 'Auditor')),
  Contraseña VARCHAR(255) NOT NULL, -- Almacenado como hash
  PRIMARY KEY (ID_Usuario)
);

-- Catálogo para los tipos de asignación de asientos
CREATE TABLE Catalogo_Asignacion (
  ID_Tipo_Asignacion INT NOT NULL IDENTITY(1,1),
  Nombre VARCHAR(50) NOT NULL,
  Detalle NVARCHAR(MAX),
  PRIMARY KEY (ID_Tipo_Asignacion)
);

-- Tabla para las transacciones (ventas de boletos)
CREATE TABLE Transaccion (
  ID_Transaccion INT NOT NULL IDENTITY(1,1),
  Fecha_Hora DATETIME2 NOT NULL,
  Tipo_Transaccion VARCHAR(20) NOT NULL CHECK (Tipo_Transaccion IN ('Venta', 'Cambio', 'Anulacion')),
  Cantidad_Asientos INT NOT NULL CHECK (Cantidad_Asientos > 0),
  Estado VARCHAR(20) NOT NULL CHECK (Estado IN ('Completada', 'Cancelada')),
  ID_Usuario INT NOT NULL,
  ID_Tipo_Asignacion INT NOT NULL,
  PRIMARY KEY (ID_Transaccion),
  FOREIGN KEY (ID_Usuario) REFERENCES Usuarios(ID_Usuario) ON DELETE NO ACTION,
  FOREIGN KEY (ID_Tipo_Asignacion) REFERENCES Catalogo_Asignacion(ID_Tipo_Asignacion) ON DELETE NO ACTION
);

-- Tabla para asignación de asientos a las transacciones
CREATE TABLE Transaccion_Asiento (
  ID_AsientoTransaccion INT NOT NULL IDENTITY(1,1),
  Estado_Asignacion VARCHAR(20) NOT NULL CHECK (Estado_Asignacion IN ('Asignado', 'Liberado')),
  Fecha_Hora_Asignacion DATETIME2 NOT NULL,
  ID_Transaccion INT NOT NULL,
  Fila CHAR(1) NOT NULL,
  Numero INT NOT NULL, CHECK (Numero > 0),
  ID_Sala INT NOT NULL,
  ID_Sesion INT NOT NULL,
  PRIMARY KEY (ID_AsientoTransaccion),
  FOREIGN KEY (ID_Transaccion) REFERENCES Transaccion(ID_Transaccion) ON DELETE NO ACTION,
  FOREIGN KEY (Fila, Numero, ID_Sala) REFERENCES Asiento(Fila, Numero, ID_Sala) ON DELETE NO ACTION,
  FOREIGN KEY (ID_Sesion) REFERENCES Sesion(ID_Sesion) ON DELETE NO ACTION
);

