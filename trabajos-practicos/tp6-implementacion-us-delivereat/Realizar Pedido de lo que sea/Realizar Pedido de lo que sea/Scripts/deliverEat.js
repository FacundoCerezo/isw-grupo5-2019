var deliverEatApp = angular.module("deliverEatApp", []);
deliverEatApp.controller("controller", function ($scope) {

    $scope.tarjeta = false;
    $scope.horario = false;
    $scope.ciudades = [{ id: 1, nombre: "Cordoba" }, { id: 2, nombre: "Rosario" }, { id: 3, nombre: "Buenos Aires" }];


});