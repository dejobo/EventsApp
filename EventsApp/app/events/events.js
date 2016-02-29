(function () {
    'use strict';

    angular
        .module('app.events')
        .controller('events', events);

    events.$inject = ['$location', 'dataservice', 'common'];

    function events($location, dataservice, common) {
        /* jshint validthis:true */
        var controllerId = "events";
        var vm = this;
        vm.title = 'events';
        vm.events = [];

        activate();

        function activate() {
            return getEvents().then(function () {
                var promises = [getEvents()];
                common.activateController(promises, controllerId);
            });
        }

        function getEvents() {
            return dataservice.getEvents(true).then(function(data) {
                vm.events = data;
                return vm.events;
            });
        }
    }
})();
