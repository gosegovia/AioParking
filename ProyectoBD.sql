-- drop database ProyectoBD;
create database ProyectoBD;
use ProyectoBD;

create table Persona (
  ci int,
  nombre varchar(20),
  apellido varchar(20),
  nro_puerta int,
  calle varchar(20),
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
  id_factura int,
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
  rodado_neumatico int, -- Tamaño del rin del neumático
  ancho_neumatico int, -- Ancho del neumático en milímetros
  perfil_neumatico int, -- Relación de aspecto entre la altura y el ancho
  primary key (id_neumatico)
);

create table Venta_Neumatico (
  id_ventaNeumatico int,
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
  id_parking int,
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
insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado)
values (56303446, 'Juan', 'Pérez', 123, 'Avenida Siempreviva', 'Montevideo', 1);
insert into Cliente (ci, tipo_cliente)
values (56303446, 'Eventual');
insert into Telefono (id_telefono, ci, telefono)
values (1 , 56303446, 096545765);
insert into Telefono (id_telefono, ci, telefono)
values (2 , 56303446, 096923456);

insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado)
values (43214321, 'María', 'González', 456, 'Calle Falsa', 'Canelones', 1);
insert into Cliente (ci, tipo_cliente)
values (43214321, 'Mensual');
insert into Telefono (id_telefono, ci, telefono)
values (3, 43214321, 097654321);

insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado)
values (32132143, 'Carlos', 'Rodríguez', 789, 'Boulevard Artigas', 'Maldonado', 1);
insert into Cliente (ci, tipo_cliente)
values (32132143, 'Sistemático');
insert into Telefono (id_telefono, ci, telefono)
values (4, 32132143, 091234567);

insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado)
values (54839454, 'Lucía', 'Fernández', 321, 'Avenida Libertador', 'Montevideo', 1);
insert into Cliente (ci, tipo_cliente)
values (54839454, 'Mensual');
insert into Telefono (id_telefono, ci, telefono)
values (5, 54839454, 098765432);

/* EMPLEADOS */
-- Gerente
insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado)
values (12345678, 'Fernando', 'Soria', 417, 'Eusebio Valdenegro', 'Toledo', 1);
insert into Telefono (id_telefono, ci, telefono)
values (6, 12345678, 096124356);
insert into Empleado (usuario, ci, id_rol)
values ('ger', 12345678, 1);

-- Jefe de servicios
insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado)
values (87654321, 'Gonzalo', 'Segovia', 23, 'Pan y Agua', 'Toledo', 1);
insert into Telefono (id_telefono, ci, telefono)
values (7, 87654321, 096493807);
insert into Empleado (usuario, ci, id_rol)
values ('jefe', 87654321, 2);

-- Ejecutivo de servicios
insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado)
values (48569384, 'Pedro', 'Perez', 137, 'Propios', 'Montevideo', 1);
insert into Telefono (id_telefono, ci, telefono)
values (8, 48569384, 097456432);
insert into Empleado (usuario, ci, id_rol)
values ('eje', 48569384, 3);

-- Cajero
insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado)
values (53459384, 'Alejandro', 'Pizarro', 777, 'gnralFlores', 'Montevideo', 1);
insert into Telefono (id_telefono, ci, telefono)
values (9, 53459384, 22969196);
insert into Empleado (usuario, ci, id_rol)
values ('caj', 53459384, 4);

-- Operador de camaras y respaldo
insert into Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado)
values (53436384, 'Sebastian', 'Tejera', 322, '18deOctubre', 'Montevideo', 1);
insert into Telefono (id_telefono, ci, telefono)
values (10, 53436384, 22969196);
insert into Empleado (usuario, ci, id_rol)
values ('ope', 53436384, 5);

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
insert into Vehiculo (matricula, id_marca, tipo_vehiculo)
values ('abc1234', 14, 1);
insert into Posee (ci, matricula)
values (56303446, 'abc1234');

insert into Vehiculo (matricula, id_marca, tipo_vehiculo)
values ('cba4321', 16, 3);
insert into Posee (ci, matricula)
values (43214321, 'cba4321');

/* MARCA NEUMATICO */
insert into Marca_Neumatico (id_neumatico, nombre_neumatico, marca_neumatico, precio_neumatico, stock_neumatico, rodado_neumatico, ancho_neumatico, perfil_neumatico) values
(1, 'Pilot Sport 4', 'Michelin', 250.00, 20, 17, 225, 45),
(2, 'Potenza RE-71R', 'Bridgestone', 230.00, 10, 18, 245, 40),
(3, 'P Zero', 'Pirelli', 280.00, 31, 19, 255, 35),
(4, 'Eagle F1 Asymmetric 5', 'Pirelli', 270.00, 15, 18, 235, 45),
(5, 'Turanza T005', 'Bridgestone', 210.00, 25, 16, 205, 55),
(6, 'Primacy 4', 'Michelin', 240.00, 18, 17, 215, 50),
(7, 'SportContact 6', 'Michelin', 300.00, 12, 19, 275, 35),
(8, 'Ventus S1 evo3', 'Bringestone', 220.00, 20, 18, 245, 40),
(9, 'Ecsta PS91', 'Pirelli', 200.00, 22, 17, 225, 45),
(10, 'Dynapro AT2', 'Michelin', 180.00, 16, 16, 245, 70);

/* VENTA NEUMATICO */
insert into Venta_Neumatico (id_ventaNeumatico, id_neumatico, precio_total, cantidad_neumatico) values
(1, 3, 1120.00, 4),
(2, 9, 400, 2);

