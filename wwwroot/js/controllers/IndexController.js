app.controller('IndexController', ['$scope', '$routeParams', '$rootScope', '$http', function ($scope, $routeParams, $rootScope, $http) {
    $scope.restaurant = $rootScope.restaurant;

    $scope.sendForm = function () {
        $http({
            method: 'POST',
            data: $scope.restaurant,
            url: '/api/config'
        }).then(function success(response) {
            console.log(response);
            alert("Configurações salvas com sucesso");
            //window.location.href = "/admin";
        }, function error(response) {
            console.log(response);
            alert("Houve um erro, tente novamente");
        });
    }

    $scope.open = function (employer) {
        window.location.href = "/" + employer;
    }

    $scope.file_change = function (file) {
        $scope.restaurant.logoBase64 = file.data;
        $scope.restaurant.logo = file.name;
    }
}]);