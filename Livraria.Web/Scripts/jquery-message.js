(function(jQuery) {
    var methods = {
        show: function(options) {

            options = jQuery.extend({}, jQuery.fn.message.defaults, options);

            //Cria html da mensagem
            this.message('createHtml', options);

            var messageElem = this.children().eq(0);

            //Seta a classe da mensagem, se é erro ou normal
            messageElem.find('.ui-corner-all').attr('class', (options.isError ? 'ui-state-error' : 'ui-state-highlight') + ' ui-corner-all');
            messageElem.find('.ui-icon').attr('class', 'ui-icon ' + (options.isError ? "ui-icon-alert" : "ui-icon-info"));

            //Seta o texto da mensagem
            messageElem.find('span.message-text').html(options.message);

            var that = this;
            if (options.closeOnClick && typeof (options.closeOnClick) == 'boolean') {
                this.css('cursor', 'pointer');
                // Esconde a mensagem
                this.click(function() {
                    that.message('hide', options);
                });
            }

            var thatMessageElem = messageElem;
            this.message('hide', options, function() {
                that.stop()
                    .css('visibility', 'hidden')
                    .css('display', 'block')
                    .css('height', 'auto');
                    var _height = that.height();
                    that.css('height', '0');
                    that
                    .css('visibility', '')
                    .animate({ height: _height }, 200);
                //Aguarda o autoClose e esconde a mensagem
                var timeOutFunc = setTimeout(function() { that.message('hide', options); }, options.autoClose);

                $(that).data('message', {
                    timeOutFuncId: timeOutFunc
                });

            });
        },

        hide: function(options, callBackFunction) {
            options = jQuery.extend({}, jQuery.fn.message.defaults, options);

            //Limpa o timeOut
            var data = this.data('message');
            if (data)
                clearTimeout(data.timeOutFuncId);

            var callBack = function() {
                $(this).css('display', 'none');
                if (callBackFunction) {
                    callBackFunction.apply(this, arguments);
                }
            };

            //Esconde a mensagem
            this.stop().animate({ height: "0px" }, 200, callBack);
        },
        createHtml: function(options) {
            if (this.find('> .message-container').length != 0) return;

            // Constrói o html da mensagem
            var messageHtml =
                '<div class="ui-widget message-container">\
                   <div class="ui-corner-all">\
                       <p><table cellpadding="0" cellspacing="0" border="0"><tr><td><span class="ui-icon" /></td><td valign="top"><span class="message-text" /></td></tr></table></p>\
                   </div>\
                </div>';
            //Seta o html construido para o container
            this.html(messageHtml);
        }
    };

    $.fn.message = function(method) {

        if (methods[method]) {
            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        }
        else if (typeof method === 'object' || !method) {
            return methods.init.apply(this, arguments);
        }

    };

    //valores padroes de opcoes
    jQuery.fn.message.defaults = {
        message: "", //em branco usa o texto da div
        isError: false,
        autoClose: 5000, //tempo em milisegundos para fechar
        closeOnClick: true //fechar se o usuario clicar em cima
    };

})(jQuery);