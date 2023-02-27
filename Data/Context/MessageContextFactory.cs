
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class MessageContextFactory : IDesignTimeDbContextFactory<MesaggeContext>
    {
        public MesaggeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MesaggeContext>();
            

            return new MesaggeContext(optionsBuilder.Options);
        }
    }
}
