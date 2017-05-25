app.directive('mdFile', function () {
    var r = Math.random();
    return {
        restrict: 'E',
        scope: {
            change: '&'
        },
        link: function (scope, elem, attrs) {
            scope.label = attrs.label;
            scope.name = attrs.name;
            scope.accept = attrs.accept;

            scope.change = scope.change();

            var input_file = elem.find("input")[0];
            var input_text = elem.find("input")[1];

            scope.chooseFile = function () {
                elem.find("input")[0].click();
            }

            angular.element(input_file).bind('change', function () {
                setTimeout(function () {
                    scope.change(scope.file);
                }, 1000);

                var value = input_file.files[0].name;

                $(input_text).val(value);
                $(input_text).parent().addClass("md-input-has-value");
            });
        },
        templateUrl: 'js/directives/mdFile.html?v=' + r
    };
});