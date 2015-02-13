require.config({
    paths: {
        entityService: "/sitecore/shell/client/Services/Assets/lib/entityservice"
    }
});

define(["sitecore", "jquery", "underscore", "entityService"], function (Sitecore, $, _, entityService) {
    var EntityServiceDemo = Sitecore.Definitions.App.extend({

        filesUploaded: [],

        initialized: function () {
            this.ListControl1.on("change:selectedItemId", this.ItemSelected, this);
            this.GetNewsArticles();
        },

        initialize: function () {


        },

        EntityServiceConfig: function () {
            var newsService = new entityService({
                url: "/sitecore/api/ssc/MikeRobbins-EntityServiceDemo-Controllers/NewsArticles"
            });

            return newsService;
        },

        GetNewsArticles: function () {

            var newsService = this.EntityServiceConfig();

            var datasource = this.DataSource;

            var result = newsService.fetchEntities().execute().then(function (newsArticles) {
                datasource.viewModel.items(newsArticles);
            });

        },

        ItemSelected: function () {
            if (!this.aeItemDetails.viewModel.isOpen()) {
                this.aeItemDetails.viewModel.toggle();
            }

            var newsService = this.EntityServiceConfig();

            var selectedId = this.ListControl1.viewModel.selectedItemId();

            var self = this;

            var result = newsService.fetchEntity(selectedId).execute().then(function (newsArticle) {
                self.tbID.viewModel.text(newsArticle.Id);
                self.tbTitle.viewModel.text(newsArticle.Title);
                self.tbDescription.viewModel.text(newsArticle.Description);
                self.dpDate.viewModel.setDate(newsArticle.Date);
            });

        },

        UpdateArticle: function() {
            var newsService = this.EntityServiceConfig();
        },

        DeleteArticle: function() {
            var newsService = this.EntityServiceConfig();

            var successMessage = this.mbDeleted;

            var itemId = this.ListControl1.viewModel.selectedItemId();

            var result = newsService.fetchEntity(itemId).execute().then(function (newsArticle) {
                newsArticle.destroy().then(function () {
                    successMessage.viewModel.show();
                });
            });
        },

        AddArticle: function() {
            var newsService = this.EntityServiceConfig();

            var newsArticle = {
                Title: this.tbTitle.viewModel.text(),
                Description: this.txtDescription.viewModel.text(),
                Date: this.dpDate.viewModel.getDate()
            };

            var result = newsService.create(newsArticle).execute().then(function (newArticle) {
                var test = "";
            });

        },

    });

    return EntityServiceDemo;
});