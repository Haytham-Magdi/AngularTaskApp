//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IbsHaythamMagdiTask.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserWithUserRole
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public Nullable<short> Dmy { get; set; }
    
        public virtual UserRole UserRole { get; set; }
        public virtual User User { get; set; }
    }
}