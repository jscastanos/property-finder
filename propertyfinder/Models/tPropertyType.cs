namespace propertyfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tPropertyType")]
    public partial class tPropertyType
    {
        [Key]
        public int recNo { get; set; }

        [StringLength(50)]
        public string PropertyTypeId { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DatedUpdated { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        [StringLength(10)]
        public string Status { get; set; }
    }
}
