using System;
using Realms;

namespace WhiteLabelPodcastApp.Models
{
    public class RSSFeedItem : RealmObject
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String Link { get; set; }
        public String PublishDate { set; get; }
        public String ID { set; get; }

    }
}
