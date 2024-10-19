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
  estado TINYINT DEFAULT 1
);

CREATE TABLE Telefono (
  ci INT,
  telefono VARCHAR(9) NOT NULL,
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
  UNIQUE (nombre_rol)
);

CREATE TABLE Empleado (
  ci INT,
  id_rol INT NOT NULL,
  usuario VARCHAR(20) NOT NULL,
  PRIMARY KEY (ci),
  FOREIGN KEY (ci) REFERENCES Persona(ci),
  FOREIGN KEY (id_rol) REFERENCES Rol(id_rol)
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
  FOREIGN KEY (id_tipo) REFERENCES Tipo_Vehiculo(id_tipo)
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
  ci_cliente INT NOT NULL,
  ci_empleado INT NOT NULL,
  matricula VARCHAR(10) NOT NULL,
  factura_paga BOOL NOT NULL,
  fecha DATETIME NOT NULL,
  PRIMARY KEY (id_factura),
  FOREIGN KEY (ci_cliente) REFERENCES Cliente(ci),
  FOREIGN KEY (ci_empleado) REFERENCES Empleado(ci),
  FOREIGN KEY (matricula) REFERENCES Vehiculo(matricula)
);

CREATE TABLE Neumatico (
  id_neumatico INT AUTO_INCREMENT,
  nombre_neumatico VARCHAR(40) NOT NULL,
  marca_neumatico VARCHAR(20) NOT NULL,
  precio_neumatico DECIMAL(10, 2) NOT NULL,
  stock_neumatico INT NOT NULL,
  estado_neumatico TINYINT NOT NULL,
  PRIMARY KEY (id_neumatico)
);

CREATE TABLE Compra (
  id_factura INT NOT NULL,
  id_neumatico INT NOT NULL,
  precio_compra DOUBLE NOT NULL,
  cantidad_compra INT NOT NULL,
  PRIMARY KEY (id_factura, id_neumatico),
  FOREIGN KEY (id_factura) REFERENCES Factura(id_factura),
  FOREIGN KEY (id_neumatico) REFERENCES Neumatico(id_neumatico)
);

CREATE TABLE Parking (
  id_parking INT AUTO_INCREMENT,
  hora_entrada DATETIME NOT NULL,
  hora_salida DATETIME NOT NULL,
  precio_parking DOUBLE NOT NULL DEFAULT 0,
  PRIMARY KEY (id_parking)
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
    PRIMARY KEY (id_ticket, matricula, ci, id_plaza),
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
  PRIMARY KEY (id_factura, id_ayb),
  FOREIGN KEY (id_factura) REFERENCES Factura(id_factura),
  FOREIGN KEY (id_ayb) REFERENCES Alineacion_Balanceo(id_ayb)
);

/* ----- INGRESO DE DATOS ----- */

/* ROL */

