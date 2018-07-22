using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lottery.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Lottery.WebAPI.Services
{
    public class TicketService : ITicketService
    {
        private DbContextOptions<LotteryDbContext> _dbContextOptions;

        public TicketService(DbContextOptions<LotteryDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public async Task<Ticket> GetTicket(string lotteryNumber, string ticketNumber)
        {
            try
            {
                using (var db = new LotteryDbContext(_dbContextOptions))
                {
                    var ticket = await db.Tickets.AsNoTracking()
                        .Where(t => t.Number == ticketNumber && t.Lottery.Number == lotteryNumber)
                        .FirstOrDefaultAsync();

                    return ticket;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ошибка получения билета по номеру");
            }
        }
    }
}
