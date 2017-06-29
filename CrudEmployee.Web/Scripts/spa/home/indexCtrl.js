//(function (app) {
//    'use strict';

//    app.controller('indexCtrl', indexCtrl);

//    indexCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

//    function indexCtrl($scope, apiService, notificationService) {
//        $scope.pageClass = 'page-home';
//        $scope.loadingEmployees = true;

//        $scope.isReadOnly = true;
//        $scope.listEmployees = [];
//        $scope.loadData = loadData;

//        function loadData() {
//            apiService.get('/home/employeelist', null,
//                employeesLoadCompleted,
//                employeesLoadFailed);
//        }

//        function employeesLoadCompleted(result) {
//            $scope.listEmployees = result.data.Items;
//            $scope.loadingEmployees = false;
//        }

//        function employeesLoadFailed(response) {
//            notificationService.displayError(response.data);
//        }

//        loadData();
//    }

//})(angular.module('crudEmployee'));
(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function indexCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-employees';
        $scope.loadingEmployees = true;
        $scope.page = 0;
        $scope.pagesCount = 0;

        $scope.Employees = [];

        $scope.search = search;
        $scope.clearSearch = clearSearch;

        function search(page) {
            page = page || 0;

            $scope.loadingEmployees = true;

            var config = {
                params: {
                    page: page,
                    pageSize: 6,
                    filter: $scope.filterEmployees
                }
            };

            apiService.get('/home/employeelist/', config,
            employeesLoadCompleted,
            employeesLoadFailed);
        }

        function employeesLoadCompleted(result) {
            $scope.Employees = result.data.Items;
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;
            $scope.loadingEmployees = false;

            if ($scope.filterEmployees && $scope.filterEmployees.length) {
                notificationService.displayInfo(result.data.Items.length + ' сотрудников найдено')
            }
        }

        function employeesLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.filterEmployees = '';
            search();
        }

        $scope.search();
    }

})(angular.module('crudEmployee'));