app.controller('personController', 
    function ($scope, $routeParams, $location, peopleService, colourService) {

        $scope.person = peopleService.get({ id: $routeParams.personId });

        $scope.saveForm = function () {
            peopleService.update($scope.person,
                function (data) {
                    $location.path('#');
                },
                function(e) {
                    console.log('Error:' + e);
                });
        };

        $scope.colours = colourService.query();



    });

