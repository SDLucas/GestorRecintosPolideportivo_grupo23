-- Crear base de datos si no existe y usarla
IF DB_ID('polideportivoDev') IS NULL
    CREATE DATABASE polideportivoDev;
GO

USE polideportivoDev;
GO
CREATE TABLE Cliente
(
  id_cliente INT IDENTITY(1,1) NOT NULL,
  dni_cliente INT NOT NULL,
  nombre_cliente VARCHAR(30) NOT NULL,
  apellido_cliente VARCHAR(30) NOT NULL,
  telefono_cliente VARCHAR(20) NOT NULL,
  CONSTRAINT PK_Cliente PRIMARY KEY (id_cliente),

  CONSTRAINT UQ_Cliente UNIQUE (dni_cliente)
);

CREATE TABLE Tipo_Recinto
(
  id_tipo_recinto INT IDENTITY(1,1) NOT NULL,
  nombre_tipo_recinto VARCHAR(50) NOT NULL,
  CONSTRAINT PK_Tipo_Recinto PRIMARY KEY (id_tipo_recinto)
);

CREATE TABLE Tipo_Usuario
(
  Id_Tipo INT IDENTITY(1,1) NOT NULL,
  nombre_Tipo VARCHAR(30) NOT NULL,
  CONSTRAINT PK_Tipo_Usuario PRIMARY KEY (Id_Tipo)
);

CREATE TABLE Recinto
(
  nro_recinto INT NOT NULL,
  tarifa_hora FLOAT NOT NULL,
  ubicacion_recinto VARCHAR(200) NOT NULL,
  id_tipo_recinto INT NOT NULL,
  habilitado bit default 1,
  CONSTRAINT PK_Recinto PRIMARY KEY (nro_recinto),
  CONSTRAINT FK_Recinto_Tipo_Recinto FOREIGN KEY (id_tipo_recinto) REFERENCES Tipo_Recinto(id_tipo_recinto)
);

CREATE TABLE Usuario
(
  id_Usuario INT IDENTITY(1,1) NOT NULL,
  DNI_Usuario INT NOT NULL,
  foto_usuario VARBINARY(MAX),
  Nombre_Usuario VARCHAR(30) NOT NULL,
  Apellido_Usuario VARCHAR(30) NOT NULL,
  Fecha_Ingreso DATE NOT NULL,
  Fecha_Nacimiento DATE NOT NULL,
  pass VARCHAR(50) NOT NULL,
  telefono VARCHAR(30) NOT NULL,
  Id_Tipo INT NOT NULL,
  Sexo_Usuario VARCHAR(40) NOT NULL,
  estado_usuario BIT DEFAULT 1,
  CONSTRAINT PK_Usuario PRIMARY KEY (id_Usuario),
  CONSTRAINT FK_Usuario_Tipo_Usuario FOREIGN KEY (Id_Tipo) REFERENCES Tipo_Usuario(Id_Tipo),
  Constraint UQ_Usuario UNIQUE (DNI_Usuario)
);


CREATE TABLE Reserva
(
  id_reserva INT IDENTITY(1,1) NOT NULL,
  fecha_reserva DATE NOT NULL,
  id_cliente INT NOT NULL,
  nro_recinto INT NOT NULL,
  id_Usuario INT NOT NULL,
  hora_reserva INT NOT NULL,
  monto_reserva FLOAT NOT NULL,
  pagado bit DEFAULT 0,
  estado BIT DEFAULT 1, -- 1 = activa, 0 = cancelada
  CONSTRAINT PK_Reserva PRIMARY KEY (id_reserva),
  CONSTRAINT FK_Reserva_Cliente FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
  CONSTRAINT FK_Reserva_Recinto FOREIGN KEY (nro_recinto) REFERENCES Recinto(nro_recinto),
  CONSTRAINT FK_Reserva_Usuario FOREIGN KEY (id_Usuario) REFERENCES Usuario(id_Usuario),
  CONSTRAINT CK_Reserva_Hora CHECK(hora_reserva > 0 and hora_reserva<=24)
);

CREATE TABLE Medio_Pago
(
  id_medio INT NOT NULL,
  nombre_medio VARCHAR(30) NOT NULL,
  CONSTRAINT PK_Medio_Pago PRIMARY KEY (id_medio),
);

