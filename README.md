# dsi-2023
Repositorio de codigo fuente de ejemplos para la asignatura Diseño de Sistemas en Internet de la carrera Ingeniería de Sistemas de la Facultad de Ciencias y Sistemas de la Universidad Nacional de Ingeniería.

# Instalación de paquetes necesarios
```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

# Comando para crear contexto de bases de datos y modelos basados en las tablas de la base de datos
```
Scaffold-DbContext 'Data Source=Data Source=daltanias.eastus.cloudapp.azure.com;Initial Catalog=AdventureWorks2019;Persist Security Info=True;User ID=sa;Password=my$3rv3r;TrustServerCertificate=True;MultipleActiveResultSets=true' Microsoft.EntityFrameworkCore.SqlServer -Context AdventureWorksContext -OutputDir Db
```

# Nodo de configuración ConnectionStrings
```JSON
  "ConnectionStrings": {
    "AwConnectionString": "Data Source=daltanias.eastus.cloudapp.azure.com;Initial Catalog=AdventureWorks2019;Persist Security Info=True;User ID=sa;Password=my$3rv3r;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
```
