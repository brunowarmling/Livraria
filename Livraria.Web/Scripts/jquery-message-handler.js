var messageElem = '#divMessage';

function ShowOkMessage(message) {
    ShowMessage(message, false);
}

function ShowErrorMessage(message) {
    ShowMessage(message, true);
}

function ShowMessage(usrMessage, usrIsError) {
    var options = { message: usrMessage, isError: usrIsError };
    $(messageElem).message('show', options);
}