(function () {
    'use strict';

    angular
        .module('app.users')
        .controller('userProfile', userProfile);

    userProfile.$inject = ['$location', '$routeParams', 'common', 'dataservice'];

    function userProfile($location, $routeParams, common, dataservice) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'user profile';
        vm.dim = function(time) {
            if (moment(time) < new Date()) {
                return 'list-group-item-warning';
            }
        };

        activate();

        function activate() {
            common.activateController([getUser()], 'userProfile');
        }

        function getUser() {
            return dataservice.getUser($routeParams.userId).then(function(data) {
                vm.user = data;
                return vm.user;
            });
        }
    }
})();
