using IkProject.Domain.Base;
using IkProject.Domain.Company;
using IkProject.Domain.Identities;
using IkProject.Domain.Requests;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Persistence.Context
{
    public class IkPorjectDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public IkPorjectDbContext(DbContextOptions<IkPorjectDbContext> options) : base(options) { }
        public DbSet<AdvancePayment> AdvancePayments { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<PermissionRequest> PermissionRequests { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<SiteManager> SiteManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppRole>().HasData(new { Id = new Guid("2355ccfb-5e9e-4a8c-972d-384fb2315457"), Name = "CompanyManager", NormalizedName = "COMPANYMANAGER" });
            builder.Entity<AppRole>().HasData(new { Id = new Guid("7865269f-01b8-4d28-9c07-645245ce9a1e"), Name = "Personal", NormalizedName = "PERSONAL" });
            builder.Entity<AppRole>().HasData(new { Id = new Guid("093f1aca-7fde-44a4-88de-0bdb9a1f96ae"), Name = "SiteManager", NormalizedName = "SITEMANAGER" });

            builder.Entity<PermissionType>().HasData(new { Id = new Guid("945e2b85-36ea-4947-bf8a-002c7d97b9d1"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Yıllık izin", Gender = Gender.All });
            builder.Entity<PermissionType>().HasData(new { Id = new Guid("ae5d8436-9e77-40fc-8e14-f8ff49bca5c3"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Doğum izni", Gender = Gender.Woman });
            builder.Entity<PermissionType>().HasData(new { Id = new Guid("0db8f712-e880-45bc-898e-a4a140ef6439"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Süt izni", Gender = Gender.Woman });
            builder.Entity<PermissionType>().HasData(new { Id = new Guid("6e9d4f4a-9ddb-4098-adae-e275d83c086d"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Babalık izni", Gender = Gender.Man });
            builder.Entity<PermissionType>().HasData(new { Id = new Guid("d8f07d79-2f03-4915-975d-aa167a954af3"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Hastalık izni", Gender = Gender.All });
            builder.Entity<PermissionType>().HasData(new { Id = new Guid("668cd66d-9bf3-4ab8-8e09-6e108ed3f4bb"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Ölüm izni", Gender = Gender.All });
            builder.Entity<PermissionType>().HasData(new { Id = new Guid("7b40b5a0-ce10-409d-95af-d22ea63e5d2a"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Yeni iş arama izni", Gender = Gender.All });
            builder.Entity<PermissionType>().HasData(new { Id = new Guid("3ce6e2e3-a471-47ee-a4cf-343ec355096a"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Evlilik izni", Gender = Gender.All });
            builder.Entity<PermissionType>().HasData(new { Id = new Guid("f64f5dce-a84d-4dad-8235-a5fca38ec831"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Evlat edinme izni", Gender = Gender.All });
            builder.Entity<PermissionType>().HasData(new { Id = new Guid("b402370a-c4db-4890-9070-056d9ece33b4"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Mazeret izni", Gender = Gender.All });
            builder.Entity<PermissionType>().HasData(new { Id = new Guid("40cc4874-ef44-47d5-bc68-56bf5dd8fbff"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Refakat izni", Gender = Gender.All });
            builder.Entity<PermissionType>().HasData(new { Id = new Guid("f3357e7d-6c4b-455a-bf95-308fcee78e58"), Status = DataStatus.Created, Created = DateTime.Now, Name = "Askerlik izni", Gender = Gender.Man });


            builder.Entity<Company>().HasData(new Company{Id= new Guid("b28c70eb-112f-44d0-a0a3-4b7c4f2931d1"), Status = DataStatus.Created, Created = DateTime.Now,Name="Bilgeadam",MersisNo= "4532453245324532",TaxNo= "3453234532", 
                TaxAdministration="İstanbul Vergi Dairesi",Address="İstanbul", ContractStartDate = new DateTime(2021, 11, 12), ContractEndDate = new DateTime(2026, 11, 12),Email="bilgeadammain@bilgeadam.com",
                EstablishmentDate = new DateTime(1999, 8, 21),PhoneNumber="+905432175485"
            });

            base.OnModelCreating(builder);
        }

    }
}
