namespace propertyfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tPersonInfo")]
    public partial class tPersonInfo
    {
        [Key]
        public int recNo { get; set; }

        [StringLength(50)]
        public string PersonId { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Middlename { get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string ContactNo { get; set; }

        public byte[] ProfileImg { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public int? Status { get; set; }
    }
}