INSERT INTO Rol (id_rol, nombre_rol) VALUES 
(1, 'Operador de Camaras y Respaldo'),
(2, 'Cajero'),
(3, 'Ejecutivo de Servicios'),
(4, 'Jefe de Servicios'),
(5, 'Gerente');

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
(43210987, 'Ricardo', 'Cruz', 123, 'Boulevard del Río', 'San José', 1),
(11111111, 'Gabriel', 'Torres', 101, 'Calle Principal', 'Montevideo', 1),
(23456789, 'Laura', 'López', 102, 'Avenida Central', 'Canelones', 1),
(34567890, 'Matías', 'Sánchez', 103, 'Calle del Parque', 'Maldonado', 1),
(45678901, 'Sofía', 'Ramos', 104, 'Calle del Bosque', 'Salto', 1),
(56789012, 'Diego', 'Pereira', 105, 'Calle del Estadio', 'Paysandú', 1),
(67890123, 'Camila', 'Arias', 106, 'Calle del Faro', 'Colonia', 1),
(78901234, 'Lucas', 'Díaz', 107, 'Avenida de la Paz', 'Rivera', 1),
(89012345, 'Valentina', 'Giménez', 108, 'Calle del Mar', 'Maldonado', 1),
(90123456, 'Santiago', 'Bianchi', 109, 'Calle del Sol', 'Salto', 1),
(10234567, 'Natalia', 'Cabrera', 110, 'Calle del Río', 'San José', 1),
(21345678, 'Martín', 'Acosta', 111, 'Avenida Independencia', 'Montevideo', 1),
(32456789, 'Florencia', 'Méndez', 112, 'Calle del Lago', 'Paysandú', 1),
(43567890, 'Federico', 'Silva', 113, 'Calle de los Pinos', 'Canelones', 1),
(54678901, 'Mariana', 'Gutiérrez', 114, 'Calle de los Olivos', 'Rivera', 1),
(65789012, 'Andrés', 'Lima', 115, 'Calle de la Playa', 'Durazno', 1),
(76890123, 'Luciana', 'Ortega', 116, 'Boulevard Artigas', 'Montevideo', 1),
(87901234, 'Sebastián', 'Castro', 117, 'Calle 18 de Julio', 'Salto', 1),
(98012345, 'Julieta', 'Sosa', 118, 'Calle de la Cruz', 'Paysandú', 1),
(19876543, 'Ignacio', 'Herrera', 119, 'Calle del Campo', 'Rivera', 1),
(20987654, 'Agustina', 'Martínez', 120, 'Calle de la Amistad', 'San José', 1),
(31098765, 'Juan Pablo', 'Álvarez', 121, 'Calle de los Ángeles', 'Colonia', 1),
(42109876, 'Emilia', 'Ruiz', 122, 'Calle del Norte', 'Canelones', 1),
(53210987, 'Tomás', 'Fernández', 123, 'Calle del Este', 'Maldonado', 1),
(64321098, 'Daniela', 'Lorenzo', 124, 'Calle de las Flores', 'Rivera', 1),
(75432109, 'Maximiliano', 'Cabrera', 125, 'Avenida Artigas', 'Montevideo', 1),
(86543210, 'Victoria', 'Pérez', 126, 'Calle de la Luna', 'Salto', 1),
(97654321, 'Emilio', 'García', 127, 'Calle de las Estrellas', 'Paysandú', 1),
(58765432, 'Catalina', 'Navarro', 128, 'Calle de los Andes', 'Rivera', 1),
(69876543, 'Ezequiel', 'Peralta', 129, 'Calle del Horizonte', 'Maldonado', 1),
(70987654, 'Paula', 'Molina', 130, 'Calle de los Arrayanes', 'San José', 1);

INSERT INTO Cliente (ci, tipo_cliente) VALUES 
(56303446, 'Eventual'),
(43210987, 'Eventual'),
(11111111, 'Eventual'),
(45678901, 'Eventual'),
(67890123, 'Eventual'),
(90123456, 'Eventual'),
(54678901, 'Eventual'),
(87901234, 'Eventual'),
(20987654, 'Eventual'),
(53210987, 'Eventual'),
(86543210, 'Eventual'),
(70987654, 'Eventual'),

(43214321, 'Mensual'),
(54839454, 'Mensual'), 
(38765432, 'Mensual'), 
(26543210, 'Mensual'),
(15432109, 'Mensual'), 
(34321098, 'Mensual'),
(23456789, 'Mensual'),
(56789012, 'Mensual'),
(78901234, 'Mensual'),
(10234567, 'Mensual'),
(21345678, 'Mensual'),
(43567890, 'Mensual'),
(76890123, 'Mensual'),
(98012345, 'Mensual'),
(31098765, 'Mensual'),
(64321098, 'Mensual'),
(97654321, 'Mensual'),
(69876543, 'Mensual'),

(32132143, 'Sistematico'), 
(57654321, 'Sistematico'),
(34567890, 'Sistematico'),
(89012345, 'Sistematico'),
(32456789, 'Sistematico'),
(65789012, 'Sistematico'),
(19876543, 'Sistematico'),
(42109876, 'Sistematico'),
(75432109, 'Sistematico'),
(58765432, 'Sistematico');

INSERT INTO Telefono (ci, telefono) VALUES
(56303446, '096545765'),
(56303446, '096923456'),
(43214321, '097654321'),
(32132143, '091234567'),
(54839454, '098765432'),
(38765432, '097583475'),
(57654321, '099174854'),
(26543210, '093453672'),
(15432109, '091348571'),
(34321098, '09238591'),
(43210987, '096123451'),
(11111111, '098765432'),
(23456789, '099123456'),
(34567890, '098654321'),
(45678901, '099876543'),
(56789012, '091234567'),
(67890123, '098987654'),
(78901234, '099654321'),
(89012345, '091876543'),
(90123456, '098123456'),
(10234567, '099432198'),
(21345678, '091765432'),
(32456789, '099876123'),
(43567890, '098321987'),
(54678901, '091234876'),
(65789012, '099234567'),
(76890123, '098987321'),
(87901234, '091654321'),
(98012345, '099876654'),
(19876543, '098123876'),
(20987654, '091432198'),
(31098765, '099987432'),
(42109876, '098765678'),
(53210987, '099123765'),
(64321098, '091987543'),
(75432109, '098654876'),
(86543210, '099876345'),
(97654321, '098321654'),
(58765432, '091234543'),
(69876543, '099432765'),
(70987654, '098987543');

