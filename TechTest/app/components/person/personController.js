app.controller('personController', 
    function ($scope, $routeParams, $location, peopleService, colourService) {

        $scope.person = peopleService.get({ id: $routeParams.personId });

        $scope.saveForm = function () {
            peopleService.update($scope.person,
                // successful response
                function (data) {
                    $location.path('#');
                },
                // error
                function(e) {
                    console.log('Error:' + e);
                });
        };

        $scope.cancel = function() {
            $location.path('#');
        };

        $scope.colours = colourService.query();
    });

