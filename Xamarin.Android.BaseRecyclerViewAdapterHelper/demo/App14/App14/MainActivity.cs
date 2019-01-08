using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace App14
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView recyclerView;
        private List<Model> datas;
        private MyAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);

            datas = new List<Model>();
            for (int i = 0; i < 15; i++)
            {
                datas.Add(new Model
                {
                    Title = "我是第" + i + "条标题",
                    Content = "第" + i + "条内容"
                });
            }

            LinearLayoutManager layoutManager = new LinearLayoutManager(this)
            {
                Orientation = LinearLayoutManager.Vertical
            };
            recyclerView.SetLayoutManager(layoutManager);

            adapter = new MyAdapter(Resource.Layout.item_rv, datas);
            recyclerView.SetAdapter(adapter);
        }
    }
}