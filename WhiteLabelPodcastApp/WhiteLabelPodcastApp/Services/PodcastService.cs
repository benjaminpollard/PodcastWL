using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WhiteLabelPodcastApp.Models;

namespace WhiteLabelPodcastApp.Services
{
    public class PodcastService
    {
   
        public PodcastService()
        {
        }

        public async Task<List<RSSFeedItem>> ParseFeed(string rss)
        {
            return await Task.Run(() =>
            {
                var xdoc = XDocument.Parse(rss);
                var id = 0;
                return (from item in xdoc.Descendants("item")
                        select new RSSFeedItem
                        {
                    
                            Title = (string)item.Element("title"),
                            Description = (string)item.Element("description"),
                            Link = (string)item.Element("link"),
                            PublishDate = (string)item.Element("pubDate"),
                            ID = id++.ToString()
                        }).ToList();
            });
        }


    }
}
