using ProfileManager.Model;
using System.Collections.Generic;

namespace ProfileManager.Dao
{
    public interface ISettingsRepository
    {
        /// <summary>
        /// Get settings entity by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>person</returns>
        Settings Get(int id);

        /// <summary>
        /// Get all settingss
        /// </summary>
        /// <returns>settings</returns>
        List<Settings> GetAll();

        /// <summary>
        /// Get last settingss
        /// </summary>
        /// <returns>person</returns>
        Settings GetLast();

        /// <summary>
        /// Save settings entity
        /// </summary>
        /// <param name="Settings">settingss</param>
        void Save(Settings settings);

        /// <summary>
        /// Update settings entity
        /// </summary>
        /// <param name="Settings">settingss</param>
        void Update(Settings settings);

        /// <summary>
        /// Delete settings entity
        /// </summary>
        /// <param name="settings">settings</param>
        void Delete(Settings settings);

        /// <summary>
        /// Row count settings in db
        /// </summary>
        /// <returns>number of rows</returns>
        long RowCount();
    }

}
