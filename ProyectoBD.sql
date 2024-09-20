DROP DATABASE ProyectoBD;
CREATE DATABASE ProyectoBD;
USE ProyectoBD;

CREATE TABLE Persona (
  ci INT PRIMARY KEY,
  nombre VARCHAR(50) NOT NULL,
  apellido VARCHAR(50) NOT NULL,
  nro_puerta INT NOT NULL,
  calle VARCHAR(100) NOT NULL,
  ciudad VARCHAR(50) NOT NULL,
  estado TINYINT DEFAULT 1,
  CONSTRAINT chk_estado CHECK (estado IN (0, 1))
);

CREATE TABLE Telefono (
  ci INT,
  telefono INT NOT NULL,
  PRIMARY KEY (ci, telefono),
  FOREIGN KEY (ci) REFERENCES Persona(ci)
);

CREATE TABLE Cliente (
  ci INT,
  tipo_cliente VARCHAR(20) NOT NULL,
  PRIMARY KEY (ci),
  FOREIGN KEY (ci) REFERENCES Persona(ci)
);

CREATE TABLE Rol (
  id_rol INT AUTO_INCREMENT,
  nombre_rol VARCHAR(40) NOT NULL,
  PRIMARY KEY (id_rol),
  UNIQUE (nombre_rol) -- Restricción de unicidad en nombre_rol
);

CREATE TABLE Empleado (
  ci INT,
  id_rol INT NOT NULL,
  usuario VARCHAR(20) NOT NULL,
  PRIMARY KEY (ci),
  FOREIGN KEY (ci) REFERENCES Persona(ci),
  FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
  UNIQUE (usuario) -- Restricción de unicidad en usuario
);

CREATE TABLE Marca (
  id_marca INT AUTO_INCREMENT,
  nombre_marca VARCHAR(20) NOT NULL,
  PRIMARY KEY (id_marca),
  UNIQUE (nombre_marca)
);

CREATE TABLE Tipo_Vehiculo (
  id_tipo INT AUTO_INCREMENT,
  nombre_tipo VARCHAR(20) NOT NULL,
  precio_tipo DOUBLE NOT NULL DEFAULT 0,
  plaza_ocupa INT NOT NULL DEFAULT 0,
  PRIMARY KEY (id_tipo),
  UNIQUE (nombre_tipo)
);

CREATE TABLE Vehiculo (
  matricula VARCHAR(10) NOT NULL,
  id_marca INT NOT NULL,
  id_tipo INT NOT NULL,
  estado_vehiculo TINYINT NOT NULL DEFAULT 1,
  PRIMARY KEY (matricula),
  FOREIGN KEY (id_marca) REFERENCES Marca(id_marca),
  FOREIGN KEY (id_tipo) REFERENCES Tipo_Vehiculo(id_tipo),
  CONSTRAINT chk_estado_vehiculo CHECK (estado_vehiculo IN (0, 1))
);

CREATE TABLE Posee (
  ci INT NOT NULL,
  matricula VARCHAR(10) NOT NULL,
  PRIMARY KEY (ci, matricula),
  FOREIGN KEY (ci) REFERENCES Persona(ci),
  FOREIGN KEY (matricula) REFERENCES Vehiculo(matricula)
);

CREATE TABLE Factura (
  id_factura INT AUTO_INCREMENT,
  ci INT NOT NULL,
  matricula VARCHAR(10) NOT NULL,
  fecha DATETIME NOT NULL,
  PRIMARY KEY (id_factura),
  FOREIGN KEY (ci) REFERENCES Persona(ci),
  FOREIGN KEY (matricula) REFERENCES Vehiculo(matricula)
);

CREATE TABLE Marca_Neumatico (
  id_neumatico INT AUTO_INCREMENT,
  nombre_neumatico VARCHAR(40) NOT NULL,
  marca_neumatico VARCHAR(20) NOT NULL,
  precio_neumatico DECIMAL(10, 2) NOT NULL,
  stock_neumatico INT NOT NULL,
  estado_neumatico TINYINT NOT NULL DEFAULT 1,
  CONSTRAINT chk_estado_neumatico CHECK (estado_neumatico IN (0, 1)),
  PRIMARY KEY (id_neumatico)
);