/* EMPLEADOS */

INSERT INTO Persona (ci, nombre, apellido, nro_puerta, calle, ciudad, estado) VALUES
(12345678, 'Fernando', 'Soria', 417, 'Eusebio Valdenegro', 'Toledo', 1),
(57659321, 'Gonzalo', 'Segovia', 23, 'Pan y Agua', 'Toledo', 1),
(48569384, 'Pedro', 'Perez', 137, 'Propios', 'Montevideo', 1),
(53459384, 'Alejandro', 'Pizarro', 777, 'gnralFlores', 'Montevideo', 1),
(53436384, 'Sebastian', 'Tejera', 322, '18deOctubre', 'Montevideo', 1),
(12345679, 'Lucas', 'Martínez', 45, 'Avenida de la Paz', 'Montevideo', 1),
(12345680, 'Sofía', 'González', 78, 'Calle de la Amistad', 'Canelones', 1),
(12345681, 'Esteban', 'Ramos', 99, 'Calle de los Olivos', 'Salto', 1),
(12345682, 'Natalia', 'Acosta', 21, 'Calle del Río', 'Durazno', 1),
(12345683, 'Diego', 'López', 64, 'Boulevard Artigas', 'Maldonado', 1),
(12345684, 'Claudia', 'Torres', 11, 'Calle del Sol', 'Rivera', 1),
(12345685, 'Andrés', 'Hernández', 31, 'Calle de la Luna', 'Paysandú', 1),
(12345686, 'Marta', 'Cruz', 54, 'Avenida Central', 'Colonia', 1),
(12345687, 'Fernando', 'Ortega', 13, 'Calle de las Flores', 'Toledo', 1),
(12345688, 'Camila', 'Gómez', 77, 'Calle de la Paz', 'Montevideo', 1),
(12345689, 'Sebastián', 'Díaz', 88, 'Avenida Libertador', 'Canelones', 1),
(12345690, 'Valentina', 'Suárez', 45, 'Calle del Lago', 'Salto', 1),
(12345691, 'Joaquín', 'Méndez', 36, 'Calle de la Independencia', 'Durazno', 1),
(12345692, 'Pablo', 'Cabrera', 22, 'Avenida San Martín', 'Maldonado', 1),
(12345693, 'Florencia', 'Pérez', 19, 'Calle del Bosque', 'Rivera', 1),
(12345694, 'Alejandra', 'Castro', 87, 'Calle 18 de Julio', 'Paysandú', 1),
(12345695, 'Ricardo', 'Bianchi', 44, 'Calle del Parque', 'Colonia', 1),
(12345696, 'Martín', 'Gutiérrez', 12, 'Boulevard de los Pinos', 'Toledo', 1),
(12345697, 'Lourdes', 'Vázquez', 25, 'Avenida del Norte', 'Montevideo', 1),
(12345698, 'Martina', 'Navarro', 67, 'Calle de los Andes', 'Canelones', 1),
(12345699, 'Lucas', 'Santos', 78, 'Calle del Faro', 'Salto', 1),
(12345700, 'Gabriel', 'Bermúdez', 99, 'Calle del Mar', 'Durazno', 1),
(12345701, 'Laura', 'Salazar', 54, 'Avenida de los Deportes', 'Maldonado', 1),
(12345702, 'Hugo', 'Mora', 45, 'Calle del Estadio', 'Rivera', 1),
(12345703, 'Sergio', 'Peña', 12, 'Calle de las Estrellas', 'Paysandú', 1),
(12345704, 'Tamara', 'Acosta', 88, 'Calle de la Amistad', 'Colonia', 1),
(12345705, 'Cristian', 'Rojas', 67, 'Calle de la Esperanza', 'Toledo', 1),
(12345706, 'Diana', 'Gómez', 39, 'Calle de la Libertad', 'Montevideo', 1),
(12345707, 'Maximiliano', 'López', 22, 'Avenida del Sol', 'Canelones', 1),
(12345708, 'Valeria', 'Cifuentes', 25, 'Calle de los Ríos', 'Salto', 1),
(12345709, 'Alejandro', 'Solís', 74, 'Calle de la Paz', 'Durazno', 1),
(12345710, 'Alicia', 'Sánchez', 36, 'Calle de los Sueños', 'Maldonado', 1),
(12345711, 'Ezequiel', 'Téllez', 47, 'Calle del Cielo', 'Rivera', 1),
(12345712, 'Isabel', 'Guerrero', 56, 'Calle de la Esperanza', 'Paysandú', 1),
(12345713, 'Bruno', 'Aguirre', 13, 'Calle del Horizonte', 'Colonia', 1);

