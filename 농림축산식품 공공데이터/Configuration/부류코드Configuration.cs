using Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using 농림축산식품_공공데이터.Model;

namespace 농림축산식품_공공데이터.Configuration
{
    public class 부류Configuration : EntityConfiguration<부류>
    {
        public override void Configure(EntityTypeBuilder<부류> builder)
        {
            base.Configure(builder);
        }
    }
    public class 품목Configuration : EntityConfiguration<품목>
    {
        public override void Configure(EntityTypeBuilder<품목> builder)
        {
            base.Configure(builder);

            // 테이블 이름 설정
            builder.ToTable("품목");

            // 부류와의 관계 설정
            builder.HasOne(p => p.부류)
                   .WithMany(b => b.품목)
                   .HasForeignKey(p => p.부류코드);

            // 품종과의 관계 설정
            builder.HasMany(p => p.품종)
                   .WithOne(s => s.품목)
                   .HasForeignKey(s => s.품목코드);

            // 인덱스 설정
            builder.HasIndex(p => p.부류코드);
        }
    }
    // 품종Configuration
    public class 품종Configuration : EntityConfiguration<품종>
    {
        public override void Configure(EntityTypeBuilder<품종> builder)
        {
            base.Configure(builder);

            // 품목과의 관계
            builder.HasOne(t => t.품목)
                   .WithMany(p => p.품종)
                   .HasForeignKey(t => t.품목코드);

            // 시장도매가격들과의 관계
            builder.HasMany(t => t.시장도매가격들)
                   .WithOne(d => d.품종)
                   .HasForeignKey(d => d.품종코드);

            // 시장소매가격들과의 관계
            builder.HasMany(t => t.시장소매가격들)
                   .WithOne(r => r.품종)
                   .HasForeignKey(r => r.품종코드);
        }
    }

    // 지역Configuration
    public class 지역Configuration : EntityConfiguration<지역>
    {
        public override void Configure(EntityTypeBuilder<지역> builder)
        {
            base.Configure(builder);

            // 시장과의 관계
            builder.HasMany(r => r.시장)
                   .WithOne(m => m.지역)
                   .HasForeignKey(m => m.지역코드);
        }
    }

    // 시장Configuration
    public class 시장Configuration : EntityConfiguration<시장>
    {
        public override void Configure(EntityTypeBuilder<시장> builder)
        {
            base.Configure(builder);

            // 시장도매가격과의 관계
            builder.HasMany(m => m.시장도매가격들)
                   .WithOne(d => d.시장)
                   .HasForeignKey(d => d.시장코드);

            // 시장소매가격과의 관계
            builder.HasMany(m => m.시장소매가격들)
                   .WithOne(r => r.시장)
                   .HasForeignKey(r => r.시장코드);
        }
    }

    // 도매법인Configuration
    public class 도매법인Configuration : EntityConfiguration<도매법인>
    {
        public override void Configure(EntityTypeBuilder<도매법인> builder)
        {
            base.Configure(builder);

            // 시장과의 관계
            builder.HasOne(w => w.시장)
                   .WithMany(m => m.도매법인들)
                   .HasForeignKey(w => w.시장코드);
        }
    }
    // 시장도매가격Configuration
    public class 시장도매가격Configuration : EntityConfiguration<시장도매가격>
    {
        public override void Configure(EntityTypeBuilder<시장도매가격> builder)
        {
            base.Configure(builder);

            // 테이블 이름 설정
            builder.ToTable("시장도매가격");

            // 품종과의 관계 설정
            builder.HasOne(d => d.품종)
                   .WithMany(t => t.시장도매가격들)
                   .HasForeignKey(d => d.품종코드);

            // 시장과의 관계 설정
            builder.HasOne(d => d.시장)
                   .WithMany(m => m.시장도매가격들)
                   .HasForeignKey(d => d.시장코드);
        }
    }

    // 시장소매가격Configuration
    public class 시장소매가격Configuration : EntityConfiguration<시장소매가격>
    {
        public override void Configure(EntityTypeBuilder<시장소매가격> builder)
        {
            base.Configure(builder);

            // 테이블 이름 설정
            builder.ToTable("시장소매가격");

            // 품종과의 관계 설정
            builder.HasOne(r => r.품종)
                   .WithMany(t => t.시장소매가격들)
                   .HasForeignKey(r => r.품종코드);

            // 시장과의 관계 설정
            builder.HasOne(r => r.시장)
                   .WithMany(m => m.시장소매가격들)
                   .HasForeignKey(r => r.시장코드);
        }
    }

    // 도매법인별경락가격Configuration
    public class 도매법인별경락가격Configuration : EntityConfiguration<도매법인별경락가격>
    {
        public override void Configure(EntityTypeBuilder<도매법인별경락가격> builder)
        {
            base.Configure(builder);

            // 테이블 이름 설정
            builder.ToTable("도매법인별경락가격");

            // 도매법인과의 관계 설정
            builder.HasOne(d => d.도매법인)
                   .WithMany(w => w.도매법인별경락가격들)
                   .HasForeignKey(d => d.도매법인코드);

            // 품종과의 관계 설정
            builder.HasOne(d => d.품종)
                   .WithMany(t => t.도매법인별경락가격들)
                   .HasForeignKey(d => d.품종코드);
        }
    }
}
