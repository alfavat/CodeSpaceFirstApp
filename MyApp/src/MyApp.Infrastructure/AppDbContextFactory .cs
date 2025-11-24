using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyApp.Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        var connectionString = "Server=sql7.freesqldatabase.com;Port=3306;Database=sql7808853;User=sql7808853;Password=n5hAXMNbqy;";

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));


        return new AppDbContext(optionsBuilder.Options);
    }
}
