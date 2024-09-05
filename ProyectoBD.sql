-- drop database ProyectoBD;
create database ProyectoBD;
use ProyectoBD;

create table Persona (
  ci int,
  nombre varchar(20),
  apellido varchar(20),
  nro_puerta int,
  calle varchar(50),
  ciudad varchar(20),
  estado bool,
  primary key (ci)
);

create table Telefono (
  id_telefono int auto_increment,
  ci int,
  telefono int,
  primary key (id_telefono, ci),
  foreign key (ci) references Persona(ci)
);

create table Cliente (
  ci int,
  tipo_cliente varchar(20),
  primary key (ci),
  foreign key (ci) references Persona(ci)
);

create table Rol (
  id_rol int,
  nombre_rol varchar(40),
  primary key (id_rol)
);

create table Empleado (
  ci int,
  id_rol int,
  usuario varchar(20),
  primary key (ci),
  foreign key (ci) references Persona(ci),
  foreign key (id_rol) references Rol(id_rol)
);

create table Marca (
  id_marca int,
  nombre_marca varchar(20),
  primary key (id_marca)
);

create table Vehiculo (
  matricula varchar(10),
  id_marca int,
  tipo_vehiculo int,
  estado_vehiculo bool,
  primary key (matricula),
  foreign key (id_marca) references Marca(id_marca)
);

create table Posee (
  ci int,
  matricula varchar(10),
  primary key (ci, matricula),
  foreign key (ci) references Persona(ci),
  foreign key (matricula) references Vehiculo(matricula)
);

create table Factura (
  id_factura int auto_increment,
  ci int,
  matricula varchar(10),
  fecha datetime,
  primary key (id_factura),
  foreign key (ci) references Persona(ci),
  foreign key (matricula) references Vehiculo(matricula)
);

create table Marca_Neumatico (
  id_neumatico int,
  nombre_neumatico varchar(40),
  marca_neumatico varchar(20),
  precio_neumatico double,
  stock_neumatico int,
  estado_neumatico bool,
  primary key (id_neumatico)
);

create table Venta_Neumatico (
  id_ventaNeumatico int auto_increment,
  id_neumatico int,
  precio_total double,
  cantidad_neumatico int,
  primary key (id_ventaNeumatico),
  foreign key (id_neumatico) references Marca_Neumatico(id_neumatico)
);

create table Compra (
  id_factura int,
  id_ventaNeumatico int,
  primary key (id_factura, id_ventaNeumatico),
  foreign key (id_factura) references Factura(id_factura),
  foreign key (id_ventaNeumatico) references Venta_Neumatico(id_ventaNeumatico)
);

create table Parking (
  id_parking int auto_increment,
  hora_entrada datetime,
  hora_salida datetime,
  primary key (id_parking)
);

create table Plaza (
  id_plaza int,
  nro_plaza int,
  estado_plaza varchar(20),
  precio_plaza double,
  primary key (id_plaza)
);

create table Reserva (
  id_parking int,
  id_plaza int,
  primary key (id_parking, id_plaza),
  foreign key (id_parking) references Parking(id_parking),
  foreign key (id_plaza) references Plaza(id_plaza)
);

create table Solicita (
  id_factura int,
  id_plaza int,
  id_parking int,
  precio_solicita double,
  primary key (id_factura, id_plaza, id_parking),
  foreign key (id_factura) references Factura(id_factura),
  foreign key (id_plaza) references Plaza(id_plaza),
  foreign key (id_parking) references Parking(id_parking)
);

create table Lavado (
  id_lavado int,
  nombre_lavado varchar(20),
  precio_lavado double,
  primary key (id_lavado)
);

create table Usa (
  id_factura int,
  id_lavado int,
  precio_usa double,
  primary key (id_factura, id_lavado),
  foreign key (id_factura) references Factura(id_factura),
  foreign key (id_lavado) references Lavado(id_lavado)
);

create table Alineacion_Balanceo (
  id_ayb int,
  nombre_ayb varchar(60),
  precio_ayb double,
  primary key (id_ayb)
);

create table Hace (
  id_factura int,
  id_ayb int,
  precio_hace double,
  cantidad_hace int,
  primary key (id_factura, id_ayb),
  foreign key (id_factura) references Factura(id_factura),
  foreign key (id_ayb) references Alineacion_Balanceo(id_ayb )
);

/* ----- INGRESO DE DATOS ----- */

/* ROL */
insert into Rol (id_rol, nombre_rol) values 
(1, 'Gerente'),
(2, 'Jefe de Servicios'),
(3, 'Ejecutivo de Servicios'),
(4, 'Cajero'),
(5, 'Operador de Camaras y Respaldo');

