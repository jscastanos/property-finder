//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace service_and_job_finder_web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tCertification
    {
        public int recNo { get; set; }
        public string UserId { get; set; }
        public string Filename { get; set; }
        public string Description { get; set; }
        public byte[] FileImg { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
