using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ProfileManager.Model
{
    public class ApplicationMap : ClassMapping<Application>
    {
        public ApplicationMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Increment));
            Property(x => x.Version);
            Property(x => x.Parameters);
        }
    }

}
