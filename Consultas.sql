SELECT p.ci, p.matricula, m.nombre_marca, t.nombre_tipo
FROM Posee p
JOIN Vehiculo v ON p.matricula = v.matricula
JOIN Marca m ON v.id_marca = m.id_marca
JOIN Tipo_Vehiculo t ON t.id_tipo = v.id_tipo
WHERE p.ci = 56303446 AND p.matricula = 'abc1234';

SELECT * FROM ticket ORDER BY fecha_ticket DESC;

SELECT p.ci, p.matricula, f.id_factura
FROM Posee p
JOIN Factura f ON f.matricula = p.matricula AND f.ci = p.ci
WHERE p.ci = 56303446 AND p.matricula = 'abc1234' AND f.factura_paga = '0';

SELECT ayb.nombre_ayb, h.precio_hace
FROM Alineacion_Balanceo ayb
JOIN Hace h ON ayb.id_ayb = h.id_ayb
JOIN Factura f ON f.id_factura = h.id_factura
WHERE f.factura_paga = '0';

SELECT l.nombre_lavado, u.precio_usa
FROM Lavado l
JOIN Usa u ON l.id_lavado = u.id_lavado
JOIN Factura f ON f.id_factura = u.id_factura
WHERE f.factura_paga = '0' AND f.matricula = 'cba4321';

SELECT n.nombre_neumatico, c.precio_compra, c.cantidad_compra
FROM Neumatico n
JOIN Compra c ON n.id_neumatico = c.id_neumatico
JOIN Factura f ON f.id_factura = c.id_factura
WHERE f.factura_paga = '0' AND f.matricula = 'abc1234';

SELECT p.hora_entrada, p.hora_salida, s.precio_solicita
FROM Parking p
JOIN Reserva r ON r.id_parking = p.id_parking
JOIN Solicita s ON s.id_parking = r.id_parking
JOIN Factura f ON f.id_factura = s.id_factura
WHERE f.factura_paga = '0' AND f.matricula = 'abc1234';

SELECT matricula, ci, id_plaza, fecha_ticket 
FROM ticket
WHERE id_ticket = 2;

SELECT f.factura_paga
FROM Factura f
JOIN Solicita s ON f.id_factura = s.id_factura
WHERE f.factura_paga = '0' AND f.matricula = 'abc1234';

SELECT * FROM factura;

SELECT f.id_factura
FROM Factura f
LEFT JOIN Solicita s ON f.id_factura = s.id_factura
WHERE f.factura_paga = '0' 
 AND f.matricula = 'abc1234'
 AND s.id_parking IS NULL;

UPDATE Factura
SET factura_paga = '1'
WHERE ci = 56303446 and id_factura = 1;

SELECT id_factura, ci, matricula, factura_paga, fecha
FROM factura
WHERE factura_paga = '1'
ORDER BY fecha DESC
LIMIT 10;

SELECT par.hora_entrada, par.hora_salida, r.id_plaza
FROM Parking par
JOIN Reserva r ON r.id_parking = par.id_parking
JOIN Solicita s ON s.id_parking = par.id_parking
JOIN Factura f ON f.id_factura = s.id_factura
WHERE f.id_factura = 2;

SELECT l.nombre_lavado
FROM Lavado l
JOIN Usa u ON u.id_lavado = l.id_lavado
JOIN Factura f ON f.id_factura = u.id_factura
WHERE f.id_factura = 2;

SELECT ayb.nombre_ayb
FROM Alineacion_Balanceo ayb
JOIN Hace h ON h.id_ayb = ayb.id_ayb
JOIN Factura f ON f.id_factura = h.id_factura
WHERE f.id_factura = 2;

SELECT n.nombre_neumatico, c.cantidad_compra
FROM Neumatico n
JOIN Compra c ON n.id_neumatico = c.id_neumatico
JOIN Factura f ON f.id_factura = c.id_factura
WHERE f.id_factura = 1;

