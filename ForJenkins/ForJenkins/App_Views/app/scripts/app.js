'use strict';

/**
 * @ngdoc overview
 * @name jenkinApp
 * @description
 * # jenkinApp
 *
 * Main module of the application.
 */
angular
  .module('jenkinApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngFileUpload'
  ])
  .config(function ($routeProvider, $httpProvider) {
      $routeProvider
        .when('/', {
            templateUrl: 'views/main.html',
            controller: 'MainCtrl',
            controllerAs: 'main'
        })
        .when('/about', {
            templateUrl: 'views/about.html',
            controller: 'AboutCtrl',
            controllerAs: 'about'
        })
        .when('/file', {
            templateUrl: 'views/file.html',
            controller: 'FileCtrl',
            controllerAs: 'file'
        })
        .otherwise({
            redirectTo: '/'
        });
      $httpProvider.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
  });
