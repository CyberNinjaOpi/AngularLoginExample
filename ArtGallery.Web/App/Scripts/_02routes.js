app.config(function ($routeProvider, $httpProvider) {
    $httpProvider.interceptors.push("AuthInterceptor");
    $routeProvider.when("/", {
        templateUrl: "/App/Views/ngHome.html",
        controller: "ngHomeController"
    }).when("/Artworks/", {
        templateUrl: "/App/Views/ngArtworks.html",
        controller: "ngArtworkController"
    }).when("/Detail/:id", {
        templateUrl: "/App/Views/ngDetail.html",
        controller: "ngDetailController"
    }).when("/AddArtwork", {
        templateUrl: "/App/Views/ngArtworkForm.html",
        controller: "ngAddArtworkController"
    }).when("/EditArtwork/:id", {
        templateUrl: "/App/Views/ngArtworkForm.html",
        controller: "ngEditArtworkController"
    });
});