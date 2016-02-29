(function () {
    'use strict';

    angular
        .module('app.users')
        .controller('users', users);

    users.$inject = ['$location', 'common', 'dataservice'];

    function users($location, common, dataservice) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'users';
        vm.users = [];

        activate();

        function activate() {
            common.activateController([getUsers()], 'users');
        }

        function getUsers() {
            return dataservice.getUsers().then(function(data) {
                vm.users = data;
                return vm.users;
            });
        }
    }
})();
