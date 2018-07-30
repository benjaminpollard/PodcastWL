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
            var l = new List<PodcastModel>();
            var bb = new PodcastModel();
            bb.isFav = true;
            bb.name = "test 1";
            l.Add(bb);

            var bb2 = new PodcastModel();
            bb2.isFav = false;
            bb2.name = "test 2";

            l.Add(bb2);
            this.database.SaveItems(l);
        }

        public List<PodcastModel> GetPodcasts()
        {
            return database.GetList<PodcastModel>();
        }
    }
}
