//Patterns
var ControllerPatterns = {};
ControllerPatterns.REQUIRED_FIELD = 'data-required';
ControllerPatterns.FIELD_DATA_TYPE = 'data-type';
ControllerPatterns.FORM_TEMPLATE = 'data-form-mode';
ControllerPatterns.BUTTON_ACTION = 'data-action';
ControllerPatterns.DATA_FIELD = 'data-field';
ControllerPatterns.READ_ONLY_EDIT = 'data-readonly-edit';
ControllerPatterns.DATA_BEAN = 'data-bean';
ControllerPatterns.DATA_CONTROL = 'data-control';
ControllerPatterns.DATA_DEVCONTROL = 'data-devcontrol';
ControllerPatterns.DATA_KEY = 'data-key';
ControllerPatterns.DATA_BLOCKCLEAR = 'data-blockclear';

//Actions
var RequestActions = {};
RequestActions.INSERT = 'Insert';
RequestActions.UPDATE = 'Update';
RequestActions.DELETE = 'Delete';
RequestActions.FIND = 'Find';
RequestActions.SELECT = 'Select';

//Data Types
var DataTypes = {};
DataTypes.NUMBER = "number";
DataTypes.DOUBLE = "double";

//Form templates
var formViewMode = {};
formViewMode.INSERT = "Insert";
formViewMode.EDIT = "Edit";

//Messages
var messages = {};
messages.REQUIRED_FIELD = 'Este campo é obrigatório';
messages.INSERT_SUCESS = 'Registro inserido com sucesso';
messages.SAVE_SUCESS = 'Registro salvo com sucesso';
messages.DELETE_SUCESS = 'Registro removido com sucesso';
messages.CONFIRM_DELETE = 'Deseja realmente excluir esse registro';


//Inicializa um form e uma grid
function initialize(form, grid, logged) {

    //Inicia em modo Insert
    changeFormMode(form, formViewMode.INSERT);

    //Tranforma em accordion
    form.accordion({ collapsible: false, icons: logged ? { "header": "ui-icon-note", "activeHeader": "ui-icon-note" } : { "header": "ui-icon-key", "activeHeader": "ui-icon-key" } });

    //Transforma os bot�es
    form.find('input[type="button"]').button();

    //Transforma os inputs
    form.find('input').each(function () {
        var jThis = $(this);

        var dataTypeAttr = jThis.attr(ControllerPatterns.FIELD_DATA_TYPE);
        if (dataTypeAttr !== undefined) {

            if (dataTypeAttr === DataTypes.NUMBER)
                //Transforma os inputs do tipo number
                jThis.number(true, 0, '', '');
            else if (dataTypeAttr === DataTypes.DOUBLE)
                //Transforma os inputs do tipo number
                jThis.number(true, 2, '.', ',');
        }

        var actionAttr = jThis.attr(ControllerPatterns.BUTTON_ACTION);
        if (actionAttr !== undefined) {
            //Atribui os eventos aos bot�es
            jThis.bind('click', function (event, args) { eval(actionAttr + 'Handler(event,args,form,grid);'); });
        }
    });

    if (grid) {

        //Transforma a grid
        grid.addClass('ui-accordion ui-widget');


        //Atualia os registros da grid		
        FindHandler(null, null, form, grid);
    }

    //Seta o foco no primeiro campo
    form.find('input').eq(0).focus();



    //Não faz resize no login
    if (logged === true) {

        //Ajusta a altura da page
        autoResizeContainer();

        $(document).ready(function () {
            $(window).resize(autoResizeContainer);
        });
    }

}

//Muda o template do form, conforme o formato passado
function changeFormMode(jForm, mode) {
    jForm.find('div').each(function () {
        var jThis = $(this);
        var formTemplateAttr = jThis.attr(ControllerPatterns.FORM_TEMPLATE);
        if (formTemplateAttr) {
            if (mode === formViewMode.INSERT) {
                if (formTemplateAttr === formViewMode.INSERT)
                    jThis.show();
                if (formTemplateAttr === formViewMode.EDIT)
                    jThis.hide();
            }
            else if (mode === formViewMode.EDIT) {
                if (formTemplateAttr === formViewMode.INSERT)
                    jThis.hide();
                if (formTemplateAttr === formViewMode.EDIT)
                    jThis.show();
            }
        }
    });

    if (mode === formViewMode.EDIT)
        jForm.find('input,select,textarea').each(function () {
            var jThis = $(this);
            jThis.css('background-color', '');
            var readOnlyAttr = jThis.attr(ControllerPatterns.READ_ONLY_EDIT);
            if (readOnlyAttr)
                jThis.attr('disabled', 'disabled');
        });
    else
        jForm.find('input').each(function () {
            var jThis = $(this);
            jThis.removeAttr('disabled');
        });
}