INSERT INTO Empleado (usuario, ci, id_rol) VALUES 
('ope', 53436384, 1),
('caj', 53459384, 2),
('eje', 48569384, 3),
('jefe', 57659321, 4),
('ger', 12345678, 5),

('lmartinez', 12345679, 1),
('ctorres', 12345684, 1),
('vsuarez', 12345689, 1),
('rbianchi', 12345694, 1),
('gbermudez', 12345699, 1),
('crojas', 12345704, 1),
('asolis', 12345709, 1),

('sgonzalez', 12345680, 2),
('ahernandez', 12345685, 2),
('jmendez', 12345690, 2),
('mgutierrez', 12345695, 2),
('lsalazar', 12345700, 2),
('dgomez', 12345705, 2),
('asanchez', 12345710, 2),

('estebanr', 12345681, 3),
('mcabrera', 12345686, 3),
('pcabrera', 12345691, 3),
('lvazquez', 12345696, 3),
('hmora', 12345701, 3),
('mlopez', 12345706, 3),
('etellez', 12345711, 3),

('nacosta', 12345682, 4),
('fgomez', 12345687, 4),
('fperez', 12345692, 4),
('mnavarro', 12345697, 4),
('speña', 12345702, 4),
('vcifuentes', 12345707, 4),
('iguerrero', 12345712, 4),

('dlopez', 12345683, 5),
('sdiaz', 12345688, 5),
('acastro', 12345693, 5),
('lsantos', 12345698, 5),
('tacosta', 12345703, 5),
('baguirre', 12345713, 5);

INSERT INTO Telefono (ci, telefono) VALUES 
(12345678, '091124356'),
(57659321, '096493807'),
(48569384, '097456432'),
(53459384, '22969196'),
(53436384, '22969196'),
(12345679, '096112233'),
(12345680, '096223344'),
(12345681, '096334455'),
(12345682, '096445566'),
(12345683, '096556677'),
(12345684, '096667788'),
(12345685, '096778899'),
(12345686, '096889900'),
(12345687, '096990011'),
(12345688, '097101112'),
(12345689, '097111213'),
(12345690, '097121314'),
(12345691, '097131415'),
(12345692, '097141516'),
(12345693, '097151617'),
(12345694, '097161718'),
(12345695, '097171819'),
(12345696, '097181920'),
(12345697, '097192021'),
(12345698, '097202122'),
(12345699, '097212223'),
(12345700, '097222324'),
(12345701, '097232425'),
(12345702, '097242526'),
(12345703, '097252627'),
(12345704, '097262728'),
(12345705, '097272829'),
(12345706, '097282930'),
(12345707, '097293041'),
(12345708, '097304152'),
(12345709, '097315263'),
(12345710, '097326374'),
(12345711, '097337485'),
(12345712, '097348596'),
(12345713, '097359607');

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
('nop1357', 14, 1, 1),
('abc9876', 2, 1, 1),
('mno6789', 6, 1, 1),
('pqr9876', 14, 1, 1),
('efg4680', 2, 1, 1),
('qrs8024', 6, 1, 1),
('opq6802', 16, 1, 1),

('das7869', 7, 2, 1),
('uvw8765', 2, 2, 1),
('qrs2468', 16, 2, 1),
('stu3579', 4, 2, 1),
('def5432', 3, 2, 1),
('jkl4567', 5, 2, 1),
('stu2345', 16, 2, 1),
('vwx1357', 4, 2, 1),
('hij5791', 3, 2, 1),
('nop7913', 5, 2, 1),
('fgh3579', 13, 2, 1),

('lmn6543', 8, 3, 1),
('ijk9876', 12, 3, 1),
('vwx4680', 7, 3, 1),
('ghi1234', 8, 3, 1),
('yza2468', 7, 3, 1),
('klm6802', 8, 3, 1),
('ijk4680', 14, 3, 1),
('rst7913', 17, 3, 1),

('xyz5678', 1, 4, 1),
('rst3456', 3, 4, 1),
('yz01234', 1, 4, 1),
('bcd3579', 1, 4, 1),
('zab1357', 11, 4, 1),

