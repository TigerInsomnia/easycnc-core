Ext.onReady(function () {
    Ext.create('Ext.container.Viewport', {
        layout: 'border',
        items: [{
            region: 'north',
            layout:'column',
            border: false,
            height: 40,

            items:[{
                xtype: 'panel',
                columnWidth: 0.5,
                height: 40,
                border:false,
                bodyCls:'header-bg',
                layout:'column',
                items:[{
                    xtype : 'image',
                    src : "/img/logo.png",
                    width:30,
                    height:30,
                    margin:'5 0 5 5',

                },{
                    xtype: 'label',
                    text: '机械行业管理平台',
                    cls:'logo-title'
                }]

            },{
                xtype: 'panel',
                columnWidth: 0.5,
                height: 40,
                border: false,
                bodyCls: 'header-bg'
            }]
        }, {
            region: 'west',
            collapsible: true,
            split: true,
            id: 'MainMenu',
            title: '系统导航',
            width: 200,
            layout: 'fit',
            items: [
                {
                  
                    layout: 'fit',
                    items: [
                        {
                            xtype: 'treepanel',
                            border: 0,
                            rootVisible: true,                          
                            root: {
                                expanded: true,
                                text:'功能菜单',
                                children: [
                                    { id: "01", text: "用户管理", leaf: true, href: '/user' },
                                    { id: "02", text: "密码修改", leaf: true, href: '#' },
                                    { id: "03", text: "菜单管理", leaf: true, href: '#' }
                                ]
                            }
                        }
                    ]
                },
            ]
            // could use a TreePanel or AccordionLayout for navigational items
        }, {
            region: 'south',
            collapsible: false,
            html: '状态栏',
            split: false,
            height: 22
        },{
            region: 'center',
            xtype: 'tabpanel', 
            id: 'MainTabPanel',
            activeTab: 0,  
            items: {
                title: '首页',
                html: '<h1>欢迎使用</h1><input type="button" value="添加新标签" οnclick="CreateIframeTab(\'MainTabPanel\',\'01\', \'系统管理\', \'http://www.baidu.com\');" />'
            }
        }]
    });

    bindNavToTab("MainMenu", "MainTabPanel");
});

function bindNavToTab(accordionId, tabId) {
    var accordionPanel = Ext.getCmp(accordionId);
    if (!accordionPanel) return;

    var treeItems = accordionPanel.queryBy(function (cmp) {
        if (cmp && cmp.getXType() === 'treepanel') return true;
        return false;
    });
    if (!treeItems || treeItems.length == 0) return;

    for (var i = 0; i < treeItems.length; i++) {
        var tree = treeItems[i];

        tree.on('itemclick', function (view, record, htmlElement, index, event, opts) {
            if (record.isLeaf()) {
                // 阻止事件传播
                event.stopEvent();

                var href = record.data.href;

                if (!href) return;
                // 修改地址栏
                window.location.hash = '#' + href;
                // 新增Tab节点
                CreateIframeTab(tabId, record.data.id, record.data.text, href);
            }
        });
    }
}

function CreateIframeTab(tabpanelId, tabId, tabTitle, iframeSrc) {
    var tabpanel = Ext.getCmp(tabpanelId);
    if (!tabpanel) return;  //未找到tabpanel，返回

    //寻找id相同的tab
    var tab = Ext.getCmp(tabId);
    if (tab) { tabpanel.setActiveTab(tab); return; }

    //新建一个tab，并将其添加到tabpanel中
    //tab = Ext.create('Ext.tab.Tab', );
    tab = tabpanel.add({
        id: tabId,
        title: tabTitle,
        closable: true,
        html: '<iframe style="overflow:auto;width:100%; height:100%;" src="' + iframeSrc + '" frameborder="0"></iframe>'
    });
    tabpanel.setActiveTab(tab);
}