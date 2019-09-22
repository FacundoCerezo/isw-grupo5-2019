var deliverEatApp = angular.module("deliverEatApp", []);
deliverEatApp.controller("controller", function ($scope) {

    $scope.tarjetaFlag = false;
    $scope.horarioFlag = false;
    $scope.ciudades = [{ id: 1, nombre: "Cordoba" },
        { id: 2, nombre: "Rosario" },
        { id: 3, nombre: "Buenos Aires" }];
    $scope.ciudadComercio = $scope.ciudades[0];
    $scope.ciudadEntrega = $scope.ciudades[0];

    $scope.limpiarFormulario = function () {
        $scope.calleComercio = "";
        $scope.numeroComercio = "";
        $scope.ciudadComercio = $scope.ciudades[0];
        $scope.descripcionComercio = "";
        $scope.calleEntrega = "";
        $scope.numeroEntrega = "";
        $scope.ciudadEntrega = $scope.ciudades[0];
        $scope.descripcionEntrega = "";
        $scope.monto = "";
        $scope.numeroTarjeta = "";
        $scope.apellidoNombre = "";
        $scope.anioTarjeta = "";
        $scope.mesTarjeta = "";
        $scope.cvcTarjeta = "";
        $scope.horarioEntrega = "";
        $scope.frmPedido.$setPristine(true);
    }
});