/* PARKING */
INSERT INTO Parking (id_parking, hora_entrada, hora_salida) VALUES
(1, '2024-08-19 08:00:00', '2024-08-19 10:00:00'),
(2, '2024-08-19 09:00:00', '2024-08-19 11:45:00'),
(3, '2024-08-19 11:00:00', '2024-08-19 13:30:00');

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
(21, 21, 'Libre'),
(22, 22, 'Libre'),
(23, 23, 'Libre'),
(24, 24, 'Libre'),
(25, 25, 'Libre'),
(26, 26, 'Libre'),
(27, 27, 'Libre'),
(28, 28, 'Libre'),
(29, 29, 'Libre'),
(30, 30, 'Libre'),
(31, 31, 'Libre'),
(32, 32, 'Libre'),
(33, 33, 'Libre'),
(34, 34, 'Libre'),
(35, 35, 'Libre'),
(36, 36, 'Libre'),
(37, 37, 'Libre'),
(38, 38, 'Libre'),
(39, 39, 'Libre'),
(40, 40, 'Libre'),
(41, 41, 'Libre'),
(42, 42, 'Libre'),
(43, 43, 'Libre'),
(44, 44, 'Libre'),
(45, 45, 'Libre'),
(46, 46, 'Libre'),
(47, 47, 'Libre'),
(48, 48, 'Libre'),
(49, 49, 'Libre'),
(50, 50, 'Libre'),
(51, 51, 'Libre'),
(52, 52, 'Libre'),
(53, 53, 'Libre'),
(54, 54, 'Libre'),
(55, 55, 'Libre'),
(56, 56, 'Libre'),
(57, 57, 'Libre'),
(58, 58, 'Libre'),
(59, 59, 'Libre'),
(60, 60, 'Libre');

/* RESERVA */
insert into Reserva(id_parking, id_plaza) values
(1, 3),
(2, 6),
(3, 9);

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

/* FACTURA */
insert into Factura(id_factura, ci, matricula, fecha) values
(1, 56303446, 'abc1234', '2024-08-17 14:22:45'),
(2, 43214321, 'cba4321', '2024-08-18 10:34:12');

/* COMPRA */ -- Referencia a venta neumatico
insert into Compra(id_factura, id_ventaNeumatico) 
values (1, 1);

/* HACE */ -- Referencia a alineacion y balanceo
insert into Hace(id_factura, id_ayb, precio_hace, cantidad_hace) 
values (1, 5, 2475.00, 1);

/* SOLICITA */ -- Referencia al parking
insert into Solicita(id_factura, id_plaza, id_parking, precio_solicita)
values (2, 3, 1, 200.00);

/* USA */
insert into Usa(id_factura, id_lavado, precio_usa)
values (2, 6, 0.00);

/* USUARIOS DEL SISTEMA */

-- Borrar empleados si existen
-- drop user if exists 'ger'@'%';
-- drop user if exists 'jefe'@'%';
-- drop user if exists 'eje'@'%';
-- drop user if exists 'caj'@'%';
-- drop user if exists 'ope'@'%';

/* ----- USUARIOS ----- */
-- create user 'ger' identified by '123';
-- create user 'jefe' identified by '123';
-- create user 'eje' identified by '123';
-- create user 'caj' identified by '123';
-- create user 'ope' identified by '123';

-- Doy permiso a los usuarios segun lo necesiten
-- Gerente
grant select on Empleado to ger;
grant insert on Empleado to ger;
grant update on Empleado to ger;

grant select on Cliente to ger;
grant insert on Cliente to ger;
grant update on Cliente to ger;

grant select on Persona to ger;
grant insert on Persona to ger;
grant update on Persona to ger;

grant select on Telefono to ger;
grant insert on Telefono to ger;
grant update on Telefono to ger;
grant delete on Telefono to ger;

grant select on Rol to ger;
grant select on Marca to ger;
grant select on Vehiculo to ger;
grant select on Posee to ger;
grant select on Parking to ger;
grant select on Solicita to ger;
grant select on Plaza to ger;
grant select on Factura to ger;
grant select on Usa to ger;

-- Jefe de servicios
grant select on Empleado to jefe;
grant select on Cliente to ger;
grant select on Persona to jefe;
grant select on Telefono to jefe;
grant select on Rol to jefe;
grant select on Marca to jefe;

-- Ejecutivo de servicios
grant select on Empleado to eje;
grant select on Cliente to eje;
grant select on Persona to eje;
grant select on Telefono to eje;
grant select on Marca to eje;

-- Cajero
grant select on Empleado to caj;
grant select on Persona to caj;
grant select on Telefono to caj;

-- Operador de camaras y respaldo
grant select on Empleado to ope;
grant select on Persona to ope;
grant select on Telefono to ope;
grant select on Plaza to ope;

/*
SELECT p.nro_plaza
FROM Vehiculo v
JOIN Posee po ON v.matricula = po.matricula
JOIN Factura f ON po.ci = f.ci
JOIN Solicita s ON f.id_factura = s.id_factura
JOIN Plaza p ON s.id_plaza = p.id_plaza
WHERE v.matricula = 'cba4321';
*/

select p.ci, p.nombre, p.apellido, p.nro_puerta, p.calle, p.ciudad, p.estado, t.telefono, c.tipo_cliente
from Persona p, Telefono t, Cliente c
where p.ci = t.ci and p.ci = c.ci;

update Persona
set estado = 0
where ci =123321123;
