# 📦 Base de Datos - Sistema Biblioteca v7

Esta carpeta contiene todos los scripts SQL necesarios para crear la base de datos completa desde cero.

---

## 📋 Archivos Incluidos

| Archivo | Descripción | Orden |
|---------|-------------|-------|
| `01_CREAR_BD_COMPLETA_v7.sql` | Script principal - Crea BD completa con campos v7 | **1º** |
| `02_DATOS_PRUEBA_v7.sql` | Datos de prueba (opcional pero recomendado) | **2º** |
| `INSTRUCCIONES_CARGA_BD.txt` | Guía detallada paso a paso | - |
| `README.md` | Este archivo | - |

---

## 🚀 Inicio Rápido (3 pasos)

### ⚡ Método Rápido - MySQL Workbench

```
1. Abrir MySQL Workbench
2. File → Open SQL Script → 01_CREAR_BD_COMPLETA_v7.sql
3. Click en ⚡ Execute
```

### ⚡ Método Rápido - Línea de Comandos

```bash
cd SistemaBiblioteca-v7/BaseDatos
mysql -u root -p < 01_CREAR_BD_COMPLETA_v7.sql
mysql -u root -p < 02_DATOS_PRUEBA_v7.sql
```

---

## ✅ Verificar que Funcionó

```sql
USE bibliotecadb;
SHOW TABLES;
DESCRIBE prestamos;  -- Debe mostrar NotificacionEnviada, EstadoLibroDevuelto
DESCRIBE libros;     -- Debe mostrar EstadoFisico
```

---

## 🆕 Novedades v7

### Nuevos Campos en `prestamos`:
- ✅ `NotificacionEnviada` - Flag booleano para notificaciones
- ✅ `EstadoLibroDevuelto` - Estado del libro al devolverse
- ✅ `ObservacionesEstado` - Detalles sobre daños

### Nuevos Campos en `libros`:
- ✅ `EstadoFisico` - Estado físico actual del libro
  - Valores: Excelente, Bueno, Regular, Malo, En Reparación

---

## 📊 Estructura Completa

La base de datos incluye **10 tablas**:

1. **categorias** - Categorías de libros
2. **autores** - Autores de libros
3. **libros** - Catálogo de libros (con `EstadoFisico` v7)
4. **libro_autor** - Relación muchos-a-muchos
5. **usuarios** - Usuarios del sistema
6. **prestamos** - Préstamos (con campos v7)
7. **historial_prestamo** - Historial de préstamos
8. **reservas** - Reservas de libros
9. **multas** - Multas generadas
10. **Vistas** - vistas útiles para consultas

---

## 📦 Datos de Prueba Incluidos

Si ejecutas `02_DATOS_PRUEBA_v7.sql` obtendrás:

- 8 categorías
- 10 autores (García Márquez, Borges, Allende, etc.)
- 10 libros (con diferentes estados físicos)
- 8 usuarios
- 7 préstamos (ejemplos de todos los estados)
- 2 reservas

---

## ⚠️ Importante

- ⚠️ El script **ELIMINA** la base de datos si existe
- ⚠️ Haz **BACKUP** si tienes datos importantes
- ✅ Es seguro ejecutar en instalación nueva
- ✅ Compatible con MySQL 5.7+

---

## 🔧 Solución Rápida de Problemas

| Error | Solución |
|-------|----------|
| "Access denied" | Verificar usuario y contraseña |
| "Table already exists" | Ya ejecutaste el script (está OK) |
| Caracteres raros | Configurar UTF-8 en MySQL Workbench |

---

## 📖 Más Información

Para instrucciones detalladas, ver: **INSTRUCCIONES_CARGA_BD.txt**

---

## 🎯 Siguiente Paso

Después de cargar la BD:

1. Abrir Visual Studio
2. Abrir `SistemaBiblioteca.sln`
3. Verificar cadena de conexión
4. Compilar y ejecutar pruebas

---

**Versión:** 7.0  
**Fecha:** 21 de Enero 2026  
**Estado:** ✅ Listo para usar
