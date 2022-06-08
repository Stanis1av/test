namespace telecom_neva_svyaz.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RequestEquipment")]
    public partial class RequestEquipment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EquipmentId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(45)]
        public string RequestId { get; set; }
    }
}
