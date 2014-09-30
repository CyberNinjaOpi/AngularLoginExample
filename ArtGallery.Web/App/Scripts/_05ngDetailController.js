
app.controller("ngDetailController", function ($scope, $http, $location, $routeParams) {
    console.log("ngDetail");

    
    $scope.artwork;

    $http.get("api/values/" + $routeParams.id).success(function (data) {
        $scope.artwork = data;
    });
});