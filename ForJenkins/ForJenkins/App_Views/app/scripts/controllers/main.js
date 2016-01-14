'use strict';

/**
 * @ngdoc function
 * @name jenkApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the jenkApp
 */
angular.module('jenkApp')
  .controller('MainCtrl', function ($http) {
    this.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];

    $http({
        method: 'GET',
        url: '/api/Text'
    }).then(function successCallback(response) {
        alert("res : " + response);
    }, function errorCallback(response) {
        alert("error!");
    });
    
  });
