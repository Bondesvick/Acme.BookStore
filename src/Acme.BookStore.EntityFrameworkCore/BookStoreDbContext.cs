using Acme.BookStore;
using Acme.BookStore.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

public class BookStoreDbContext : AbpDbContext<BookStoreDbContext>//,
    //IIdentityDbContext,
    //ITenantManagementDbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    //public DbSet<IdentityUser> Users => throw new System.NotImplementedException();

    //public DbSet<IdentityRole> Roles => throw new System.NotImplementedException();

    //public DbSet<IdentityClaimType> ClaimTypes => throw new System.NotImplementedException();

    //public DbSet<OrganizationUnit> OrganizationUnits => throw new System.NotImplementedException();

    //public DbSet<IdentitySecurityLog> SecurityLogs => throw new System.NotImplementedException();

    //public DbSet<IdentityLinkUser> LinkUsers => throw new System.NotImplementedException();

    //public DbSet<Tenant> Tenants => throw new System.NotImplementedException();

    //public DbSet<TenantConnectionString> TenantConnectionStrings => throw new System.NotImplementedException();

    //...

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();


        /* Configure your own tables/entities inside here */

        builder.Entity<Book>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "Books",
                BookStoreConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });
    }
}
