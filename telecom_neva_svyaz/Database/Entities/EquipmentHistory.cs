namespace telecom_neva_svyaz.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EquipmentHistory")]
    public partial class EquipmentHistory
    {
        public int EquipmentHistoryId { get; set; }

        public DateTime EquipmentHistoryDate { get; set; }

        public sbyte EquipmentHistoryType { get; set; }

        public int EquipmentHistoryEquipment { get; set; }

        public int Client_ClientId { get; set; }

        public int Staff_Staffid { get; set; }

        public virtual Client Client { get; set; }

        public virtual Equipment Equipment { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
