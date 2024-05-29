# Red Efectiva - Prueba Técnica #2 - CRUD Customer - Backend

Este proyecto es correspondiente a la prueba técnica #2 de `Red Efectiva`. Es el API el cual contiene el CRUD de un catálogo de clientes. Este código se puede utilizar únicamente como; servicio, utilizar o desarrollar una interfaz personalizada con cualquier tecnología o hacer uso del portal desarrollado en `React` [crud-customer-test-frontend](https://github.com/argelalfaro95/crud-customer-test-frontend?tab=readme-ov-file) que acompaña y es complemento de esta prueba.

## Requerimientos

`.NET Core SDK`: [Descargar versión v8.0+](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

`MySQL Community Server`: [Descargar versión v8.4+](https://dev.mysql.com/downloads/mysql/)

`Git`: [Descargar versión v2.45+](https://git-scm.com/downloads)

## Pasos a seguir

### Clonar el repositorio

    git clone https://github.com/argelalfaro95/crud-customer-test-backend.git

### Configurar la versión de ejecución del SDK

Para esto necesitamos editar el archivo `./global.json` en base a la versión que tengamos instalada de .NET 8, debemos verificar con el siguiente comando:

    dotnet --version

Una vez sabemos que versión exacta es la que contamos editamos el archivo `./global.json` en base a la versión que contamos de .NET y nos quedaría de la siguiente manera:    

```
{
  "sdk": {
    "version": "8.0.300",
    "rollForward": "latestMajor"
  }
}
```

### Configurar el `appsettings.json` con nuestra cadena de conexión

Debemos de editar el archivo que se encuentra `./src/API_CleanArchitecture.Web/appsettings.json` y en el deberá estar la cadena de conexión con las credenciales del servidor que configuramos en la instalación de `MySQL Community Server` quedando algo similar a esto:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=db_customer;User=user;Password=pass"
  },
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information"
    },
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "log.txt",
          "rollingInterval": "Day"
        }
      }
    ]
  },
  "Mailserver": {
    "Server": "localhost",
    "Port": 25
  }
}
```

### Restaurar el proyecto

Para restaurar el proyecto debemos estar en la raíz del repositorio y ejecutar lo siguiente:

    dotnet restore

### Compilar la solución

Siempre desde la raíz del repositorio ejecutamos el siguiente comando:

    dotnet build

### Ejecutar la solución

Para ejecutar la solución debidamente, nos dirigimos a la siguiente ruta `./src/API_CleanArchitecture.Web/` una vez dentro de la ruta ejecutamos el siguiente comando:

    dotnet run

Si todo está correctamente configurado y se ha seguido hasta este punto los pasos anteriores, el proyecto al ejecutar nos creará la base de datos en `MySQL` con el nombre `db_customer` y dentro del esquema la tabla para guardar registros `customer`, al finalizar el proceso y terminar de ejecutarse, podremos dirigirnos a nuestro navegador y consultar el `swagger` del API en la siguiente url [https://localhost:57679/swagger/index.html](https://localhost:57679/swagger/index.html), o podemos dirigirnos directamente a nuestros `endpoints` a través del siguiente url [https://localhost:57679/swagger/index.html#/Customer](https://localhost:57679/swagger/index.html#/Customer)

### Configuraciones opcionales

#### CORS

En caso de querer utilizar este API para consumirse a través de una interfaz externa o de manera remota, es necesario agregar la regla para nuestro `CORS` e indicarle cuales serían los `dominios`/`ip` que se estarán conectando, para ello editaremos el siguiente archivo `./src/API_CleanArchitecture.Web/Program.cs`:

```
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowLocalhost",
                    builder =>
                    {
                      builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
});
```

Y en los origenes podemos cambiar el `dominio`/`ip` o agregar más de ser necesarios. Esto es requerido realizarlo para consumir el servicio y es una capa de seguridad para el proyecto.

#### Otros Sistemas Operativos

Si hemos optado por levantar este proyecto desde una PC con `Linux`, deberemos de modificar el siguiente archivo `./src/API/CleanArchitecture.Web/API_CleanArchitecture.Web.csproj` y agregar la siguiente línea:

      <RuntimeIdentifier>linux-x64</RuntimeIdentifier>

En la entrada de `<PropertyGroup>` quedando de la siguiente manera:

```
  <PropertyGroup>
    <PreserveCompilationContext>true</PreserveCompilationContext>
    <OutputType>Exe</OutputType>
    <WebProjectMode>true</WebProjectMode>
    <GenerateDocumentationFile>True</GenerateDocumentationFile>
    <RuntimeIdentifier>linux-x64</RuntimeIdentifier>
  </PropertyGroup>
```

Esto aplica de igual forma si se desea ejecutar en MacOS y se debería de agregar la configuración correspondiente.

## Casos de uso

### CURLs

Se puede utilizar los siguientes CURLs que nos permitirán transaccionar el `CRUD` de `Customer`.

#### Create Customer

```
curl -X 'POST' \
  'https://localhost:57679/Customer' \
  -H 'accept: application/json' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "Fulano",
  "lastName": "Pérez",
  "email": "fulanito@redefectiva.com",
  "identification": "001-112-0025",
  "phone": "(+505) 8923-1254",
  "address": "Tangamandapio",
  "gender": "Masculino",
  "birthday": "1990-01-01",
  "createdDate": null,
  "lastModifiedDate": null
}'
```

#### Get List

```
curl -X 'GET' \
  'https://localhost:57679/Customer' \
  -H 'accept: application/json'
```

#### Update Customer

```
curl -X 'PUT' \
  'https://localhost:57679/Customer/1' \
  -H 'accept: application/json' \
  -H 'Content-Type: application/json' \
  -d '{
  "Id": 1,
  "name": "Fulanito",
  "lastName": "Sutano",
  "email": "fulanito2@redefectiva.com",
  "identification": "001-112-0025E",
  "phone": "(+51) 8923-12541212",
  "address": "Panangaricutirimicuaro",
  "gender": "Masculinito",
  "birthday": "1991-02-02"
}'
```

#### Delete Customer

```
curl -X 'DELETE' \
  'https://localhost:57679/Customer/1' \
  -H 'accept: text/plain'
```

## Preview API

### Swagger

![Swagger](/public/resource/crud-backend-customer-01.png)

### Swagger Endpoint

![Swagger](/public/resource/crud-backend-customer-02.png)