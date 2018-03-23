using NHibernate;
using ProfileManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileManager.Dao
{
    public class NHibernateApplicationRepository : IApplicationRepository
    {
        public void Save(Application application)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(application);
                transaction.Commit();
            }
        }

        public Application Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<Application>(id);
        }

        public List<Application> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Query<Application>().ToList<Application>();
        }

        public Application GetLast()
        {
            List<Application> applicationList = GetAll();

            var max = applicationList.Max(s => s.Id);
            var result =  applicationList.Find(s => s.Id == max);

            return result;
        }

        public void Update(Application application)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(application);
                transaction.Commit();
            }
        }

        public void Delete(Application application)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(application);
                transaction.Commit();
            }
        }

        public long RowCount()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Application>().RowCountInt64();
            }
        }
    }

}
