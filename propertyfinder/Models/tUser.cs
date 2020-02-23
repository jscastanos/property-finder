namespace propertyfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tUser")]
    public partial class tUser
    {
        [Key]
        public int recNo { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }

        public int? AccountTypeId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public int? Status { get; set; }
    }
}
