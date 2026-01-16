# Plan de Iteraciones - Sistema de Gestión Bibliotecaria

**Proyecto:** Sistema de Biblioteca Automatizado  
**Metodología:** Extreme Programming (XP)  
**Equipo de Desarrollo:**
* Owen Jonathan Zubieta Mendoza (Líder)
* Leandro Emilio Leyes Clavijo
* Noel David Limachi Abelo
* Juan Simon Pacaje Tarqui

---

## 📅 Visión General del Release (Release Planning)

El objetivo de este Release 1.0 es entregar un MVP (Producto Mínimo Viable) que permita la gestión administrativa de la biblioteca, incluyendo el control de inventario (libros/autores), gestión de usuarios y el ciclo completo de préstamos y devoluciones con cálculo automático de multas.

| Iteración | Foco Principal | Estado |
| :--- | :--- | :--- |
| **Iteración 1** | Arquitectura y Base de Datos | ✅ Completado |
| **Iteración 2** | Gestión de Catálogos (CRUDs) | ✅ Completado |
| **Iteración 3** | Lógica de Negocio (Préstamos) | 🔄 En Progreso |
| **Iteración 4** | Refinamiento y Entrega Final | 📅 Pendiente |

---

## 📝 Detalle de Iteraciones

### 📍 Iteración 1: Fundamentos y Arquitectura
**Objetivo:** Establecer la estructura del proyecto en capas y la persistencia de datos.

| ID Historia | Tarea / Historia de Usuario | Responsable | Estado |
| :--- | :--- | :--- | :--- |
| **H-01** | Diseño del Modelo Entidad-Relación (BD) | Todo el Equipo | ✅ Terminado |
| **H-02** | Creación de scripts SQL (Tablas y Relaciones) | Juan / Noel | ✅ Terminado |
| **H-03** | Configuración de Solución en Visual Studio (N-Capas) | Owen | ✅ Terminado |
| **H-04** | Configuración de Entity Framework y DbContext | Leandro | ✅ Terminado |
| **H-05** | Creación de Entidades (Clases POCO) | Juan | ✅ Terminado |

**Entregable:** Base de datos `bibliotecadb` funcional y conexión exitosa desde C#.

---

### 📍 Iteración 2: Gestión de Catálogos (Back Office)
**Objetivo:** Permitir al bibliotecario administrar la información estática del sistema.

| ID Historia | Tarea / Historia de Usuario | Responsable | Estado |
| :--- | :--- | :--- | :--- |
| **H-06** | CRUD de Autores y Categorías | Noel | ✅ Terminado |
| **H-07** | CRUD de Libros (con manejo de Stock) | Leandro | ✅ Terminado |
| **H-08** | CRUD de Usuarios (Socios y Administrativos) | Juan | ✅ Terminado |
| **H-09** | Implementación de Repositorio Genérico o Específico | Owen | ✅ Terminado |
| **H-10** | Pruebas Unitarias de Inserción de Datos | Todo el Equipo | ✅ Terminado |

**Entregable:** Módulos de administración capaces de crear, leer, actualizar y borrar registros (Demostración 2.5).

---

### 📍 Iteración 3: Core del Negocio (Transacciones)
**Objetivo:** Implementar la lógica de préstamos, devoluciones y reglas de negocio.

| ID Historia | Tarea / Historia de Usuario | Responsable | Estado |
| :--- | :--- | :--- | :--- |
| **H-11** | HU: "Como bibliotecario, quiero registrar un préstamo validando disponibilidad" | Owen | 🔄 En Revisión |
| **H-12** | Desarrollo de `PrestamoRepository` y lógica transaccional | Leandro | ✅ Terminado |
| **H-13** | Implementación de Extension Methods (`LibroExtensions`) | Juan | ✅ Terminado |
| **H-14** | HU: "Como sistema, quiero calcular multas automáticamente al devolver tarde" | Noel | 🔄 En Progreso |
| **H-15** | Diagramas de Secuencia (Préstamo y Devolución) | Todo el Equipo | ✅ Terminado |

**Entregable:** Flujo funcional de Préstamo -> Validación -> Devolución -> Multa.

---

### 📍 Iteración 4: Refinamiento y UI (Próxima)
**Objetivo:** Mejorar la experiencia de usuario y asegurar la estabilidad.

| ID Historia | Tarea / Historia de Usuario | Responsable | Estado |
| :--- | :--- | :--- | :--- |
| **H-16** | Diseño de Formularios de Windows (WinForms/WPF) | Todo el Equipo | 📅 Pendiente |
| **H-17** | Integración de UI con Capa de Negocio | Owen | 📅 Pendiente |
| **H-18** | Reportes Básicos (Libros más prestados, Multas pendientes) | Leandro | 📅 Pendiente |
| **H-19** | Pruebas de Integración y Corrección de Bugs | Todos | 📅 Pendiente |

---

## 📊 Métricas de Avance

* **Historias Totales:** 19
* **Completadas:** 12
* **En Progreso:** 2
* **Pendientes:** 5
* **Porcentaje de Avance Global:** ~73%

---
*Documento generado para el informe de progreso académico - Enero 2026.*
