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
  pagado bit DEFAULT 0,
  CONSTRAINT PK_Reserva PRIMARY KEY (id_reserva),
  CONSTRAINT FK_Reserva_Cliente FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
  CONSTRAINT FK_Reserva_Recinto FOREIGN KEY (nro_recinto) REFERENCES Recinto(nro_recinto),
  CONSTRAINT FK_Reserva_Usuario FOREIGN KEY (id_Usuario) REFERENCES Usuario(id_Usuario),
  CONSTRAINT CK_Reserva_Hora CHECK(hora_reserva > 0 and hora_reserva<=24)
);

CREATE TABLE Pago
(
  id_pago INT IDENTITY(1,1) NOT NULL,
  id_reserva INT NOT NULL,
  id_usuario INT NOT NULL,
  monto INT NOT NULL,
  CONSTRAINT PK_Pago PRIMARY KEY (id_pago),
  CONSTRAINT FK_Pago_Reserva FOREIGN KEY (id_reserva) REFERENCES Reserva(id_reserva)
);

insert into Tipo_Recinto(nombre_tipo_recinto) values ('cancha de futbol');
insert into Tipo_Recinto(nombre_tipo_recinto) values ('cancha de padel');
insert into Tipo_Recinto(nombre_tipo_recinto) values ('parrilla');
insert into Tipo_Recinto(nombre_tipo_recinto) values ('pileta de natacion');


insert into Tipo_Usuario (nombre_Tipo) values ('Administrador'), ('Recepcionista');
select * from Tipo_Usuario

insert into Usuario (DNI_Usuario,Nombre_Usuario,Apellido_Usuario,Fecha_Ingreso,Fecha_Nacimiento,pass,telefono,Id_Tipo,Sexo_Usuario) values
(1234,'Milton','admin','2021-06-15','2021-06-15','admin','3794149452',2,'hombre'),

(43822713,'Lucas','Scherf','2021-08-09','2001-12-19','admin','3794149452',1,'hombre');

insert into Usuario (DNI_Usuario,Nombre_Usuario,Apellido_Usuario,Fecha_Ingreso,Fecha_Nacimiento,pass,telefono,Id_Tipo,Sexo_Usuario) values
(42450489,'Fernando','Romero','2021-06-15','2021-06-15','recep','3794149452',2,'hombre');

select * from usuario;