CREATE TABLE Pago
(
  id_pago INT IDENTITY(1,1) NOT NULL,
  id_medio INT NOT NULL,
  id_reserva INT NOT NULL,
  id_usuario INT NOT NULL,
  monto_pago FLOAT NOT NULL,
  fecha_pago DATE NOT NULL,
  CONSTRAINT PK_Pago PRIMARY KEY (id_pago),
  CONSTRAINT FK_Pago_Medio_Pago FOREIGN KEY (id_medio) REFERENCES Medio_Pago(id_medio),
  CONSTRAINT FK_Pago_Reserva FOREIGN KEY (id_reserva) REFERENCES Reserva(id_reserva)
);

insert into Tipo_Recinto(nombre_tipo_recinto) values ('cancha de futbol');
insert into Tipo_Recinto(nombre_tipo_recinto) values ('cancha de padel');
insert into Tipo_Recinto(nombre_tipo_recinto) values ('parrilla');
insert into Tipo_Recinto(nombre_tipo_recinto) values ('pileta de natacion');

insert into Medio_Pago(id_medio,nombre_medio) values
(1,'Efectivo'),
(2,'Credito'),
(3,'Debito'),
(4,'Transferencia');
insert into Tipo_Usuario (nombre_Tipo) values ('Administrador'), ('Recepcionista');
select * from Tipo_Usuario

insert into Usuario (DNI_Usuario,Nombre_Usuario,Apellido_Usuario,Fecha_Ingreso,Fecha_Nacimiento,pass,telefono,Id_Tipo,Sexo_Usuario) values
(2,'Recepcionista','Estandar','2021-06-15','2021-06-15','recep','-',2,'hombre'),

(1,'Administrador','Estandar','2021-08-09','2001-12-19','admin','-',1,'hombre');

insert into Usuario (DNI_Usuario,Nombre_Usuario,Apellido_Usuario,Fecha_Ingreso,Fecha_Nacimiento,pass,telefono,Id_Tipo,Sexo_Usuario) values
(42450489,'Fernando','Romero','2021-06-15','2021-06-15','recep','3794149452',2,'hombre');
--creacion de procedimientos almacenados
-- Agregar recinto
GO
CREATE OR ALTER PROCEDURE sp_AgregarRecinto
    @nro_recinto INT,
    @tarifa_hora FLOAT,
    @ubicacion_recinto VARCHAR(200),
    @id_tipo_recinto INT
AS
BEGIN
    INSERT INTO Recinto (nro_recinto, tarifa_hora, ubicacion_recinto, id_tipo_recinto)
    VALUES (@nro_recinto, @tarifa_hora, @ubicacion_recinto, @id_tipo_recinto);
END;
GO
-- Obtener todos los recintos
CREATE OR ALTER PROCEDURE sp_ObtenerTodosLosRecintos
AS
BEGIN
    SELECT r.nro_recinto, r.tarifa_hora, r.ubicacion_recinto, r.habilitado,
           t.id_tipo_recinto, t.nombre_tipo_recinto
    FROM Recinto r
    INNER JOIN Tipo_Recinto t ON r.id_tipo_recinto = t.id_tipo_recinto;
END;
GO

-- Obtener todos los recintos
CREATE OR ALTER PROCEDURE sp_ObtenerRecintosHabilitados
AS
BEGIN
    SELECT 
        r.nro_recinto, 
        r.tarifa_hora, 
        r.ubicacion_recinto, 
        r.habilitado,
        t.id_tipo_recinto, 
        t.nombre_tipo_recinto
    FROM Recinto r
    INNER JOIN Tipo_Recinto t ON r.id_tipo_recinto = t.id_tipo_recinto
    WHERE r.habilitado = 1;
END;
GO

-- Obtener recinto por número
CREATE OR ALTER PROCEDURE sp_ObtenerRecintoPorNumero
    @nro_recinto INT
AS
BEGIN
    SELECT r.nro_recinto, r.tarifa_hora, r.ubicacion_recinto, r.habilitado,
           t.id_tipo_recinto, t.nombre_tipo_recinto
    FROM Recinto r
    INNER JOIN Tipo_Recinto t ON r.id_tipo_recinto = t.id_tipo_recinto
    WHERE r.nro_recinto = @nro_recinto;
END;
GO
-- Habilitar recinto
CREATE OR ALTER PROCEDURE sp_HabilitarRecinto
    @nro_recinto INT
AS
BEGIN
    UPDATE Recinto SET habilitado = 1 WHERE nro_recinto = @nro_recinto;
