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
    
    public partial class tPersonInfo
    {
        public int recNo { get; set; }
        public string PersonId { get; set; }
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Title { get; set; }
        public string Introduction { get; set; }
        public byte[] ProfileImg { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
