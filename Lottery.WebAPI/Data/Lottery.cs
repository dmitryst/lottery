using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.WebAPI.Data
{
    public class Lottery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime DateOfConducting { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
