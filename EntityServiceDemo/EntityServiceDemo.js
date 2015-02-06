require.config({
    paths: {
        entityService: "/sitecore/shell/client/Services/Assets/lib/entityservice"
    }
});

define(["sitecore", "jquery", "underscore", "entityService"], function (Sitecore, $, _, entityService) {
    var EntityServiceDemo = Sitecore.Definitions.App.extend({

        filesUploaded: [],

        initialized: function () {
            this.GetNewsArticles();
        },

        initialize: function () {

            this.on("selected", this.ItemSelected, this);
        },

        EntityServiceConfig: function () {
            var newsService = new entityService({
                url: "/sitecore/api/ssc/MikeRobbins-EntityServiceDemo-Controllers/NewsArticles"
            });

            return newsService;
        },

        GetNewsArticles: function() {

            var newsService = this.EntityServiceConfig();

            var datasource = this.DataSource;

            var result = newsService.fetchEntities().execute().then(function (newsArticles) {
                datasource.viewModel.items(newsArticles);
            });

        },

        ItemSelected: function() {
            alert("hello");
        }

    });

    return EntityServiceDemo;
});