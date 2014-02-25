using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using UserInfo.Entity;
using UserInfo.Model;
using UserInfo.Common;

namespace UserInfo
{
    [Activity(Label = "UserInfo", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btnSave);

            button.Click += button_Click;

            Button btnSearch = FindViewById<Button>(Resource.Id.btnShowData);
            btnSearch.Click += btnSearch_Click;
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        void button_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            User u = new User();
            u.Name = FindViewById<EditText>(Resource.Id.txtName).Text;
            u.Pwd= FindViewById<EditText>(Resource.Id.txtPwd).Text;
            bool flag = da.InsertData(u);
            if (flag)
            {
                MessageBox.Show(this, "提示", "保存成功！");
            }
            else
            {
                MessageBox.Show(this, "提示", "保存失败！");
            }
        }
    }
}

