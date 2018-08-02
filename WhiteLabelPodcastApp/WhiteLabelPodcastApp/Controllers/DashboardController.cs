using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLabelPodcastApp.Droid.Dashboard;
using WhiteLabelPodcastApp.Repos;

namespace WhiteLabelPodcastApp.Controllers
{
    public class DashboardController
    {
        DatabaseRepo database;
        DashboardRepo dashboardRepo;

        public DashboardController(DatabaseRepo database, DashboardRepo dashboardRepo)
        {
            this.database = database;
            this.dashboardRepo = dashboardRepo;

        }

        public List<PodcastModel> GetPodcastsFromDatabase()
        {
            //if(database.GetList<PodcastModel>().Count == 0)
            //{
            //    database.SaveItem(dashboardRepo.PodcastDefaults());
            //    return dashboardRepo.PodcastDefaults();
            //}
            return dashboardRepo.PodcastDefaults();
        }

        public List<PodcastModel> GetPodcastsNetwork()
        {
            return database.GetList<PodcastModel>();
        }

        public Task<List<Models.RSSFeedItem>> GetFeed(PodcastModel podcastModel)
        {
            return dashboardRepo.GetFeed(podcastModel.URL);
        }
    }
}
