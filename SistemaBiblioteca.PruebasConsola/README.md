# Sistema Biblioteca - Proyecto de Pruebas en Consola

Este proyecto permite ejecutar y demostrar las historias de usuario del Sprint 1 mediante una aplicacion de consola interactiva.

## Proposito

Este proyecto sirve para:
- Demostrar el funcionamiento de la logica de negocio
- Verificar los criterios de aceptacion de cada historia de usuario
- Probar las validaciones antes de implementarlas en Windows Forms
- Facilitar la demostracion al profesor/evaluador

## Estructura del Proyecto

```
SistemaBiblioteca.PruebasConsola/
├── Program.cs                          (Menu principal)
├── ContextHelper.cs                    (Helper para crear DbContext)
├── PruebaRegistrarUsuario.cs          (HU-01)
├── PruebaRegistrarPrestamo.cs         (HU-08)
├── PruebaRegistrarDevolucion.cs       (HU-09)
├── PruebaReservarLibro.cs             (HU-11)
├── PruebaCalcularMulta.cs             (HU-13)
└── PruebaTodasLasHistorias.cs         (Suite completa)
```

## Requisitos Previos

1. **MySQL corriendo** en localhost:3306
2. **Base de datos creada:**
   ```sql
   CREATE DATABASE BibliotecaDB;
   ```
3. **Tablas creadas** (ejecutar script SQL del proyecto)
4. **Datos iniciales** (libros, categorias, autores)

## Como Ejecutar

### Opcion 1: Desde Visual Studio

1. Abrir la solucion `SistemaBiblioteca.sln`
2. Click derecho en `SistemaBiblioteca.PruebasConsola`
3. Seleccionar "Set as Startup Project"
4. Presionar F5 o Ctrl+F5

### Opcion 2: Desde Linea de Comandos

```bash
cd SistemaBiblioteca-Corregido/SistemaBiblioteca.PruebasConsola
dotnet run
```

## Menu Principal

Al ejecutar, veras este menu:

```
╔════════════════════════════════════════════════════════════╗
║   SISTEMA BIBLIOTECA - PRUEBAS DE HISTORIAS DE USUARIO    ║
╚════════════════════════════════════════════════════════════╝

  1. HU-01: Registrar Usuario
  2. HU-08: Registrar Prestamo
  3. HU-09: Registrar Devolucion
  4. HU-11: Reservar Libro
  5. HU-13: Calcular Multa
  6. Ejecutar TODAS las pruebas

  0. Salir

Seleccione una opcion:
```

## Descripcion de Cada Prueba

### HU-01: Registrar Usuario
- **Objetivo:** Demostrar el registro de nuevos usuarios
- **Validaciones:** Email unico, campos obligatorios, formato de email
- **Casos de prueba:** Usuario valido, email duplicado

### HU-08: Registrar Prestamo
- **Objetivo:** Demostrar el registro de prestamos de libros
- **Validaciones:** Libro disponible, usuario activo, sin multas
- **Resultado:** Prestamo creado, stock decrementado

### HU-09: Registrar Devolucion
- **Objetivo:** Demostrar el registro de devoluciones
- **Validaciones:** Prestamo activo existente
- **Resultado:** Devolucion registrada, stock incrementado, calculo de atraso

### HU-11: Reservar Libro
- **Objetivo:** Demostrar el sistema de reservas
- **Validaciones:** Libro no disponible, limite de reservas, sin multas
- **Resultado:** Reserva creada con estado Pendiente

### HU-13: Calcular Multa
- **Objetivo:** Demostrar el calculo automatico de multas
- **Formula:** DiasAtraso × $1.00
- **Resultado:** Multa generada si hay atraso

## Configuracion de Base de Datos

Si necesitas cambiar la cadena de conexion, edita el archivo `ContextHelper.cs`:

```csharp
optionsBuilder.UseMySql(
    "server=localhost;database=BibliotecaDB;user=root;password=TU_PASSWORD",
    new MySqlServerVersion(new Version(8, 0, 31))
);
```

