var deliverEatApp = angular.module("deliverEatApp", ['ngMask']);
deliverEatApp.controller("controller", function ($scope, $http) {

    $scope.tarjetaFlag = false;
    $scope.horarioFlag = false;
    $scope.ciudades = [];
	$scope.anioActual = new Date().getFullYear() - 2000;
	$scope.mesActual = new Date().getMonth();
	$scope.FechaEntrega = new Date();
	$scope.HoraEntrega = new Date();
	$scope.HoraEntrega.setSeconds(0);

    $scope.cargarCiudades = function () {
        $http.get("api/ciudades").then(function (response) {
			$scope.ciudades = response.data;
			console.log($scope.ciudades);
        });
    };
	$scope.cargarCiudades();

	

    $scope.Pedido = {
        DomicilioOrigen: {
            Calle: "",
            Numero: "",
            Descripcion: "",
        },
        DomicilioDestino: {
            Calle: "",
            Numero: "",
            Descripcion: "",
        },
        Monto: "",
        EstadoPedidoId: 1,
        FormaPagoId: 1,
        Tarjeta: {
            Numero: "",
            NombreTitular: "",
            Anio: "",
            Mes: "",
            CVC: ""
        },
        FechaHoraEntrega: null,
        Imagen: "",
        Descripcion: "",
    };

    $scope.limpiarFormulario = function () {
        $scope.Pedido = {
            Monto: "",
            FechaHoraEntrega: null,
            Imagen: "",
            Descripcion: "",
            FormaPagoId: 1,
            EstadoPedidoId: 1,

            DomicilioOrigen: {
                Calle: "",
                Numero: "",
                Descripcion: "",
            },

            DomicilioDestino: {
                Calle: "",
                Numero: "",
                Descripcion: "",
            },

            Tarjeta: {
                Numero: "",
                NombreTitular: "",
                Anio: "",
                Mes: "",
                CVC: ""
            },
        }
        $scope.CiudadDestino = $scope.ciudades[0];
        $scope.CiudadOrigen = $scope.ciudades[0];
        $scope.frmPedido.$setPristine(true);
	};

	$scope.getCombinedDateTime = function (date, time) {
		var datePart = date.toISOString().substring(0, 10);
		var timePart = time.toISOString().substring(10, 24);
		return new Date(datePart + timePart);
	};

    $scope.grabar = function () {
        $scope.Pedido.FormaPagoId = ($scope.tarjetaFlag ? 2 : 1);

        if ($scope.tarjetaFlag) {
            $scope.Pedido.Monto = 0;
        } else {
            /*$scope.Pedido.Tarjeta.Numero = "";
            $scope.Pedido.Tarjeta.NombreTitular = "";
            $scope.Pedido.Tarjeta.Anio = "";
            $scope.Pedido.Tarjeta.Mes = "";
            $scope.Pedido.Tarjeta.CVC = 0;*/
			$scope.Pedido.Tarjeta = undefined;
			delete $scope.Pedido.Tarjeta;
        };
        if (!$scope.horarioFlag) {
            $scope.Pedido.FechaHoraEntrega = new Date;
		} else {
			var today = $scope.FechaEntrega;
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0'); 
			var yyyy = today.getFullYear();
			var horas = $scope.HoraEntrega.getHours();
			var minutos = $scope.HoraEntrega.getMinutes();
		/*var horas = $scope.Pedido.FechaHoraEntrega.getHours();*/
			$scope.Pedido.FechaHoraEntrega = new Date;
            $scope.Pedido.FechaHoraEntrega.setFullYear(yyyy);
            $scope.Pedido.FechaHoraEntrega.setMonth(mm);
            $scope.Pedido.FechaHoraEntrega.setDate(dd);
			$scope.Pedido.FechaHoraEntrega.setHours(horas - 3);
			$scope.Pedido.FechaHoraEntrega.setMinutes(minutos);
		}

		
/*
        for (var i = 0; i < $scope.ciudades.length; i++) {
            if ($scope.ciudades[i] === $scope.CiudadDestino) {
                $scope.Pedido.DomicilioDestino.CiudadId = i;
            };
        };

        for (var i = 0; i < $scope.ciudades.length; i++) {
            if ($scope.ciudades[i] === $scope.CiudadOrigen) {
                $scope.Pedido.DomicilioOrigen.CiudadId = i;
            };
        };*/

        $http.post("api/pedidos", $scope.Pedido).then(function (response) {
            window.alert("Pedido Enviado");
        });
        $scope.limpiarFormulario();
    };

    $scope.cargarOrigen = function () {
        $scope.Pedido.DomicilioOrigen = {
                Calle: "Bv. Chacabuco",
                Numero: 480,
                Descripcion: "Entre Bv Illia y Rondeau"
        }
        $scope.Pedido.DomicilioOrigen.CiudadId = 1;
    }

    $scope.cargarDestino = function () {
        $scope.Pedido.DomicilioDestino = {
            Calle: "Ituzaingo",
            Numero: 655,
            Descripcion: "Entre Obispo Oro y San Lorenzo"
        }
		$scope.Pedido.DomicilioDestino.CiudadId = 1;
	}

	$scope.cargarFoto = function (files) {
		var fd = new FormData();
		//Take the first selected file
		fd.append("file", files[0]);
		$http.post("api/uploads", fd,
			{
				headers: { 'Content-Type': undefined },
				transformRequest: angular.identity
			}
		).then(function(data){
			$scope.Pedido.Imagen = data.data;
		}, function (status) { console.log(status); window.alert("Error: " + status.status +" "+status.statusText +"\n"+status.data) });
	};


});

deliverEatApp.directive
	('cardExpiration'
		, function () {
			var directive =
			{
				require: 'ngModel'
				, link: function (scope, elm, attrs, ctrl) {
					scope.$watch('[Pedido.Tarjeta.Mes,Pedido.Tarjeta.Anio]', function (value) {
						ctrl.$setValidity('invalid', true)
						if (scope.Pedido.Tarjeta.Anio == scope.anioActual
							&& scope.Pedido.Tarjeta.Mes <= scope.mesActual
							&& scope.tarjetaFlag
						) {
							ctrl.$setValidity('invalid', false)
						}
						return value
					}, true)
				}
			}
			return directive
		}
)

deliverEatApp.directive
	('validEntrega'
		, function () {
			var directive =
			{
				require: 'ngModel'
				, link: function (scope, elm, attrs, ctrl) {
					scope.$watch('[FechaEntrega,HoraEntrega]', function (value) {
						ctrl.$setValidity('invalid', true);
						var today = new Date();
						today.setSeconds(0);

						var dd = scope.FechaEntrega.getDate();
						var mm = scope.FechaEntrega.getMonth();
						var yyyy = scope.FechaEntrega.getFullYear();

						var horas = scope.HoraEntrega.getHours();
						var minutos = scope.HoraEntrega.getMinutes();

						var test = new Date;
						test.setFullYear(yyyy);
						test.setMonth(mm);
						test.setDate(dd);
						test.setHours(horas);
						test.setMinutes(minutos);
						test.setSeconds(0);

						console.log(today);
						console.log(test)

						if (test < today
							&& scope.horarioFlag
						) {
							ctrl.$setValidity('invalid', false)
						}
						return value
					}, true)
				}
			}
			return directive
		}
	)