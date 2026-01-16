# 📘 Modelado de Comportamiento: Diagramas de Secuencia

Este documento detalla los flujos de interacción dinámica del **Sistema de Gestión Bibliotecaria**. Se presentan los diagramas de secuencia correspondientes al **Sprint 1**, enfocados en los procesos críticos de Préstamo y Devolución de libros.

Los diagramas han sido diseñados siguiendo la arquitectura en **N-Capas** del proyecto, evidenciando la separación de responsabilidades entre la Interfaz de Usuario (UI), la Lógica de Negocio y el Acceso a Datos (Repositorio).

## 🛠 Herramientas Utilizadas
* **Lenguaje de Modelado:** UML 2.0
* **Motor de Renderizado:** Mermaid.js
* **Arquitectura:** Capas (.NET 10.0 + MySQL)

---

## 1. Flujo de Registro de Préstamo (HU-08)

Este diagrama modela la interacción necesaria para otorgar un libro a un usuario. El sistema debe garantizar la integridad de los datos antes de confirmar la transacción.

![Diagrama de Secuencia - Préstamo](assets/diagrama%20de%20secuencia%20-%20%20registro%20de%20prestamo.png)
*(Asegúrate de que la ruta de la imagen coincida con la carpeta donde la subiste en GitHub)*

### 🔍 Lógica del Flujo
1.  **Solicitud:** El bibliotecario inicia el proceso con el `IdUsuario` y `IdLibro`.
2.  **Validaciones (Bloques de Activación):**
    * **Verificación de Libro:** Se consulta a la BD si el libro existe y si su `Stock > 0`.
    * **Verificación de Usuario:** Se consulta si el usuario existe y si tiene `MultasPendientes`.
3.  **Toma de Decisiones (Fragmento `alt`):**
    * **Camino Exitoso:** Si las reglas se cumplen, se inserta el préstamo y **se actualiza el stock** (resta 1) dentro de una transacción implícita.
    * **Camino de Fallo:** Si hay multas o no hay stock, el sistema retorna un error sin modificar la base de datos.

---

## 2. Flujo de Devolución y Cálculo de Multas (HU-09 & HU-13)

Este proceso es más complejo ya que involucra lógica condicional para el cálculo automático de sanciones monetarias en caso de retraso.

![Diagrama de Secuencia - Devolución](assets/diagrama%20de%20secuencia%20-%20%20prestamo%20o%20devolucion.png)
*(Asegúrate de que la ruta de la imagen coincida con la carpeta donde la subiste en GitHub)*

### 🔍 Lógica del Flujo
1.  **Recuperación de Contexto:** Al ingresar el `IdPrestamo`, el sistema recupera toda la información vinculada (Libro y Usuario) mediante un `JOIN`.
2.  **Cálculo de Fechas:** La capa de Lógica de Negocio compara la `FechaEsperada` contra la fecha actual (`Hoy`).
3.  **Lógica de Multas (Fragmento `opt/alt`):**
    * Se evalúa la condición: `[Días de Atraso > 0]`.
    * Si es verdadero, se ejecuta el cálculo: `Monto = Días * Tarifa`.
    * Se inserta un registro en la tabla `Multas` asociado al usuario.
4.  **Cierre de Transacción:**
    * Se actualiza el estado del préstamo a `'Devuelto'`.
    * **Restauración de Stock:** Se incrementa el inventario del libro (+1) para que esté disponible nuevamente.

---

## 📐 Estructura de Capas Representada

Los diagramas respetan la siguiente comunicación de componentes:

| Componente | Responsabilidad en el Diagrama |
| :--- | :--- |
| **Sistema UI** | Captura eventos y muestra confirmaciones/errores. No procesa datos. |
| **Lógica Negocio** | "Cerebro" del flujo. Realiza cálculos (fechas, multas) y orquesta validaciones. |
| **Repositorio** | Abstrae el acceso a datos. Ejecuta los métodos CRUD (`Get`, `Insert`, `Update`). |
| **Base de Datos** | Motor MySQL que persiste la información y mantiene la integridad relacional. |

---

## 📝 Notas para Desarrolladores

* **Transaccionalidad:** Los pasos de *Insertar Préstamo* y *Actualizar Stock* deben manejarse dentro de una transacción de base de datos (`BeginTransaction` / `Commit`) para evitar inconsistencias de datos.
* **Parámetros:** Todas las consultas SQL representadas en el diagrama deben implementarse utilizando parámetros (ej. `@IdUsuario`) para prevenir inyección SQL.

---
*Documentación generada para la asignatura Desarrollo de Sistemas I - UPDS*
