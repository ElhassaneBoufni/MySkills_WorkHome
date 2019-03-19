using Microsoft.EntityFrameworkCore;
using MySkills.Persistence.Infrastructure;

namespace MySkills.Persistence
{
    public class MySkillsDbContextFactory : DesignTimeDbContextFactoryBase<MySkillsDbContext>
    {
        protected override MySkillsDbContext CreateNewInstance(DbContextOptions<MySkillsDbContext> options)
        {
            return new MySkillsDbContext(options);
        }
    }
}
