(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('dataservice', dataservice);

    dataservice.$inject = ['$http', 'common', 'config'];

    function dataservice($http, common, config) {
        var $q = common.$q;
        
        var service = {
            getUsers: getUsers,
            getUser: getUser,
            getEvents: getEvents,
            getEvent: getEvent,
            getEventUsers: getEventUsers,
            addEvent: addEvent,
            updateEvent: updateEvent
        };

        return service;

        function getUsers(forceRemote) {
            var useCache = true;
            if (forceRemote) {
                useCache = false;
            }
            var deferred = $q.defer();
            $http.get('api/users', { cache: useCache })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }

        function getUser(id, forceRemote) {
            var useCache = true;
            if (forceRemote) {
                useCache = false;
            }
            var deferred = $q.defer();
            $http.get('api/users/' + id, { cache: useCache })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }

        function getEvents(forceRemote) {
            var useCache = true;
            if (forceRemote) {
                useCache = false;
            }
            var deferred = $q.defer();
            $http.get('api/events', { cache: useCache })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }

        function getEvent(id, forceRemote) {
            var useCache = true;
            if (forceRemote) {
                useCache = false;
            }
            var deferred = $q.defer();
            $http.get('api/events/' + id, { cache: useCache })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }

        function getEventUsers(eventId, forceRemote) {
            var useCache = true;
            if (forceRemote) {
                useCache = false;
            }
            var deferred = $q.defer();
            $http.get('api/events/' + eventId + '/users', { cache: useCache })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }

        function addEvent(model) {
            var deferred = $q.defer();
            $http.post('api/events', model)
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }

        function updateEvent(id, model) {
            var deferred = $q.defer();
            $http.put('api/events/' + id, model)
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }
    }
})();