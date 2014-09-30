
app.controller("ngEditArtworkController", function ($scope, $http, $location, $routeParams) {
    console.log("ngEditArtwork");
    $scope.artwork;

    $scope.isEdit = true;

    $scope.cancel = function () { $location.path("/Detail/" + $routeParams.id); };

    $scope.saveArtwork = function (artwork) {
        $http.put("/api/values/" + $routeParams.id, artwork).success(function (data) {
            $location.path("/Detail/" + data.Id);
        }).error(function (data) {
            console.log(JSON.stringify(data));
            $location.path("/");
        })
    }

    $scope.deleteArtwork = function (artwork) {
        $http.delete("/api/values/" + artwork.Id).success(function (data) {
            $location.path("/Artworks");
        }).error(function (data) {
            console.log(JSON.stringify(data));
            $location.path("/");

        });
    };

    $http.get("/api/values/" + $routeParams.id).success(function (data) {
        $scope.artwork = data;
    }).error(function (data) {
        console.log(JSON.stringify(data));
    });
});