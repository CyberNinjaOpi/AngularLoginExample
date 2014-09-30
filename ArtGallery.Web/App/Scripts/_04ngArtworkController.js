
app.factory("Artworks", function () {
    return [];
})

app.controller("ngArtworkController", function ($scope, $http, Artworks, $location) {
    console.log("ngArtwork");
    $scope.viewDetail = function (id) {
        console.log(id);
        $location.path("/Detail/" + id);
    };

    $scope.artworks = Artworks;

    $http.get("api/values").success(function (data) {
        console.log("GET success");
        $scope.artworks = data;
    }).error(function (data) {
        console.log(JSON.stringify(data));
    });
});