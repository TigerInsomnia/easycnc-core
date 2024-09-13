
Ext.override(Ext.form.field.Base,{
    initComponent:function(){
        if(this.allowBlank!==undefined && !this.allowBlank){
            if(this.fieldLabel){
                this.fieldLabel += '<span style="color: red; ">*</span>';
            }
        }
        this.callParent(arguments);
    }
});
