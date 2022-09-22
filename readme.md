App Gestión de Fotos realiza con .NET

Se creará un CRUD de imágenes, con VS code, una APP con un slide dínamico y un pandel control donde se podrá subir, actualizar y borrar imágenes.

Se estará trabajando con Entity Framework con la que haremos la base de datos local con Code First. 
Para ello es necesario que instalamos los siguientes  paquetes:

Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.aspnetcore.mvc.core

Creado el Modelo donde definimos las propiedades con las que seguardará la información de los archivos.

Creado también ApplicationDbContext, que hereda de "DbContext"

En appsettings.json Creamos la cadena de conexión para acceder y crear la BBDD.

Para que la aplicación pueda ser utilizada tenemo que hacer La primera migración y crear el archivo de la base de datos, desde la consola.

        PM> Add-Migration «Nombre de la Migración»
        PM> Update-Database

Una vez migrado, ya podemos correr nuestra app.

Tenemos las vistas cshtml para cargar el front, para el HOME, CREAR, ELIMINAR Y EDITAR.

Para los estilos alternamos CSS y Bootstrap.

Tanto el head, footer, menu nav y Head estan en una carpeta Shared desde donde podemos editar desde un solo documento toda la app.

Las imagenes subidas son almacenadas en Local, pudiendo acceder a ellas desde root.

Cuando borramos desde el panel de control también se eliminan de la carpeta local y de la BBDD.

Las pruebas TEST han sido realizadas desde el mismo Visual Studio y con Xunit.
Con Xunit se crea un proyecto paralelo para ver y corregir los fallos del proyecto principal.
Visual Studio 2022 te ofrece la ventaja de poder ejecutar pruebas unitarias de tu código y una en modo desarrollador te va arrojando a la consola de LISTADO DE ERRORES todos los fallos.


Espero que se haya podido cumplir con todos los requisitos.

Muchas gracias.
Guillermo de Porras.

