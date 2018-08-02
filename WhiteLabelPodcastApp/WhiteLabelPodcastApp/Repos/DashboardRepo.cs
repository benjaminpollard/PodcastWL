using System;
using System.Collections.Generic;
using WhiteLabelPodcastApp.Droid.Dashboard;
using WhiteLabelPodcastApp.Services;

namespace WhiteLabelPodcastApp.Repos
{
    public class DashboardRepo
    {
        PodcastService podcastService;
        public DashboardRepo(PodcastService podcastService)
        {
            this.podcastService = podcastService;
        }
       
        //private static final String TopLevelPodcast =  "http://www.toplevelpodcast.com/tag/podcasts/feed/";
        //private static final String TheCommaneZone = "https://collected.company/category/the-command-zone/feed/";
        //private static final String MondayNightMagic = "http://mtgcast.com/topics/mtgcast-podcast-shows/active-podcast-shows/monday-night-magic/feed";
        //private static final String TapTapConced =  "http://loadingreadyrun.com/lrrcasts/feed/ttc";
        //private static final String MastersOfModen = "https://collected.company/category/the-masters-of-modern/feed/";
        public List<PodcastModel> PodcastDefaults()
        {
            var l = new List<PodcastModel>();
            var dtw = new PodcastModel();
            dtw.name = "Drive To Work";
            dtw.URL = "http://www.wizards.com/drivetoworkpodcast.xml";
            dtw.imageUrl = "";
            l.Add(dtw);

            var lr = new PodcastModel();
            lr.isFav = false;
            lr.name = "Limited Resources";
            lr.URL = "http://lrcast.com/feed/";
            l.Add(lr);

            return l;
        } 

        public System.Threading.Tasks.Task<List<Models.RSSFeedItem>> GetFeed(String Url)
        {
            if(Url.Equals(String.Empty))
            {
                return;
            }
            return podcastService.ParseFeed(Url);
        }
    }
}