//Constrói um objeto com os dados do form
function buildDataFields(jForm) {
    var obj = {};
    jForm.find('input,select,textarea').each(function () {
        var jThis = $(this);
        var dataFieldAttr = jThis.attr(ControllerPatterns.DATA_FIELD);
        if (dataFieldAttr)
            obj[dataFieldAttr] = jThis.val();
    });

    return obj;
}

//Realiza uma requisição ao servidor
function makeRequest(dataBean, dataControl, action, dataObject, callBackFunction) {
    
    var sucessFun = function (result) {
        //Enable the buttons
        $('.ui-button').prop('disabled', '');

        if (result.Sucess === true) {
            if (callBackFunction)
                callBackFunction(result);
        }
        else {
            ShowErrorMessage(result.ErrorMessage);
        }
    };

    //Disable the buttons
    $('.ui-button').prop('disabled', 'disabled');

    $.ajax({
        type: "POST",
        url: '../../api/' + dataBean.toString() + '/' + action.toString(),
        data: dataObject,
        dataType: 'json',
        success: sucessFun
    });
}

//Realiza a validação dos campos obrigatórios de um form
function validateForm(jForm) {

    var obj = {};
    var hasBalloonVisible = false;

    jForm.find('input,select,textarea').each(function () {
        var jThis = $(this);
        if (jThis.attr(ControllerPatterns.REQUIRED_FIELD)) {
            if (jThis.val().trim())
                jThis.css('background-color', '');
            else {

                jThis.css('background-color', 'rgba(253, 255, 165, 0.811765)');
                if (!hasBalloonVisible) {
                    showTooltip(jThis, messages.REQUIRED_FIELD);
                    hasBalloonVisible = true;
                }
            }
        }
    });

    return !hasBalloonVisible;
}

//Controla o evento 'SELECT' de um action
function selectHandler(event, form) {
    var jThis = $(event.currentTarget);
    var key = jThis.attr(ControllerPatterns.DATA_KEY);

    var cbFunc = function (data) {
        //Altera para o modo insert
        changeFormMode(form, formViewMode.EDIT);

        //Popula os campos
        for (var dataField in data.UserData) {
            var dataValue = data.UserData[dataField];
            var field = form.find("*[data-field=\"" + dataField.toString() + "\"]");
            field.val(dataValue);
        }
    };

    var obj = eval("(" + key + ")");
    var dataBean = form.attr(ControllerPatterns.DATA_BEAN);
    var dataControl = form.attr(ControllerPatterns.DATA_CONTROL);
    makeRequest(dataBean, dataControl, RequestActions.SELECT, obj, cbFunc);
}

//Controla o evento 'INSERT' de um action
function InsertHandler(event, args, form, grid) {

    //Verifica se o form está válido
    if (validateForm(form)) {

        var cbFunc = function (data) {
            //Altera para o modo insert
            changeFormMode(form, formViewMode.INSERT);

            //Limpa o form
            clearFormData(form);

            //Atualiza a grid
            FindHandler(event, args, form, grid);

            //Mostra mensagem de sucesso
            ShowOkMessage(messages.INSERT_SUCESS);
        };

        var obj = buildDataFields(form);
        var dataBean = form.attr(ControllerPatterns.DATA_BEAN);
        var dataControl = form.attr(ControllerPatterns.DATA_CONTROL);
        makeRequest(dataBean, dataControl, RequestActions.INSERT, obj, cbFunc);
    }
}

//Controla o evento 'SAVE' de uma action
function SaveHandler(event, args, form, grid) {

    //Verifica se o form está válido
    if (validateForm(form)) {

        var cbFunc = function (data) {
            //Altera para o modo insert
            changeFormMode(form, formViewMode.INSERT);

            //Limpa o form
            clearFormData(form);

            //Atualiza a grid
            FindHandler(event, args, form, grid);

            //Mostra mensagem de sucesso
            ShowOkMessage(messages.SAVE_SUCESS);
        };

        var obj = buildDataFields(form);
        var dataBean = form.attr(ControllerPatterns.DATA_BEAN);
        var dataControl = form.attr(ControllerPatterns.DATA_CONTROL);
        makeRequest(dataBean, dataControl, RequestActions.UPDATE, obj, cbFunc);
    }
}

