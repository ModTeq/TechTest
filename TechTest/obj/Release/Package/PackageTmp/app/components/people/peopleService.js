app.factory('peopleService', function($resource) {
    return $resource('api/people/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    });
});