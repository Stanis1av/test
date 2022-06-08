namespace telecom_neva_svyaz.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipment")]
    public partial class Equipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipment()
        {
            EquipmentHistories = new HashSet<EquipmentHistory>();
        }

        public int EquipmentId { get; set; }

        [Required]
        [StringLength(64)]
        public string EquipmentSerial { get; set; }

        [Required]
        [StringLength(48)]
        public string EquipmentMacAdress { get; set; }

        public int EquipmentTypeId { get; set; }

        [Required]
        [StringLength(255)]
        public string EquipmentModel { get; set; }

        public sbyte EquipmentIsStorage { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentHistory> EquipmentHistories { get; set; }
    }
}
