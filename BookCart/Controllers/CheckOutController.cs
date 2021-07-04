using MovieTheater.Dto;
using MovieTheater.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
namespace MovieTheater.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CheckOutController : Controller
    {

        readonly IOrderService _orderService;
        readonly ICartService _cartService;

        public CheckOutController(IOrderService orderService, ICartService cartService)
        {
            _orderService = orderService;
            _cartService = cartService;
        }

        /// <summary>
        /// Checkout from shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="checkedOutItems"></param>
        /// <returns></returns>
        [HttpPost("{userId}")]
        public int Post(int userId, [FromBody]OrdersDto checkedOutItems)
        {
            // Sending Email via MailKit, please create a new account on ethereal and change it here
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("moriah.daniel47@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("bojan.trpezanovski@students.finki.ukim.mk"));
            email.Subject = "Ticket Order";
            email.Body = new TextPart(TextFormat.Plain) { 
                Text = "Thank you for your order. Your ticket has been sucessfully purchased." 
            };
            _orderService.CreateOrder(userId, checkedOutItems);
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("moriah.daniel47@ethereal.email", "xjtf3s8Zr2XrkPyuVy");
            smtp.Send(email);
            smtp.Disconnect(true);
            return _cartService.ClearCart(userId);
        }
    }
}