/* CLIENTES */
insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado) values 
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

insert into Cliente (ci, tipo_cliente) values
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

insert into Telefono (id_telefono, ci, telefono) values
(1 , 56303446, 096545765),
(2 , 56303446, 096923456),
(3, 43214321, 097654321),
(4, 32132143, 091234567),
(5, 54839454, 098765432),
(6, 38765432, 097583475),
(7, 57654321, 099174854),
(8, 26543210, 093453672),
(9, 15432109, 091348571),
(10, 34321098, 09238591),
(11, 43210987, 096123451);

/* EMPLEADOS */

insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado) values
(12345678, 'Fernando', 'Soria', 417, 'Eusebio Valdenegro', 'Toledo', 1),
(57659321, 'Gonzalo', 'Segovia', 23, 'Pan y Agua', 'Toledo', 1),
(48569384, 'Pedro', 'Perez', 137, 'Propios', 'Montevideo', 1),
(53459384, 'Alejandro', 'Pizarro', 777, 'gnralFlores', 'Montevideo', 1),
(53436384, 'Sebastian', 'Tejera', 322, '18deOctubre', 'Montevideo', 1);

insert into Telefono (id_telefono, ci, telefono) values 
(12, 12345678, 096124356),
(13, 57659321, 096493807),
(14, 48569384, 097456432),
(15, 53459384, 22969196),
(16, 53436384, 22969196);

insert into Empleado (usuario, ci, id_rol) values 
('ger', 12345678, 1),
('jefe', 57659321, 2),
('eje', 48569384, 3),
('caj', 53459384, 4),
('ope', 53436384, 5);

/* MARCA VEHICULO */
insert into Marca (id_marca, nombre_marca) values
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

/* VEHICULO */
insert into Vehiculo (matricula, id_marca, tipo_vehiculo, estado_vehiculo) values
('abc1234', 14, 1, 1),
('cba4321', 16, 3, 1),
('fga1235', 4, 5, 1),
('das7869', 7, 3, 1),
('xyz5678', 1, 4, 1),
('uvw8765', 2, 2, 1),
('rst3456', 3, 4, 1),
('opq2345', 5, 1, 1),
('lmn6543', 8, 3, 1),
('ijk9876', 12, 1, 1);

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
insert into Marca_Neumatico (id_neumatico, nombre_neumatico, marca_neumatico, precio_neumatico, stock_neumatico) values
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

insert into Factura (id_factura, ci, matricula, fecha) values
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
insert into Venta_Neumatico (id_ventaNeumatico, id_neumatico, precio_total, cantidad_neumatico) values
(1, 3, 1120.00, 4),
(2, 9, 400, 2);

/* PARKING */
INSERT INTO Parking (id_parking, hora_entrada, hora_salida) VALUES
(1, '2024-08-19 08:00:00', '2024-08-19 10:00:00'),
(2, '2024-08-19 09:00:00', '2024-08-19 11:45:00'),
(3, '2024-08-19 11:00:00', '2024-08-19 13:30:00'),
(4, '2024-08-19 12:00:00', '2024-08-19 14:00:00'),
(5, '2024-08-19 13:00:00', '2024-08-19 15:15:00'),
(6, '2024-08-19 14:00:00', '2024-08-19 16:30:00'),
(7, '2024-08-19 15:00:00', '2024-08-19 17:00:00'),
(8, '2024-08-19 16:00:00', '2024-08-19 18:30:00'),
(9, '2024-08-19 17:00:00', '2024-08-19 19:00:00'),
(10, '2024-08-19 18:00:00', '2024-08-19 20:00:00');

