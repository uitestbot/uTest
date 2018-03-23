using ProfileManager.Model;
using System.Collections.Generic;

namespace ProfileManager.Dao
{
    public interface IApplicationRepository
    {
        /// <summary>
        /// Get application entity by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>person</returns>
        Application Get(int id);

        /// <summary>
        /// Get all applications
        /// </summary>
        /// <returns>application</returns>
        List<Application> GetAll();

        /// <summary>
        /// Get last applications
        /// </summary>
        /// <returns>person</returns>
        Application GetLast();

        /// <summary>
        /// Save application entity
        /// </summary>
        /// <param name="Application">applications</param>
        void Save(Application application);

        /// <summary>
        /// Update application entity
        /// </summary>
        /// <param name="Application">applications</param>
        void Update(Application application);

        /// <summary>
        /// Delete application entity
        /// </summary>
        /// <param name="application">application</param>
        void Delete(Application application);

        /// <summary>
        /// Row count application in db
        /// </summary>
        /// <returns>number of rows</returns>
        long RowCount();
    }

}
