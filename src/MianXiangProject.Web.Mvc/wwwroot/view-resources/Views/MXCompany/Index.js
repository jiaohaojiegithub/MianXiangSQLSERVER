(function () {
    $(function () {

        var _MXCompanyService = abp.services.app.mXCompany;
        var _$modal = $('#MXCompanyCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate();

        $('#RefreshButton').click(function () {
            refreshMXCompanyList();
        });

        //删除方法
        $('.delete-MXCompany').click(function () {
            var MXCompanyId = $(this).attr("data-MXCompany-id");
            var MXCompanyName = $(this).attr('data-MXCompany-name');
            deleteMXCompany(MXCompanyId, MXCompanyName);
        });

        //编辑方法
        $('.edit-MXCompany').click(function (e) {
            var MXCompanyId = $(this).attr("data-MXCompany-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'MXCompany/EditMXCompanyModal?id=' + MXCompanyId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#MXCompanyEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var MXCompany = { MXCompany: _$form.serializeFormToObject() }; //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _MXCompanyService.createOrUpdate(MXCompany).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new equipmentType!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshMXCompanyList() {
            location.reload(true); //reload page to see new equipmentType!
        }

        function deleteMXCompany(MXCompanyId, MXCompanyName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MianxiangProject'), MXCompanyName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _MXCompanyService.delete({
                            id: MXCompanyId
                        }).done(function () {
                            refreshMXCompanyList();
                        });
                    }
                }
            );
        }
    });
})();