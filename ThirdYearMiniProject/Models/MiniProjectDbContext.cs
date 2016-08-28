namespace ThirdYearMiniProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MiniProjectDbContext : DbContext
    {
        public MiniProjectDbContext()
            : base("name=MiniProjectDbContext")
        {
        }

        public virtual DbSet<CustomerInvoice> CustomerInvoices { get; set; }
        public virtual DbSet<CustomerProduct> CustomerProducts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<MpsInvoice> MpsInvoices { get; set; }
        public virtual DbSet<MpsProduct> MpsProducts { get; set; }
        public virtual DbSet<Mpss> Mpsses { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<RdInvoice> RdInvoices { get; set; }
        public virtual DbSet<RdProduct> RdProducts { get; set; }
        public virtual DbSet<Rd> Rds { get; set; }
        public virtual DbSet<SrInvoice> SrInvoices { get; set; }
        public virtual DbSet<SrProduct> SrProducts { get; set; }
        public virtual DbSet<Sr> Srs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerInvoice>()
                .HasMany(e => e.CustomerProducts)
                .WithRequired(e => e.CustomerInvoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerNic)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerInvoices)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.LocationName)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Persons)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Nic)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<MpsInvoice>()
                .HasMany(e => e.MpsProducts)
                .WithRequired(e => e.MpsInvoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MpsProduct>()
                .HasMany(e => e.CustomerProducts)
                .WithRequired(e => e.MpsProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mpss>()
                .HasMany(e => e.CustomerInvoices)
                .WithRequired(e => e.Mpss)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mpss>()
                .HasMany(e => e.MpsInvoices)
                .WithRequired(e => e.Mpss)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.PersonAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Occupid)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Nic)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Login)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Mpsses)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Rds)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Srs)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RdInvoice>()
                .HasMany(e => e.RdProducts)
                .WithRequired(e => e.RdInvoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RdProduct>()
                .Property(e => e.EmiNo)
                .IsUnicode(false);

            modelBuilder.Entity<RdProduct>()
                .Property(e => e.ModelName)
                .IsUnicode(false);

            modelBuilder.Entity<RdProduct>()
                .HasMany(e => e.SrProducts)
                .WithRequired(e => e.RdProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rd>()
                .HasMany(e => e.SrInvoices)
                .WithRequired(e => e.Rd)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SrInvoice>()
                .HasMany(e => e.SrProducts)
                .WithRequired(e => e.SrInvoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SrProduct>()
                .HasMany(e => e.MpsProducts)
                .WithRequired(e => e.SrProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sr>()
                .HasMany(e => e.MpsInvoices)
                .WithRequired(e => e.Sr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sr>()
                .HasMany(e => e.SrInvoices)
                .WithRequired(e => e.Sr)
                .WillCascadeOnDelete(false);
        }
    }
}
