(function ($) {

    var _MXQuestionService = abp.services.app.mXQuestion;
    var _$modal = $('#MXQuestionEditModal');
    var _$form = $('form[name=MXQuestionEditForm]');

    function save() {

        if (!_$form.valid()) {
            return;
        }

        

        //
     
        $(document).on('click', '.RemoveOption', function () {
            $(this).parent().parent().remove();
        });

        var MXQuestion = {
            MXQuestion: _$form.serializeFormToObject()
        }; //serializeFormToObject is defined in main.js
        switch (MXQuestion.MXQuestion.QuestionType) {
            case '1':
            case '2':
                //var jsonObj = $("input[name='指定你想要的name值']").serializeArray();
                var $OptionsItme = $("input[name=OptionsItme]");//假设name为test
                var Options = '{';
                for (var i = 0; i < $OptionsItme.length; i++) {
                    Options += '"' + $OptionsItme.eq(i).attr("id") + '":"' + $OptionsItme.eq(i).val() + '",';

                }
                Options = Options.substring(0, Options.length - 1);
                Options += '}';
                var objOptions = JSON.parse(Options);
                alert(Options);
                MXQuestion.MXQuestion.Options = objOptions;
                break;
            case '3':
            case '4':
            case '5':

                break;
            default:
                break;
        }
        abp.ui.setBusy(_$form);
        _MXQuestionService.createOrUpdate(MXQuestion).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited equipmentType!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);