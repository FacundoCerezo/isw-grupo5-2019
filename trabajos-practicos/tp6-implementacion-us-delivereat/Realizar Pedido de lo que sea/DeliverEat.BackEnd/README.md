# DeliverEat.BackEnd 
Este proyecto contiene la capa de datos para acceder a la base SQLite mediante REST.

## Ejemplo para crear un pedido desde JavaScript

Para agregar un pedido desde la API REST se hace una solicitud POST a `/api/pedidos`

`{
	"DomicilioOrigen": {
		"Calle": "Maipu",
		"Numero": "3235",
		"Descripcion": "Kiosko 'La hormiga'",
		"CiudadId": 1
	},
	"DomicilioDestino": {
		"Calle": "General Paz",
		"Numero": "353",
		"Descripcion": "6F, al lado de rotiseria",
		"CiudadId": 1
	},
	"Monto": 300,
	"EstadoPedidoId": 2,
	"FormaPagoId": 2,
	"Tarjeta": {
			"Numero": 9329103920493294,
			"NombreTitular": "Facundo Cerezo",
			"Anio": 29,
			"Mes": "09",
			"CVC": 324
	},
	"Descripcion": "Mochila Intercalar de color Negro"
}`