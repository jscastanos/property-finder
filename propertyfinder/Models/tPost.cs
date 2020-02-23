namespace propertyfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tPost")]
    public partial class tPost
    {
        [Key]
        public int recNo { get; set; }

        [StringLength(50)]
        public string PostId { get; set; }

        [StringLength(50)]
        public string PropertyTypeId { get; set; }

        [StringLength(50)]
        public string PersonId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        [StringLength(50)]
        public string ImgId { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public int? Category { get; set; }

        public int? Status { get; set; }
    }
}