/* PLAZA */
insert into Plaza (id_plaza, nro_plaza, estado_plaza) values
(1, 1, 'Libre'),
(2, 2, 'Libre'),
(3, 3, 'Ocupado'),
(4, 4, 'Libre'),
(5, 5, 'Libre'),
(6, 6, 'Ocupado'),
(7, 7, 'Libre'),
(8, 8, 'Libre'),
(9, 9, 'Ocupado'),
(10, 10, 'Libre'),
(11, 11, 'Libre'),
(12, 12, 'Libre'),
(13, 13, 'Libre'),
(14, 14, 'Libre'),
(15, 15, 'Libre'),
(16, 16, 'Libre'),
(17, 17, 'Libre'),
(18, 18, 'Libre'),
(19, 19, 'Libre'),
(20, 20, 'Libre'),
(21, 21, 'Ocupado'),
(22, 22, 'Libre'),
(23, 23, 'Libre'),
(24, 24, 'Libre'),
(25, 25, 'Ocupado'),
(26, 26, 'Libre'),
(27, 27, 'Libre'),
(28, 28, 'Libre'),
(29, 29, 'Libre'),
(30, 30, 'Ocupado'),
(31, 31, 'Libre'),
(32, 32, 'Libre'),
(33, 33, 'Libre'),
(34, 34, 'Libre'),
(35, 35, 'Libre'),
(36, 36, 'Libre'),
(37, 37, 'Libre'),
(38, 38, 'Libre'),
(39, 39, 'Libre'),
(40, 40, 'Ocupado'),
(41, 41, 'Libre'),
(42, 42, 'Libre'),
(43, 43, 'Ocupado'),
(44, 44, 'Libre'),
(45, 45, 'Libre'),
(46, 46, 'Libre'),
(47, 47, 'Libre'),
(48, 48, 'Libre'),
(49, 49, 'Libre'),
(50, 50, 'Libre'),
(51, 51, 'Libre'),
(52, 52, 'Ocupado'),
(53, 53, 'Ocupado'),
(54, 54, 'Libre'),
(55, 55, 'Libre'),
(56, 56, 'Libre'),
(57, 57, 'Libre'),
(58, 58, 'Libre'),
(59, 59, 'Libre'),
(60, 60, 'Libre');

/* RESERVA */
insert into Reserva (id_parking, id_plaza) values
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

insert into Solicita(id_factura, id_plaza, id_parking, precio_solicita) values 
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
insert into Lavado(id_lavado, nombre_lavado, precio_lavado) values
(1, 'Moto', 200.00),
(2, 'Auto', 400.00),
(3, 'Camioneta', 460.00),
(4, 'Pequenio camion', 500.00),
(5, 'Pequenio utilitario', 500.00),
(6, 'Lavado gratis', 0.00);

/* ALINEACION Y BALANCEO */
insert into Alineacion_Balanceo(id_ayb, nombre_ayb, precio_ayb) values
(1, 'Montaje neumatico', 200.00),
(2, 'Alineacion 1 tren desde R17', 1850.00),
(3, 'Alineacion', 1650.00),
(4, 'Balanceo auto y valvula', 385.00),
(5, 'Alineacion 2 trenes', 2475.00),
(6, 'Pack alineacion, 4 balanceos para camioneta y valvulas', 3510),
(7, 'Balanceo de camioneta y valvula', 415);

/* COMPRA */ -- Referencia a venta neumatico
insert into Compra(id_factura, id_ventaNeumatico) 
values (1, 1);

/* HACE */ -- Referencia a alineacion y balanceo
insert into Hace(id_factura, id_ayb, precio_hace, cantidad_hace) 
values (1, 5, 2475.00, 1);

/* SOLICITA */ -- Referencia al parking
insert into Solicita(id_factura, id_plaza, id_parking, precio_solicita) values 
(1, 6, 2, 500.00),
(2, 3, 1, 200.00);

/* USA */
insert into Usa(id_factura, id_lavado, precio_usa)
values (2, 6, 0.00);

/* USUARIOS DEL SISTEMA */

-- Borrar empleados si existen
DROP USER IF EXISTS 'ger'@'localhost';
DROP USER IF EXISTS 'jefe'@'localhost';
DROP USER IF EXISTS 'eje'@'localhost';
DROP USER IF EXISTS 'caj'@'localhost';
DROP USER IF EXISTS 'ope'@'localhost';

/* ----- USUARIOS ----- */
-- CREATE USER 'ger'@'localhost' IDENTIFIED BY '123';
-- CREATE USER 'jefe'@'localhost' IDENTIFIED BY '123';
-- CREATE USER 'eje'@'localhost' IDENTIFIED BY '123';
-- CREATE USER 'caj'@'localhost' IDENTIFIED BY '123';
-- CREATE USER 'ope'@'localhost' IDENTIFIED BY '123';

-- Doy permiso a los usuarios segun lo necesiten
-- Gerente

-- Agregar localhost o ip del servidor
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
GRANT SELECT ON Posee TO 'ope'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Factura TO 'ope'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Parking TO 'ope'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Plaza TO 'ope'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Reserva TO 'ope'@'localhost';
GRANT SELECT, INSERT, UPDATE ON Solicita TO 'ope'@'localhost';

/*
SELECT p.nro_plaza
FROM Vehiculo v
JOIN Posee po ON v.matricula = po.matricula
JOIN Factura f ON po.matricula = f.matricula
JOIN Solicita s ON f.id_factura = s.id_factura
JOIN Reserva r ON s.id_parking = r.id_parking
JOIN Parking pa ON r.id_parking = pa.id_parking
JOIN Plaza p ON r.id_plaza = p.id_plaza
WHERE v.matricula = 'abc1234';
*/