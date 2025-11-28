using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyApp.Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        var connectionString = @"Server=sql.bsite.net\MSSQL2016;Database=qartal_test;User=qartal_test;Password=Azadi@1414;";

        optionsBuilder.UseSqlServer(connectionString);


        return new AppDbContext(optionsBuilder.Options);
    }
}
