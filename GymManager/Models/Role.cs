﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleType { get; set; }

    }
}
