using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace IC.Core.Entity.CloudLink.DB
{
    public class HasId
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string Id { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDel { get; set; }

        public DateTime DelTime { get; set; }
    }
}