CREATE TABLE Venta_Neumatico (
  id_ventaNeumatico INT AUTO_INCREMENT,
  id_neumatico INT NOT NULL,
  precio_total DECIMAL(10, 2) NOT NULL,
  cantidad_neumatico INT NOT NULL CHECK (cantidad_neumatico > 0),
  PRIMARY KEY (id_ventaNeumatico),
  FOREIGN KEY (id_neumatico) REFERENCES Marca_Neumatico(id_neumatico)
);

CREATE TABLE Compra (
  id_factura INT NOT NULL,
  id_ventaNeumatico INT NOT NULL,
  PRIMARY KEY (id_factura, id_ventaNeumatico),
  FOREIGN KEY (id_factura) REFERENCES Factura(id_factura),
  FOREIGN KEY (id_ventaNeumatico) REFERENCES Venta_Neumatico(id_ventaNeumatico)
);

CREATE TABLE Parking (
  id_parking INT AUTO_INCREMENT,
  hora_entrada DATETIME NOT NULL,
  hora_salida DATETIME NOT NULL,
  precio_parking DECIMAL(10, 2) NOT NULL DEFAULT 0,
  PRIMARY KEY (id_parking),
  CHECK (hora_salida IS NULL OR hora_salida > hora_entrada)
);

CREATE TABLE Plaza (
  id_plaza INT AUTO_INCREMENT,
  estado_plaza ENUM('Libre', 'Ocupada') NOT NULL,
  PRIMARY KEY (id_plaza)
);

CREATE TABLE Reserva (
  id_parking INT NOT NULL,
  id_plaza INT NOT NULL,
  PRIMARY KEY (id_parking, id_plaza),
  FOREIGN KEY (id_parking) REFERENCES Parking(id_parking),
  FOREIGN KEY (id_plaza) REFERENCES Plaza(id_plaza)
);

CREATE TABLE Ticket (
	id_ticket INT AUTO_INCREMENT,
    matricula VARCHAR(10) NOT NULL,
    ci INT NOT NULL,
    id_plaza INT NOT NULL,
    fecha_ticket DATETIME NOT NULL,
    PRIMARY KEY (id_ticket),
    FOREIGN KEY (matricula) REFERENCES Vehiculo(matricula),
    FOREIGN KEY (ci) REFERENCES Cliente(ci),
    FOREIGN KEY (id_plaza) REFERENCES Plaza(id_plaza)
);

CREATE TABLE Solicita (
  id_factura INT NOT NULL,
  id_plaza INT NOT NULL,
  id_parking INT NOT NULL,
  precio_solicita DECIMAL(10, 2) NOT NULL,
  PRIMARY KEY (id_factura, id_plaza, id_parking),
  FOREIGN KEY (id_factura) REFERENCES Factura(id_factura),
  FOREIGN KEY (id_plaza) REFERENCES Plaza(id_plaza),
  FOREIGN KEY (id_parking) REFERENCES Parking(id_parking)
);

CREATE TABLE Lavado (
  id_lavado INT AUTO_INCREMENT,
  nombre_lavado VARCHAR(20) NOT NULL,
  precio_lavado DECIMAL(10, 2) NOT NULL,
  PRIMARY KEY (id_lavado)
);

CREATE TABLE Usa (
  id_factura INT NOT NULL,
  id_lavado INT NOT NULL,
  precio_usa DECIMAL(10, 2) NOT NULL,
  PRIMARY KEY (id_factura, id_lavado),
  FOREIGN KEY (id_factura) REFERENCES Factura(id_factura),
  FOREIGN KEY (id_lavado) REFERENCES Lavado(id_lavado)
);

