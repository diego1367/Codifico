# Codifico
Desarrollé una aplicación en Angular 19 con un backend en .NET 9, implementando Entity Framework para la generación de todos los modelos y operaciones básicas. Además, creé uno de los endpoints utilizando un procedimiento almacenado desde el backend. En el frontend configuré rutas específicas para las vistas:

/newapp → NewOrderComponent
/orderview → OrdersViewComponent
/prediction → SalesPredictionComponent
/vanilla → VanillaViewComponent

Para inicializar la aplicación Angular, primero ejecuta npm install para instalar todas las dependencias, luego inicia el servidor de desarrollo con ng serve.
Para el backend en .NET 9, basta con tener instalado el SDK de .NET 9, configurar la cadena de conexión a la base de datos en appsettings.json, y luego ejecutar la aplicación directamente con dotnet run.


el procedimiento almacenado se encuentra en el mismo commit
