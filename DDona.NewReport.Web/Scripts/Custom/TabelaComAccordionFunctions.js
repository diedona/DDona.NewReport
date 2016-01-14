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
            "data": ArrayToObject(Parametros)
        }
    });

    return DataTable;
}

function ArrayToObject(Obj)
{
    var o = {};
    $.each(Obj, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
}