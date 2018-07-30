using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using WhiteLabelPodcastApp.Controllers;

namespace WhiteLabelPodcastApp.Droid.Dashboard
{
    public class DashboardFragment : Android.Support.V4.App.Fragment
    {
        DashboardController controller;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            controller = new DashboardController(new Repos.DatabaseRepo());

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_dashboard, container, false);
            var mLayoutManager = new GridLayoutManager(this.Context,4);//
            //GridLayoutManager gridVertical = new GridLayoutManager(this,3,GridLayoutManager.VERTICAL,false);

            var mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.fragment_dashboard_recycle_view);

            mRecyclerView.HasFixedSize = true;
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mRecyclerView.SetAdapter(new DashboardAdapter(controller.GetPodcasts()));

            return view;
           // return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}