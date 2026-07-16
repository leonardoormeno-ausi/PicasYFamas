# 🎮 PicasYFamas API

Backend REST desarrollado en **ASP.NET Core Web API (.NET 9)** para el juego **Picas y Famas**.

El sistema permite registrar jugadores, autenticarse mediante JWT, crear partidas, realizar intentos, consultar historial y obtener estadísticas del jugador.

---

# 📋 Características

- Registro de jugadores
- Inicio de sesión con JWT
- Autenticación y autorización
- Creación de partidas
- Intentos de adivinanza
- Historial de partidas
- Historial de intentos
- Estadísticas del jugador
- Validaciones de datos
- Manejo global de excepciones
- Persistencia con SQLite
- Documentación mediante Swagger

---

# 🛠 Tecnologías

- ASP.NET Core Web API (.NET 9)
- Entity Framework Core
- SQLite
- JWT Authentication
- Swagger / OpenAPI
- C#
- Git
- GitHub

---

# 📁 Estructura del proyecto

```
PicasYFamas
│
├── backend
│   └── NumberGuessGameApi
│       ├── Controllers
│       ├── Data
│       ├── DTOs
│       ├── Helpers
│       ├── Middleware
│       ├── Migrations
│       ├── Models
│       ├── Security
│       ├── Services
│       └── Program.cs
│
└── PicasYFamas.sln
```

---

# 🚀 Instalación

Clonar el repositorio

```bash
git clone https://github.com/leonardoormeno-ausi/PicasYFamas.git
```

Entrar al proyecto

```bash
cd PicasYFamas
```

Restaurar paquetes

```bash
dotnet restore
```

Ejecutar la aplicación

```bash
dotnet run --project backend/NumberGuessGameApi
```

---

# 📖 Documentación

Una vez iniciada la aplicación, abrir:

```
http://localhost:5065/swagger
```

Desde Swagger se pueden probar todos los endpoints.

---

# 🔐 Autenticación

La API utiliza autenticación mediante **JWT Bearer Token**.

Flujo recomendado:

1. Registrar jugador.
2. Iniciar sesión.
3. Copiar el token.
4. Autorizar en Swagger.
5. Consumir los endpoints protegidos.

---

# 📌 Endpoints

## Autenticación

| Método | Endpoint |
|---------|----------|
| POST | /api/game/v1/register |
| POST | /api/game/v1/login |

## Juego

| Método | Endpoint |
|---------|----------|
| POST | /api/game/v1/new-game |
| POST | /api/game/v1/guess |

## Consultas

| Método | Endpoint |
|---------|----------|
| GET | /api/game/v1/history |
| GET | /api/game/v1/history/{gameId} |
| GET | /api/game/v1/stats |

---

# ✔ Validaciones

Se implementaron validaciones utilizando **DataAnnotations**.

Ejemplos:

- Nombre obligatorio.
- Apellido obligatorio.
- Edad entre 1 y 120 años.
- Email válido.
- Contraseña mínima de 6 caracteres.
- Número de juego de exactamente 4 dígitos.

---

# 📊 Estado del proyecto

Backend finalizado en su primera versión funcional.

Incluye:

- Autenticación JWT
- Entity Framework Core
- SQLite
- Swagger
- Validaciones
- Middleware de excepciones

Frontend en desarrollo.

---

# 👨‍💻 Autor

**Leonardo Emmanuel Ormeño**

Proyecto académico desarrollado utilizando **ASP.NET Core Web API (.NET 9)**.