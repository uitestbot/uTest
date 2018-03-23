using ProfileManager.Model;
using System;
using System.Collections.Generic;

namespace ProfileManager.Dao
{
    public interface IProfileRepository
    {
        /// <summary>
        /// Get profile entity by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>person</returns>
        Profile Get(int id);

        /// <summary>
        /// Get all profiles
        /// </summary>
        /// <returns>person</returns>
        List<Profile> GetAll();

        /// <summary>
        /// Get last profile
        /// </summary>
        /// <returns>person</returns>
        Profile GetLast();

        /// <summary>
        /// Save profile entity
        /// </summary>
        /// <param name="profile">profile</param>
        void Save(Profile profile);

        /// <summary>
        /// Update profile entity
        /// </summary>
        /// <param name="profile">profile</param>
        void Update(Profile profile);

        /// <summary>
        /// Delete profile entity
        /// </summary>
        /// <param name="profile">profile</param>
        void Delete(Profile profile);

        /// <summary>
        /// Row count profile in db
        /// </summary>
        /// <returns>number of rows</returns>
        long RowCount();
    }

}
