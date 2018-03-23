using NHibernate;
using ProfileManager.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProfileManager.Dao
{
    public class NHibernateSettingsRepository : ISettingsRepository
    {
        public void Save(Settings settings)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(settings);
                transaction.Commit();
            }
        }

        public Settings Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<Settings>(id);
        }

        public List<Settings> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Query<Settings>().ToList<Settings>();
        }

        public Settings GetLast()
        {
            List<Settings> settingsList = GetAll();

            var max = settingsList.Max(s => s.Id);
            var result =  settingsList.Find(s => s.Id == max);

            return result;
        }

        public void Update(Settings settings)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(settings);
                transaction.Commit();
            }
        }

        public void Delete(Settings settings)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(settings);
                transaction.Commit();
            }
        }

        public long RowCount()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Settings>().RowCountInt64();
            }
        }
    }

}
