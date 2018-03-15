var GameController = {
    div: $("#viewdiv"),

    addGamesToTable: function (game) {
        var $game = $('<div class="well" style="margin-right: 10px">');

        if (game.ImageData != null)
            $game.append($('<div class="pull-left" style="margin-right: 10px">').html('<img class="img-thumbnail" width="75" height="75" src="/Game/GetImage?gameId=' + game.GameId + '" />'));

        $game
            .append($("<div>").html('<h3><strong>' + game.Name + '</strong><span class="pull-right label label-primary">' + game.Price + '</span></h3>'))
            .append($('<div class="pull-right">').html('<input type="submit" class=" btn btn-success" value="Добавить в корзину"/>'))
            .append($('<span class="lead">').text(game.Description))
        return $game;
    },

    showGame: function (page, category) {
        this.div.empty();
        var that = this

        var data = {
            page: page
        }

        if (category)
            data.category = category

        $.ajax({
            url: "/Game/GetGames/",
            data: data,
            success: function (data) {
                var games = data.games
                games.map(function (game) {
                   that.div.append(that.addGamesToTable(game));
                })
                that.generatePages(data.pagecount, data.CurrentPage)
            }
        })
    },

    showCategories: function () {
        var that = this
        var categor = $("#categories")
        $.ajax({
            url: "/Nav/Menu",
            success: function (data) {
                var categories = data.categories
                categories.map(function (category) {
                    categor.append($('<a class="btn btn-block btn-default btn-lg">').text(category).attr("data-categories", category))
                })
            }
        })
    },

    generatePages: function (pages, curpage) {
        var that = this
        var pagination = $("#pagination");
        pagination.empty();
        for (var i = 1; i <= pages; i++) {
            var a = $('<a>').text(i).attr("data-page", i)

            if (curpage == i) {
                a.addClass('btn btn-primary')
            }
            else {
                a.addClass('btn btn-default')
            }
            pagination.append(a);
        }
    },

    init: function () {
        var that = this;
        this.showCategories();
        this.showGame(1, null);
        $("#pagination").on("click", "a", function (ev) {
            $a = $(ev.currentTarget);
            var page = $a.attr("data-page");
            that.showGame(page, null);
        })
        $("#categories").on("click", "a", function (ev) {
            $a = $(ev.currentTarget);
            var categor = $a.attr("data-categories");
            that.showGame(1, categor)
        })
    },

    onDocumentReady: function () {
        this.init();
    }
}



$(document).ready(function () {
    GameController.onDocumentReady();
})