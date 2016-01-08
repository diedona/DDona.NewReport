function MontarTabela(TabelaId, Colunas, Url, Parametros)
{
    var TabelaHtml = $("#" + TabelaId);
    DestruirTabela(TabelaId);
    return ConfigurarTabela(TabelaHtml, Colunas, Url, Parametros);
}

function DestruirTabela(TabelaId)
{
    if( $.fn.dataTable.isDataTable("#"+TabelaId))
    {
        var DataTable = $("#" + TabelaId).DataTable();
        DataTable.destroy();
    }
}

function ConfigurarTabela(TabelaHtml, Colunas, Url, Parametros)
{
    var DataTable;

    DataTable = TabelaHtml.DataTable({
        "processing": true,
        "serverSide": true,
        "columns": Colunas,
        "ajax": {
            "url": Url,
            "type": "POST",
            "data": function (d) {
                for(var i = 0; i < Parametros.length; i++)
                {
                    var Parametro = Parametros[i];
                    d[Parametro.name] = Parametro.value;
                }
            }
        }
    });

    return DataTable;
}