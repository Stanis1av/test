using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace telecom_neva_svyaz.Database
{
    public partial class EfModel : DbContext
    {
        private static EfModel Instance;

        public static EfModel Init() => Instance == null ? Instance = new EfModel() : Instance;

        public EfModel()
            : base("name=EfModel")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<EquipmentHistory> EquipmentHistories { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestEquipment> RequestEquipments { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.ClientFirstname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ClientLastname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ClientPatronymic)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ClientPassportSeries)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ClientEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.ClientAdress)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.EquipmentHistories)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.Client_ClientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.RequestClientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.EquipmentSerial)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.EquipmentMacAdress)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.EquipmentModel)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.EquipmentHistories)
                .WithRequired(e => e.Equipment)
                .HasForeignKey(e => e.EquipmentHistoryEquipment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EquipmentType>()
                .Property(e => e.EquipmentTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<EquipmentType>()
                .HasMany(e => e.Equipments)
                .WithRequired(e => e.EquipmentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequestEquipment>()
                .Property(e => e.RequestId)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .Property(e => e.RequestTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<RequestType>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.RequestType1)
                .HasForeignKey(e => e.RequestType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.ServiceName)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.ServiceDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Service)
                .HasForeignKey(e => e.RequestServiceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.StaffFirstname)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.StaffLastname)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.StaffPatronymic)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.EquipmentHistories)
                .WithRequired(e => e.Staff)
                .HasForeignKey(e => e.Staff_Staffid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Staff)
                .HasForeignKey(e => e.RequestStaff)
                .WillCascadeOnDelete(false);
        }
    }
}
