using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace MapDemo
{
    [Activity(Label = "MapDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;


        private GoogleMap _map;
        private MapFragment _mapFragment;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            var btnLocate = FindViewById<Button>(Resource.Id.btnLocate);

            //將地圖初始化
            _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeSatellite)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);

                var fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }


            btnLocate.Click += delegate
            {
                if (_map == null)
                {
                    _map = _mapFragment.Map;

                }
                if (_map != null)
                {
                    //定位置台北101
                    _map.MapType = GoogleMap.MapTypeNormal;
                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(new LatLng(25.033611, 121.565000), 15);
                    _map.MoveCamera(cameraUpdate);
                }
            };

        }
    }
}

