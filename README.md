# API Gestor de Tareas 📋

La API Gestor de Tareas es una aplicación desarrollada en .NET que permite gestionar tareas y sus estados. Ofrece funcionalidades para crear, leer, actualizar y eliminar tareas, así como gestionar los estados asociados.

## Tecnologías Utilizadas ⚙️

- .NET 8
- Entity Framework Core
- ASP.NET
- Base de datos SQL Server
- Swagger

## Instalación y Configuración del Backend  ⚙️

1. Clonar el repositorio. git clone https://github.com/YennyHernandez/ApiTaskManagement.git
2. Navegar al directorio. cd webApi
3. Restaurar las dependencias. dotnet restore
4. Iniciar el servidor. dotnet run
5. El Backend estará corriendo en http://localhost:5228/  pero para acceder a la documentación de Swagger, dirígete a http://localhost:5228/swagger/index.html
   
## Endpoints 🚀

![image](https://github.com/user-attachments/assets/c37ff77b-38f9-4f45-8eb3-8f784adb2b50)

### TaskController

#### Listar Tareas
- **Método**: `GET`
- **Ruta**: `/api/tasks`
- **Descripción**: Obtiene la lista de todas las tareas.

#### Listar Estados
- **Método**: `GET`
- **Ruta**: `/api/listState`
- **Descripción**: Obtiene la lista de estados disponibles para relacionar.

#### Crear Tarea
- **Método**: `POST`
- **Ruta**: `/api/tasks`
- **Descripción**: Crea una nueva tarea.
- **Body**:
    ```json
    {
        "title": "Nombre de la tarea",
        "stateId": 1
    }
    ```

#### Actualizar Tarea
- **Método**: `PUT`
- **Ruta**: `/api/tasks/{id}`
- **Descripción**: Actualiza una tarea existente por su ID.
- **Body**:
    ```json
    {
        "title": "Nombre actualizado de la tarea",
        "stateId": 2
    }
    ```

#### Eliminar Tarea
- **Método**: `DELETE`
- **Ruta**: `/api/tasks/{id}`
- **Descripción**: Elimina una tarea específica por su ID.

---

### StateController

#### Listar Estados
- **Método**: `GET`
- **Ruta**: `/api/states`
- **Descripción**: Obtiene la lista de todos los estados.

#### Crear Estado
- **Método**: `POST`
- **Ruta**: `/api/states`
- **Descripción**: Crea un nuevo estado.
- **Body**:
    ```json
    {
        "state": "Nuevo Estado"
    }
    ```

#### Actualizar Estado
- **Método**: `PUT`
- **Ruta**: `/api/states/{id}`
- **Descripción**: Actualiza un estado existente por su ID.
- **Body**:
    ```json
    {
        "state": "Estado actualizado"
    }
    ```

#### Eliminar Estado
- **Método**: `DELETE`
- **Ruta**: `/api/states/{id}`
- **Descripción**: Elimina un estado específico por su ID.




