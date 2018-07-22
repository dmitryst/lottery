using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lottery.WebAPI.Models;
using Lottery.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lottery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class LotteryController : Controller
    {
        private readonly ITicketService _ticketService;

        public LotteryController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Produces("application/json")]
        [HttpGet("/restapi/v1/GetTicket/{number}")]
        public async Task<IActionResult> GetTicketByNumber(string number)
        {
            try
            {
                if (!string.IsNullOrEmpty(number))
                {
                    var splitted = number.Split('-');
                    string lotteryNumber = splitted[0];
                    string ticketNumber = splitted[1];

                    var ticket = await _ticketService.GetTicket(lotteryNumber, ticketNumber);

                    if (ticket != null)
                        return NewtownJson(new ResponseModel { IsSuccess = true, IsWinning = ticket.IsWinning });

                    return NewtownJson(new ResponseModel { IsSuccess = false, Message = "Билет не найден" });
                }

                return NewtownJson(new ResponseModel { IsSuccess = false, Message = "Не введен номера билета" });
            }
            catch (Exception ex)
            {
                return NewtownJson(new ResponseModel { IsSuccess = false, Message = ex.Message });
            }        
        }

        private ContentResult NewtownJson(object data)
        {
            var serializerSettings = new JsonSerializerSettings();
            return Content(JsonConvert.SerializeObject(data, Formatting.None, serializerSettings),
                "application/json");
        }
    }
}