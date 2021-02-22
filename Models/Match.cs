using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Models
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }
        public Tournament Tournament { get; set; }

        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

        public string Result { get; set; }
    }
}
