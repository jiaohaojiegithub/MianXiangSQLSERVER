/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.toolbarGroups = [
        { name: 'clipboard', groups: ['clipboard', 'undo'] },
        { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
        { name: 'forms', groups: ['forms'] },
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
        { name: 'links', groups: ['links'] },
        { name: 'insert', groups: ['insert'] },
        { name: 'styles', groups: ['styles'] },
        { name: 'colors', groups: ['colors'] },
        { name: 'document', groups: ['document', 'doctools', 'mode'] },
        { name: 'tools', groups: ['tools'] },
        { name: 'others', groups: ['others'] },
        { name: 'about', groups: ['about'] }
    ];

    //�Ƴ��İ�ť
    config.removeButtons = 'Templates,Print,Find,Replace,SelectAll,Scayt,Checkbox,Form,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,CreateDiv,Blockquote,BidiLtr,BidiRtl,Flash,PageBreak,Iframe,About,ShowBlocks,Smiley,SpecialChar,HorizontalRule,CopyFormatting,RemoveFormat';

    //�ϴ�ͼƬ�����õ��Ľӿ�
    config.filebrowserImageUploadUrl = "http://122.51.177.94:8080/api/services/app/FileManage/UploadFiles";
    config.filebrowserUploadUrl = "http://122.51.177.94:8080/services/app/FileManage/UploadFiles";

    // ʹ�ϴ�ͼƬ�������ֶ�Ӧ�ġ��ϴ���tab��ǩ
    config.removeDialogTabs = 'image:advanced;link:advanced';

    //ճ��ͼƬʱ�õõ�
    config.extraPlugins = 'uploadimage';
    config.uploadUrl = 'http://localhost:21021/api/services/app/FileManage/UploadFiles';
};
