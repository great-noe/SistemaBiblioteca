-- ═══════════════════════════════════════════════════════════════════════════════
-- DATOS DE PRUEBA - SISTEMA BIBLIOTECA v7
-- ═══════════════════════════════════════════════════════════════════════════════
-- Descripción: Inserta datos de prueba para testing
-- Ejecutar DESPUÉS de 01_CREAR_BD_COMPLETA_v7.sql
-- ═══════════════════════════════════════════════════════════════════════════════

USE bibliotecadb;

-- ═══════════════════════════════════════════════════════════════════════════════
-- 1. INSERTAR CATEGORÍAS
-- ═══════════════════════════════════════════════════════════════════════════════

INSERT INTO categorias (Nombre, Descripcion) VALUES
('Ficción', 'Novelas y cuentos de ficción'),
('Ciencia Ficción', 'Literatura de ciencia ficción y fantasía'),
('Historia', 'Libros de historia y biografías'),
('Tecnología', 'Libros de programación y tecnología'),
('Filosofía', 'Obras filosóficas y pensamiento'),
('Literatura Clásica', 'Obras clásicas de la literatura universal'),
('Infantil', 'Literatura infantil y juvenil'),
('Autoayuda', 'Libros de desarrollo personal');

-- ═══════════════════════════════════════════════════════════════════════════════
-- 2. INSERTAR AUTORES
-- ═══════════════════════════════════════════════════════════════════════════════

INSERT INTO autores (Nombre, Apellido, Nacionalidad, FechaNacimiento) VALUES
('Gabriel', 'García Márquez', 'Colombiano', '1927-03-06'),
('Jorge', 'Luis Borges', 'Argentino', '1899-08-24'),
('Isabel', 'Allende', 'Chilena', '1942-08-02'),
('Mario', 'Vargas Llosa', 'Peruano', '1936-03-28'),
('Julio', 'Cortázar', 'Argentino', '1914-08-26'),
('Miguel', 'de Cervantes', 'Español', '1547-09-29'),
('Pablo', 'Neruda', 'Chileno', '1904-07-12'),
('Octavio', 'Paz', 'Mexicano', '1914-03-31'),
('Carlos', 'Fuentes', 'Mexicano', '1928-11-11'),
('Ernesto', 'Sabato', 'Argentino', '1911-06-24');

-- ═══════════════════════════════════════════════════════════════════════════════
-- 3. INSERTAR LIBROS (con EstadoFisico v7)
-- ═══════════════════════════════════════════════════════════════════════════════

INSERT INTO libros (ISBN, Titulo, IdCategoria, Editorial, AñoPublicacion, NumeroPaginas, CantidadTotal, CantidadDisponible, EstadoFisico) VALUES
('978-0307474728', 'Cien años de soledad', 1, 'Editorial Sudamericana', 1967, 471, 5, 5, 'Excelente'),
('978-0525433354', 'El amor en los tiempos del cólera', 1, 'Penguin Books', 1985, 368, 3, 3, 'Excelente'),
('978-8497592581', 'Ficciones', 1, 'Alianza Editorial', 1944, 174, 4, 4, 'Bueno'),
('978-0060883287', 'La casa de los espíritus', 1, 'Plaza & Janés', 1982, 433, 3, 3, 'Excelente'),
('978-8420471839', 'Rayuela', 1, 'Alfaguara', 1963, 600, 2, 2, 'Regular'),
('978-8437604947', 'Don Quijote de la Mancha', 6, 'Cátedra', 1605, 863, 4, 4, 'Bueno'),
('978-0307475466', 'El laberinto de la soledad', 5, 'Fondo de Cultura Económica', 1950, 191, 2, 2, 'Excelente'),
('978-8437613482', 'Veinte poemas de amor y una canción desesperada', 6, 'Cátedra', 1924, 120, 5, 5, 'Excelente'),
('978-0374529659', 'La ciudad y los perros', 1, 'Alfaguara', 1963, 405, 3, 3, 'Bueno'),
('978-8432217326', 'El túnel', 1, 'Booket', 1948, 142, 4, 4, 'Excelente');

-- ═══════════════════════════════════════════════════════════════════════════════
-- 4. INSERTAR RELACIÓN LIBRO-AUTOR
-- ═══════════════════════════════════════════════════════════════════════════════

INSERT INTO libro_autor (IdLibro, IdAutor) VALUES
(1, 1),  -- Cien años de soledad - García Márquez
(2, 1),  -- El amor en los tiempos del cólera - García Márquez
(3, 2),  -- Ficciones - Borges
(4, 3),  -- La casa de los espíritus - Isabel Allende
(5, 5),  -- Rayuela - Cortázar
(6, 6),  -- Don Quijote - Cervantes
(7, 8),  -- El laberinto de la soledad - Octavio Paz
(8, 7),  -- Veinte poemas - Neruda
(9, 4),  -- La ciudad y los perros - Vargas Llosa
(10, 10); -- El túnel - Sabato

-- ═══════════════════════════════════════════════════════════════════════════════
-- 5. INSERTAR USUARIOS
-- ═══════════════════════════════════════════════════════════════════════════════

