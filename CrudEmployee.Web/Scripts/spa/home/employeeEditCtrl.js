(function (app) {
    'use strict';

    app.controller('employeeEditCtrl', employeeEditCtrl);

    employeeEditCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService'];

    function employeeEditCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService) {
        $scope.pageClass = 'page-employees';
        $scope.employee = {};
        $scope.positions = [];
        $scope.loadingEmployee = true;
        $scope.isReadOnly = false;
        $scope.UpdateEmployee = UpdateEmployee;
        $scope.prepareFiles = prepareFiles;
        $scope.openDatePicker = openDatePicker;

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };
        $scope.datepicker = {};

        var employeeImage = null;

        function loadEmployee() {
            $scope.loadingEmployee = true;

            apiService.get('/home/getemployee/' + $routeParams.id, null, employeeLoadCompleted, employeeLoadFailed);
        }

        function employeeLoadCompleted(result) {
            $scope.employee = result.data;
            $scope.loadingEmployee = false;
            
            loadPositions();
        }

        function employeeLoadFailed() {
            notificationService.displayError(response.data);
        }

        function positionsLoadCompleted(response) {
            $scope.positions = response.data;
        }

        function positionsLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function loadPositions() {
            apiService.get('/home/getPositions/', null, positionsLoadCompleted, positionsLoadFailed);
        }

        function UpdateEmployee() {
            if (employeeImage) {
                fileUploadService.uploadImage(employeeImage, $scope.employee.Id, UpdateEmployeeModel);
            }
            else
                UpdateEmployeeModel();
        }

        function UpdateEmployeeModel() {
            apiService.post('/home/update', $scope.employee,
            updateEmployeeSucceded,
            updateEmployeeFailed);
        }

        function prepareFiles($files) {
            employeeImage = $files;
        }

        function updateEmployeeSucceded(response) {
            console.log(response);
            notificationService.displaySuccess($scope.employee.LastName + ' был обновлен');
            $scope.employee = response.data;
            employeeImage = null;
        }

        function updateEmployeeFailed(response) {
            notificationService.displayError(response);
        }

        function openDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.datepicker.opened = true;
        };

        loadEmployee();
    }
})(angular.module('crudEmployee'));