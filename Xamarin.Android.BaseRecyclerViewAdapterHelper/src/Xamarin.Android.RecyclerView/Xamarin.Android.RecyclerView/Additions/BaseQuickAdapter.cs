using Android.Runtime;
using Java.Interop;
using System;

namespace Com.Chad.Library.Adapter.Base
{
    public abstract partial class BaseQuickAdapter
    {
        // Metadata.xml XPath method reference: path="/api/package[@name='com.chad.library.adapter.base']/class[@name='BaseQuickAdapter']/method[@name='onCreateViewHolder' and count(parameter)=2 and parameter[1][@type='android.view.ViewGroup'] and parameter[2][@type='int']]"
        [Register("onCreateViewHolder", "(Landroid/view/ViewGroup;I)Lcom/chad/library/adapter/base/BaseViewHolder;", "GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler")]
        public override unsafe global::Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(global::Android.Views.ViewGroup parent, int viewType)
        {
            const string __id = "onCreateViewHolder.(Landroid/view/ViewGroup;I)Lcom/chad/library/adapter/base/BaseViewHolder;";
            try
            {
                JniArgumentValue* __args = stackalloc JniArgumentValue[2];
                __args[0] = new JniArgumentValue((parent == null) ? IntPtr.Zero : ((global::Java.Lang.Object)parent).Handle);
                __args[1] = new JniArgumentValue(viewType);
                var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod(__id, this, __args);
                return global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.RecyclerView.ViewHolder>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
            }
            finally
            {
            }
        }
    }
}