CREATE TABLE Alineacion_Balanceo (
  id_ayb INT AUTO_INCREMENT,
  nombre_ayb VARCHAR(60) NOT NULL,
  precio_ayb DECIMAL(10, 2) NOT NULL,
  PRIMARY KEY (id_ayb)
);

CREATE TABLE Hace (
  id_factura INT NOT NULL,
  id_ayb INT NOT NULL,
  precio_hace DECIMAL(10, 2) NOT NULL,
  cantidad_hace INT NOT NULL,
  PRIMARY KEY (id_factura, id_ayb),
  FOREIGN KEY (id_factura) REFERENCES Factura(id_factura),
  FOREIGN KEY (id_ayb) REFERENCES Alineacion_Balanceo(id_ayb)
);

/* ----- INGRESO DE DATOS ----- */

/* ROL */

INSERT INTO Rol (id_rol, nombre_rol) VALUES 
(1, 'Gerente'),
(2, 'Jefe de Servicios'),
(3, 'Ejecutivo de Servicios'),
(4, 'Cajero'),
(5, 'Operador de Camaras y Respaldo');

/* CLIENTES */

INSERT INTO Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado) VALUES 
(56303446, 'Juan', 'Pérez', 123, 'Avenida Siempreviva', 'Montevideo', 1),
(43214321, 'María', 'González', 456, 'Calle Falsa', 'Canelones', 1),
(32132143, 'Carlos', 'Rodríguez', 789, 'Boulevard Artigas', 'Maldonado', 1),
(54839454, 'Lucía', 'Fernández', 321, 'Avenida Libertador', 'Montevideo', 1),
(38765432, 'Ana', 'Martínez', 654, 'Calle de la Paz', 'Salto', 1),
(57654321, 'Luis', 'Morales', 987, 'Avenida de los Deportes', 'Paysandú', 1),
(26543210, 'Elena', 'Suárez', 321, 'Calle del Sol', 'Tacuarembó', 1),
(15432109, 'Jorge', 'Paniagua', 654, 'Avenida San Martín', 'Rivera', 1),
(34321098, 'Claudia', 'Gómez', 987, 'Calle del Lago', 'Durazno', 1),
(43210987, 'Ricardo', 'Cruz', 123, 'Boulevard del Río', 'San José', 1);

INSERT INTO Cliente (ci, tipo_cliente) VALUES
(56303446, 'Eventual'),
(43214321, 'Mensual'),
(32132143, 'Sistemático'),
(54839454, 'Mensual'),
(38765432, 'Mensual'),
(57654321, 'Sistematico'),
(26543210, 'Eventual'),
(15432109, 'Mensual'),
(34321098, 'Mensual'),
(43210987, 'Eventual');

INSERT INTO Telefono (ci, telefono) values
(56303446, 096545765),
(56303446, 096923456),
(43214321, 097654321),
(32132143, 091234567),
(54839454, 098765432),
(38765432, 097583475),
(57654321, 099174854),
(26543210, 093453672),
(15432109, 091348571),
(34321098, 09238591),
(43210987, 096123451);

/* EMPLEADOS */

INSERT INTO Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado) VALUES
(12345678, 'Fernando', 'Soria', 417, 'Eusebio Valdenegro', 'Toledo', 1),
(57659321, 'Gonzalo', 'Segovia', 23, 'Pan y Agua', 'Toledo', 1),
(48569384, 'Pedro', 'Perez', 137, 'Propios', 'Montevideo', 1),
(53459384, 'Alejandro', 'Pizarro', 777, 'gnralFlores', 'Montevideo', 1),
(53436384, 'Sebastian', 'Tejera', 322, '18deOctubre', 'Montevideo', 1);

INSERT INTO Telefono (ci, telefono) VALUES 
(12345678, 096124356),
(57659321, 096493807),
(48569384, 097456432),
(53459384, 22969196),
(53436384, 22969196);

