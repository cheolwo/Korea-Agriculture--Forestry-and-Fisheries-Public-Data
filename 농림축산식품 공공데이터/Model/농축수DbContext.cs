using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace 농림축산식품_공공데이터.Model
{
    /// <summary>
    /// AgricultureLivestock
    /// </summary>
    public class 농림축산DbContext : DbContext
    {
        public 농림축산DbContext(DbContextOptions<농림축산DbContext> options) : base(options)
        {
        }

        public DbSet<부류> 부류들 { get; set; }
        public DbSet<품목> 품목들 { get; set; }
        public DbSet<품종> 품종들 { get; set; }
        public DbSet<도매시장> 도매시장들 { get; set; }
        public DbSet<도매법인> 도매법인들 { get; set; }
        public DbSet<도매가격> 도매가격들 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new 부류Configuration());
            modelBuilder.ApplyConfiguration(new 품목Configuration());
            modelBuilder.ApplyConfiguration(new 품종Configuration());
            modelBuilder.ApplyConfiguration(new 도매시장Configuration());
            modelBuilder.ApplyConfiguration(new 도매법인Configuration());
            modelBuilder.ApplyConfiguration(new 도매가격Configuration());
        }
    }

    public class 부류Configuration : IEntityTypeConfiguration<부류>
    {
        public void Configure(EntityTypeBuilder<부류> builder)
        {
            builder.HasKey(b => b.코드);
            builder.Property(b => b.이름).IsRequired().HasMaxLength(100);
        }
    }

    public class 품목Configuration : IEntityTypeConfiguration<품목>
    {
        public void Configure(EntityTypeBuilder<품목> builder)
        {
            builder.HasKey(p => p.코드);
            builder.Property(p => p.이름).IsRequired().HasMaxLength(100);
            builder.HasOne(p => p.부류).WithMany(b => b.품목들).HasForeignKey(p => p.부류코드);
        }
    }

    public class 품종Configuration : IEntityTypeConfiguration<품종>
    {
        public void Configure(EntityTypeBuilder<품종> builder)
        {
            builder.HasKey(v => v.코드);
            builder.HasOne(v => v.품목).WithMany(p => p.품종들).HasForeignKey(v => v.품목코드);
            builder.HasOne(v => v.부류).WithMany(b => b.품종들).HasForeignKey(v => v.부류코드);
        }
    }

    public class 도매시장Configuration : IEntityTypeConfiguration<도매시장>
    {
        public void Configure(EntityTypeBuilder<도매시장> builder)
        {
            builder.HasKey(m => m.코드);
            builder.Property(m => m.이름).IsRequired().HasMaxLength(100);
        }
    }

    public class 도매법인Configuration : IEntityTypeConfiguration<도매법인>
    {
        public void Configure(EntityTypeBuilder<도매법인> builder)
        {
            builder.HasKey(c => c.코드);
            builder.Property(c => c.이름).IsRequired().HasMaxLength(100);
            builder.HasOne(c => c.시장).WithMany(m => m.도매법인들).HasForeignKey(c => c.시장코드);
        }
    }

    public class 도매가격Configuration : IEntityTypeConfiguration<도매가격>
    {
        public void Configure(EntityTypeBuilder<도매가격> builder)
        {
            builder.HasKey(p => new { p.날짜, p.법인코드, p.품종코드 });
            builder.HasOne(p => p.법인).WithMany(c => c.도매가격들).HasForeignKey(p => p.법인코드);
            builder.HasOne(p => p.품종).WithMany(v => v.도매가격들).HasForeignKey(p => p.품종코드);
            builder.HasOne(p => p.등급).WithMany().HasForeignKey(p => p.등급코드);
            builder.HasOne(p => p.규굑).WithMany().HasForeignKey(p => p.규격코드);
        }
    }
}
