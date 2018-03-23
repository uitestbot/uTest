using System;
using NHibernate.Tool.hbm2ddl;
using ProfileManager.Dao;
using System.IO;
using ProfileManager.Model;
using System.Collections.Generic;

namespace ProfileManager
{
    public class ProfileManager
    {
        private static IProfileRepository ProfileRepository;
        private static ISettingsRepository SettingsRepository;
        private static IApplicationRepository ApplicationRepository;
        public static Profile DefaultProfile;
        public static Profile Profile;
        public static List<Profile> Profiles;
        public static List<Application> ApplicationList;

        public static List<Profile> GetProfiles()
        {
            try
            {
                var profiles = ProfileRepository.GetAll();

                return profiles;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting profiles!", ex);
            }
        }

        public static Profile GetDefaultProfile()
        {
            try
            {
                var currentProfile = ProfileRepository.Get(1);

                return currentProfile;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting default profile!", ex);
            }
        }

        public static List<Application> GetApplicationList()
        {
            try
            {
                var applicationList = ApplicationRepository.GetAll();

                return applicationList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting application list!", ex);
            }
        }

        public static void InitProfile()
        {
            try
            {
                SetProfileRepository();
                SetSettingsRepository();
                //SetApplicationRepository();
                CreateDB();
                InitDefaultProfile();
                SetDefaultProfile();
                InitDefaultSettings();
                SetProfiles();
                //SetApplicationList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing profile!", ex);
            }
        }

        private static void SetProfileRepository()
        {
            ProfileRepository = new NHibernateProfileRepository();
        }

        private static void SetSettingsRepository()
        {
            SettingsRepository = new NHibernateSettingsRepository();
        }

        private static void SetApplicationRepository()
        {
            ApplicationRepository = new NHibernateApplicationRepository();
        }

        private static void CreateDB()
        {
            if (File.Exists(@"profiles.db")) return;

            try
            {
                var schemaUpdate = new SchemaUpdate(NHibernateHelper.Configuration);
                schemaUpdate.Execute(false, true);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating profile!", ex);
            }
        }

        private static void InitDefaultProfile()
        {
            if (!File.Exists(@"profiles.db")) return;
            if (ProfileRepository.RowCount() > 0) return;

            ProfileRepository.Save(new Profile
            {
                ProfileName = @"default",
                TestRailUrl = @"http://10.0.33.57/",
                TestRailUsername = @"sevim.ataseven@comodo.com",
                TestRailPassword = @"browser",
                IsTestRailReportEnabled = true,
                RerunIfFailed = 2,
                SpeedMultiplier = 1,
                DefaultTimeout = 30
            });
        }

        private static void InitDefaultSettings()
        {
            if (!File.Exists(@"profiles.db")) return;
            if (SettingsRepository.RowCount() > 0) return;

            SettingsRepository.Save(new Settings
            {
                CurrentProfile = DefaultProfile
            });
        }

        private static void SetDefaultProfile()
        {
            DefaultProfile = GetDefaultProfile();
        }

        private static void SetApplicationList()
        {
            ApplicationList = GetApplicationList();
        }

        private static void SetProfiles()
        {
            Profiles = GetProfiles();
        }

        public static void UpdateProfile()
        {
            ProfileRepository.Update(Profile);
        }

        public static void SaveProfile()
        {
            ProfileRepository.Save(Profile);
        }

        public static void DeleteProfile()
        {
            ProfileRepository.Delete(Profile);
        }

        public static void AddTestValues()
        {
            if (!File.Exists(@"profiles.db")) return;

            if (ApplicationRepository.RowCount() > 0) return;
            ApplicationRepository.Save(new Application
            {
                Version = @"60.0.3112.114",
                Parameters = @"ProductId=19;ChannelId=25050030001"
            });
        }

    }

}
