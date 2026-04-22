using System;
using System.Collections.Generic;

namespace Common.Entities
{
    //[Keyless]
    public partial class ViewUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public int? ScopeId { get; set; }
        public string RaionId { get; set; }
        public short Status { get; set; }
        public string Password { get; set; }
        public string Telefon { get; set; }
    }
}