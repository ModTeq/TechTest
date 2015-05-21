app.controller('peopleController',
    function PeopleController($scope, peopleService) {
        $scope.people = peopleService.query();

        $scope.isPalindrome = function (str) {
            if (str.toLowerCase().replace(' ', '') === str.toLowerCase().replace(' ', '').split('').reverse().join('')) {
                return 'Yes';
            } else {
                return 'No';
            }
        }


    }
);