INSERT INTO Empleado (usuario, ci, id_rol) VALUES 
('ger', 12345678, 1),
('jefe', 57659321, 2),
('eje', 48569384, 3),
('caj', 53459384, 4),
('ope', 53436384, 5);

/* MARCA VEHICULO */

INSERT INTO Marca (id_marca, nombre_marca) VALUES
(1, 'Toyota'),
(2, 'Honda'),
(3, 'Ford'),
(4, 'BMW'),
(5, 'Mercedes-Benz'),
(6, 'Audi'),
(7, 'Chevrolet'),
(8, 'Volkswagen'),
(9, 'Nissan'),
(10, 'Hyundai'),
(11, 'Kia'),
(12, 'Mazda'),
(13, 'Subaru'),
(14, 'Tesla'),
(15, 'Mitsubishi'),
(16, 'Ducati'),
(17, 'Harley-Davidson'),
(18, 'Kawasaki'),
(19, 'Yamaha'),
(20, 'Suzuki');

/* TIPO VEHICULO */

INSERT INTO Tipo_Vehiculo (id_tipo, nombre_tipo, precio_tipo, plaza_ocupa) VALUES
(1, 'Moto', 50, 0),
(2, 'Auto', 100, 1),
(3, 'Camioneta', 120, 1),
(4, 'Pequenio camion', 150, 2),
(5, 'Pequenio utilitario', 150, 2);

/* VEHICULO */

INSERT INTO Vehiculo (matricula, id_marca, id_tipo, estado_vehiculo) VALUES
('abc1234', 14, 1, 1),
('cba4321', 16, 1, 1),
('fga1235', 4, 1, 1),
('das7869', 7, 2, 1),
('xyz5678', 1, 4, 1),
('uvw8765', 2, 2, 1),
('rst3456', 3, 4, 1),
('opq2345', 5, 2, 1),
('lmn6543', 8, 3, 1),
('ijk9876', 12, 3, 1);

/* POSEE */

insert into Posee (ci, matricula) values
(56303446, 'abc1234'),
(43214321, 'cba4321'),
(32132143, 'fga1235'),
(54839454, 'das7869'),
(38765432, 'xyz5678'),
(57654321, 'uvw8765'),
(26543210, 'rst3456'),
(15432109, 'opq2345'),
(34321098, 'lmn6543'),
(43210987, 'ijk9876');

/* MARCA NEUMATICO */

INSERT INTO Marca_Neumatico (id_neumatico, nombre_neumatico, marca_neumatico, precio_neumatico, stock_neumatico) VALUES
(1, 'Pilot Sport 4', 'Michelin', 250.00, 20),
(2, 'Potenza RE-71R', 'Bridgestone', 230.00, 10),
(3, 'P Zero', 'Pirelli', 280.00, 31),
(4, 'Eagle F1 Asymmetric 5', 'Pirelli', 270.00, 15),
(5, 'Turanza T005', 'Bridgestone', 210.00, 25),
(6, 'Primacy 4', 'Michelin', 240.00, 18),
(7, 'SportContact 6', 'Michelin', 300.00, 12),
(8, 'Ventus S1 evo3', 'Bringestone', 220.00, 20),
(9, 'Ecsta PS91', 'Pirelli', 200.00, 22),
(10, 'Dynapro AT2', 'Michelin', 180.00, 16);

/* FACTURA */

INSERT INTO Factura (id_factura, ci, matricula, fecha) VALUES
(1, 56303446, 'abc1234', '2024-08-17 14:22:45'),
(2, 43214321, 'cba4321', '2024-08-18 10:34:12'),
(3, 32132143, 'fga1235', '2024-08-19 09:00:00'),
(4, 54839454, 'das7869', '2024-08-20 15:45:00'),
(5, 38765432, 'xyz5678', '2024-08-21 11:22:00'),
(6, 57654321, 'uvw8765', '2024-08-22 13:30:00'),
(7, 26543210, 'rst3456', '2024-08-23 10:15:00'),
(8, 15432109, 'opq2345', '2024-08-24 16:00:00'),
(9, 34321098, 'lmn6543', '2024-08-25 14:50:00'),
(10, 43210987, 'ijk9876', '2024-08-26 12:10:00');

