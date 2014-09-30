
app.controller("ngAddArtworkController", function ($scope, $http, $location) {
    console.log("ngAddArtwork");

    $scope.cancel = function () { $location.path("/Artworks"); };

    $scope.saveArtwork = function (artwork) {
        $http.post("/api/values", artwork).success(function (data) {
            artwork = data;
            $location.path("/Detail/" + artwork.Id);
        }).error(function (data) {
            console.log(JSON.stringify(data));
            $location.path("/");
        });
    };
});