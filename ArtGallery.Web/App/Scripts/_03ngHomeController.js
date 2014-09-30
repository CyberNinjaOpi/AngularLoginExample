
app.controller("ngHomeController", function ($scope, $window, $q, LoginService, $location) {
    console.log("ngHome");

    $scope.login = function () {
        LoginService.processLogin($scope.user.username, $scope.user.password)
        .then(function () {
            $scope.token = $window.sessionStorage.getItem("token");
            $location.path("/Artworks/");
        }, function (status) {
            $scope.token = status;
        });
    };

    $scope.logout = function () {
        LoginService.processLogout().then(function () { }, function () { });
    };
});