/* VENTA NEUMATICO */

INSERT INTO Venta_Neumatico (id_ventaNeumatico, id_neumatico, precio_total, cantidad_neumatico) VALUES
(1, 3, 1120.00, 4),
(2, 9, 400, 2);

/* PARKING */

INSERT INTO Parking (id_parking, hora_entrada, hora_salida, precio_parking) VALUES
(1, '2024-08-19 08:00:00', '2024-08-19 10:00:00', 50),
(2, '2024-08-19 09:00:00', '2024-08-19 11:45:00', 100),
(3, '2024-08-19 11:00:00', '2024-08-19 13:30:00', 50),
(4, '2024-08-19 12:00:00', '2024-08-19 14:00:00', 120),
(5, '2024-08-19 13:00:00', '2024-08-19 15:15:00', 100),
(6, '2024-08-19 14:00:00', '2024-08-19 16:30:00', 125),
(7, '2024-08-19 15:00:00', '2024-08-19 17:00:00', 100),
(8, '2024-08-19 16:00:00', '2024-08-19 18:30:00', 50),
(9, '2024-08-19 17:00:00', '2024-08-19 19:00:00', 150),
(10, '2024-08-19 18:00:00', '2024-08-19 20:00:00', 120);

/* PLAZA */

INSERT INTO Plaza (id_plaza, estado_plaza) VALUES
(1, 'Libre'),
(2, 'Libre'),
(3, 'Ocupada'),
(4, 'Libre'),
(5, 'Libre'),
(6, 'Ocupada'),
(7, 'Libre'),
(8, 'Libre'),
(9, 'Ocupada'),
(10, 'Libre'),
(11, 'Libre'),
(12, 'Libre'),
(13, 'Libre'),
(14, 'Libre'),
(15, 'Libre'),
(16, 'Libre'),
(17, 'Libre'),
(18, 'Libre'),
(19, 'Libre'),
(20, 'Libre'),
(21, 'Ocupada'),
(22, 'Libre'),
(23, 'Libre'),
(24, 'Libre'),
(25, 'Ocupada'),
(26, 'Ocupada'),
(27, 'Libre'),
(28, 'Libre'),
(29, 'Libre'),
(30, 'Ocupada'),
(31, 'Libre'),
(32, 'Libre'),
(33, 'Libre'),
(34, 'Libre'),
(35, 'Libre'),
(36, 'Libre'),
(37, 'Libre'),
(38, 'Libre'),
(39, 'Libre'),
(40, 'Ocupada'),
(41, 'Ocupada'),
(42, 'Libre'),
(43, 'Ocupada'),
(44, 'Libre'),
(45, 'Libre'),
(46, 'Libre'),
(47, 'Libre'),
(48, 'Libre'),
(49, 'Libre'),
(50, 'Libre'),
(51, 'Libre'),
(52, 'Ocupada'),
(53, 'Ocupada'),
(54, 'Libre'),
(55, 'Libre'),
(56, 'Libre'),
(57, 'Libre'),
(58, 'Libre'),
(59, 'Libre'),
(60, 'Libre');

/* RESERVA */

INSERT INTO Reserva (id_parking, id_plaza) VALUES
(1, 3),
(2, 6),
(3, 9),
(4, 21),
(5, 25),
(6, 30),
(7, 40),
(8, 43),
(9, 52),
(10, 53);

/* TICKET */

