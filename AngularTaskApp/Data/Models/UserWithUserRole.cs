//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularTaskApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    using System.ComponentModel.DataAnnotations;
    
    public partial class UserWithUserRole
    {
    
    //	one
        //[Required]
    public int UserId { get; set; } // hhh
    
    //	one
        //[Required]
    public int UserRoleId { get; set; } // hhh
    
    //	one
        //[Required]
    public Nullable<short> Dmy { get; set; } // hhh
    
        public virtual UserRole UserRole { get; set; }
        public virtual User User { get; set; }
    }
}
