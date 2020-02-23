namespace propertyfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tPostImage")]
    public partial class tPostImage
    {
        [Key]
        public int recNo { get; set; }

        [StringLength(50)]
        public string ImgId { get; set; }

        [StringLength(50)]
        public string PostId { get; set; }

        public byte[] Image { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public int? Status { get; set; }
    }
}
