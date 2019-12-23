(function () {
    $(function () {

        var _MXQuestionService = abp.services.app.mXQuestion;
        var _$modal = $('#MXQuestionCreateModal');
        var _$form = _$modal.find('form');
        //var myEditor = null;
        _$form.validate();

        $('#RefreshButton').click(function () {
            refreshMXQuestionList();
        });
        //DataTable
        $('#MXQuestionTable').DataTable({
            processing: true,
            serverSide: true,
            autoWidth: false,
            ajax: {
                type: 'post',
                url: '/MXQuestion/GetList',
                dataSrc: 'data',//,
                data: function (d) {
                    input: {
                        SkipCount = d.start;//跳过元素
                        MaxResultCount = d.length;//，每页数据
                        //FilterText =$('input[type="search"]').val();
                    }
                },
                dataType: 'json',
                dataFilter: function (data) {//json是服务器端返回的数据                   
                    return data;
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    // window.parent.location.href = "login.html";
                    console.log(XMLHttpRequest);
                    console.log(textStatus);
                    console.log(errorThrown);
                }
            },
            columns: [
                { data: 'id', title: 'Id' },
                { data: 'question', title: '题目', orderable: false, width:"20%" },
                { data: 'questionTypeVaule', title: '题目类型', orderable: false, width: "10%" },
                { data: 'questionCate', title: '题目种类', width: "10%" },
                { data: 'answer', title: '答案' },
                { data: 'options', title: '选项' },
                { data: 'tags', title: '标签' },              
                {
                    data: 'id',             
                    title: "操作",
                    className: 'dropdown'
                }
            ],
            columnDefs: [
                {
                    // The `data` parameter refers to the data for the cell (defined by the
                    // `data` option, which defaults to the column being worked with, in
                    // this case `data: 0`.
                    render: function (data, type, row) {
                        var Actionhtml =
                            '   <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false" >'
                            + '     <i class="material-icons">menu</i>'
                            + '   </a>'
                            + '   <ul class="dropdown-menu pull-right">'
                            + '      <li><a href="#" class="waves-effect waves-block edit-MXQuestion" data-MXQuestion-id="' + row.id + '" data-toggle="modal" data-target="#MXQuestionEditModal"><i class="material-icons">edit</i>编辑</a></li>'
                            + '    <li><a href="#" class="waves-effect waves-block delete-MXQuestion" data-MXQuestion-id="' + row.id + '" data-MXQuestion-name="' + row.QuestionTypeVaule + '"><i class="material-icons">delete_sweep</i>删除</a></li>'
                            + '   </ul>';
                        return Actionhtml;
                    },
                    targets: 7
                }
            ],

            language: {
                "sProcessing": "处理中...",
                "sLengthMenu": "显示 _MENU_ 项结果",
                "sZeroRecords": "没有匹配结果",
                "sInfo": "显示第 _START_ 至 _END_ 项结果，共 _TOTAL_ 项",
                "sInfoEmpty": "显示第 0 至 0 项结果，共 0 项",
                "sInfoFiltered": "(由 _MAX_ 项结果过滤)",
                "sInfoPostFix": "",
                "sSearch": "搜索:",
                "sUrl": "",
                "sEmptyTable": "表中数据为空",
                "sLoadingRecords": "载入中...",
                "sInfoThousands": ",",
                "oPaginate": {
                    "sFirst": "首页",
                    "sPrevious": "上页",
                    "sNext": "下页",
                    "sLast": "末页"
                },
                "oAria": {
                    "sSortAscending": ": 以升序排列此列",
                    "sSortDescending": ": 以降序排列此列"
                }
            }
        });
        
      
        //
        $('#AddOption').click(function () {
            var key = $('#OptionKey option:selected').val();
            var value = $('#OptionsInput').val();
            OptionsHtml = '<div class="input-group">'
                + '<div class="input-group-btn" style="width:40px;">'
                + ' <input type="text" value="' + key + '" class="form-control">'
                + '</div>'
                + '<div class="form-line">'
                + '   <input type="text" name="OptionsItme" id="' + key + '" value="' + value + '"  class="validate form-control">'
                + '</div>'
                + ' <div class="input-group-addon">'
                + '     <a href="#" class="RemoveOption"><i class="material-icons">remove</i></a>'
                + ' </div>'
                + '</div>';


            if (document.getElementById(key)) {
                alert('对象存在');
            } else {
                $('.OptionInfo').append(OptionsHtml);
            }
        });
        $(document).on('click', '.RemoveOption', function () {
            $(this).parent().parent().remove();
        });
        //$('.RemoveOption').click(function () {
        //    $(this).parent().parent().remove();
        //});
        //编辑器
        //ClassicEditor
        //    .create(document.querySelector('#Question'), {
        //        language: 'zh-cn',  //设置语言
        //        toolbar: {          //设置工具栏
        //            items: [
        //                'heading',
        //                '|',
        //                'bold',
        //                'italic',
        //                'link',
        //                'bulletedList',
        //                'numberedList',
        //                'imageUpload',
        //                'blockQuote',
        //                'insertTable',
        //                //'mediaEmbed',
        //                'undo',
        //                'redo'
        //            ]
        //        },
        //        ckfinder: {     //设置上传路径
        //            uploadUrl:'http://localhost:21021/api/services/app/FileManage/UploadFiles'
        //            //后端处理上传逻辑返回json数据,包括uploaded(选项true/false)和url两个字段
        //        }
        //    })
        //    .then(editor => {
        //        //editor.plugins.get('FileRepository').createUploadAdapter = (loader) => {
        //        //    return new UploadAdapter(loader);
        //        //};
        //        myEditor = editor;
        //    })
        //    .catch(error => {
        //        console.error(error);
        //    });
        CKEDITOR.replace('Question');
        //题目类型
        $('#QuestionType').change(function () {
            var QuestionTypeValue = $('#QuestionType option:selected').text();
            switch (QuestionTypeValue) {
                case '单选题':
                case '多选题':
                    $('#OptionsInput').parent().parent().parent().parent().parent().removeAttr('hidden');
                    $('#OptionInfo').removeAttr('hidden');
                    break;
                case '简答题':
                case '判断题':
                case '填空题':
                    $('#OptionsInput').parent().parent().parent().parent().parent().attr('hidden', 'hidden');
                    $('#OptionInfo').attr('hidden', 'hidden');
                    break;
                default:
                    break;
            }
        });
        //定义标签属性
        var _$tagsKnowledgeLables = $('#Tags');
        _$tagsKnowledgeLables.tagsinput({
            maxChars: 10,//每个标签最大字符数量10个
            maxTags: 10//最多支持10个标签
        });
        //删除方法
        $(document).on('click', '.delete-MXQuestion', function () {
            var MXQuestionId = $(this).attr("data-MXQuestion-id");
            var MXQuestionName = $(this).attr('data-MXQuestion-name');
            deleteMXQuestion(MXQuestionId, MXQuestionName);
        });
        //$('.delete-MXQuestion').click(function () {
        //    var MXQuestionId = $(this).attr("data-MXQuestion-id");
        //    var MXQuestionName = $(this).attr('data-MXQuestion-name');
        //    deleteMXQuestion(MXQuestionId, MXQuestionName);
        //});

        //编辑方法
        //$('.edit-MXQuestion').click(function (e) {
        //    var MXQuestionId = $(this).attr("data-MXQuestion-id");

        //    e.preventDefault();
        //    $.ajax({
        //        url: abp.appPath + 'MXQuestion/EditMXQuestionModal?id=' + MXQuestionId,
        //        type: 'POST',
        //        contentType: 'application/html',
        //        success: function (content) {
        //            $('#MXQuestionEditModal div.modal-content').html(content);
        //        },
        //        error: function (e) { }
        //    });
        //});
        $(document).on('click', '.edit-MXQuestion', function (e) {
            var MXQuestionId = $(this).attr("data-MXQuestion-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'MXQuestion/EditMXQuestionModal?Id=' + MXQuestionId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#MXQuestionEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var MXQuestion = { MXQuestion: _$form.serializeFormToObject() }; //serializeFormToObject is defined in main.js


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
            // MXQuestion.MXQuestion.Question = myEditor.getData();
            MXQuestion.MXQuestion.Question = CKEDITOR.instances.Question.getData();
            abp.ui.setBusy(_$modal);
            _MXQuestionService.createOrUpdate(MXQuestion).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new equipmentType!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshMXQuestionList() {
            location.reload(true); //reload page to see new equipmentType!
        }

        function deleteMXQuestion(MXQuestionId, MXQuestionName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MianxiangProject'), MXQuestionName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _MXQuestionService.delete({
                            id: MXQuestionId
                        }).done(function () {
                            refreshMXQuestionList();
                        });
                    }
                }
            );
        }


    });

})();