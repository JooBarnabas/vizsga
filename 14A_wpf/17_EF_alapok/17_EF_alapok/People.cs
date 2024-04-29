using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace _17_EF_alapok
{
    /// <summary>
    /// Egy ember adatai
    /// </summary>
    public class People
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Job { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(150)]
        public string Email { get; set; }
    }
}
