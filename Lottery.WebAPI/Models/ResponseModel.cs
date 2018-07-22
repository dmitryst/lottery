using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.WebAPI.Models
{
    public class ResponseModel
    {
        public bool IsWinning { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
