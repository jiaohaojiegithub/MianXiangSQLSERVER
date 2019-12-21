(function () {
    $(function () {

        var _MXJobService = abp.services.app.mXJob;
        var _$modal = $('#MXJobCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate();

        $('#RefreshButton').click(function () {
            refreshMXJobList();
        });

        //删除方法
        $('.delete-MXJob').click(function () {
            var MXJobId = $(this).attr("data-MXJob-id");
            var MXJobName = $(this).attr('data-MXJob-name');
            deleteMXJob(MXJobId, MXJobName);
        });

        //编辑方法
        $('.edit-MXJob').click(function (e) {
            var MXJobId = $(this).attr("data-MXJob-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'MXJob/EditMXJobModal?id=' + MXJobId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#MXJobEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var MXJob = { MXJob: _$form.serializeFormToObject() }; //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _MXJobService.createOrUpdate(MXJob).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new equipmentType!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshMXJobList() {
            location.reload(true); //reload page to see new equipmentType!
        }

        function deleteMXJob(MXJobId, MXJobName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MianxiangProject'), MXJobName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _MXJobService.delete({
                            id: MXJobId
                        }).done(function () {
                            refreshMXJobList();
                        });
                    }
                }
            );
        }
    });
})();