# Informe de Diseño: Sistema de Gestión Bibliotecaria
**Asignatura:** Desarrollo de Sistemas 1  
**Sprint:** 1 - Fundamentos del Diseño  
**Fecha:** Enero 2026  
**Tecnologías:** .NET 6.0, MySQL 8.0  

---

## 1. Introducción
Este documento consolida los artefactos de diseño creados para el proyecto "Sistema Bibliotecario". Se detallan los modelos de comportamiento, estructura de código y diseño de base de datos, garantizando la integridad referencial y el cumplimiento de la 3ra Forma Normal (3FN).

---

## 2. Modelo de Comportamiento (Casos de Uso)
Define las interacciones funcionales entre los actores y el sistema.

![Diagrama de Casos de Uso](Diagrama%20de%20casos%20de%20uso.png)

### Detalles del Diseño
* **Actores:** Usuario/Miembro, Bibliotecario y Administrador.
* **Módulos Clave:** Gestión de Préstamos, Devoluciones, Reservas y Multas.
* **Relaciones:** Se implementaron `<<include>>` para validaciones obligatorias (ej. Validar Disponibilidad) y `<<extend>>` para flujos alternativos (ej. Generar Multa tras devolución tardía).

---

## 3. Arquitectura de Software (Diagrama de Clases)
Estructura estática para la implementación en el backend (.NET).

![Diagrama de Clases](diegrama%20de%20clases.png)

### Estructura
* **Entidades de Negocio:** `Usuario`, `Libro`, `Prestamo`, `Multa`, `Reserva`.
* **Lógica Encapsulada:** Métodos como `CalcularMulta()`, `ActualizarStock()` y `PuedePrestar()`.
* **Relaciones:**
    * **Composición:** Préstamo → Multa (Ciclo de vida dependiente).
    * **Agregación:** Categoría → Libro (Agrupación lógica).

---

## 4. Diseño de Base de Datos

### 4.1. Modelo Conceptual (Notación Chen)
Representación de alto nivel de entidades y relaciones semánticas.

![Modelo Chen](modelado%20chen.png)

* **Descripción:** Visualización clara de las entidades principales y sus atributos clave.
* **Relaciones N:M:** Se identifica conceptualmente la relación "LIBRO ESCRIBE AUTOR".

### 4.2. Modelo Lógico/Físico (Entidad-Relación)
Esquema normalizado final para la implementación en MySQL.

![Diagrama ER](diagrama%20ER.png)

* **Tabla Central:** `PRESTAMOS` funciona como el eje transaccional del sistema.
* **Normalización:**
    * Se resolvió la relación muchos a muchos con la tabla intermedia `LIBROS_AUTORES`.
    * Diseño validado con **0 circuitos** y **0 paralelismos**.
* **Integridad:** Las tablas `RESERVAS`, `MULTAS` e `HISTORIAL` dependen directamente del flujo de `PRESTAMOS` para mantener la consistencia de los datos.

---

## 5. Conclusiones
El diseño presentado cumple con los requerimientos del Sprint 1, proporcionando una base sólida, escalable y normalizada para el desarrollo del Sistema Bibliotecario.
