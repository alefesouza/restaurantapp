var app = angular.module('RestaurantApp', ['ngRoute', 'ngMaterial', 'ngMessages', 'ng-file-model']);

app.config(function ($routeProvider, $locationProvider, $mdThemingProvider) {
    $mdThemingProvider.theme("default")
        .primaryPalette('red')
        .accentPalette('yellow');

    var r = Math.random();

    $locationProvider.html5Mode(true);

    $routeProvider
        .when("/", {
            type: "index",
            title: "Início",
            controller: "IndexController",
            templateUrl: "views?v=" + r
        })
        .when("/admin", {
            type: "admin",
            title: "Gerenciar produtos",
            controller: "AdminController",
            templateUrl: "views/admin?v=" + r
        })
        .when("/admin/products/:id", {
            type: "admin",
            title: "Produtos",
            controller: "ProductsController",
            templateUrl: "views/product?v=" + r
        })
        .when("/cooker", {
            type: "employer",
            title: "Cozinha",
            controller: "CookerController",
            templateUrl: "views/employer/cooker?v=" + r
        })
        .when("/waiter", {
            type: "employer",
            title: "Atendente",
            controller: "WaiterController",
            templateUrl: "views/employer/waiter?v=" + r
        })
        .when("/cashier", {
            type: "employer",
            title: "Caixa",
            controller: "CashierController",
            templateUrl: "views/employer/cashier?v=" + r
        })
        .when("/settings", {
            type: "app",
            title: "Configurações",
            controller: "SettingsController",
            templateUrl: "views/settings?v=" + r
        })
        .when("/about", {
            type: "app",
            title: "Sobre",
            controller: "AboutController",
            templateUrl: "views/about?v=" + r
        })
        .otherwise({
            redirectTo: '/'
        });
});

app.run(['$rootScope', '$location', '$routeParams', '$mdSidenav', '$http', function ($rootScope, $location, $routeParams, $mdSidenav, $http) {
    $rootScope.toggleDrawer = function () {
        $mdSidenav("left-drawer").toggle();
    }

    $rootScope.$on('$routeChangeSuccess', function (event, current, previous) {
        $rootScope.title = current.$$route.title;
        $rootScope.route = current.$$route.originalPath;
    });

    $http({
        method: 'GET',
        url: '/api/config'
    }).then(function success(response) {
        $rootScope.restaurant = response.data.result;
    }, function error(response) {
        console.log(response);
    });

    $rootScope.drawer = {
        items: [
            {
                icon: "home",
                name: "Início",
                link: "/",
                type: "link"
            },
            {
                icon: "",
                name: "Administrador",
                type: "header"
            },
            {
                icon: "mode_edit",
                name: "Gerenciar produtos",
                link: "/admin",
                type: "link"
            },
            {
                icon: "",
                name: "Funcionário",
                type: "header"
            },
            {
                icon: "note",
                name: "Atendente",
                link: "/waiter",
                type: "link"
            },
            {
                icon: "restaurant",
                name: "Cozinheiro",
                link: "/cooker",
                type: "link"
            },
            {
                icon: "attach_money",
                name: "Caixa",
                link: "/cashier",
                type: "link"
            },
            {
                icon: "",
                name: "Aplicativo",
                type: "header"
            },
            {
                icon: "settings",
                name: "Configurações",
                link: "/settings",
                type: "link"
            },
            {
                icon: "info",
                name: "Sobre",
                link: "/about",
                type: "link"
            }
        ]
    }
}]);