('opq2345', 5, 5, 1),
('tuv9135', 9, 5, 1),
('wxy0246', 10, 5, 1),
('cde2468', 12, 5, 1),
('lmn5791', 15, 5, 1),
('uvw8024', 18, 5, 1);

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
(43210987, 'ijk9876'),
(11111111, 'nop1357'),
(23456789, 'qrs2468'),
(34567890, 'stu3579'),
(45678901, 'vwx4680'),
(56789012, 'yz01234'),
(67890123, 'abc9876'),
(78901234, 'def5432'),
(89012345, 'ghi1234'),
(90123456, 'jkl4567'),
(10234567, 'mno6789'),
(21345678, 'pqr9876'),
(32456789, 'stu2345'),
(43567890, 'vwx1357'),
(54678901, 'yza2468'),
(65789012, 'bcd3579'),
(76890123, 'efg4680'),
(87901234, 'hij5791'),
(98012345, 'klm6802'),
(19876543, 'nop7913'),
(20987654, 'qrs8024'),
(31098765, 'tuv9135'),
(42109876, 'wxy0246'),
(53210987, 'zab1357'),
(64321098, 'cde2468'),
(75432109, 'fgh3579'),
(86543210, 'ijk4680'),
(97654321, 'lmn5791'),
(58765432, 'opq6802'),
(69876543, 'rst7913'),
(70987654, 'uvw8024');

/* MARCA NEUMATICO */

INSERT INTO Neumatico (id_neumatico, nombre_neumatico, marca_neumatico, precio_neumatico, stock_neumatico, estado_neumatico) VALUES
(1, 'Pilot Sport 4', 'Michelin', 250.00, 20, 1),
(2, 'Potenza RE-71R', 'Bridgestone', 230.00, 10, 1),
(3, 'P Zero', 'Pirelli', 280.00, 31, 1),
(4, 'Eagle F1 Asymmetric 5', 'Pirelli', 270.00, 15, 1),
(5, 'Turanza T005', 'Bridgestone', 210.00, 25, 1),
(6, 'Primacy 4', 'Michelin', 240.00, 18, 1),
(7, 'SportContact 6', 'Michelin', 300.00, 12, 1),
(8, 'Ventus S1 evo3', 'Bringestone', 220.00, 20, 1),
(9, 'Ecsta PS91', 'Pirelli', 200.00, 22, 1),
(10, 'Dynapro AT2', 'Michelin', 180.00, 16, 1);

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
(33, 'Ocupada'),
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
(4, 'Balanceo auto + valvula', 385.00),
(5, 'Alineacion 2 trenes', 2475.00),
(6, 'Alineacion + 4 balanceos + valvula', 3510),
(7, 'Balanceo de camioneta + valvula', 415);

/* FACTURAS abc1234 */
INSERT INTO Factura (id_factura, ci_cliente, ci_empleado, matricula, factura_paga, fecha) VALUES
(1, 56303446, 53459384, 'abc1234', '1', '2024-10-20 10:00:00'),
(11, 56303446, 53459384, 'abc1234', '1', '2024-10-21 09:00:00'),
(12, 56303446, 53459384, 'abc1234', '1', '2024-10-22 11:00:00'),
(13, 56303446, 53459384, 'abc1234', '1', '2024-10-23 13:00:00'),
(14, 56303446, 53459384, 'abc1234', '1', '2024-10-24 10:00:00'),
(15, 56303446, 53459384, 'abc1234', '0', '2024-11-18 11:00:00');

/* PARKING */
INSERT INTO Parking (id_parking, hora_entrada, hora_salida, precio_parking) VALUES
(1, '2024-10-20 08:00:00', '2024-10-20 10:00:00', 50),
(11, '2024-10-21 08:00:00', '2024-10-21 09:00:00', 50),
(12, '2024-10-22 07:00:00', '2024-10-22 11:00:00', 50),
(13, '2024-10-23 07:00:00', '2024-10-23 13:00:00', 50),
(14, '2024-10-24 08:00:00', '2024-10-24 10:00:00', 50),
(15, '2024-11-18 08:00:00', '2024-11-18 11:00:00', 50);

/* RESERVA */
INSERT INTO Reserva(id_parking, id_plaza) VALUES
(1, 3),
(11, 5),
(12, 2),
(13, 3),
(14, 4),
(15, 2);

