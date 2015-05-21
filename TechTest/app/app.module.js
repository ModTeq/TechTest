var app = angular.module('app', ['ngResource', 'ngRoute', 'checklist-model'])
    .config(function($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: 'app/components/people/peopleView.html',
        controller: 'peopleController'
    });

    $routeProvider.when('/home', {
        templateUrl: 'app/components/people/peopleView.html',
        controller: 'peopleController'
    });

    $routeProvider.when('/person/:personId',
    {
        templateUrl: 'app/components/person/personView.html',
        controller: 'personController'
    });

    $routeProvider.otherwise({ redirectTo: '/home' });
});