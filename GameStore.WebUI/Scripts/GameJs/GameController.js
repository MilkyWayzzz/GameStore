var GameController = {
    div: $("#viewdiv"),

    addGamesToTable: function (game) {
        var tr = $('<div class="well" style="margin-right: 10px">')
            .append($("<div>").html('<h3><strong>' + game.Name + '</strong><span class="pull-right label label-primary">' + game.Price + '</span></h3>'))
            .append($('<div class="pull-right">').html('<input type="submit" class=" btn btn-success" value="Добавить в корзину"/>'))
            .append($('<span class="lead">').text(game.Description))
        return tr
    },


    showGame: function (page) {
        this.div.empty();
        var that = this
        $.ajax({
            url: "/Game/GetGames",
            success: function (data) {
                var games = data.games
                games.map(function (game) {
                    that.div.append(that.addGamesToTable(game));
                })
                that.generatePages(data.pagecount, data.CurrentPage)
            }
        })
    },

    generatePages: function (pages, curpage) {
        var that = this
        var pagination = $("#pagination");
        for (var i = 1; i <= pages; i++) {
            var a = $('<a href="/Game/GetGames?page=' + i + '">').text(i).attr("data-page", i)

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
        this.showGame(1);
        $("#pagination").on("click", "a", function (ev) {
            $a = $(ev.currentTarget);
            var page = $a.attr("data-page");
            that.showGame(page);
        })
    },

    onDocumentReady: function () {
        this.init();
    }
}



$(document).ready(function () {
    GameController.onDocumentReady();
})