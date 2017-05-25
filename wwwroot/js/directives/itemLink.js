app.directive('itemLink', function () {
    var r = Math.random();
    return {
        restrict: 'E',
        link: function (scope, elem, attrs) {
            scope.icon = attrs.icon;
            scope.name = attrs.name;
            scope.link = attrs.link;
        },
        templateUrl: 'js/directives/itemLink.html?v=' + r
    };
});