END;
GO
-- Deshabilitar recinto
CREATE OR ALTER PROCEDURE sp_DeshabilitarRecinto
    @nro_recinto INT
AS
BEGIN
    UPDATE Recinto SET habilitado = 0 WHERE nro_recinto = @nro_recinto;
END;
GO
-- Actualizar recinto
CREATE OR ALTER PROCEDURE sp_ActualizarRecinto
    @nro_recinto INT,
    @tarifa_hora FLOAT,
    @ubicacion_recinto VARCHAR(200),
    @id_tipo_recinto INT
AS
BEGIN
    UPDATE Recinto
    SET tarifa_hora = @tarifa_hora,
        ubicacion_recinto = @ubicacion_recinto,
        id_tipo_recinto = @id_tipo_recinto
    WHERE nro_recinto = @nro_recinto;
END;
GO
--Listado de tipos de recinto
CREATE OR ALTER PROCEDURE sp_ListarTiposDeRecinto
AS
BEGIN
    SELECT id_tipo_recinto, nombre_tipo_recinto
    FROM Tipo_Recinto;
END;
GO
--Validacion del inicio de sesion del usuario
CREATE OR ALTER PROCEDURE sp_VerificarUsuarioLogin
    @dni INT,
    @pass NVARCHAR(100)
AS
BEGIN
    SELECT *
    FROM Usuario
    WHERE DNI_Usuario = @dni AND pass = @pass
	AND estado_usuario = 1;
END;
GO
-- Insertar cliente
CREATE OR ALTER PROCEDURE sp_InsertarCliente
    @dni_cliente INT,
    @nombre_cliente VARCHAR(30),
    @apellido_cliente VARCHAR(30),
    @telefono_cliente VARCHAR(20)
AS
BEGIN
    INSERT INTO Cliente (dni_cliente, nombre_cliente, apellido_cliente, telefono_cliente)
    VALUES (@dni_cliente, @nombre_cliente, @apellido_cliente, @telefono_cliente);
END;
GO

-- Listar todos los clientes
CREATE OR ALTER PROCEDURE sp_ListarClientes
AS
BEGIN
    SELECT * FROM Cliente;
END;
GO

-- Buscar cliente por DNI
CREATE OR ALTER PROCEDURE sp_ObtenerClientePorDNI
    @dni_cliente INT
AS
BEGIN
    SELECT * FROM Cliente WHERE dni_cliente = @dni_cliente;
END;
GO
--agregar nueva reserva
CREATE OR ALTER PROCEDURE sp_InsertarReserva
    @fecha_reserva DATE,
    @id_cliente INT,
    @nro_recinto INT,
    @id_usuario INT,
    @hora_reserva INT,
    @monto_reserva FLOAT
AS
BEGIN
    INSERT INTO Reserva (
        fecha_reserva, 
        id_cliente, 
        nro_recinto, 
        id_usuario, 
        hora_reserva, 
        monto_reserva,
        estado
    )
    VALUES (
        @fecha_reserva, 
        @id_cliente, 
        @nro_recinto, 
        @id_usuario, 
        @hora_reserva, 
        @monto_reserva,
        1 -- Siempre se inserta como activa
    );
END;
GO

CREATE OR ALTER PROCEDURE sp_ModificarCliente
    @id_cliente INT,
    @dni_cliente INT,
    @nombre_cliente VARCHAR(30),
    @apellido_cliente VARCHAR(30),
    @telefono_cliente VARCHAR(20)
AS
BEGIN
    UPDATE Cliente
    SET dni_cliente = @dni_cliente,
        nombre_cliente = @nombre_cliente,
        apellido_cliente = @apellido_cliente,
        telefono_cliente = @telefono_cliente
    WHERE id_cliente = @id_cliente;
END;
GO
-- Listar reservas con respectivos clientes y usuarios
CREATE OR ALTER PROCEDURE sp_ListarReservas
AS
BEGIN
    SELECT 
        r.id_reserva,
        r.fecha_reserva,
        r.hora_reserva,
        r.pagado,
        r.nro_recinto,
        r.id_cliente,
        r.id_usuario,
		r.monto_reserva,
		r.estado,
        c.nombre_cliente,
        c.apellido_cliente,
        u.Nombre_Usuario AS nombre_usuario,
        u.Apellido_Usuario AS apellido_usuario
    FROM Reserva r
    INNER JOIN Cliente c ON r.id_cliente = c.id_cliente
    INNER JOIN Usuario u ON r.id_Usuario = u.id_Usuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_HorasReservadas
    @nro_recinto INT,
    @fecha_reserva DATE
