$(document).ready(function () {
    getUserStocks();
});

function getUserStocks() {
    $.ajax({
        type: "POST",
        url: uri + "/Services/StockService.asmx/GetUserStocks",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (argStocks) {
            $("#UserStockList").html('');
            var stocks = new EJS({ url: 'Templates/Stocks.ejs' }).render({ stocks: argStocks.d });
            $("#UserStockList").append(stocks);
            setTimeout(function () { getUserStocks(); }, 10000);
        },
        error: function (msg) {
            location.href = "errorpage.html?errorMessage=" + encodeURI(jQuery.parseJSON(msg.responseText).Message);
        }
    });
}

function displayNewStockAppender() {
    var renderedData = new EJS({ url: 'Templates/StockAppender.ejs' }).render({ open: 1 });
    $(renderedData).modal('show');
}

function addNewStockCode(argGuid) {
    var stockCode = $('#newStockCode' + argGuid).val();
    if(stockCode.length >= 3){
        $.ajax({
            type: "POST",
            url: uri + "/Services/StockService.asmx/AddNewStock",
            data: '{ argStockCode: "' + stockCode + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (argStock) {
                var stocks = [];
                stocks[0] = argStock.d;
                var newStock = new EJS({ url: 'Templates/Stocks.ejs' }).render({ stocks: stocks });
                $("#UserStockList").append(newStock);
                $('#stockAppender' + argGuid).modal('hide');
            },
            error: function (msg) {
                alert(jQuery.parseJSON(msg.responseText).Message);
            }
        });
    }else{
        alert("Stock codes can be at least 3 character.")
    }
}

function removeStock(argStockCode) {
    $.ajax({
        type: "POST",
        url: uri + "/Services/StockService.asmx/RemoveStock",
        data: '{ argStockCode: "' + argStockCode + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            $('#stock' + argStockCode).remove();
        },
        error: function (msg) {
            alert(jQuery.parseJSON(msg.responseText).Message);
        }
    });
}