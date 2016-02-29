(function () {
    'use strict';

    angular
        .module('app.events')
        .controller('eventEdit', eventEdit);

    eventEdit.$inject = ['$location', '$routeParams', 'common', 'dataservice', 'logger'];

    function eventEdit($location, $routeParams, common, dataservice, logger) {
        /* jshint validthis:true */
        var vm = this;
        var eventId = $routeParams.eventId;
        vm.save = save;

        activate();

        function activate() {
            var promises = [];

            if (eventId === 'new') {
                promises = [getUsers()];
                vm.title = 'New Event';
                
            } else {
                promises = [getEvent(), getEventUsers()];
            }

            common.activateController(promises, 'eventEdit');
        }

        function getEvent() {
            return dataservice.getEvent(eventId, true).then(function (data) {
                vm.event = data;
                vm.title = vm.event.title;
                return vm.event;
            });
        }

        function getEventUsers() {
            return dataservice.getEventUsers(eventId, true).then(function (data) {
                vm.users = data.users;
                return vm.users;
            });
        }

        function getUsers() {
            return dataservice.getUsers().then(function(data) {
                vm.users = data;
                return vm.users;
            });
        }

        function save(event) {
            //clear
            event.users = [];

            angular.forEach(vm.users, function(value, key) {
                if (value.isSelected) {
                    this.push(value);
                }
            }, event.users);

            console.log("Selected Users: " + event);

            if (eventId === 'new') {
                dataservice.addEvent(event).then(function () {
                    logger.logSuccess(event.title + " added!");
                    //redirect to events
                    $location.path("/events");
                });
            } else {
                dataservice.updateEvent(eventId, event).then(function() {
                    logger.logSuccess(event.title + " updated!", event, 'eventEdit', true);
                });
            }

        }
    }
})();
