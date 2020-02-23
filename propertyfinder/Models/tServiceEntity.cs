namespace propertyfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tServiceEntity")]
    public partial class tServiceEntity
    {
        [Key]
        public int recNo { get; set; }

        [StringLength(50)]
        public string ServiceEntityId { get; set; }

        [StringLength(50)]
        public string PropertyTypeId { get; set; }

        [StringLength(50)]
        public string ServiceEntityName { get; set; }

        public string ServiceEntityAddress { get; set; }

        public byte[] ProfileImg { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public int? Status { get; set; }
    }
}
