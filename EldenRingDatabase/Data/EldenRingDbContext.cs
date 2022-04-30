namespace EldenRingDatabase.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class EldenRingDbContext : IdentityDbContext
    {
        public EldenRingDbContext(DbContextOptions<EldenRingDbContext> options)
            : base(options)
        {
        }
    }
}
