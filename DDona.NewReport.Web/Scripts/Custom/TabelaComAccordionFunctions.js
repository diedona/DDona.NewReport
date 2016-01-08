function MontarTabela(TabelaId, Colunas, Url)
{
    var TabelaHtml = $("#" + TabelaId);
    DestruirTabela(TabelaId);
    return ConfigurarTabela(TabelaHtml, Colunas, Url);
}

function DestruirTabela(TabelaId)
{
    if( $.fn.dataTable.isDataTable("#"+TabelaId))
    {
        var DataTable = $("#" + TabelaId).DataTable();
        DataTable.destroy();
    }
}

function ConfigurarTabela(TabelaHtml, Colunas, Url)
{
    var DataTable;

    DataTable = TabelaHtml.DataTable({
        "processing": true,
        "serverSide": true,
        "columns": Colunas,
        "ajax": {
            "url": Url,
            "type": "POST"
        }
    });

    return DataTable;
}