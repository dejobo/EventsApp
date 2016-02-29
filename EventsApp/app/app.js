(function () {
    'use strict';
    
    var app = angular.module('app', [
       'app.core',
       'app.users',
       'app.events'
    ]);
    
    // Handle routing errors and success events
    app.run(['$route',  function ($route) {
            // Include $route to kick start the router.
        }]);        
})();