var deliverEatApp = angular.module("deliverEatApp", []);
deliverEatApp.controller("controller", function ($scope, $http) {

    $scope.tarjetaFlag = false;
    $scope.horarioFlag = false;
    $scope.ciudades = [{ id: 1, nombre: "Cordoba" },
        { id: 2, nombre: "Rosario" },
        { id: 3, nombre: "Buenos Aires" }];

    $scope.Pedido = {
        DomicilioOrigen: {
            Calle: "",
            Numero: "",
            Descripcion: "",
            Ciudad: $scope.ciudades[0],
            CiudadId: 0
        },
        DomicilioDestino: {
            Calle: "",
            Numero: "",
            Descripcion: "",
            Ciudad: $scope.ciudades[0],
            CiudadId: 0
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
    }

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
                Ciudad: $scope.ciudades[0],
            },

            DomicilioDestino: {
                Calle: "",
                Numero: "",
                Descripcion: "",
                Ciudad: $scope.ciudades[0],
            },

            Tarjeta: {
                Numero: "",
                NombreTitular: "",
                Anio: "",
                Mes: "",
                CVC: ""
            },
        }
        $scope.frmPedido.$setPristine(true);
    };

    $scope.grabar = function () {
        $scope.Pedido.FormaPagoId = $scope.tarjetaFlag ? 2 : 1;

        if ($scope.tarjetaFlag) {
            $scope.Pedido.Monto = 0;
        } else {
            $scope.Pedido.Tarjeta.Numero = "";
            $scope.Pedido.Tarjeta.NombreTitular = "";
            $scope.Pedido.Tarjeta.Anio = "";
            $scope.Pedido.Tarjeta.Mes = "";
            $scope.Pedido.Tarjeta.CVC = 0;
        };
        if (!$scope.horarioFlag) {
            $scope.Pedido.FechaHoraEntrega = new Date;
        };

        for (var i = 0; i < $scope.ciudades.length; i++) {
            if ($scope.ciudades[i] === $scope.Pedido.DomicilioDestino.Ciudad) {
                $scope.Pedido.DomicilioDestino.CiudadId = i;
            };
        };

        for (var i = 0; i < $scope.ciudades.length; i++) {
            if ($scope.ciudades[i] === $scope.Pedido.DomicilioOrigen.Ciudad) {
                $scope.Pedido.DomicilioOrigen.CiudadId = i;
            };
        };

        $http.post("api/pedidos", $scope.Pedido).then(function (response) {
            window.alert("Pedido Enviado");
        });
        $scope.limpiarFormulario();
    }

    $scope.grabarImagen = function() {
        $http.post("api/uploads", $scope.FuenteImagen).then(function (response) {
            $scope.Pedido.Imagen = response;
        })
    }
});