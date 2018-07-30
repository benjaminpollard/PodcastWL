using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLabelPodcastApp.Repos
{
    public class DatabaseRepo
    {
        Realm database;
        public DatabaseRepo()
        {
            database = Realm.GetInstance();
        }


        public void SaveItem<T>(T item) where T: RealmObject
        {
            database.Write(() =>
            {
                database.Add(item);
            });
        }

        public void Update<T>(T item) where T : RealmObject
        {
            database.Write(() =>
            {
                database.Add(item,true);
            });
        }

        public List<T> GetList<T>() where T : RealmObject
        {
            return database.All<T>().ToList();
        }
        public T Get<T>() where T : RealmObject
        {
            return database.All<T>().ToList().FirstOrDefault();
        }

        public void Remove<T>(T item) where T : RealmObject
        {
            // Delete an object with a transaction
            using (var trans = database.BeginWrite())
            {
                database.Remove(item);
                trans.Commit();
            }
        }

        public void RemoveAll<T>(T item) where T : RealmObject
        {
            // Delete an object with a transaction
            using (var trans = database.BeginWrite())
            {
                database.RemoveAll(item.GetType().ToString());
                trans.Commit();
            }
        }
    }
}