/* SOLICITA */
INSERT INTO Solicita(id_factura, id_plaza, id_parking, precio_solicita) VALUES 
(1, 3, 1, 500.00),
(11, 5, 11, 500.00),
(12, 2, 12, 500.00),
(13, 3, 13, 500.00),
(14, 4, 14, 500.00),
(15, 2, 15, 500.00);
/* USA-LAVADO */
INSERT INTO Usa(id_factura, id_lavado, precio_usa) VALUES
(1, 1, 200.00),
(11, 1, 200.00),
(13, 1, 200.00),
(12, 1, 200.00);
/* HACE-ALINEACION/BALANCEO */
INSERT INTO Hace(id_factura, id_ayb, precio_hace) VALUES
(1, 5, 2475.00),
(11, 1, 200.00),
(13, 7, 415.00);
/* COMPRA-NEUMATICO */
INSERT INTO Compra(id_factura, id_neumatico, precio_compra, cantidad_compra) 
VALUES (15, 1, 1000.00, 4);

/* FACTURAS cba4321 */
INSERT INTO Factura (id_factura, ci_cliente, ci_empleado, matricula, factura_paga, fecha) VALUES
(2, 43214321, 53459384, 'cba4321', '1', '2024-10-06 10:00:00'),
(16, 43214321, 53459384, 'cba4321', '1', '2024-10-08 09:00:00'),
(17, 43214321, 53459384, 'cba4321', '0', '2024-11-18 11:00:00');
INSERT INTO Parking (id_parking, hora_entrada, hora_salida, precio_parking) VALUES
(2, '2024-10-06 08:00:00', '2024-10-06 10:00:00', 50),
(16, '2024-10-08 08:00:00', '2024-10-08 09:00:00', 50),
(17, '2024-11-18 07:00:00', '2024-11-18 11:00:00', 50);
INSERT INTO Reserva (id_parking, id_plaza) VALUES
(2, 9),
(16, 8),
(17, 4);
INSERT INTO Solicita(id_factura, id_plaza, id_parking, precio_solicita) VALUES 
(2, 9, 2, 400.00),
(16, 8, 16, 500.00),
(17, 4, 17, 450.00);
/* USA-LAVADO */
INSERT INTO Usa(id_factura, id_lavado, precio_usa) VALUES
(2, 1, 200.00),
(16, 6, 0.00);
/* HACE-ALINEACION/BALANCEO */
INSERT INTO Hace(id_factura, id_ayb, precio_hace) VALUES
(16, 1, 200.00);

/* FACTURA */

INSERT INTO Factura (id_factura, ci_cliente, ci_empleado, matricula, factura_paga, fecha) VALUES
(3, 32132143, 53459384, 'fga1235', '0', '2024-10-06 09:00:00'),
(4, 54839454, 53459384, 'das7869', '0', '2024-10-06 15:45:00'),
(5, 38765432, 53459384, 'xyz5678', '0', '2024-10-06 11:22:00'),
(6, 57654321, 53459384, 'uvw8765', '0', '2024-10-06 13:30:00'),
(7, 26543210, 53459384, 'rst3456', '0', '2024-09-28 10:15:00'),
(8, 15432109, 53459384, 'opq2345', '0', '2024-09-18 16:00:00'),
(9, 34321098, 53459384, 'lmn6543', '0', '2024-09-25 14:50:00'),
(10, 43210987, 53459384, 'ijk9876', '0', '2024-09-29 12:10:00'),

-- (18, 32132143, 53459384, 'fga1235', '0', '2024-10-06 09:00:00'),
-- (19, 54839454, 53459384, 'das7869', '0', '2024-10-06 15:45:00'),
-- (20, 32132143, 53459384, 'fga1235', '0', '2024-10-06 09:00:00'),
-- (21, 54839454, 53459384, 'das7869', '0', '2024-10-06 15:45:00'),
(22, 86543210, 53459384, 'ijk4680', '0', '2024-10-06 11:22:00');

/* PARKING */
INSERT INTO Parking (id_parking, hora_entrada, hora_salida, precio_parking) VALUES
(3, '2024-11-18 11:00:00', '2024-11-18 13:30:00', 50),
(4, '2024-11-18 12:00:00', '2024-11-18 14:00:00', 120),
(5, '2024-11-18 13:00:00', '2024-11-18 15:15:00', 100),
(6, '2024-11-18 14:00:00', '2024-11-18 16:30:00', 125),
(7, '2024-11-18 15:00:00', '2024-11-18 17:00:00', 100),
(8, '2024-11-18 16:00:00', '2024-11-18 18:30:00', 50),
(9, '2024-11-18 17:00:00', '2024-11-18 19:00:00', 150),
(10, '2024-11-18 18:00:00', '2024-11-18 20:00:00', 120),

(22, '2024-11-18 18:00:00', '2024-11-18 20:00:00', 120);

/* RESERVA */
INSERT INTO Reserva (id_parking, id_plaza) VALUES
(3, 9),
(4, 21),
(5, 25),
(6, 30),
(7, 40),
(8, 43),
(9, 52),
(10, 53),

