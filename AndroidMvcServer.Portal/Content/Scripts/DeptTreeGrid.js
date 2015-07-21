Ext.require([
    'Ext.data.*',
    'Ext.grid.*',
    'Ext.tree.*'
]);

Ext.onReady(function () {
    Ext.QuickTips.init();

    Ext.define('dept', {
        extend: 'Ext.data.Model',
        fields: ['DepId',
                 'DepName',
                 'DirectorName',
                 'DepEmail',
                 'Status',
                 'Comment'
        ]
    });

    function renderTitle(value, p, record) {
        alert(123);
        return value;
    }

    var store = Ext.create('Ext.data.TreeStore', {
        model: 'dept',
        proxy: {
            type: 'ajax',
            reader: 'json',
            url: 'Dept/GetDeptListJson'
        },
        lazyFill: true
    });

    Ext.create('Ext.tree.Panel', {
        header: false,
        height: document.documentElement.clientHeight -50 ,
        autoScroll: true,
        renderTo: Ext.getBody(),
        collapsible: true,
        loadMask: false,
        useArrows: true,
        rootVisible: false,
        store: store,
        animate: true,
        plugins: [{
            ptype: 'bufferedrenderer'
        }],
        columns: [{
            xtype: 'treecolumn', //this is so we know which column will show the tree
            text: '部门名称',
            flex: 2.5,
            sortable: true,
            dataIndex: 'DepName'
        }, {
            text: '部门ID',
            flex: 1,
            dataIndex: 'DepId',
            sortable: true
        }, {
            text: '部门主管',
            flex: 1,
            dataIndex: 'DirectorName',
            sortable: true
        }, {
            text: '部门邮箱',
            flex: 2,
            dataIndex: 'DepEmail',
            sortable: true
        }],
        listeners: {
            'itemdblclick': function (me, record, item, index, e) {
                var window = new Ext.Window({
                    id: 'window',
                    title: '编辑',
                    width: 350,
                    height: 220,
                    plain: true,
                    modal: 'true',
                    layout: 'form',
                    items: [{
                        layout: 'column',
                        style: 'padding:8px;',
                        baseCls: 'x-plain',
                        items: [{
                            layout: 'form',
                            columnWidth: 0.95,
                            baseCls: 'x-plain',
                            items: [{
                                xtype: 'textfield',
                                fieldLabel: '部门名称',
                                value: record.data.DepName,
                                anchor: '90%'
                            }, {
                                id: 'age',
                                xtype: 'textfield',
                                fieldLabel: '部门ID',
                                value: record.data.DepId,
                                readOnly: true,
                                anchor: '90%'
                            }, {
                                xtype: 'textfield',
                                fieldLabel: '部门主管',
                                value: record.data.DirectorName,
                                anchor: '90%'
                            }, {
                                xtype: 'textfield',
                                fieldLabel: '部门邮箱',
                                value: record.data.DepEmail,
                                anchor: '90%'
                            }]
                        }]
                    }],
                    buttonAlign: 'center',
                    buttons: [{
                        text: '确定',
                        handler: function () {

                        }
                    }, {
                        text: '取消',
                        handler: function () {
                            window.close();
                        }
                    }]
                });
                window.show();
            }
        }
    });
});