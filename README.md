# Users Management

## Tabla de Contenidos  
1. [Presentación](#presentación)  
2. [Instalación](#instalación)  
3. [Desarrollo](#desarrollo)  
4. [Herramientas](#herramientas)  
5. [Despliegue](#despliegue)  

---

## Presentación

Es una API REST que permite gestionar usuarios mediante autenticación y authorizacion. El proyecto tiene una arquitectura en capas, es escalable y mantenible.

### Características
- Registro y login de usuarios con JWT.
- Protección de rutas con token y autorización basada en roles.
- Seguridad de datos y encriptación.
- Captura y trato de excepciones.
- Documentación de la API.


##  Instalación

###Instrucciones de instalación

1. Cloná el repositorio:
   ```bash
   git clone https://github.com/Geider10/UsersManagment.git
   cd UsersManagment
   ```
2. Restaurá los paquetes NuGet:
```bash
  dotnet restore
```
3. Ejecutá la aplicación:
```bash
   dotnet run
```
### Archivo de configuración
Editá el archivo appsettings.json con tu propia conexión a base de datos y clave secreta:
```bash
  "ConnectionStrings": {
  "Connection": ""
},
"SECRET_KEY": ""
```

## Desarrollo
### Tecnologías
Backend: ASP.NET 8.0, C#, Entity Framework Core

Base de datos: SQL Server

### Mejoras Futuras
- Validacion de los datos.
- Crear una imagen Docker del backend.
- Desplegar la aplicación en Azure App Service.
- Usar Azure SQL como base de datos remota.

## Herramientas
### Librerías del backend
- BCrypt.Net-Next: Permite hashear y verificar contraseñas de forma segura usando el algoritmo BCrypt, ideal para guardar contraseñas en bases de datos.
- Microsoft.AspNetCore.Authenticacion.JwtBearer: Proporciona middleware para validar y autenticar tokens JWT enviados en las solicitudes HTTP.
- Microsoft.EntityFrameworkCore.SqlServer: Habilita el uso de SQL Server como base de datos cuando usás Entity Framework Core para interactuar con tablas.
- Microsoft.EntityFrameworkCore.Tools: Incluye comandos para usar dotnet ef.

## Despliegue
Azure App Service
Link: 
