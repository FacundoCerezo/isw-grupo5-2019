# PROPUESTA DE SOLUCIÓN

## Clases de equivalencias

### Clases de equivalencias de entrada

|Condición externa|Clases de equivalencia válidas|Clases de equivalencia inválidas|
|-----------------|------------------------------|--------------------------------|
|Barrio           |Existe<br> No existe           |No se ingresa ningún valor      |
|Estado           |Ocupado<br> Libre<br> Solicitado<br> Fuera de servicio|No se selecciona ningún estado            |
|Chapa            |Existe                        |Formato no válido|
|Usuario logueado |Usuario registrado con perfil de Administrador central|No existe el usuario<br> Tiene otro perfil|

### Clases de equivalencias de salida

|Condición externa|Condición externa|Clases de equivalencia inválidas|
|-----------------|-----------------|--------------------------------|
|Color de estado de taxi|Verde <br> Amarillo<br> Rojo<br> Negro<br>|Taxi no conectado|
|Datos del pasajero|Nombre<br> Apellido<br> Celular<br>|Me da error que no es posible ver los datos del pasajero|
|Horario|hh:mm dd/MM/aaaa mayor que el actual|Menor que el actual|
|Costo|Positivo|Mensaje de error|
|Ubicación|Ubicación válida|Ubicación no válida|
|Mensaje de búsqueda|N/A|Barrio inexistente|

## Casos de Prueba para partición de equivalencias

|Id del Caso de Prueba|Prioridad|Nombre del Caso de Prueba|Precondiciones|Pasos|Resultado esperado|
|---------------------|---------|-------------------------|--------------|-----|------------------|
|1                    |Alta     | Búsqueda de taxi (por estado) exitosa |El usuario logueado tiene permiso de Administrador central (AC)  |1. El AC selecciona la opción "Ver mapa de taxis"<br> 2. El AC  selecciona la opción "Filtros"<br> 3. El AC  ingresa estado = "Libre"<br> 4. El AC  selecciona la opción "Buscar"         |1. El sistema muestra el mapa con los distintos taxis registrados.<br> 2. El sistema muestra la pantalla para selección de filtros.<br> 4. El sistema muestra en el mapa únicamente los taxis en estado "Libre" con un icono de color verde. |
