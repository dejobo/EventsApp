(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/users/users.html',
                    title: 'users',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-user"></i> Users'
                    }
                }
            }, {
                url: '/users/:userId',
                config: {
                    templateUrl: 'app/users/userProfile.html',
                    title: 'user profile',
                    settings: {
                        content: '<i class="fa fa-users"></i> User Profile'
                    }
                }
            }, {
                url: '/events',
                config: {
                    title: 'events',
                    templateUrl: 'app/events/events.html',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-flag"></i> Events'
                    }
                }
            }, {
                url: '/events/:eventId',
                config: {
                    title: 'event',
                    templateUrl: 'app/events/eventEdit.html',
                    settings: {
                        content: '<i class="fa fa-lock"></i> Event'
                    }
                }
            }
        ];
    }
})();