(22, 33);

/* SOLICITA */

INSERT INTO Solicita(id_factura, id_plaza, id_parking, precio_solicita) VALUES 
(3, 9, 3, 300.00),
(4, 21, 4, 100.00),
(5, 25, 5, 500.00),
(6, 30, 6, 300.00),
(7, 40, 7, 100.00),
(8, 43, 8, 200.00),
(9, 52, 9, 700.00),
(10, 53, 10, 900.00),

(22, 33, 22, 400.0);

/* TICKET */

INSERT INTO Ticket (id_ticket, matricula, ci, id_plaza, fecha_ticket) VALUES 
(1, 'abc1234', 56303446, 3, '2024-08-17 14:22:45'), 
(2, 'cba4321', 43214321, 6, '2024-08-18 10:34:12'), 
(3, 'fga1235', 32132143, 9, '2024-08-19 09:00:00'), 
(4, 'das7869', 54839454, 21, '2024-09-20 15:45:00'), 
(5, 'xyz5678', 38765432, 25, '2024-09-21 11:22:00'), 
(6, 'xyz5678', 38765432, 26, '2024-08-21 11:22:00'), 
(7, 'uvw8765', 57654321, 30, '2024-08-22 13:30:00'), 
(8, 'rst3456', 26543210, 40, '2024-08-23 10:15:00'), 
(10, 'opq2345', 15432109, 43, '2024-09-24 16:00:00'), 
(11, 'lmn6543', 34321098, 52, '2024-09-25 14:50:00'), 
(12, 'ijk9876', 43210987, 53, '2024-08-26 12:10:00');

/* USUARIOS DEL SISTEMA */

-- Borrar empleados si existen
DROP USER IF EXISTS 'ger'@'%';
DROP USER IF EXISTS 'jefe'@'%';
DROP USER IF EXISTS 'eje'@'%';
DROP USER IF EXISTS 'caj'@'%';
DROP USER IF EXISTS 'ope'@'%';

/* ----- USUARIOS ----- */

CREATE USER 'ger'@'%' IDENTIFIED BY '123';
CREATE USER 'jefe'@'%' IDENTIFIED BY '123';
CREATE USER 'eje'@'%' IDENTIFIED BY '123';
CREATE USER 'caj'@'%' IDENTIFIED BY '123';
CREATE USER 'ope'@'%' IDENTIFIED BY '123';

-- Doy permiso a los usuarios segun lo necesiten

-- Gerente
GRANT ALL PRIVILEGES ON ProyectoBD.* TO 'ger'@'%';

-- Jefe de servicios
GRANT SELECT, INSERT, UPDATE ON Persona TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE, DELETE ON Telefono TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Cliente TO 'jefe'@'%';
GRANT SELECT ON Rol TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Empleado TO 'jefe'@'%';
GRANT SELECT ON Marca TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Vehiculo TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Tipo_Vehiculo TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Posee TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Ticket TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Factura TO 'jefe'@'%';
GRANT SELECT, UPDATE ON Neumatico TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Compra TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Parking TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Plaza TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Reserva TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Solicita TO 'jefe'@'%';
GRANT SELECT ON Lavado TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Usa TO 'jefe'@'%';
GRANT SELECT ON Alineacion_Balanceo TO 'jefe'@'%';
GRANT SELECT, INSERT, UPDATE ON Hace TO 'jefe'@'%';

-- Ejecutivo de servicios
GRANT SELECT, INSERT, UPDATE ON Persona TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE, DELETE ON Telefono TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Cliente TO 'eje'@'%';
GRANT SELECT ON Rol TO 'eje'@'%';
GRANT SELECT ON Empleado TO 'eje'@'%';
GRANT SELECT ON Marca TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Vehiculo TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Tipo_Vehiculo TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Posee TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Ticket TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Factura TO 'eje'@'%';
GRANT SELECT, UPDATE ON Neumatico TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Compra TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Parking TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Plaza TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Reserva TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Solicita TO 'eje'@'%';
GRANT SELECT ON Lavado TO 'eje'@'%';
GRANT SELECT ON Usa TO 'eje'@'%';
GRANT SELECT ON Alineacion_Balanceo TO 'eje'@'%';
GRANT SELECT, INSERT, UPDATE ON Hace TO 'eje'@'%';

-- Cajero

