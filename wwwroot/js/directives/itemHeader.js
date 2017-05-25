app.directive('itemHeader', function () {
    var r = Math.random();
    return {
        restrict: 'E',
        link: function (scope, elem, attrs) {
            scope.name = attrs.name;
        },
        templateUrl: 'js/directives/itemHeader.html?v=' + r
    };
});