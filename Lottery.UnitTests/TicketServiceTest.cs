using Lottery.WebAPI.Data;
using Lottery.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Lottery.UnitTests
{
    public class TicketServiceTest
    {
        private readonly DbContextOptionsBuilder<LotteryDbContext> dbContextOptionsBuilder;
        private readonly ITicketService ticketService;

        public TicketServiceTest()
        {
            dbContextOptionsBuilder = new DbContextOptionsBuilder<LotteryDbContext>()
                .UseSqlServer(@"Server=DESKTOP-J01R736;Database=LotteryDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            ticketService = new TicketService(dbContextOptionsBuilder.Options);
        }

        [Theory]
        [InlineData("101-BS7K3LP", true)]
        [InlineData("102-AY7739U", true)]
        [InlineData("103-Z888399", true)]
        public async Task IsWinningTicket(string number, bool winning)
        {           
            var splitted = number.Split('-');
            string lotteryNumber = splitted[0];
            string ticketNumber = splitted[1];

            var ticket = await ticketService.GetTicket(lotteryNumber, ticketNumber);

            Assert.Equal(winning, ticket.IsWinning);
        }

        [Theory]
        [InlineData("101-BS7K3L9", false)]
        [InlineData("102-AY77399", false)]
        [InlineData("103-Z888390", false)]
        public async Task IsTicketExist(string number, bool exist)
        {
            var splitted = number.Split('-');
            string lotteryNumber = splitted[0];
            string ticketNumber = splitted[1];

            var ticket = await ticketService.GetTicket(lotteryNumber, ticketNumber);
            var isExist = ticket == null ? false : true;

            Assert.Equal(exist, isExist);
        }
    }
}
