namespace propertyfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tNotification")]
    public partial class tNotification
    {
        [Key]
        public int recNo { get; set; }

        [StringLength(50)]
        public string notificationId { get; set; }

        [StringLength(50)]
        public string SenderId { get; set; }

        [StringLength(50)]
        public string RecipientId { get; set; }

        public string Message { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? Status { get; set; }
    }
}
