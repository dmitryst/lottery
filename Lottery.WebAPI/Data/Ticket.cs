using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.WebAPI.Data
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Number { get; set; }
        public bool IsWinning { get; set; }

        public int LotteryId { get; set; }
        public Lottery Lottery { get; set; }
    }
}
