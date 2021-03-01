using Premier.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.DTOS
{
    public class MatchDTO
    {
        [Required]
        [StringLength(100)]
        public string teamTeamName { get; set; }
        [Required]
        [StringLength(100)]
        public string teamTeamName2 { get; set; }
        [Required]
        [StringLength(50)]
        public string Result { get; set; }
    }
}
