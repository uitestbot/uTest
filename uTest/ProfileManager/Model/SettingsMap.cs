using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace ProfileManager.Model
{
    public class SettingsMap : ClassMapping<Settings>
    {
        public SettingsMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Increment));
            ManyToOne(x => x.CurrentProfile, x =>
            x.Column("CurrentProfile"));
            //Property(x => x.CurrentProfile);
        }
    }

}