INSERT INTO Ticket(id_ticket, matricula, ci, id_plaza, fecha_ticket) VALUES
(1, 'abc1234', 56303446, 3, '2024-08-17 14:22:45'),
(2, 'cba4321', 43214321, 6, '2024-08-18 10:34:12'),
(3, 'fga1235', 32132143, 9, '2024-08-19 09:00:00'),
(4, 'das7869', 54839454, 21, '2024-08-20 15:45:00'),
(5, 'xyz5678', 38765432, 25, '2024-08-21 11:22:00'),
(6, 'xyz5678', 38765432, 26, '2024-08-21 11:22:00'),
(7, 'uvw8765', 57654321, 30, '2024-08-22 13:30:00'),
(8, 'rst3456', 26543210, 40, '2024-08-23 10:15:00'),
(9, 'rst3456', 26543210, 41, '2024-08-23 10:15:00'),
(10, 'opq2345', 15432109, 43, '2024-08-24 16:00:00'),
(11, 'lmn6543', 34321098, 52, '2024-08-25 14:50:00'),
(12, 'ijk9876', 43210987, 53, '2024-08-26 12:10:00');

/* SOLICITA */

INSERT INTO Solicita(id_factura, id_plaza, id_parking, precio_solicita) VALUES 
(1, 3, 1, 500.00),
(2, 6, 2, 200.00),
(3, 9, 3, 300.00),
(4, 21, 4, 100.00),
(5, 25, 5, 500.00),
(6, 30, 6, 300.00),
(7, 40, 7, 100.00),
(8, 43, 8, 200.00),
(9, 52, 9, 700.00),
(10, 53, 10, 900.00);

/* LAVADO */

INSERT INTO Lavado(id_lavado, nombre_lavado, precio_lavado) VALUES
(1, 'Moto', 200.00),
(2, 'Auto', 400.00),
(3, 'Camioneta', 460.00),
(4, 'Pequenio camion', 500.00),
(5, 'Pequenio utilitario', 500.00),
(6, 'Lavado gratis', 0.00);

/* ALINEACION Y BALANCEO */

INSERT INTO Alineacion_Balanceo(id_ayb, nombre_ayb, precio_ayb) VALUES
(1, 'Montaje neumatico', 200.00),
(2, 'Alineacion 1 tren desde R17', 1850.00),
(3, 'Alineacion', 1650.00),
(4, 'Balanceo auto y valvula', 385.00),
(5, 'Alineacion 2 trenes', 2475.00),
(6, 'Pack alineacion, 4 balanceos para camioneta y valvulas', 3510),
(7, 'Balanceo de camioneta y valvula', 415);

/* COMPRA */

INSERT INTO Compra(id_factura, id_ventaNeumatico) 
VALUES (1, 1);

/* HACE */

INSERT INTO Hace(id_factura, id_ayb, precio_hace, cantidad_hace) 
VALUES (1, 5, 2475.00, 1);

/* USA */

INSERT INTO Usa(id_factura, id_lavado, precio_usa)
VALUES (2, 6, 0.00);

/* USUARIOS DEL SISTEMA */

-- Borrar empleados si existen
DROP USER IF EXISTS 'ger'@'localhost';
DROP USER IF EXISTS 'jefe'@'localhost';
DROP USER IF EXISTS 'eje'@'localhost';
DROP USER IF EXISTS 'caj'@'localhost';
DROP USER IF EXISTS 'ope'@'localhost';

/* ----- USUARIOS ----- */

CREATE USER 'ger'@'localhost' IDENTIFIED BY '123';
CREATE USER 'jefe'@'localhost' IDENTIFIED BY '123';
CREATE USER 'eje'@'localhost' IDENTIFIED BY '123';
CREATE USER 'caj'@'localhost' IDENTIFIED BY '123';
CREATE USER 'ope'@'localhost' IDENTIFIED BY '123';

-- Doy permiso a los usuarios segun lo necesiten

-- Gerente
GRANT ALL PRIVILEGES ON ProyectoBD.* TO 'ger'@'localhost';

