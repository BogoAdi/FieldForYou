using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class FieldForYouContextFactory : IDesignTimeDbContextFactory<FieldForYouContext>
    {
        public FieldForYouContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FieldForYouContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=FieldForYouDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new FieldForYouContext(optionsBuilder.Options);
        }
    }
}
