var deliverEatApp = angular.module("deliverEatApp", []);
deliverEatApp.controller("controller", function ($scope, $http) {

    $scope.tarjetaFlag = false;
    $scope.horarioFlag = false;
    $scope.ciudades = [{ id: 1, nombre: "Cordoba" },
        { id: 2, nombre: "Rosario" },
        { id: 3, nombre: "Buenos Aires" }];

    $scope.limpiarFormulario = function () {
        $scope.Pedido = {
            Monto: "",
            FechaHoraEntrega: "",
            Imagen: "",
            Descripcion: "",
            FormaPagoId: 1,
            EstadoPedidoId: 1,

            DomicilioOrigen: {
                Calle: "",
                Numero: "",
                Descripcion: "",
                Ciudad: $scope.ciudades[0]
            },

            DomicilioDestino: {
                Calle: "",
                Numero: "",
                Descripcion: "",
                Ciudad: $scope.ciudades[0]
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
            $scope.Pedido.Monto = "";
        } else {
            $scope.Pedido.Tarjeta.Numero = "";
            $scope.Pedido.Tarjeta.NombreTitular = "";
            $scope.Pedido.Tarjeta.Anio = "";
            $scope.Pedido.Tarjeta.Mes = "";
            $scope.Pedido.Tarjeta.CVC = "";
        };
        if (!$scope.horarioFlag) {
            $scope.Pedido.FechaHoraEntrega = null;
        };

        $http.post("api/pedidos", $scope.Pedido).then(function (response) {
            window.alert("Pedido Enviado");
        });
        $scope.limpiarFormulario();
    }
});