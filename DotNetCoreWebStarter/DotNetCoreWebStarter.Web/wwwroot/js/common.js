const QuoteStatus = {
    Enquiry: 1,
    Quoted: 2,
    Ordered: 4,
    Lost: 6,
    Cancelled: 7,
    ClientAccepted: 8,
    Checked: 9,
    Released: 10
}

const OverridePropertyType = {
    QuoteNocharge: 1,
    QuoteLineDescription: 2,
    QuoteLineUnitDiscountPercentage: 3,
    QuoteLineAccessoryDiscountPercentage: 4
}

//$.extend(true, $.fn.dataTable.defaults, {
//    autoWidth: false,
//    searching: false,
//    paging: true,
//    pageLength: 5,
//    sPaginationType: "full_numbers",
//    language: {
//        "lengthMenu": "Page Size : _MENU_ ",
//        "info": "Records _START_ to _END_ of (_TOTAL_)",
//        "emptyTable": "No Record(s) Found",
//        "oPaginate":
//        {
//            "sNext": '&nbsp;',
//            "sLast": '&nbsp;',
//            "sFirst": '&nbsp;',
//            "sPrevious": '&nbsp;'
//        }
//    },
//});


function checkEmailValidation(emailadd) {
    var regex = /^\s*[\w\-\+_]+(\.[\w\-\+_]+)*\@[\w\-\+_]+\.[\w\-\+_]+(\.[\w\-\+_]+)*\s*$/;

    if (!regex.test(emailadd)) {
        return false;
    } else {
        return true;
    }
}


//Show Message for Success, Danger and Warning
function ShowMessage(type, message) {

    if (type == null || type == 'undefined') {
        type = 'success';
    }

    if (message != null && message != 'undefined' || message != '') {
        //message = message.replace('&lt;br/&gt;', '<br/>')
        message = message.split('&lt;br/&gt;').join('<br/>');

        $.toast({
            heading: 'Starter Pack',
            text: message,
            position: 'top-center',
            loaderBg: '#ff6849',
            icon: type,
            hideAfter: 4000,
            stack: 6,
        });
    }

}
//Convert Date from Json

function SetJsonDateTime(jsonDate) {
    var result = "";
    if (jsonDate != null && jsonDate != '/Date(-62135596800000)/') {
        var nowDate = new Date(parseInt(jsonDate.substr(6)));
        result = nowDate.toLocaleDateString('en-ZA', { year: "numeric", month: "long", day: "numeric" }) + " " + nowDate.toLocaleTimeString('en-US', { hour: "2-digit", minute: "2-digit", hour12: true })
    }
    return result;
}

function SetJsondate(jsonDate) {

    var result = "";
    if (jsonDate != null && jsonDate != '/Date(-62135596800000)/') {
        var Format = 'dd-mmm-yyyy';
        var nowDate = new Date(parseInt(jsonDate.substr(6)));
        result = nowDate.format(Format);
    }
    return result;
}

