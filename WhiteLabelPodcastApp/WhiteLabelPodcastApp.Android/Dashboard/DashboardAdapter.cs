using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Square.Picasso;

namespace WhiteLabelPodcastApp.Droid.Dashboard
{
    class DashboardAdapter : RecyclerView.Adapter
    {
        public List<PodcastModel> itemList;

        public DashboardAdapter(List<PodcastModel> itemList)
        {
            this.itemList = itemList;
        }

        public override int ItemCount => itemList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DashboardItem vh = holder as DashboardItem;

            // Load the photo image resource from the photo album:
            if (itemList[position].imageUrl != null && itemList[position].imageUrl != "")
            {
                Picasso.With(vh.Image.Context).Load(itemList[position].imageUrl).Into(vh.Image);
            }
            else
            {
                try
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    vh.Image.SetBackgroundColor(vh.Image.Context.Resources.GetColor(Resource.Color.my_blue));
#pragma warning restore CS0618 // Type or member is obsolete
                }
                catch { }
            }

            if (itemList[position].isFav)
            {
                vh.favImage.SetImageResource(Resource.Drawable.heart_on);
            }
            else
            {
                vh.favImage.SetImageResource(Resource.Drawable.heart_off);
            }

            // Load the photo caption from the photo album:
            vh.Caption.Text = itemList[position].name;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                            Inflate(Resource.Layout.list_item_dashboard, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            DashboardItem vh = new DashboardItem(itemView);
            return vh;

        }

        public class DashboardItem : RecyclerView.ViewHolder
        {
            public ImageView Image { get; private set; }
            public ImageView favImage { get; private set; }
            public TextView Caption { get; private set; }

            public DashboardItem(View itemView) : base(itemView)
            {
                // Locate and cache view references:
                Image = itemView.FindViewById<ImageView>(Resource.Id.list_item_dash_pod_icon);
                favImage = itemView.FindViewById<ImageView>(Resource.Id.list_item_dash_pod_fav);
                Caption = itemView.FindViewById<TextView>(Resource.Id.list_item_dashboard_title);
            }
        }
    }
}