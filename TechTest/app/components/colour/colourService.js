app.factory('colourService', function($resource) {
    return $resource('api/colour', {}, {
    });
});


