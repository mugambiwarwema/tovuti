using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace tovuti.EntityFrameworkCore
{
    public static class tovutiDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<tovutiDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<tovutiDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
