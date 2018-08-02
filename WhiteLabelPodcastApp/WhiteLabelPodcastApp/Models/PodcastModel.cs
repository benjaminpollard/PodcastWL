using Realms;
using System;


namespace WhiteLabelPodcastApp.Droid.Dashboard
{

    public class PodcastModel : RealmObject
    {
        public String name { get; set; }
        public Boolean isFav { get; set; }
        public String imageUrl { get; set; }
        public string URL { set; get; }
    }
}