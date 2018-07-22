$(document).ready(function () {
    $('#checkBtn').prop('disabled', true);

    $('#ticketNumber').mask("DDD-AAAAAAA",
        {
            placeholder: "Введите номер билета в формате XXX-XXXXXXX",
            clearIfNotMatch: true,
            'translation': {
                A: { pattern: /[A-Za-z0-9]/ },
                D: { pattern: /[0-9]/ }
            }
        });
    
    initValidation();
});

function checkTicket() {
    if ($('#checkTicketForm').data('formValidation').isValid()) {
        var number = $('#ticketNumber').val();

        var port = document.location.port ? (":" + document.location.port) : "";
        var url = document.location.protocol + "//" + document.location.hostname + port + "/restApi/v1/GetTicket/" + number;
        var obj = { "number": number };

        $.ajax({
            'url': url,
            'type': "GET",
            'accepts': "application/json; charset=utf-8",
            'contentType': "application/json",
            'data': JSON.stringify(obj),
            'dataType': "json",
            'success': function (response) {
                var modal = $('#resultModal');

                if (response.IsSuccess) {
                    if (response.IsWinning) {
                        modal.find('.modal-body').text("Поздравляем! Ваш билет выигрышный!");
                    }
                    else {
                        modal.find('.modal-body').text("Увы, вы ничего не выиграли.");
                    }
                }
                else {
                    modal.find('.modal-body').text(response.Message);
                }

                modal.modal('show');
            }
        }); 
    }
}