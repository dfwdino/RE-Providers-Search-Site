var myApp = angular.module('myModule', []);

myApp.controller('myController', function ($scope) {
    $scope.init = function (Users) {
        $scope.sortType = 'LoginName';
        $scope.sortReverse = true;
        $scope.Users = Users;
    }
});