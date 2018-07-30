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

        public DashboardController(DatabaseRepo database)
        {
            this.database = database;
        }

        public List<PodcastModel> GetPodcasts()
        {
            return database.GetList<PodcastModel>();
        }
    }
}
