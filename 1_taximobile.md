# *Taxi Mobile*

## Buscar Taxis Cercanos


## Registrar Nuevo Pasajero
Como Pasajero, quiero registrarme en el sistema para poder utilizar la aplicación.

### Notas
- Deberá ser posible registrar al Pasajero mediante sus datos (nombre, apellido, correo electrónico, teléfono y contraseña)
- Debe ser posible registrar al Pasajero a través de Facebook.
- Debe ser posible obtener el número de teléfono del usuario mediante el dispositivo móvil.

### Pruebas
- Probar registrarse con todos sus datos correctos (pasa)
- Probar registrarse sin ingresar sus datos (falla)
- Probar registrarse con un correo electrónico no válido (falla)
- Probar registrarse con Facebook y no autorizar el acceso (falla)
- Probar registrarse sin acceso al número de teléfono del dispositivo móvil (falla)

## Registrar Taxista
Como Taxista, quiero registrarme en el sistema para aceptar viajes y brindar mis servicios

### Nota
- El taxista debe estar registrado en una central que haya contratado el servicio.
- El taxista debe ingresar el número de taxi, el dominio, sus datos de identificación y la central a la que pertenece.

### Pruebas

- Probar registrarse ingresando todos los datos válidos y estando registrado en una central (pasa)
- Probar registrarse ingresando todos los datos y no está registrado en una central (falla)
- Probar registrarse sin ingresar los datos del taxi (falla)
- Probar registrarse sin ingresar sus datos de identificación (falla)

## Pedir Taxi Deseado
> Por otro alumno

Como pasajero, quiero seleccionar un taxi de los disponibles para realizar un viaje.
### Notas:
- Se debe emitir una notificación a la central de taxi y al celular del taxista seleccionado.
- Debe tener la ubicación activada y GPS con señal disponible

### Pruebas:
- Probar pedir un taxi de los disponibles más cercanos (Pasa)
- Probar pedir un taxi cuando no hay disponibles (falla)
- Probar pedir un taxi sin señal de GPS (falla)
- Probar pedir un taxi sin acceso a Internet (falla)

## Actualizar Estado Viaje
Como Taxista, quiero confirmar el inicio *y* el fin del viaje para informar a la central el estado de mi Móvil.
> Se puede (y conviene) dividirla en dos historias. Se detecta buscando los "y".

### Nota
- El taxista debe tener un viaje en estado solicitado para iniciarlo.
>Corregido: El taxi debe estar en estado "solicitado" para poder iniciar el viaje
- El taxista debe tener un viaje en estado activo para finalizarlo.
>Corregido: El taxi debe tener un viaje en estado Iniciado/Ocupado para poder finalizarlo


### Pruebas
- Probar confirmar el inicio de un viaje en estado solicitado (pasa)
- Probar confirmar el inicio de un viaje sin estado solicitado (falla)
- Probar confirmar el fin de un viaje en estado activo (pasa)
- Probar confirmar el fin de un viaje sin estado activo (falla)

## Ver Taxi Pedido
Como Taxista, quiero ver el estado de la solicitud para conocer la posición del pasajero e irlo a buscar.

## Ver Móviles de Central
Como Administrativo de la Central, quiero ver los taxis de mi central para poder conocer el estado y posicionamiento de los mismos.

### Notas
- El taxista debe tener habilitada la ubicación 