using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace TelephoneDirectory.EntityFrameworkCore
{
    public static class TelephoneDirectoryDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TelephoneDirectoryDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TelephoneDirectoryDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
