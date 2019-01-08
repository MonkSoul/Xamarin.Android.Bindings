using Android.Support.V7.Widget;
using Com.Chad.Library.Adapter.Base;
using System;
using System.Collections.Generic;

namespace App14
{
    public class MyAdapter : BaseQuickAdapter
    {
        public MyAdapter(int layoutResId, List<Model> data) : base(layoutResId: layoutResId, data: data)
        {
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);
        }

        protected override void Convert(Java.Lang.Object p0, Java.Lang.Object p1)
        {
            var helper = (BaseViewHolder)p0;
            var item = (Model)p1;

            helper.SetText(Resource.Id.tv_title, item.Title)
                .SetText(Resource.Id.tv_content, item.Content)
                .SetImageResource(Resource.Id.iv_img, Resource.Mipmap.ic_launcher);
        }
    }
}