function validateDateFormat(inputDate, dateFormat) {
    var regExpDate = '';

    if (dateFormat === 'dd-MM-yyyy') {
        regExpDate = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
    }
    else if (dateFormat === 'MM-dd-yyyy') {
        regExpDate = /^(0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])[\/\-]\d{4}$/;
    }
    else if (dateFormat === 'yyyy-MM-dd') {
        regExpDate = /^\d{4}\-\d{1,2}\-\d{1,2}$/;
    }

    // Match the date format through regular expression
    if (inputDate.match(regExpDate)) {

        //Test which seperator is used '/' or '-'
        var opera1 = inputDate.split('/');
        var opera2 = inputDate.split('-');
        lopera1 = opera1.length;
        lopera2 = opera2.length;

        // Extract the string into month, date and year
        if (lopera1 > 1) {
            var pdate = inputDate.split('/');
        }
        else if (lopera2 > 1) {
            var pdate = inputDate.split('-');
        }

        var mm;
        var dd;
        var yy;

        if (dateFormat === 'dd-MM-yyyy') {
            dd = parseInt(pdate[0]);
            mm = parseInt(pdate[1]);
            yy = parseInt(pdate[2]);
        }
        else if (dateFormat === 'MM-dd-yyyy') {
            mm = parseInt(pdate[0]);
            dd = parseInt(pdate[1]);
            yy = parseInt(pdate[2]);
        }
        else if (dateFormat === 'yyyy-MM-dd') {
            yy = parseInt(pdate[0]);
            mm = parseInt(pdate[1]);
            dd = parseInt(pdate[2]);
        }

        var ListofDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        if (mm == 1 || mm > 2) {
            if (ListofDays[mm - 1] !== undefined) {
                if (dd > ListofDays[mm - 1]) {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        if (mm == 2) {
            var lyear = false;
            if ((!(yy % 4) && yy % 100) || !(yy % 400)) {
                lyear = true;
            }
            if ((lyear == false) && (dd >= 29)) {
                return false;
            }
            if ((lyear == true) && (dd > 29)) {
                return false;
            }
        }
    }
    else {
        return false;
    }

    return true;
}

function FormattedMoneyValue(data) {
    var FormattedNumber = Number(data).toLocaleString('en-ZA', {
        // maximumFractionDigits: 2,
        style: 'currency',
        currency: 'ZAR',
    });
    return FormattedNumber.replace(',', '.');
}


function FormattedNumberValue(data) {
    var FormattedNumber = Number(data).toLocaleString('en-ZA');
    FormattedNumber = FormattedNumber.replace(',', '.');
    return FormattedNumber;
}


//convert thousand seperater and decimal 2 point formate for amount value
function formatDecimalNumber(number, point = 2) {
    // Ensure two decimal places
    const formattedNumber = number.toFixed(point);

    // Split the number into integer and decimal parts
    const [integerPart, decimalPart] = formattedNumber.split('.');

    var withCommas = Number(integerPart).toLocaleString('en-ZA');
    withCommas = withCommas.replace(',', ' ');
    // Combine formatted parts
    return `${withCommas}.${decimalPart}`;
}

//disable submit button after click
$(document).on('submit', 'form', function () {
    if ($(this).attr('class') != 'search-form' && !$(this).hasClass('noDisable')) {
        if ($(this).attr('id') != 'loginform') {
            $(':submit', this).attr('disabled', 'disabled');
        }
    }
});

//set focus on first textbox if not then first text area
$(document).ready(function () {
    if ($("form:first input:text:visible:not([readonly]):enabled").eq(0).length > 0) {
        $("form:first input:text:visible:not([readonly]):enabled").eq(0).focus();
    }
    else if ($("form:first textarea").eq(0).length > 0) {
        $("form:first textarea").eq(0).focus();
    }
});

function getQuoteStatusBadge(quoteStatusId, quoteStatusName) {
    var statusClass = '';
    switch (quoteStatusId) {
        case QuoteStatus.Enquiry:
            statusClass = "primary";
            break;
        case QuoteStatus.Quoted:
            statusClass = "info-quoted";
            break;
        case QuoteStatus.Ordered:
        case QuoteStatus.Released:
            statusClass = "success";
            break;
        case QuoteStatus.Lost:
            statusClass = "danger";
            break;
        case QuoteStatus.Cancelled:
            statusClass = "light";
            break;
        case QuoteStatus.ClientAccepted:
            statusClass = "success";
            break;
        case QuoteStatus.Checked:
            statusClass = "warning";
            break;


    }
    return '<span class="badge badge-' + statusClass + '"><strong>' + quoteStatusName + '</strong></span>';
}

function parseValue(input) {
    var output = 0;
    if (input !== '') {
        output = isNaN(input) || input == null ? 0 : input;
    }
    return parseFloat(output);
}
//Allow only numbers to be typed in a textbox
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

function TrimZero(txtbox) {
    if ($(txtbox).val() == "0" || $(txtbox).val() == "0.00")
        $(txtbox).val("");
    return;
};

function FormattedNumberValue(data, noOfDidits = 2) {
    var FormattedNumber = Number(data).toLocaleString('en-ZA', {
        // maximumFractionDigits: 2,
        minimumFractionDigits: noOfDidits,
        maximumFractionDigits: noOfDidits,
        style: 'currency',
        currency: 'ZAR',
    });
    return FormattedNumber.replace(',', ' ').replace('R', '').trim();
}

function FormattedCurrencyValue(data, noOfDidits = 2) {
    var FormattedNumber = Number(data).toLocaleString('en-ZA', {
        // maximumFractionDigits: 2,
        minimumFractionDigits: noOfDidits,
        maximumFractionDigits: noOfDidits,
        style: 'currency',
        currency: 'ZAR',
    });
    return FormattedNumber.replace(',', ' ').replace('R', '').trim();
}

