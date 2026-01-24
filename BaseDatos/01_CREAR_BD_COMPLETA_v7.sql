-- ═══════════════════════════════════════════════════════════════════════════════
-- SCRIPT COMPLETO BASE DE DATOS - SISTEMA BIBLIOTECA v7
-- ═══════════════════════════════════════════════════════════════════════════════
-- Fecha: 21 de Enero 2026
-- Versión: 7.0
-- Motor: MySQL 5.7+
-- Descripción: Crea base de datos completa con todas las actualizaciones v7
-- ═══════════════════════════════════════════════════════════════════════════════

-- ═══════════════════════════════════════════════════════════════════════════════
-- 1. CREAR Y SELECCIONAR BASE DE DATOS
-- ═══════════════════════════════════════════════════════════════════════════════

DROP DATABASE IF EXISTS bibliotecadb;
CREATE DATABASE bibliotecadb CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE bibliotecadb;

-- ═══════════════════════════════════════════════════════════════════════════════
-- 2. CREAR TABLA CATEGORIAS
-- ═══════════════════════════════════════════════════════════════════════════════

CREATE TABLE categorias (
    IdCategoria INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL UNIQUE,
    Descripcion VARCHAR(500),
    Activo TINYINT(1) DEFAULT 1 NOT NULL,
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ═══════════════════════════════════════════════════════════════════════════════
-- 3. CREAR TABLA AUTORES
-- ═══════════════════════════════════════════════════════════════════════════════

CREATE TABLE autores (
    IdAutor INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Nacionalidad VARCHAR(50),
    FechaNacimiento DATE,
    Biografia TEXT,
    Activo TINYINT(1) DEFAULT 1 NOT NULL,
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ═══════════════════════════════════════════════════════════════════════════════
-- 4. CREAR TABLA LIBROS (CON CAMPO EstadoFisico - NUEVO EN v7)
-- ═══════════════════════════════════════════════════════════════════════════════

CREATE TABLE libros (
    IdLibro INT AUTO_INCREMENT PRIMARY KEY,
    ISBN VARCHAR(20) UNIQUE,
    Titulo VARCHAR(200) NOT NULL,
    IdCategoria INT,
    Editorial VARCHAR(100),
    AñoPublicacion INT,
    NumeroPaginas INT,
    Idioma VARCHAR(50) DEFAULT 'Español',
    CantidadTotal INT DEFAULT 1 NOT NULL,
    CantidadDisponible INT DEFAULT 1 NOT NULL,
    Ubicacion VARCHAR(50),
    Activo TINYINT(1) DEFAULT 1 NOT NULL,
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP,
    -- ✅ NUEVO EN v7: Estado físico del libro
    EstadoFisico VARCHAR(20) DEFAULT 'Excelente' NOT NULL,
    FOREIGN KEY (IdCategoria) REFERENCES categorias(IdCategoria)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ═══════════════════════════════════════════════════════════════════════════════
-- 5. CREAR TABLA LIBRO_AUTOR (Relación muchos a muchos)
-- ═══════════════════════════════════════════════════════════════════════════════

CREATE TABLE libro_autor (
    IdLibroAutor INT AUTO_INCREMENT PRIMARY KEY,
    IdLibro INT NOT NULL,
    IdAutor INT NOT NULL,
    FOREIGN KEY (IdLibro) REFERENCES libros(IdLibro) ON DELETE CASCADE,
    FOREIGN KEY (IdAutor) REFERENCES autores(IdAutor) ON DELETE CASCADE,
    UNIQUE KEY unique_libro_autor (IdLibro, IdAutor)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ═══════════════════════════════════════════════════════════════════════════════
-- 6. CREAR TABLA USUARIOS
-- ═══════════════════════════════════════════════════════════════════════════════

CREATE TABLE usuarios (
    IdUsuario INT AUTO_INCREMENT PRIMARY KEY,
    NumeroIdentificacion VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    Telefono VARCHAR(20),
    Direccion VARCHAR(200),
    FechaNacimiento DATE,
    TipoUsuario VARCHAR(50) DEFAULT 'Socio' NOT NULL,
    MultasPendientes DECIMAL(10,2) DEFAULT 0.00,
    Suspendido TINYINT(1) DEFAULT 0 NOT NULL,
    FechaFinSuspension DATE,
    Activo TINYINT(1) DEFAULT 1 NOT NULL,
    FechaRegistro DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ═══════════════════════════════════════════════════════════════════════════════
-- 7. CREAR TABLA PRESTAMOS (CON CAMPOS NUEVOS v7)
-- ═══════════════════════════════════════════════════════════════════════════════

CREATE TABLE prestamos (
    IdPrestamo INT AUTO_INCREMENT PRIMARY KEY,
    IdUsuario INT NOT NULL,
    IdLibro INT NOT NULL,
    FechaPrestamo DATETIME DEFAULT CURRENT_TIMESTAMP,
    FechaDevolucionEstimada DATETIME NOT NULL,
    FechaDevolucionReal DATETIME,
    EstadoPrestamo VARCHAR(20) DEFAULT 'Activo' NOT NULL,
    DiasRetraso INT DEFAULT 0,
    MontoMulta DECIMAL(10,2) DEFAULT 0.00,
    MultaPagada TINYINT(1) DEFAULT 0,
    Observaciones VARCHAR(500),
    -- ✅ NUEVOS CAMPOS v7: Notificaciones y Estado del Libro
    NotificacionEnviada TINYINT(1) DEFAULT 0 NOT NULL,
    EstadoLibroDevuelto VARCHAR(20),
    ObservacionesEstado VARCHAR(500),
    FOREIGN KEY (IdUsuario) REFERENCES usuarios(IdUsuario),
    FOREIGN KEY (IdLibro) REFERENCES libros(IdLibro)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ═══════════════════════════════════════════════════════════════════════════════
-- 8. CREAR TABLA HISTORIAL_PRESTAMO
-- ═══════════════════════════════════════════════════════════════════════════════

CREATE TABLE historial_prestamo (
    IdHistorial INT AUTO_INCREMENT PRIMARY KEY,
    IdPrestamo INT NOT NULL,
    IdUsuario INT NOT NULL,
    IdLibro INT NOT NULL,
    Accion VARCHAR(50) NOT NULL,
    FechaAccion DATETIME DEFAULT CURRENT_TIMESTAMP,
    UsuarioAccion VARCHAR(100),
    Observaciones VARCHAR(500),
    FOREIGN KEY (IdPrestamo) REFERENCES prestamos(IdPrestamo),
    FOREIGN KEY (IdUsuario) REFERENCES usuarios(IdUsuario),
    FOREIGN KEY (IdLibro) REFERENCES libros(IdLibro)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ═══════════════════════════════════════════════════════════════════════════════
-- 9. CREAR TABLA RESERVAS
-- ═══════════════════════════════════════════════════════════════════════════════

CREATE TABLE reservas (
    IdReserva INT AUTO_INCREMENT PRIMARY KEY,
    IdUsuario INT NOT NULL,
    IdLibro INT NOT NULL,
    FechaReserva DATETIME DEFAULT CURRENT_TIMESTAMP,
    FechaExpiracion DATETIME NOT NULL,
    EstadoReserva VARCHAR(20) DEFAULT 'Pendiente' NOT NULL,
    Observaciones VARCHAR(500),
    FOREIGN KEY (IdUsuario) REFERENCES usuarios(IdUsuario),
    FOREIGN KEY (IdLibro) REFERENCES libros(IdLibro)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ═══════════════════════════════════════════════════════════════════════════════
-- 10. CREAR TABLA MULTAS
-- ═══════════════════════════════════════════════════════════════════════════════

CREATE TABLE multas (
    IdMulta INT AUTO_INCREMENT PRIMARY KEY,
    IdUsuario INT NOT NULL,
    IdPrestamo INT,
    TipoMulta VARCHAR(50) NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    FechaGeneracion DATETIME DEFAULT CURRENT_TIMESTAMP,
    FechaPago DATETIME,
    EstadoMulta VARCHAR(20) DEFAULT 'Pendiente' NOT NULL,
    Descripcion VARCHAR(500),
    FOREIGN KEY (IdUsuario) REFERENCES usuarios(IdUsuario),
    FOREIGN KEY (IdPrestamo) REFERENCES prestamos(IdPrestamo)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ═══════════════════════════════════════════════════════════════════════════════
-- 11. CREAR ÍNDICES PARA MEJORAR RENDIMIENTO
-- ═══════════════════════════════════════════════════════════════════════════════

-- Índices en libros
CREATE INDEX idx_libro_isbn ON libros(ISBN);
CREATE INDEX idx_libro_titulo ON libros(Titulo);
CREATE INDEX idx_libro_categoria ON libros(IdCategoria);
CREATE INDEX idx_libro_activo ON libros(Activo);
CREATE INDEX idx_libro_estado_fisico ON libros(EstadoFisico);

-- Índices en usuarios
CREATE INDEX idx_usuario_identificacion ON usuarios(NumeroIdentificacion);
CREATE INDEX idx_usuario_email ON usuarios(Email);
CREATE INDEX idx_usuario_activo ON usuarios(Activo);
CREATE INDEX idx_usuario_suspendido ON usuarios(Suspendido);

-- Índices en préstamos
CREATE INDEX idx_prestamo_usuario ON prestamos(IdUsuario);
CREATE INDEX idx_prestamo_libro ON prestamos(IdLibro);
CREATE INDEX idx_prestamo_estado ON prestamos(EstadoPrestamo);
CREATE INDEX idx_prestamo_fecha ON prestamos(FechaPrestamo);
CREATE INDEX idx_prestamo_notificacion ON prestamos(NotificacionEnviada);

-- Índices en reservas
CREATE INDEX idx_reserva_usuario ON reservas(IdUsuario);
CREATE INDEX idx_reserva_libro ON reservas(IdLibro);
CREATE INDEX idx_reserva_estado ON reservas(EstadoReserva);

-- ═══════════════════════════════════════════════════════════════════════════════
-- 12. CREAR VISTAS ÚTILES
-- ═══════════════════════════════════════════════════════════════════════════════

-- Vista de préstamos activos
CREATE VIEW vista_prestamos_activos AS
SELECT 
    p.IdPrestamo,
    p.FechaPrestamo,
    p.FechaDevolucionEstimada,
    p.DiasRetraso,
    p.MontoMulta,
    p.NotificacionEnviada,
    u.IdUsuario,
    CONCAT(u.Nombre, ' ', u.Apellido) AS NombreUsuario,
    u.Email,
    u.Telefono,
    l.IdLibro,
    l.Titulo AS TituloLibro,
    l.ISBN,
    l.EstadoFisico
FROM prestamos p
INNER JOIN usuarios u ON p.IdUsuario = u.IdUsuario
INNER JOIN libros l ON p.IdLibro = l.IdLibro
WHERE p.EstadoPrestamo = 'Activo';

-- Vista de libros con disponibilidad
CREATE VIEW vista_libros_disponibles AS
SELECT 
    l.IdLibro,
    l.ISBN,
    l.Titulo,
    l.Editorial,
    l.AñoPublicacion,
    l.CantidadTotal,
    l.CantidadDisponible,
    l.EstadoFisico,
    c.Nombre AS Categoria,
    GROUP_CONCAT(CONCAT(a.Nombre, ' ', a.Apellido) SEPARATOR ', ') AS Autores
FROM libros l
LEFT JOIN categorias c ON l.IdCategoria = c.IdCategoria
LEFT JOIN libro_autor la ON l.IdLibro = la.IdLibro
LEFT JOIN autores a ON la.IdAutor = a.IdAutor
WHERE l.Activo = 1
GROUP BY l.IdLibro;

-- ═══════════════════════════════════════════════════════════════════════════════
-- VERIFICACIÓN FINAL
-- ═══════════════════════════════════════════════════════════════════════════════

SELECT '═══════════════════════════════════════════════════════════════════' AS '';
SELECT '✅ BASE DE DATOS CREADA EXITOSAMENTE - VERSIÓN 7.0' AS RESULTADO;
SELECT '═══════════════════════════════════════════════════════════════════' AS '';

-- Mostrar tablas creadas
SHOW TABLES;

-- Mostrar estructura de tabla prestamos (con campos v7)
SELECT '═══════════════════════════════════════════════════════════════════' AS '';
SELECT 'ESTRUCTURA TABLA PRESTAMOS (con campos v7):' AS '';
DESCRIBE prestamos;

-- Mostrar estructura de tabla libros (con campo EstadoFisico v7)
SELECT '═══════════════════════════════════════════════════════════════════' AS '';
SELECT 'ESTRUCTURA TABLA LIBROS (con EstadoFisico v7):' AS '';
DESCRIBE libros;

-- ═══════════════════════════════════════════════════════════════════════════════
-- NOTAS IMPORTANTES v7
-- ═══════════════════════════════════════════════════════════════════════════════
--
-- NUEVOS CAMPOS v7:
-- 
-- 1. TABLA PRESTAMOS:
--    - NotificacionEnviada (TINYINT): Marca si se notificó al usuario
--    - EstadoLibroDevuelto (VARCHAR): Estado del libro al devolverse
--    - ObservacionesEstado (VARCHAR): Detalles sobre el estado
--
-- 2. TABLA LIBROS:
--    - EstadoFisico (VARCHAR): Estado actual del ejemplar físico
--      Valores: 'Excelente', 'Bueno', 'Regular', 'Malo', 'En Reparación'
--
-- CARACTERÍSTICAS:
-- - Base de datos lista para WinForms Sprint 2
-- - Sin simulaciones, todo persiste en BD
-- - Validaciones implementadas en repositorios
-- - Sistema de notificaciones con flag booleano
-- - Control de estado físico de libros
-- - Multas automáticas por daños
--
-- ═══════════════════════════════════════════════════════════════════════════════
