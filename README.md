# NetWPFAreas

NetWPFAreas es una aplicación WPF creada con .NET Framework 4.8. Este proyecto simula un sistema de autenticación y redirige a los usuarios según sus roles (admin o usuario de soporte técnico). La autenticación y el almacenamiento de datos se realizan utilizando una base de datos SQL Server mediante Entity Framework.

## Estructura del Proyecto

```bash
NetWPFAreas/
├── DataAccess/
│   └── NetWPFAreasDbContext.cs
├── Models/
│   ├── Area.cs
│   ├── User.cs
│   └── UserArea.cs
├── Services/
│   ├── AreasService.cs
│   └── AuthenticationService.cs
├── Views/
│   ├── AdminWindow.xaml
│   ├── AdminWindow.xaml.cs
│   ├── AnalystWindow.xaml
│   ├── AnalystWindow.xaml.cs
│   ├── LoginWindow.xaml
│   └── LoginWindow.xaml.cs
├── Customized/
│   ├── MessageBoxCustom.xaml
│   └── MessageBoxCustom.xaml.cs
├── App.config
├── App.xaml
├── App.xaml.cs
└── MainWindow.xaml
```

## Requisitos Previos

.NET Framework 4.8
Visual Studio
SQL Server (Express o superior)
Entity Framework (se instala mediante NuGet)

## Configuración Inicial

### Crear la Base de Datos en SQL Server
Utiliza SQL Server Management Studio (SSMS) para ejecutar los scripts SQL proporcionados en la sección de instalación para crear la base de datos y las tablas necesarias.
Asegúrate de que la base de datos NetWPFAreasDb está creada y las tablas Users, Areas y UserAreas están configuradas correctamente.

### Configurar la Cadena de Conexión
Abre el archivo App.config.
Actualiza la cadena de conexión con el nombre de tu servidor SQL:

```bash
<connectionStrings>
  <add name="NetWPFAreasDb" 
       connectionString="Data Source=TU_SERVIDOR_SQL;Initial Catalog=NetWPFAreasDb;Integrated Security=True;" 
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```
## Cómo Ejecutar el Proyecto

1. Clonar el repositorio.
2. Abrir la solución NetWPFAreas.sln en Visual Studio.
3. Restaurar los paquetes NuGet si es necesario.
4. Compilar el proyecto.
5. Ejecutar la aplicación.

## Funcionalidad

1. La ventana principal es una pantalla de Login.
   - El usuario ingresa con su **nombre de usuario** y **contraseña**.
   - Las credenciales se validan contra la base de datos SQL Server.
2. Si ingresas con credenciales de un **administrador**, serás redirigido al **Admin Panel**, que incluye las siguientes funcionalidades:
   - **Gestión de Usuarios (Admin Panel):
   - Crear nuevos usuarios con nombre de usuario, contraseña, rol, correo electrónico y número de teléfono.
   - Ver los últimos 10 usuarios creados en un listado.
   - Editar detalles de contacto (correo y número de teléfono) de los usuarios seleccionados.
   - **Sistema de Autenticación:
   - Login de usuarios y redirección a la vista correspondiente según el rol (Admin o Usuario).
   - Validación de credenciales con la base de datos.
3. Si ingresas como **usuario  de soporte técnico**, serás redirigido a la vista **Analyst**, que permite a los usuarios ver las áreas de la empresa y asignarse a una única área. Las áreas disponibles son:
   - **Nómina
   - **Facturación
   - **Servicio al Cliente
   - **IT

## Cómo Funciona

1. **Listar Áreas: Al iniciar sesión como usuario regular, se mostrará una lista de las áreas disponibles obtenidas de la base de datos.
   - Crear nuevos usuarios con nombre de usuario, contraseña, rol, correo electrónico y número de teléfono.
   - Ver los últimos 10 usuarios creados en un listado.
   - Editar detalles de contacto (correo y número de teléfono) de los usuarios seleccionados.
2. **Asignar Área: El usuario puede seleccionar un área y hacer clic en "Asignar Área Seleccionada" para asignarse a esa área.
3. **Visualizar Área Asignada: La ventana muestra el área asignada actual al usuario.
4. **Si las credenciales son incorrectas, se muestra un mensaje personalizado indicando el error.

## Archivos Clave
### General
   - **Models/User.cs: Define el modelo de datos para los usuarios, incluyendo propiedades como el correo electrónico y número de teléfono.
   - **DataAccess/NetWPFAreasDbContext.cs: Contexto de Entity Framework para interactuar con la base de datos.
   - **Services/AuthenticationService.cs: Servicio que maneja la autenticación de usuarios, creación, actualización y consulta de los últimos usuarios.
   - **Views/LoginWindow.xaml: Pantalla de login.
### Administrador
   - **Views/AdminWindow.xaml: Pantalla para administradores, que permite la gestión de usuarios (creación y modificación de detalles de contacto).
### Soporte técnico
   - **Models/Area.cs: Modelo que representa un área.
   - **Models/UserArea.cs: Modelo que representa la asociación entre usuarios y áreas.
   - **Services/AreasService.cs: Servicio que maneja la lógica de asignación de usuarios a áreas.
   - **Views/AnalystWindow.xaml: Pantalla para usuarios de soporte técnico.
   - **Views/AnalystWindow.xaml.cs: Lógica para la asignación de áreas.
### Personalizados
   - **Customized/MessageBoxCustom.xaml: Ventana personalizada para mensajes de error.
   - **Customized/MessageBoxCustom.xaml.cs: Lógica para la ventana de mensaje personalizado.

## Instalación de Dependencias

### Instalar la dependencia para JSON usando NuGet:

```bash
Install-Package Newtonsoft.Json
```

