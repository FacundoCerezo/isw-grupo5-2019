var deliverEatApp = angular.module("deliverEatApp", ['ngMask']);
deliverEatApp.controller("controller", function ($scope, $http) {

    $scope.tarjetaFlag = false;
    $scope.horarioFlag = false;
    $scope.ciudades = [];

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
            var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0'); 
            var yyyy = today.getFullYear();
            var horas = $scope.Pedido.FechaHoraEntrega.getHours();
            $scope.Pedido.FechaHoraEntrega.setFullYear(yyyy);
            $scope.Pedido.FechaHoraEntrega.setMonth(mm);
            $scope.Pedido.FechaHoraEntrega.setDate(dd);
            $scope.Pedido.FechaHoraEntrega.setHours(horas-3);
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
		}, function (status) { window.alert("Error: " + status) });
	};


});