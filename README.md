# Sistema de Biblioteca

## Integrantes
- Owen Jonathan Zubieta Mendoza (Líder)
- Leandro Emilio Leyes Clavijo
- Noel David Limachi Abelo
- Juan Simon Pacaje Tarqui

## Descripción
Sistema de gestión bibliotecaria diseñado para administrar el flujo de préstamos, devoluciones y reservas, con control de inventario de libros, gestión de usuarios y registro de multas.

## Tecnologías
- .NET
- Windows Forms
- MySQL
- Entity Framework

## Módulos Principales
1. Gestión de Autores y Libros
2. Gestión de Usuarios
3. Gestión de Préstamos
4. Gestión de Reservas
5. Gestión de Multas

## Estado del Proyecto
# Bitácora de Trabajo – Sprint 1

## Día 1 – Lunes 08/01/2026

### Jonathan – Programador / Analista
- **¿Qué hice ayer?**  
  Inicio del sprint, revisión de requerimientos y configuración del entorno.
- **¿Qué haré hoy?**  
  Crear la estructura de la base de datos y diseñar las entidades principales.
- **¿Qué dificultades tuve?**  
  Ninguna por el momento.

### Noel – Programador / Diseñador
- **¿Qué hice ayer?**  
  Preparación del entorno de desarrollo y configuración de Visual Studio.
- **¿Qué haré hoy?**  
  Diseñar mockups de interfaces y comenzar diagramas UML.
- **¿Qué dificultades tuve?**  
  Ninguna.

### Leandro – Programador / Tester
- **¿Qué hice ayer?**  
  Revisión de historias de usuario y casos de uso.
- **¿Qué haré hoy?**  
  Crear el script SQL inicial con las tablas del sistema.
- **¿Qué dificultades tuve?**  
  Ninguna.

### Simon – Programador / Documentador
- **¿Qué hice ayer?**  
  Revisión de la documentación del proyecto.
- **¿Qué haré hoy?**  
  Iniciar el documento de casos de uso y preparar el README.
- **¿Qué dificultades tuve?**  
  Ninguna.

---

## Día 2 – Martes 09/01/2026

### Jonathan – Programador / Analista
- **¿Qué hice ayer?**  
  Creé el script SQL con las 9 tablas normalizadas en Tercera Forma Normal (3FN).
- **¿Qué haré hoy?**  
  Implementar las entidades en C# con propiedades y navegación.
- **¿Qué dificultades tuve?**  
  Dudas sobre la normalización de la tabla `LIBROS_AUTORES`, resueltas consultando material de apoyo.

### Noel – Programador / Diseñador
- **¿Qué hice ayer?**  
  Completé los mockups de 5 formularios principales.
- **¿Qué haré hoy?**  
  Crear el diagrama de casos de uso en HTML.
- **¿Qué dificultades tuve?**  
  Ninguna.

### Leandro – Programador / Tester
- **¿Qué hice ayer?**  
  Implementé `ConnectionManager` y la interfaz `IRepository`.
- **¿Qué haré hoy?**  
  Comenzar el diagrama ER y validar el script SQL.
- **¿Qué dificultades tuve?**  
  Ninguna.

### Simon – Programador / Documentador
- **¿Qué hice ayer?**  
  Documenté 14 historias de usuario con criterios de aceptación.
- **¿Qué haré hoy?**  
  Crear documentación de análisis de casos de uso.
- **¿Qué dificultades tuve?**  
  Ninguna.

---

## Día 3 – Miércoles 10/01/2026

### Jonathan – Programador / Analista
- **¿Qué hice ayer?**  
  Implementé las 9 clases de entidades con propiedades básicas.
- **¿Qué haré hoy?**  
  Agregar propiedades calculadas y métodos de negocio a las entidades.
- **¿Qué dificultades tuve?**  
  Ninguna.

### Noel – Programador / Diseñador
- **¿Qué hice ayer?**  
  Creé el diagrama de casos de uso en HTML con 23 casos de uso.
- **¿Qué haré hoy?**  
  Trabajar en el diagrama de clases y comenzar el diagrama Chen.
- **¿Qué dificultades tuve?**  
  El diseño del diagrama de casos de uso tomó más tiempo del esperado.

### Leandro – Programador / Tester
- **¿Qué hice ayer?**  
  Completé el diagrama ER interactivo en HTML.
- **¿Qué haré hoy?**  
  Comenzar la implementación de `UsuarioRepository` con operaciones CRUD.
- **¿Qué dificultades tuve?**  
  Ninguna.

### Simon – Programador / Documentador
- **¿Qué hice ayer?**  
  Creé la descripción detallada de los flujos de los casos de uso.
- **¿Qué haré hoy?**  
  Revisar la coherencia entre la base de datos, las entidades y los casos de uso.
- **¿Qué dificultades tuve?**  
  Ninguna.

---

## Día 4 – Jueves 11/01/2026

### Jonathan – Programador / Analista
- **¿Qué hice ayer?**  
  Agregué propiedades calculadas como `NombreCompleto`, `EstaDisponible` y `DiasAtraso` a las entidades.
- **¿Qué haré hoy?**  
  Apoyar en `UsuarioRepository` y crear una aplicación de consola para demostración.
- **¿Qué dificultades tuve?**  
  Ninguna.

### Noel – Programador / Diseñador
- **¿Qué hice ayer?**  
  Completé el diagrama de clases en HTML con las 9 entidades.
- **¿Qué haré hoy?**  
  Agregar métodos de negocio a las entidades y finalizar el diagrama Chen.
- **¿Qué dificultades tuve?**  
  Ninguna.

### Leandro – Programador / Tester
- **¿Qué hice ayer?**  
  Implementé `UsuarioRepository` con todos los métodos CRUD (`ObtenerTodos`, `Insertar`, `Actualizar`, `Eliminar`).
- **¿Qué haré hoy?**  
  Probar el repositorio y validar su correcto funcionamiento con la base de datos.
- **¿Qué dificultades tuve?**  
  Problemas con parámetros en `MySqlCommand`, solucionados usando correctamente `AddWithValue`.

### Simon – Programador / Documentador
- **¿Qué hice ayer?**  
  Validé la coherencia del diseño completo del sistema.
- **¿Qué haré hoy?**  
  Iniciar el documento del **Sprint 1** con toda la documentación técnica.
- **¿Qué dificultades tuve?**  
  Ninguna.