//Controla o evento 'DELETE' de uma action
function DeleteHandler(event, args, form, grid) {

    var dialogConfig = {};
    dialogConfig.width = 300;
    dialogConfig.height = 140;
    dialogConfig.message = messages.CONFIRM_DELETE;
    dialogConfig.buttons = {

        "Excluir": function () {

            var thisRef = this;
            var cbFunc = function (data) {
                //Altera para o modo insert
                changeFormMode(form, formViewMode.INSERT);

                //Limpa o form
                clearFormData(form);

                //Fecha a modal
                $(thisRef).dialog("close");

                //Atualiza a grid
                FindHandler(event, args, form, grid);

                //Mostra mensagem de sucesso
                ShowOkMessage(messages.DELETE_SUCESS);
            }

            var obj = buildDataFields(form);
            var dataBean = form.attr(ControllerPatterns.DATA_BEAN);
            var dataControl = form.attr(ControllerPatterns.DATA_CONTROL);
            makeRequest(dataBean, dataControl, RequestActions.DELETE, obj, cbFunc);

        },
        "Cancelar": function () {
            $(this).dialog("close");
        }
    };

    dialogConfig.buttonsCSS = [];
    dialogConfig.buttonsCSS.push('deleteButton');
    dialogConfig.buttonsCSS.push('cancelButton');

    showDialog($("#dialog-confirm"), dialogConfig);
    return;
}

//Controla o evento 'FIND' de uma action
function FindHandler(event, args, form, grid) {

    var cbFunc = function (data) {
        buildGrid(form, grid, data.UserData, true);
    }

    var obj = buildDataFields(form);
    var dataBean = form.attr(ControllerPatterns.DATA_BEAN);
    var dataControl = form.attr(ControllerPatterns.DATA_CONTROL);
    makeRequest(dataBean, dataControl, RequestActions.FIND, obj, cbFunc);
}

//Controla o evento 'CANCEL' de uma action
function CancelHandler(event, args, form, grid) {

    //Altera para o modo insert
    changeFormMode(form, formViewMode.INSERT);

    //Limpa o form
    clearFormData(form);
}

//Limpa os dados do fomulário
function clearFormData(form) {
    form.find('input:text,input:password,select,textarea').each(function () {

        var jThis = $(this);
        var blockClearAttr = jThis.attr(ControllerPatterns.DATA_BLOCKCLEAR);

        if (!blockClearAttr)
            jThis[0].value = '';
    });

}

//Mostra um balão no campo desejado com uma mensagem
function showTooltip(jInput, message) {

    jInput[0].title = message;
    jInput.showBalloon({ position: "right", hideDuration: 700 });
    jInput.focus();
    setTimeout(function () {
        jInput.hideBalloon();
        jInput.removeAttr('title');
    }, 1300);
}

//Constrói a tabela
function buildGrid(form, grid, data, editable) {
    grid.find('thead').attr('class', 'ui-state-default ui-accordion-header-active ui-state-active ui-corner-top ui-accordion-icons');
    if (editable) {
        //Não criar se já existe
        if (grid.find('thead tr th.editableColumn').length === 0) {
            var th = $('<th width="50px">Editar</th>');
            th.addClass("editableColumn");
            th.appendTo(grid.find('thead tr'));
        }
    }

    //Limpa o que já existe
    grid.find('tbody tr').remove();

    var j = 1;
    for (r in data) {

        var row = data[r];
        var jRow = $("<tr />")
        grid.append(jRow);

        var i = 0;
        var cols = grid.find('colgroup col');
        var dataKey = null;

        for (c in row) {
            if (!dataKey) {
                dataKey = {};
                dataKey[c.toString()] = row[c];
            }

            var col = row[c];
            var td = $("<td>" + col + "</td>");
            td.attr('style', cols.eq(i).attr('style'));
            jRow.append(td);
            i++;
        }

        if (editable) {

            var strDataKey = JSON.stringify(dataKey);
            strDataKey = strDataKey.replace("\"", "'").replace("\"", "'");
            strDataKey = "\"" + strDataKey + "\"";
            jRow.append($("<td " + ControllerPatterns.DATA_KEY + "=" + strDataKey + "><span class=\"ui-icon ui-icon-pencil\"></span></td>"));
        }
        j++;
    }

    if (editable) {
        //Atribui os eventos aos botões da grid
        grid.find('tbody tr td:last-child').each(function () {
            $(this).bind('click', function (event) { eval('selectHandler(event,form);'); });
        });
    }
}

//Monstra uma dialog
function showDialog(dialog, config) {

    var jDialog = dialog;

    if (config.message)
        jDialog.find('.dialog-message').text(config.message);

    jDialog.dialog({
        resizable: false,
        width: config.width,
        height: config.height,
        modal: true,
        buttons: config.buttons,
        open: (function (event, ui) {
            var i = 0;
            jDialog.next().find('button').each(function () {
                $(this).addClass(config.buttonsCSS[i]);
                i++;
            });
        })
    });
}

//Faz resize automatico da tela
function autoResizeContainer() {

    var jGrid = $('.grid').hide();
    var jContainer = $('.container');
    jContainer.height(0);

    var docHeight = $(document).height();
    var headerHeight = $('.header').outerHeight();

    jContainer.height(docHeight - headerHeight - 40);
    $('.pageName').text('Livraria - ' + document.title);

    var formHeight = $('.form').height();
    $('.divHolder').height(jContainer.height() - formHeight);
    jGrid.show();
}