## Datos de Prueba Sugeridos

Antes de ejecutar las pruebas, inserta estos datos en la BD:

```sql
-- Categorias
INSERT INTO CATEGORIAS (Nombre, Descripcion, Activo) VALUES
('Ficcion', 'Novelas y cuentos de ficcion', TRUE),
('Tecnologia', 'Libros de programacion y tecnologia', TRUE);

-- Autores
INSERT INTO AUTORES (Nombre, Apellido, Nacionalidad, Activo) VALUES
('Gabriel', 'Garcia Marquez', 'Colombiano', TRUE),
('Robert', 'Martin', 'Estadounidense', TRUE);

-- Libros
INSERT INTO LIBROS (Titulo, ISBN, AñoPublicacion, IdCategoria, CantidadTotal, CantidadDisponible, Activo) VALUES
('Cien años de soledad', '978-0307474728', 1967, 1, 5, 5, TRUE),
('Clean Code', '978-0132350884', 2008, 2, 3, 3, TRUE);
```

## Orden Recomendado de Ejecucion

Para una demostracion completa:

1. **HU-01:** Registrar Usuario (crea un usuario de prueba)
2. **HU-08:** Registrar Prestamo (presta un libro al usuario)
3. **HU-09:** Registrar Devolucion (devuelve el libro)
4. **HU-13:** Calcular Multa (muestra calculo de multa por atraso)
5. **HU-11:** Reservar Libro (reserva un libro no disponible)

O simplemente selecciona la opcion 6 para ejecutar todas automaticamente.

## Resultados Esperados

Cada prueba mostrara:
- ✅ Pasos ejecutados correctamente
- ❌ Errores o validaciones que fallan
- 📊 Datos del resultado
- 📋 Criterios de aceptacion cumplidos

Ejemplo de salida:

```
═══ PASO 1: Validar disponibilidad del libro ═══

📚 Libro: Clean Code
   ISBN: 978-0132350884
   Cantidad Total: 3
   Cantidad Disponible: 3
✅ Libro disponible para prestamo

...

CRITERIOS DE ACEPTACION VERIFICADOS:
  ✅ 1. Libro disponible validado
  ✅ 2. Usuario sin multas validado
  ✅ 3. Fecha devolucion calculada (+15 dias)
  ✅ 4. Stock decrementado
  ✅ 5. Estado inicial 'Activo'

RESULTADO: ✅ PRUEBA HU-08 EXITOSA
```

## Solucion de Problemas

### Error: "No se puede conectar a la base de datos"
- Verifica que MySQL este corriendo
- Confirma usuario y contraseña en ContextHelper.cs
- Verifica que exista la base de datos BibliotecaDB

### Error: "No hay usuarios/libros registrados"
- Ejecuta primero los scripts de datos iniciales
- O ejecuta HU-01 para crear un usuario

### Error: "No hay prestamos activos"
- Ejecuta primero HU-08 para crear un prestamo
- O ejecuta la opcion 6 (todas las pruebas)

## Notas Importantes

- **Las pruebas son funcionales:** Realmente insertan/actualizan datos en la BD
- **Algunas pruebas son simuladas:** HU-11 y parte de HU-13 porque aun no hay repositorios completos
- **Usa una BD de pruebas:** No uses datos de produccion

## Proximos Pasos

Una vez verificadas las pruebas en consola:
1. Implementar la misma logica en Windows Forms
2. Agregar validaciones de UI
3. Mejorar la experiencia de usuario

## Contacto

Para dudas sobre las pruebas, consulta:
- GUIA_VERIFICACION_HISTORIAS.md (guion tecnico completo)
- INFORME_CORRECCIONES.md (cambios realizados)

---

**Creado:** Enero 2026  
**Version:** 1.0  
**Proyecto:** Sistema de Gestion Bibliotecaria
