namespace telecom_neva_svyaz.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            EquipmentHistories = new HashSet<EquipmentHistory>();
            Requests = new HashSet<Request>();
        }

        public int ClientId { get; set; }

        [Required]
        [StringLength(32)]
        public string ClientFirstname { get; set; }

        [Required]
        [StringLength(32)]
        public string ClientLastname { get; set; }

        [StringLength(32)]
        public string ClientPatronymic { get; set; }

        public string ClientFIO => ClientLastname + " " +  ClientFirstname + " " + ClientPatronymic;

        [Column(TypeName = "ubigint")]
        public decimal ClientContractNum { get; set; }

        [Column(TypeName = "date")]
        public DateTime ClientContractStart { get; set; }

        [Required]
        [StringLength(4)]
        public string ClientPassportSeries { get; set; }

        public int ClientPassportNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime ClientDateOfBirth { get; set; }

        [Column(TypeName = "ubigint")]
        public decimal ClientPhone { get; set; }

        [Required]
        [StringLength(64)]
        public string ClientEmail { get; set; }

        [Required]
        [StringLength(255)]
        public string ClientAdress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentHistory> EquipmentHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
