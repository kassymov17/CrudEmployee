(function (app) {
    'use strict';

    app.factory('fileUploadService', fileUploadService);

    fileUploadService.$inject = ['$rootScope', '$http', '$timeout', '$upload', 'notificationService'];

    function fileUploadService($rootScope, $http, $timeout, $upload, notificationService) {
        $rootScope.upload = [];
        
        var service = {
            uploadImage: uploadImage
        }

        function uploadImage($files, employeeId, callback) {
            // $files: an array of files selected
            for (var i = 0; i < $files.length; i++) {
                var $file = $files[i];
                (function (index) {
                    $rootScope.upload[index] = $upload.upload({
                        url: "/home/uploadimage?employeeId=" + employeeId,
                        method: "POST",
                        file: $file
                    }).progress(function (evt) {
                    }).success(function (data, status, headers, config) {
                        // успешно загружен файл
                        notificationService.displaySuccess(data.FileName + ' успешно загружен');
                        callback();
                    }).error(function (data, status, headers, config) {
                        notificationService.displayError(data.Message);
                    });
                })(i);
            }
        }

        return service;
    }

})(angular.module('common.core'));