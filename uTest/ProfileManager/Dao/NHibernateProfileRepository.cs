using NHibernate;
using ProfileManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileManager.Dao
{
    public class NHibernateProfileRepository : IProfileRepository
    {
        public void Save(Profile profile)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Save(profile);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public Profile Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<Profile>(id);
        }

        public List<Profile> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Query<Profile>().ToList<Profile>();
        }

        public Profile GetLast()
        {
            List<Profile> ProfileList = GetAll();

            var max = ProfileList.Max(s => s.Id);
            var result =  ProfileList.Find(s => s.Id == max);

            return result;
        }

        public void Update(Profile profile)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Update(profile);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public void Delete(Profile profile)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(profile);
                transaction.Commit();
            }
        }

        public long RowCount()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<Profile>().RowCountInt64();
            }
        }
    }

}
