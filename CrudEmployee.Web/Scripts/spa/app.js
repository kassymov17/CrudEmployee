(function () {
    'use strict';

    angular.module('crudEmployee', ['common.core', 'common.ui'])
        .config(config)
     
    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "/scripts/spa/home/index.html",
                controller: "indexCtrl"
            })
            .when("/employees", {
                templateUrl: "/scripts/spa/employees/employees.html",
                controller: "employeesCtrl"
            })
            .when("/home/add", {
                templateUrl: "/scripts/spa/employees/add.html",
                controller: "employeeAddCtrl"
            })
            .when("/employees/:id", {
                templateUrl: "/scripts/spa/home/details.html",
                controller: "employeeDetailsCtrl"
            })
            .when("/home/edit/:id", {
                templateUrl: "/scripts/spa/home/edit.html",
                controller: "employeeEditCtrl"
            })
    }

})();