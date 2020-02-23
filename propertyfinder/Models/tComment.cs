namespace propertyfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tComment")]
    public partial class tComment
    {
        [Key]
        public int recNo { get; set; }

        [StringLength(50)]
        public string PostId { get; set; }

        [StringLength(50)]
        public string CommentId { get; set; }

        [StringLength(50)]
        public string PersonId { get; set; }

        public string Comment { get; set; }

        public int? isReply { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public int? Status { get; set; }
    }
}
