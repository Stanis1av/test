namespace telecom_neva_svyaz.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        public int RequestId { get; set; }

        public DateTime RequestDate { get; set; }

        public DateTime RequestVisitTime { get; set; }

        public DateTime? RequestClosedDate { get; set; }

        public int RequestType { get; set; }

        public int RequestStaff { get; set; }

        public int RequestServiceId { get; set; }

        public int RequestClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual RequestType RequestType1 { get; set; }

        public virtual Service Service { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
