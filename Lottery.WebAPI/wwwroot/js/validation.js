function initValidation() {
    $('#checkTicketForm')
        .formValidation({
            framework: 'bootstrap',
            fields: {
                ticketNumber: {
                    validators: {
                        callback: {
                            callback: function (value, validator, $field) {
                                $('#ticketNumber').val(value.toUpperCase());
                                $('#checkBtn').prop('disabled', true);

                                if (value === "") {
                                    return {
                                        valid: false,
                                        message: 'Введите номер билета'
                                    };
                                }
                                else if (value.length !== 11) {
                                    return {
                                        valid: false,
                                        message: 'Введите номер билета в формате XXX-XXXXXXX'
                                    };
                                }
                                else {
                                    $('#checkBtn').prop('disabled', false);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        })
        .on('click', '[name="checkBtn"]', function (e) {
            $('#checkTicketForm').data('formValidation').revalidateField('ticketNumber');
            checkTicket();
        });
}