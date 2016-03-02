'use strict';

/**
 * @ngdoc function
 * @name jenkinApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the jenkinApp
 */
angular.module('jenkinApp')
  .controller('FileCtrl', function ($scope, $http, resourceServerUrl, Upload) {
      var sampleFolder = 'testFolder';
      $scope.submit = function (files) {
          if (files) {
              $scope.upload(files);
          }
      };
      $scope.upload = function (files) {
          var successCount = 0;
          if (files && files.length) {
              for (var i = 0; i < files.length; i++) {
                  Upload.upload({
                      url: resourceServerUrl.requestUrl + 'api/test/upload?folder=' + sampleFolder + "&filekey=" + "",
                      file: files[i]    
                  }).progress(function (evt) {
                      evt.config.file.progress = Math.min(100, parseInt(100.0 * evt.loaded / evt.total));
                  }).success(function (data, status, headers, config) {
                      successCount++;
                      config.file.isSuccess = true;
                      console.log('file ' + config.file.name + 'uploaded. Response: ' + data);
                      if (successCount == files.length) {
                          $scope.isUploadComplete = true;   // 선택했던파일에대해전송을완료했음을표시
                          console.log("알림", "파일업로드를완료하였습니다.");
                      }
                  }).error(function (data, status, headers, config) {
                      console.log('error status: ' + status);
                  })
              }
          }
      }
  });
