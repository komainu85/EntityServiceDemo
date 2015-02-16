require.config({
    paths: {
        entityService: "/sitecore/shell/client/Services/Assets/lib/entityservice"
    }
});

define(["sitecore", "jquery", "underscore", "entityService"], function (Sitecore, $, _, entityService) {
    var EntityServiceDemo = Sitecore.Definitions.App.extend({

        that: this,

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

        UpdateArticle: function () {
            var newsService = this.EntityServiceConfig();

            var itemId = this.ListControl1.viewModel.selectedItemId();

            var self = this;

            newsService.fetchEntity(itemId).execute().then(function (newsArticle) {
                newsArticle.Title = self.tbTitle.viewModel.text();
                newsArticle.Description = self.tbDescription.viewModel.text();
                newsArticle.Date = self.DateFormatter(self.dpDate.viewModel.getDate());

                newsArticle.on('save', function() {
                    self.ArticleUpdated(self);
                });

                newsArticle.save().execute();
            });

        },

        DeleteArticle: function () {
            var newsService = this.EntityServiceConfig();

            var self = this;

            var itemId = this.ListControl1.viewModel.selectedItemId();

            var result = newsService.fetchEntity(itemId).execute().then(function (newsArticle) {
                newsArticle.destroy().then(function () {
                    self.messageBar.addMessage("notification", { text: "Item deleted successfully", actions: [], closable: true, temporary: true });
                    self.GetNewsArticles();
                });
            });
        },

        AddArticle: function () {
            var newsService = this.EntityServiceConfig();

            var newsArticle = {
                Title: this.tbTitle.viewModel.text(),
                Description: this.tbDescription.viewModel.text(),
                Date: this.dpDate.viewModel.getDate()
            };

            var self = this;

            var result = newsService.create(newsArticle).execute().then(function (newArticle) {
                self.messageBar.addMessage("notification", { text: "Item created successfully", actions: [], closable: true, temporary: true });
                self.ResetFields();
                self.GetNewsArticles();
            });

        },



        ArticleUpdated: function (self) {
           self.messageBar.addMessage("notification", { text: "Item updated successfully", actions: [], closable: true, temporary: true });
           self.ResetFields();
        },

        ResetFields: function () {
            this.tbID.viewModel.text("");
            this.tbTitle.viewModel.text("");
            this.tbDescription.viewModel.text("");
            this.dpDate.viewModel.setDate("");
        },

        SaveChanges: function () {
            if (this.tbID.viewModel.text().length === 0) {
                this.AddArticle();
            }
            else {
                this.UpdateArticle();
            }
        },

        DateFormatter: function (now) {
            return now.getFullYear() + '-' + ('0' + (now.getMonth() + 1)).slice(-2) + '-' + ('0' + now.getDate()).slice(-2) + ' ' + ('0' + (now.getHours() + 1)).slice(-2) + ':' + ('0' + now.getMinutes()).slice(-2) + ':' + ('0' + now.getSeconds()).slice(-2);
        }
    });

    return EntityServiceDemo;
});