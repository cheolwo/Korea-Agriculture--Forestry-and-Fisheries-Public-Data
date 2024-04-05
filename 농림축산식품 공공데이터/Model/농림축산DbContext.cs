using Microsoft.EntityFrameworkCore;

namespace 농림축산식품_공공데이터.Model
{
    public class 농림축산DbContext : DbContext
    {
        public DbSet<부류표준품목코드> LClasses { get; set; }

        public 농림축산DbContext(DbContextOptions<농림축산DbContext> options) : base(options)
        {
        }
    }
}
