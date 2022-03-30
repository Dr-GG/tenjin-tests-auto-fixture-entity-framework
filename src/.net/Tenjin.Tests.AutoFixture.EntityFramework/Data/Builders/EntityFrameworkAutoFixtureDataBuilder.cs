using Microsoft.EntityFrameworkCore;
using Tenjin.Tests.Data.Builders.AutoFixture;
using Tenjin.Tests.Data.Builders.AutoFixture.Options;

namespace Tenjin.Tests.AutoFixture.EntityFramework.Data.Builders
{
    public abstract class EntityFrameworkAutoFixtureDataBuilder<TDbContext> : AutoFixtureDataBuilder where TDbContext : DbContext
    {
        protected EntityFrameworkAutoFixtureDataBuilder(
            TDbContext dbContext,
            AutoFixtureDataBuilderOptions? options = null) : base(options)
        {
            DbContext = dbContext;
        }

        public TDbContext DbContext { get; }

        public override void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
