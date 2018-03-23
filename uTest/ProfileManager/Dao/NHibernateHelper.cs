using System.Collections.Generic;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate;
using ProfileManager.Model;

namespace ProfileManager.Dao
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;
        private static HbmMapping _mapping;

        public static ISession OpenSession()
        {
            //Open and return the nhibernate session
            return SessionFactory.OpenSession();
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    //Create the session factory
                    _sessionFactory = Configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    //Create the nhibernate configuration
                    _configuration = CreateConfiguration();
                }
                return _configuration;
            }
        }

        public static HbmMapping Mapping
        {
            get
            {
                if (_mapping == null)
                {
                    //Create the mapping
                    _mapping = CreateMapping();
                }
                return _mapping;
            }
        }

        private static Configuration CreateConfiguration()
        {
            var configuration = new Configuration();
            //Loads properties from hibernate.cfg.xml
            configuration.SessionFactoryName(@"NHibernate.Test");
            configuration.Properties[@"connection.driver_class"] = @"NHibernate.Driver.SQLite20Driver";
            configuration.Properties[@"connection.connection_string"] = @"Data Source=profiles.db;Version=3;New=True";
            configuration.Properties[@"dialect"] = @"NHibernate.Dialect.SQLiteDialect";
            configuration.Properties[@"show_sql"] = @"true";

            //Loads nhibernate mappings 
            configuration.AddDeserializedMapping(Mapping, null);

            return configuration;
        }

        private static HbmMapping CreateMapping()
        {
            var mapper = new ModelMapper();
            //Add the person mapping to the model mapper
            mapper.AddMappings(new List<System.Type> { typeof(ProfileMap) });
            mapper.AddMappings(new List<System.Type> { typeof(ApplicationMap) });
            mapper.AddMappings(new List<System.Type> { typeof(SettingsMap) });
            //Create and return a HbmMapping of the model mapping in code
            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }

}