GRANT SELECT ON Persona TO 'caj'@'%';
GRANT SELECT ON Cliente TO 'caj'@'%';
GRANT SELECT ON Rol TO 'caj'@'%';
GRANT SELECT ON Empleado TO 'caj'@'%';
GRANT SELECT ON Marca TO 'caj'@'%';
GRANT SELECT ON Vehiculo TO 'caj'@'%';
GRANT SELECT ON Tipo_Vehiculo TO 'caj'@'%';
GRANT SELECT ON Posee TO 'caj'@'%';
GRANT SELECT, UPDATE ON Factura TO 'caj'@'%';
GRANT SELECT ON Neumatico TO 'caj'@'%';
GRANT SELECT ON Compra TO 'caj'@'%';
GRANT SELECT ON Parking TO 'caj'@'%';
GRANT SELECT ON Plaza TO 'caj'@'%';
GRANT SELECT ON Reserva TO 'caj'@'%';
GRANT SELECT ON Solicita TO 'caj'@'%';
GRANT SELECT ON Lavado TO 'caj'@'%';
GRANT SELECT ON Usa TO 'caj'@'%';
GRANT SELECT ON Alineacion_Balanceo TO 'caj'@'%';
GRANT SELECT ON Hace TO 'caj'@'%';

-- Operador de cámaras y respaldo
GRANT SELECT ON Persona TO 'ope'@'%';
GRANT SELECT ON Cliente TO 'ope'@'%';
GRANT SELECT ON Rol TO 'ope'@'%';
GRANT SELECT ON Empleado TO 'ope'@'%';
GRANT SELECT ON Marca TO 'ope'@'%';
GRANT SELECT ON Vehiculo TO 'ope'@'%';
GRANT SELECT ON Factura TO 'ope'@'%';
GRANT SELECT ON Solicita TO 'ope'@'%';
GRANT SELECT ON Reserva TO 'ope'@'%';
GRANT SELECT ON Parking TO 'ope'@'%';
GRANT SELECT ON Tipo_Vehiculo TO 'ope'@'%';
GRANT SELECT ON Posee TO 'ope'@'%';
GRANT SELECT, UPDATE ON Plaza TO 'ope'@'%';
GRANT SELECT, INSERT ON Ticket TO 'ope'@'%';

FLUSH PRIVILEGES;

/*
-- CONSULTAS SQL 
-- CONSULTA 1
SELECT id_factura, ci, matricula, factura_paga, fecha 
FROM Factura
WHERE fecha >= DATE_SUB(NOW(), INTERVAL 1 MONTH);

-- CONSULTA 2 -- COALESCA devuelve 0 si no encuentra
SELECT f.ci, 
       SUM(COALESCE(s.precio_solicita, 0) + 
           COALESCE(c.precio_compra * c.cantidad_compra, 0) + 
           COALESCE(h.precio_hace, 0) + 
           COALESCE(u.precio_usa, 0)) AS total_gastado
 FROM Factura f
 LEFT JOIN Solicita s ON s.id_factura = f.id_factura
 LEFT JOIN Compra c ON c.id_factura = f.id_factura
 LEFT JOIN Hace h ON h.id_factura = f.id_factura
 LEFT JOIN Usa u ON u.id_factura = f.id_factura
 WHERE f.fecha >= DATE_SUB(NOW(), INTERVAL 1 MONTH)
 GROUP BY f.ci
 ORDER BY total_gastado DESC
 LIMIT 5;

-- CONSULTA 3
SELECT f.matricula, COUNT(u.id_factura) AS total_lavados
FROM Factura f
JOIN Usa u ON f.id_factura = u.id_factura
WHERE f.fecha >= DATE_SUB(NOW(), INTERVAL 1 YEAR)
GROUP BY f.matricula
ORDER BY total_lavados DESC
LIMIT 5;

-- CONSULTA 4
SELECT s.id_plaza, COUNT(s.id_plaza) AS total_usos
FROM Solicita s
GROUP BY s.id_plaza
ORDER BY total_usos DESC
LIMIT 1;

-- CONSULTA 5
SELECT 'Lavado' AS servicio, nombre_lavado AS nombre, precio_lavado AS precio
FROM Lavado
UNION ALL
SELECT 'Alineación y Balanceo' AS servicio, nombre_ayb AS nombre, precio_ayb AS precio
FROM Alineacion_Balanceo
UNION ALL
SELECT 'Neumático' AS servicio, CONCAT(nombre_neumatico, ' - ', marca_neumatico) AS nombre, precio_neumatico AS precio
FROM Neumatico;

-- CONSULTA 6
SELECT nombre_neumatico, marca_neumatico, stock_neumatico
FROM Neumatico
WHERE estado_neumatico = 1
ORDER BY marca_neumatico DESC;
*/