INSERT INTO usuarios (NumeroIdentificacion, Nombre, Apellido, Email, Telefono, TipoUsuario, FechaNacimiento) VALUES
('12345678', 'Juan', 'Pérez', 'juan.perez@email.com', '555-0001', 'Socio', '1990-05-15'),
('23456789', 'María', 'González', 'maria.gonzalez@email.com', '555-0002', 'Socio', '1985-08-22'),
('34567890', 'Carlos', 'Rodríguez', 'carlos.rodriguez@email.com', '555-0003', 'Socio', '1992-03-10'),
('45678901', 'Ana', 'Martínez', 'ana.martinez@email.com', '555-0004', 'Estudiante', '2000-11-05'),
('56789012', 'Luis', 'Fernández', 'luis.fernandez@email.com', '555-0005', 'Socio', '1988-07-18'),
('67890123', 'Carmen', 'López', 'carmen.lopez@email.com', '555-0006', 'Estudiante', '2001-02-28'),
('78901234', 'Roberto', 'Sánchez', 'roberto.sanchez@email.com', '555-0007', 'Socio', '1995-09-12'),
('89012345', 'Laura', 'Torres', 'laura.torres@email.com', '555-0008', 'Estudiante', '1999-04-20');

-- ═══════════════════════════════════════════════════════════════════════════════
-- 6. INSERTAR PRÉSTAMOS DE PRUEBA (con campos v7)
-- ═══════════════════════════════════════════════════════════════════════════════

-- Préstamos activos
INSERT INTO prestamos (IdUsuario, IdLibro, FechaPrestamo, FechaDevolucionEstimada, EstadoPrestamo, NotificacionEnviada) VALUES
(1, 1, '2026-01-15 10:00:00', '2026-01-29 10:00:00', 'Activo', 0),
(2, 3, '2026-01-18 14:30:00', '2026-02-01 14:30:00', 'Activo', 0),
(3, 5, '2026-01-20 09:15:00', '2026-02-03 09:15:00', 'Activo', 0);

-- Préstamos devueltos (ejemplos con diferentes estados)
INSERT INTO prestamos (IdUsuario, IdLibro, FechaPrestamo, FechaDevolucionEstimada, FechaDevolucionReal, EstadoPrestamo, DiasRetraso, MontoMulta, NotificacionEnviada, EstadoLibroDevuelto, ObservacionesEstado) VALUES
(4, 2, '2026-01-05 11:00:00', '2026-01-19 11:00:00', '2026-01-19 15:30:00', 'Devuelto', 0, 0.00, 1, 'Bueno', NULL),
(5, 4, '2026-01-08 16:00:00', '2026-01-22 16:00:00', '2026-01-25 10:00:00', 'Devuelto', 3, 3.00, 1, 'Bueno', NULL),
(6, 6, '2026-01-10 13:00:00', '2026-01-24 13:00:00', '2026-01-24 17:00:00', 'Devuelto', 0, 2.00, 1, 'Regular', 'Páginas con esquinas dobladas'),
(7, 8, '2025-12-20 10:00:00', '2026-01-03 10:00:00', '2026-01-10 14:00:00', 'Devuelto', 7, 12.00, 1, 'Dañado', 'Portada rayada, algunas páginas manchadas');

-- Actualizar stock de libros prestados
UPDATE libros SET CantidadDisponible = CantidadDisponible - 1 WHERE IdLibro IN (1, 3, 5);

-- ═══════════════════════════════════════════════════════════════════════════════
-- 7. INSERTAR RESERVAS DE PRUEBA
-- ═══════════════════════════════════════════════════════════════════════════════

INSERT INTO reservas (IdUsuario, IdLibro, FechaReserva, FechaExpiracion, EstadoReserva) VALUES
(8, 1, '2026-01-21 09:00:00', '2026-01-26 09:00:00', 'Pendiente'),
(4, 3, '2026-01-21 10:30:00', '2026-01-26 10:30:00', 'Pendiente');

-- ═══════════════════════════════════════════════════════════════════════════════
-- VERIFICACIÓN DE DATOS
-- ═══════════════════════════════════════════════════════════════════════════════

SELECT '═══════════════════════════════════════════════════════════════════' AS '';
SELECT '✅ DATOS DE PRUEBA INSERTADOS EXITOSAMENTE' AS RESULTADO;
SELECT '═══════════════════════════════════════════════════════════════════' AS '';

-- Resumen de datos insertados
SELECT 'RESUMEN DE DATOS INSERTADOS:' AS '';
SELECT CONCAT('Categorías: ', COUNT(*)) AS Total FROM categorias;
SELECT CONCAT('Autores: ', COUNT(*)) AS Total FROM autores;
SELECT CONCAT('Libros: ', COUNT(*)) AS Total FROM libros;
SELECT CONCAT('Usuarios: ', COUNT(*)) AS Total FROM usuarios;
SELECT CONCAT('Préstamos: ', COUNT(*)) AS Total FROM prestamos;
SELECT CONCAT('Reservas: ', COUNT(*)) AS Total FROM reservas;

-- Ver préstamos con campos v7
SELECT '═══════════════════════════════════════════════════════════════════' AS '';
SELECT 'PRÉSTAMOS CON CAMPOS v7:' AS '';
SELECT 
    IdPrestamo,
    IdUsuario,
    IdLibro,
    EstadoPrestamo,
    NotificacionEnviada,
    EstadoLibroDevuelto,
    SUBSTRING(ObservacionesEstado, 1, 30) AS Observaciones
FROM prestamos;

-- Ver libros con estado físico v7
SELECT '═══════════════════════════════════════════════════════════════════' AS '';
SELECT 'LIBROS CON ESTADO FÍSICO v7:' AS '';
SELECT 
    IdLibro,
    Titulo,
    CantidadTotal,
    CantidadDisponible,
    EstadoFisico
FROM libros;

-- ═══════════════════════════════════════════════════════════════════════════════
-- FIN DEL SCRIPT
-- ═══════════════════════════════════════════════════════════════════════════════
