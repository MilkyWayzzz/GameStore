var AdminController = {
    table: $("#first"),

    addGame: function (game) {
        var that = this
        $.ajax({
            url: "/Admin/Create",
            type: "POST",
            data: game,
            success: function (id) {
                game.GameId = id;
                that.addGameToTable(game);
            }
        })
    },

    editGame: function (game) {
        var that = this
        $.ajax({
            url: "/Admin/Edit",
            type: "POST",
            data: game,
            success: function (id) {
                game.GameId = id;
                that.addGameToTable(game);
            }
        })
    },

    showGames: function () {
        var that = this
        $.ajax({
            url: "/Admin/GetGames",
            success: function (data) {
                var games = JSON.parse(data)
                games.map(function (game) {
                    that.addGameToTable(game);
                })
            }
        })
    },

    addGameToTable: function (game) {
        var that = this;
        var tr = $("<tr>").attr("data-id", game.GameId).data('data', game)
            .append($("<td>").text(game.GameId))
            .append($("<td>").text(game.Name))
            .append($("<td>").text(game.Description))
            .append($("<td>").text(game.Category))
            .append($("<td>").text(game.Price))
            .append($("<td>").html('<button data-action="edit" type="button" class="btn btn-default btn-lg">Edit</button>'))
            .append($("<td>").html('<button data-action="delete" type="button" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></button>'));
        that.table.append(tr)
    },

    editGame: function () {

    },

    init: function () {
        this.showGames();
        var that = this;
        $(document).on("click", "button[data-action=delete]", function (ev) {
            var btn = $(ev.currentTarget)
            var id = btn.closest("tr").attr("data-id")
            $.ajax({
                url: "/Admin/Delete",
                type: "POST",
                data: { gameId: id },
                success: function () {
                    $("tr[data-id=" + id + "]").remove();
                }
            })
        });

        $(document).on("click", "button[data-action=edit]", function (ev) {
            $("#gameEditor").attr("editortype", "1")
            var btn = $(ev.currentTarget)
            var game = btn.closest("tr").data("data")
            $("#gameEditor").modal("show")
            $("#gameName").val(game.Name)
            $("#gamePrice").val(game.Price);
            $("#gameDescr").val(game.Description);
            $("#gameCategory").val(game.Category);
        })

        $("#openbtn").on("click", function () {
            $("#gameEditor").modal("show")
            $("#gameEditor").attr("editortype", "1")
        })
        $("#addbtn").on("click", function () {
            var type = $("gameEditor").attr("editortype");
            if (type == "1") {
                var name = $("#gameName").val();
                var price = $("#gamePrice").val();
                var descr = $("#gameDescr").val();
                var category = $("#gameCategory").val();
                var game = {
                    Name: name,
                    Description: descr,
                    Category: category,
                    Price: price
                }
                
                that.addGame(game);
                $("#gameName").val("")
                $("#gamePrice").val("");
                $("#gameDescr").val("");
                $("#gameCategory").val("");
                $("#gameEditor").modal("hide")
            }
            else if (type == "0") {
                var name = $("#gameName").val();
                var price = $("#gamePrice").val();
                var descr = $("#gameDescr").val();
                var category = $("#gameCategory").val();
                var game = {
                    Name: name,
                    Description: descr,
                    Category: category,
                    Price: price
                }
                that.editGame(game);
            }
        })
    },

    onDocumentReady: function () {
        this.init();
    }
}

$(document).ready(function () {
    AdminController.onDocumentReady();
})