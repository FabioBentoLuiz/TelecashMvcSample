using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TelecashSample.Models;

namespace TelecashSample.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            Customer customer = new Customer();
            customer.Id = 123;
            customer.Name = "Fabio Luiz";
            customer.TransactionTime = System.DateTime.UtcNow.ToString("yyyy:MM:dd-HH:mm:ss");

            Product tv = new Product();
            tv.Name = "TV";
            tv.Price = 300;
            tv.Quantity = 2;

            Product computer = new Product();
            computer.Name = "Computer";
            computer.Price = 350;
            computer.Quantity = 1;

            customer.Products.Add(tv);
            customer.Products.Add(computer);


            var stringToHash = Store.STORE_NAME + customer.TransactionTime + customer.Total + Store.CURRENCY + Store.SHARED_SECRET;
            customer.Hash = CreateHash(stringToHash);

            return View(customer);
        }

        private string CreateHash(string stringToHash)
        {
            var ascii = System.Text.Encoding.ASCII.GetBytes(stringToHash);
            var hex = String.Empty;
            foreach (byte b in ascii)
                hex += b.ToString("X");

            var valueBytes = System.Text.Encoding.ASCII.GetBytes(hex.ToLower());
            var sha1alg = System.Security.Cryptography.SHA1.Create();
            var resultBytes = sha1alg.ComputeHash(valueBytes);
            var result = BitConverter.ToString(resultBytes).Replace("-", "").ToLower();
            return result;
        }

        /// <summary>
        /// This method works if you publish your app online, so the TeleCash service will be able to call back o your customized page with with the transaction result.
        /// Uncomment the parameter responseSuccessURL from the view Index.cshtml to do so
        /// </summary>
        /// <param name="model">Object helper with trasaction data results</param>
        /// <returns>View PaymentSuccess.cshtml</returns>
        [HttpPost]
        public ActionResult PaymentSuccess(TelecashResponse model)
        {
            ViewBag.Success = model.oid + " payment successfull.";
            return View();
        }

        /// <summary>
        /// This method works if you publish your app online, so the TeleCash service will be able to call back to your customized page with the transaction result.
        /// Uncomment the parameter responseSuccessURL from the view Index.cshtml to do so
        /// </summary>
        /// <param name="model">Object helper with trasaction data results</param>
        /// <returns>View PaymentFailure.cshtml</returns>
        [HttpPost]
        public ActionResult PaymentFailure(TelecashResponse model)
        {
            ViewBag.Failure = model.fail_reason + model.fail_rc + " - " + model.approval_code + " - " + GetReasons(model.fail_reason_details);
            return View();
        }

        private string GetReasons(string details)
        {

            if (details == null)
            {
                return "No further details";
            }

            StringBuilder sb = new StringBuilder();
            dynamic reasons = details.Split(',');
            foreach (string item in reasons)
            {
                if (item.Equals("invalidCard"))
                {
                    sb.AppendLine("Invalid card");
                }
                else if (item.Equals("cvm"))
                {
                    sb.AppendLine("Invalid CV");
                }
                else if (item.Equals("expmonth"))
                {
                    sb.AppendLine("Invalid expiration month");
                }
                else if (item.Equals("expyear"))
                {
                    sb.AppendLine("Invalid expiration year");
                }
                else if (item.Equals("expired"))
                {
                    sb.AppendLine("Card expired");
                }
                else
                {
                    sb.AppendLine(item);
                }
            }
            return sb.ToString();
        }

        
    }
}