using Microsoft.EntityFrameworkCore;
using Portfolio.Data;

namespace ProjectTests;

public class identity01Test
{
    private ApplicationDbContext _context;
    private DbContextOptions<ApplicationDbContext> _options;

    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;

        _context = new ApplicationDbContext(_options);
        _context.Database.OpenConnection();
        _context.Database.EnsureCreated();
    }

    [TearDown]
    public void TearDown()
    {
        if (_context != null)
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }

    [Test]
    public void identity01_ShouldApplyMigrationCorrectly()
    {
        // Act
        _context.Database.Migrate();

        // Assert
        var appliedMigrations = _context.Database.GetAppliedMigrations();
        Assert.Contains("20250130231619_identity01", appliedMigrations.ToList());

        // Verify the schema
        var model = _context.Model;
        Assert.IsNotNull(model.FindEntityType("Portfolio.Models.User"));
        Assert.IsNotNull(model.FindEntityType("Portfolio.Models.Project"));
        Assert.IsNotNull(model.FindEntityType("Portfolio.Models.Category"));
        Assert.IsNotNull(model.FindEntityType("Portfolio.Models.Comment"));
        Assert.IsNotNull(model.FindEntityType("Portfolio.Models.Image"));
        Assert.IsNotNull(model.FindEntityType("Portfolio.Models.LikedComments"));
        Assert.IsNotNull(model.FindEntityType("Portfolio.Models.LikedProjects"));
        Assert.IsNotNull(model.FindEntityType("Portfolio.Models.Role"));
    }
}
