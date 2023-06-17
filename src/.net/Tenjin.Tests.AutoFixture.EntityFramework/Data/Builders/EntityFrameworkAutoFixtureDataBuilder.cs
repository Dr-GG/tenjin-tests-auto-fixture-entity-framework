using Microsoft.EntityFrameworkCore;
using Tenjin.Tests.AutoFixture.Data.Builders;
using Tenjin.Tests.AutoFixture.Data.Builders.Options;

namespace Tenjin.Tests.AutoFixture.EntityFramework.Data.Builders;

/// <summary>
/// The extended AutoFixtureDataBuilder that uses a DbContext to build data.
/// </summary>
/// <typeparam name="TDbContext"></typeparam>
public abstract class EntityFrameworkAutoFixtureDataBuilder<TDbContext> : AutoFixtureDataBuilder where TDbContext : DbContext
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    protected EntityFrameworkAutoFixtureDataBuilder(
        TDbContext dbContext,
        AutoFixtureDataBuilderOptions? options = null) : base(options)
    {
        DbContext = dbContext;
    }

    /// <summary>
    /// The DbContext instance being used.
    /// </summary>
    public TDbContext DbContext { get; }

    /// <summary>
    /// Saves the current data.
    /// </summary>
    public override void Save()
    {
        DbContext.SaveChanges();
    }
}