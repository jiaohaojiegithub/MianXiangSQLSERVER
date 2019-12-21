(function () {
    $(function () {

        var _MXAttributeService = abp.services.app.mXAttribute;
        var _$modal = $('#MXAttributeCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate();

        $('#RefreshButton').click(function () {
            refreshMXAttributeList();
        });

        //删除方法
        $('.delete-MXAttribute').click(function () {
            var MXAttributeId = $(this).attr("data-MXAttribute-id");
            var MXAttributeName = $(this).attr('data-MXAttribute-name');
            deleteMXAttribute(MXAttributeId, MXAttributeName);
        });

        //编辑方法
        $('.edit-MXAttribute').click(function (e) {
            var MXAttributeId = $(this).attr("data-MXAttribute-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'MXAttribute/EditMXAttributeModal?id=' + MXAttributeId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#MXAttributeEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var MXAttribute = { MXAttribute: _$form.serializeFormToObject() }; //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _MXAttributeService.createOrUpdate(MXAttribute).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new equipmentType!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshMXAttributeList() {
            location.reload(true); //reload page to see new equipmentType!
        }

        function deleteMXAttribute(MXAttributeId, MXAttributeName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MianxiangProject'), MXAttributeName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _MXAttributeService.delete({
                            id: MXAttributeId
                        }).done(function () {
                            refreshMXAttributeList();
                        });
                    }
                }
            );
        }
    });
})();