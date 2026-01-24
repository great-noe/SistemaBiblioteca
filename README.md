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
## Estructura del proyecto
SistemaBiblioteca/
│
├── SistemaBiblioteca.Entidades/          # Modelos del dominio (tablas)
│   ├── Autor.cs
│   ├── Libro.cs
│   ├── LibroAutor.cs
│   ├── Categoria.cs
│   ├── Usuario.cs
│   ├── Prestamo.cs
│   ├── Reserva.cs
│   ├── Multa.cs
│   └── HistorialPrestamo.cs
│
├── SistemaBiblioteca.AccesoDatos/         # DAL (Data Access Layer)
│   ├── Contexto/
│   │   └── BibliotecaContext.cs
│   │
│   ├── Repositorios/                      # consultas (CRUD)
│   │   ├── IRepositorio.cs
│   │   ├── AutorRepository.cs
│   │   ├── LibroRepository.cs
│   │   ├── UsuarioRepository.cs
│   │   ├── PrestamoRepository.cs
│   │   ├── ReservaRepository.cs
│   │   └── MultaRepository.cs
│   │
│   └── Configuracion/
│       └── ConnectionManager.cs
│
├── SistemaBiblioteca.LogicaNegocio/       # Reglas de negocio
│   ├── Servicios/
│   │   ├── AutorService.cs
│   │   ├── LibroService.cs
│   │   ├── PrestamoService.cs
│   │   ├── ReservaService.cs
│   │   ├── MultaService.cs
│   │   └── UsuarioService.cs
│   │
│   └── Validaciones/
│   │   ├── PrestamoValidador.cs
│   │   ├── ReservaValidador.cs
│   │   └── UsuarioValidador.cs
|   └── DTOs/   
│       ├── AutorDto.cs
│       ├── LibroDto.cs
│       ├── LibroAutorDto.cs
│       ├── CategoriaDto.cs
│       ├── UsuarioDto.cs
│       ├── PrestamoDto.cs
│       ├── ReservaDto.cs
│       ├── MultaDto.cs
│       └── HistorialPrestamoDto.cs
│
├── SistemaBiblioteca.Presentacion/        # Windows Forms
│   ├── Formularios/
│   │   ├── FrmLogin.cs
│   │   ├── FrmPrincipal.cs
│   │   ├── FrmAutores.cs
│   │   ├── FrmLibros.cs
│   │   ├── FrmUsuarios.cs
│   │   ├── FrmPrestamos.cs
│   │   ├── FrmReservas.cs
│   │   └── FrmMultas.cs
│   │
│   ├── Controles/
│   └── Utilidades/
│
└── SistemaBiblioteca.sln