SELECT p.nombre, c.tipo_cliente, v.id_tipo
FROM Persona p
JOIN Cliente c ON c.ci = p.ci
JOIN Posee po ON po.ci = c.ci
JOIN Vehiculo v ON v.matricula = po.matricula
WHERE c.ci=56303446 AND v.matricula = 'abc1234';

SELECT f.id_factura
FROM factura f
left JOIN compra c ON c.id_factura = f.id_factura
WHERE matricula = 'abc1234' AND factura_paga = 0 and c.id_neumatico is null;

update Neumatico
set stock = 20
where id_neumatico = 1;

select * from vehiculo;

select id_neumatico, nombre_neumatico, marca_neumatico, precio_neumatico, stock_neumatico
from neumatico
where id_neumatico = 2;

SELECT v.id_tipo, COUNT(*) AS Cantidad
FROM Vehiculo v
JOIN Factura f ON v.matricula = f.matricula
JOIN Solicita s ON f.id_factura = s.id_factura
JOIN Parking p ON s.id_parking = p.id_parking
JOIN Reserva r ON p.id_parking = r.id_parking
JOIN Plaza pla ON r.id_plaza = pla.id_plaza
WHERE p.hora_salida > NOW();

SELECT id_lavado, nombre_lavado, precio_lavado
FROM Lavado
WHERE id_lavado = 1;

select * from Lavado;

SELECT f.id_factura, f.ci_cliente, f.ci_empleado, f.matricula, f.fecha,
       par.hora_entrada, par.hora_salida, r.id_plaza,
       l.nombre_lavado,
       ayb.nombre_ayb,
       n.nombre_neumatico, c.cantidad_compra
FROM Factura f
LEFT JOIN Solicita s ON f.id_factura = s.id_factura
LEFT JOIN Parking par ON s.id_parking = par.id_parking
LEFT JOIN Reserva r ON r.id_parking = par.id_parking
LEFT JOIN Usa u ON u.id_factura = f.id_factura
LEFT JOIN Lavado l ON u.id_lavado = l.id_lavado
LEFT JOIN Hace h ON h.id_factura = f.id_factura
LEFT JOIN Alineacion_Balanceo ayb ON h.id_ayb = ayb.id_ayb
LEFT JOIN Compra c ON c.id_factura = f.id_factura
LEFT JOIN Neumatico n ON n.id_neumatico = c.id_neumatico
order by f.id_factura;

SELECT u.id_factura, f.fecha
FROM Usa u
JOIN Factura f ON u.id_factura = f.id_factura
WHERE u.id_lavado = 6 
    AND f.ci_cliente = 56303446
    AND f.fecha >= DATE_SUB(NOW(), INTERVAL 1 MONTH);

SELECT f.fecha, pla.id_plaza
FROM Factura f
JOIN Solicita s ON f.id_factura = s.id_factura
JOIN Parking p ON p.id_parking = s.id_parking
JOIN Reserva r ON r.id_parking = s.id_parking
JOIN Plaza pla ON pla.id_plaza = r.id_plaza
WHERE f.matricula = 'abc1234'
AND f.factura_paga = '0';

select * from Hace;

SELECT v.id_tipo, COUNT(*) AS Cantidad
FROM Vehiculo v
JOIN Factura f ON v.matricula = f.matricula
JOIN Solicita s ON f.id_factura = s.id_factura
JOIN Parking p ON s.id_parking = p.id_parking
JOIN Reserva r ON p.id_parking = r.id_parking
JOIN Plaza pla ON r.id_plaza = pla.id_plaza
WHERE f.factura_paga = '0' AND p.hora_salida > NOW()
GROUP BY v.id_tipo;

select * from Parking;

SELECT p.nombre, c.tipo_cliente, v.id_tipo
FROM Persona p
JOIN Cliente c ON c.ci = p.ci
JOIN Posee po ON po.ci = c.ci
JOIN Vehiculo v ON v.matricula = po.matricula
WHERE c.ci=32132141 AND v.matricula = 'gfd1234';