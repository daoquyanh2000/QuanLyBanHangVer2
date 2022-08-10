

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
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

            string ConnectionString = configuration.GetConnectionString("QuanLyBanHangVer2Db");

            var optionsBuilder = new DbContextOptionsBuilder<QuanLyBanHangVer2Context>();
            optionsBuilder.UseSqlServer(ConnectionString);

            return new QuanLyBanHangVer2Context(optionsBuilder.Options);
        }
    }
}
