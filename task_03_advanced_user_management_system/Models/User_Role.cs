//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace task_03_advanced_user_management_system.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_Role
    {
        public int Role_ID { get; set; }
        public Nullable<int> Account_ID { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> Joining_Date { get; set; }
        public string Password { get; set; }
    
        public virtual Account Account { get; set; }
    }
}