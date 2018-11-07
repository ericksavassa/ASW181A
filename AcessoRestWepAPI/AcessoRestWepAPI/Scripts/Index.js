(function () {

    function resultadoLog(log) {
        var textArea = document.querySelector('textarea');
        textArea.value = log;

    }

    $('#CalcularAumento').click(function () {
        var _url = 'http://' + window.location.host + '/';
        $.ajax({
            url: _url + "Home/CalcularAumento",
            success: function (result) {
                resultadoLog(result);

            },
            error: function (data) {

            },
            complete: function () {

            }
        })
    });

    $('#AlterarStatus').click(function () {

        var idFuncionario = document.getElementById('idFuncionario');
        if (idFuncionario.value === '') {
            alert('É necessário informar um ID de funcionário!');
            return;
        }
        
        var statusFuncionario = document.getElementById('statusFuncionario');
        if (statusFuncionario.value === '') {
            alert('É necessário informar um novo status!');
            return;
        }
        if (statusFuncionario.value.toUpperCase() != 'S' && statusFuncionario.value.toUpperCase() != 'N') {
            alert('Status deve ser S (Ativo) ou N (Inativo)!');
            return;
        }
        var status = {};
        status.IdFuncionario = idFuncionario.value;
        status.StatusFuncionario = statusFuncionario.value.toUpperCase();

        var _url = 'http://' + window.location.host + '/';
        $.ajax({
            url: _url + "Home/AlterarStatus",
            type: 'PUT',
            datatype: 'json',
            contentType: 'application/json',
            data: JSON.stringify(status),
            success: function (logresult) {
                resultadoLog(logresult);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                throw errorThrown;
            }
        }); 
    });

    $('#CalcularAumentoWebAPI').click(function () {

        var _url = 'http://' + window.location.host + '/';
        $.ajax({
            url: _url + "api/values",
            type: 'POST',
            datatype: 'json',
            contentType: 'application/text',
            //Server para passar um valor para p server via post ou put
            //data: JSON.stringify(obj), 
            success: function (logresult) {

                resultadoLog(logresult);

            },
            error: function (jqXHR, textStatus, errorThrown) {

                throw errorThrown;

            }
            
        }); 
    });


    $('#ExcluirInativos').click(function () {
        var _url = 'http://' + window.location.host + '/';
        $.ajax({
            url: _url + "Home/ExcluirInativos",
            success: function (result) {
                resultadoLog(result);
            },
            error: function (data) {
            },
            complete: function () {
            }
        })
    });

    $('#ExcluirInativosWebAPI').click(function () {

        var _url = 'http://' + window.location.host + '/';
        $.ajax({
            url: _url + "api/values",
            type: 'DELETE',
            datatype: 'json',
            contentType: 'application/text',
            success: function (logresult) {
                resultadoLog(logresult);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                throw errorThrown;
            }
        });
    });

  
})();