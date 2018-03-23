using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ProfileManager.Model
{
    public class ProfileMap : ClassMapping<Profile>
    {
        public ProfileMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Increment));
            Property(x => x.ProfileName);
            Property(x => x.TestRailUrl);
            Property(x => x.TestRailUsername);
            Property(x => x.TestRailPassword);
            Property(x => x.IsTestRailReportEnabled);
            Property(x => x.RerunIfFailed);
            Property(x => x.SpeedMultiplier);
            Property(x => x.DefaultTimeout);
        }
    }

}
