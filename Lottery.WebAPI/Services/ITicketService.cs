using Lottery.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.WebAPI.Services
{
    public interface ITicketService
    {
        Task<Ticket> GetTicket(string lotteryNumber, string ticketNumber);
    }
}
