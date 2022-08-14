

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using QuanLyBanHangVer2.Utilities.Constants;
using System.IO;

namespace QuanLyBanHangVer2.Data.EF
{
    public class QuanLyBanHangVer2ContextFactory : IDesignTimeDbContextFactory<QuanLyBanHangVer2Context>
    {
        public QuanLyBanHangVer2Context CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string ConnectionString = configuration.GetConnectionString(SystemConstants.MainConnectionString);

            var optionsBuilder = new DbContextOptionsBuilder<QuanLyBanHangVer2Context>();
            optionsBuilder.UseSqlServer(ConnectionString);

            return new QuanLyBanHangVer2Context(optionsBuilder.Options);
        }
    }
}