AS
BEGIN
    SELECT hora_reserva
    FROM Reserva
    WHERE nro_recinto = @nro_recinto 
      AND fecha_reserva = @fecha_reserva
      AND estado = 1; -- Solo reservas activas
END;
GO
--baja logica de una reserva
CREATE OR ALTER PROCEDURE sp_CancelarReserva
    @id_reserva INT
AS
BEGIN
    UPDATE Reserva SET estado = 0 WHERE id_reserva = @id_reserva;
END;
GO
--actualizar los datos de una reserva
CREATE OR ALTER PROCEDURE sp_ActualizarReserva
    @id_reserva INT,
    @fecha DATE,
    @hora INT,
    @id_cliente INT,
    @nro_recinto INT
AS
BEGIN
    UPDATE Reserva
    SET 
        fecha_reserva = @fecha,
        hora_reserva = @hora,
        id_cliente = @id_cliente,
        nro_recinto = @nro_recinto
    WHERE id_reserva = @id_reserva;
END;

GO

 CREATE OR ALTER PROCEDURE sp_ExisteReservaEnHorario
    @nro_recinto INT,
    @fecha DATE,
    @hora INT,
    @id_excluir INT = NULL
AS
BEGIN
    SELECT 1
    FROM Reserva
    WHERE nro_recinto = @nro_recinto
      AND fecha_reserva = @fecha
      AND hora_reserva = @hora
      AND estado = 1
      AND (@id_excluir IS NULL OR id_reserva != @id_excluir);
END;
 GO

 CREATE OR ALTER PROCEDURE sp_ObtenerReservaPorId
    @id_reserva INT
AS
BEGIN
    SELECT r.id_reserva, r.fecha_reserva, r.hora_reserva, r.id_cliente, r.nro_recinto
    FROM Reserva r
    WHERE r.id_reserva = @id_reserva;
END;

GO

CREATE OR ALTER PROCEDURE sp_RegistrarPago
    @id_reserva INT,
    @id_usuario INT,
    @id_medio INT,
    @monto FLOAT
AS
BEGIN
    INSERT INTO Pago (id_reserva, id_usuario, id_medio, monto_pago, fecha_pago)
    VALUES (@id_reserva, @id_usuario, @id_medio, @monto, GETDATE());

    UPDATE Reserva SET pagado = 1 WHERE id_reserva = @id_reserva;
END;
GO

CREATE OR ALTER PROCEDURE sp_ListarReservasNoPagadas
AS
BEGIN
    SELECT 
        r.id_reserva,
        r.fecha_reserva,
        r.hora_reserva,
        r.id_cliente,
        r.nro_recinto,
        r.id_usuario,
        c.nombre_cliente,
        c.apellido_cliente,
        rec.tarifa_hora
    FROM Reserva r
    INNER JOIN Cliente c ON r.id_cliente = c.id_cliente
    INNER JOIN Recinto rec ON r.nro_recinto = rec.nro_recinto
    WHERE r.pagado = 0 AND r.estado = 1;
END;
GO

CREATE OR ALTER PROCEDURE sp_ListarMediosDePago
AS
BEGIN
    SELECT id_medio, nombre_medio FROM Medio_Pago;
END;
GO

CREATE OR ALTER PROCEDURE sp_ListarPagos
AS
BEGIN
    SELECT 
        p.id_pago,
        p.fecha_pago,
        p.monto_pago,
        m.nombre_medio,
        u.Nombre_Usuario,
        u.Apellido_Usuario,
        r.id_reserva,
		c.nombre_cliente,
        c.apellido_cliente
    FROM Pago p
    INNER JOIN Medio_Pago m ON p.id_medio = m.id_medio
    INNER JOIN Usuario u ON p.id_usuario = u.id_Usuario
    INNER JOIN Reserva r ON p.id_reserva = r.id_reserva
	INNER JOIN Cliente c ON r.id_cliente = c.id_cliente;
END;
GO

CREATE OR ALTER PROCEDURE sp_BajaLogicaUsuario
    @id_usuario INT
AS
BEGIN
    UPDATE Usuario
    SET estado_usuario = 0
    WHERE id_Usuario = @id_usuario;
END;


select * from usuario
