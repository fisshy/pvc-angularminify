pvc-angularpreminifier
========

### Input
```js
angular.module('myApp', []).run(function($rootScope){
  $rootScope.yo = "Yo Fishy!";
});
angular.module('myApp').controller('MyCntrl', function($scope){
  $scope.test = 'Hello World!';
  function name () {
    console.log("test");
  }
});
```

### Output
```js
angular.module('myApp', []).run(["$rootScope",function($rootScope){
  $rootScope.yo = "Yo Fishy!";
}]);
angular.module('myApp').controller('MyCntrl', ["$scope",function($scope){
  $scope.test = 'Hello World!';
  function name () {
    console.log("test");
  }
}]);

```

### After JsMinify
```js
angular.module("myApp",[]).run(["$rootScope",function(n){n.yo="Yo Fishy!"}]);angular.module("myApp").controller("MyCntrl",["$scope",function(n){n.test="Hello World!"}])
```


### Todo

1. Need to support injections within injections ( It's currently not grabbing the interceptors injection)
```js
angular.module('myModule')
.config(function ($httpProvider) {
  $httpProvider.interceptors.push(function ($q, $rootScope) {
  });
});
```