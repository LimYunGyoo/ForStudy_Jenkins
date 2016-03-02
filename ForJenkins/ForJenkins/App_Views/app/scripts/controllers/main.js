'use strict';

/**
 * @ngdoc function
 * @name jenkinApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the jenkinApp
 */
angular.module('jenkinApp')
  .controller('MainCtrl', function ($scope, $http, resourceServerUrl) {

      $scope.slow = function () {
          $http.post(resourceServerUrl.requestUrl + 'api/slow', { 'LimitNum': 500 }).success(
              function (data) {
                  console.log(data);
              });
      }


  });