-- Jefe de servicios
GRANT SELECT, INSERT, UPDATE ON Persona TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON Telefono TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Cliente TO 'jefe'@'localhost';
GRANT SELECT ON Rol TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Empleado TO 'jefe'@'localhost';
GRANT SELECT ON Marca TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Vehiculo TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Posee TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Factura TO 'jefe'@'localhost';
GRANT SELECT ON Marca_Neumatico TO 'jefe'@'localhost';
GRANT SELECT ON Venta_Neumatico TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Compra TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Parking TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Plaza TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Reserva TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Solicita TO 'jefe'@'localhost';
GRANT SELECT ON Lavado TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Usa TO 'jefe'@'localhost';
GRANT SELECT ON Alineacion_Balanceo TO 'jefe'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Hace TO 'jefe'@'localhost';

-- Ejecutivo de servicios
GRANT SELECT, INSERT, UPDATE ON Persona TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON Telefono TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Cliente TO 'eje'@'localhost';
GRANT SELECT ON Rol TO 'eje'@'localhost';
GRANT SELECT ON Empleado TO 'eje'@'localhost';
GRANT SELECT ON Marca TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Vehiculo TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Posee TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Factura TO 'eje'@'localhost';
GRANT SELECT ON Marca_Neumatico TO 'eje'@'localhost';
GRANT SELECT ON Venta_Neumatico TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Compra TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Parking TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Plaza TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Reserva TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Solicita TO 'eje'@'localhost';
GRANT SELECT ON Lavado TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Usa TO 'eje'@'localhost';
GRANT SELECT ON Alineacion_Balanceo TO 'eje'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Hace TO 'eje'@'localhost';

-- Cajero
GRANT SELECT ON Persona TO 'caj'@'localhost';
GRANT SELECT ON Cliente TO 'caj'@'localhost';
GRANT SELECT ON Rol TO 'caj'@'localhost';
GRANT SELECT ON Empleado TO 'caj'@'localhost';
GRANT SELECT ON Marca TO 'caj'@'localhost';
GRANT SELECT ON Vehiculo TO 'caj'@'localhost';
GRANT SELECT ON Posee TO 'caj'@'localhost';
GRANT SELECT ON Factura TO 'caj'@'localhost';
GRANT SELECT ON Marca_Neumatico TO 'caj'@'localhost';
GRANT SELECT ON Venta_Neumatico TO 'caj'@'localhost';
GRANT SELECT ON Compra TO 'caj'@'localhost';
GRANT SELECT ON Parking TO 'caj'@'localhost';
GRANT SELECT ON Plaza TO 'caj'@'localhost';
GRANT SELECT ON Reserva TO 'caj'@'localhost';
GRANT SELECT ON Solicita TO 'caj'@'localhost';
GRANT SELECT ON Lavado TO 'caj'@'localhost';
GRANT SELECT ON Usa TO 'caj'@'localhost';
GRANT SELECT ON Alineacion_Balanceo TO 'caj'@'localhost';
GRANT SELECT ON Hace TO 'caj'@'localhost';

-- Operador de camaras y respaldo
GRANT SELECT ON Persona TO 'ope'@'localhost';
GRANT SELECT ON Cliente TO 'ope'@'localhost';
GRANT SELECT ON Rol TO 'ope'@'localhost';
GRANT SELECT ON Empleado TO 'ope'@'localhost';
GRANT SELECT ON Marca TO 'ope'@'localhost';
GRANT SELECT ON Vehiculo TO 'ope'@'localhost';
GRANT SELECT ON Tipo_Vehiculo TO 'ope'@'localhost';
GRANT SELECT ON Posee TO 'ope'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Factura TO 'ope'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Parking TO 'ope'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Plaza TO 'ope'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Ticket TO 'ope'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Reserva TO 'ope'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Solicita TO 'ope'@'localhost';

SELECT p.ci, p.matricula, m.nombre_marca, t.nombre_tipo
FROM Posee p
JOIN Vehiculo v ON p.matricula = v.matricula
JOIN Marca m ON v.id_marca = m.id_marca
JOIN Tipo_Vehiculo t ON t.id_tipo = v.id_tipo
WHERE p.ci = 56303446 AND p.matricula = 'abc1234';

SELECT * FROM ticket ORDER BY fecha_ticket DESC;
