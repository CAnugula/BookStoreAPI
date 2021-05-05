using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using RestSharp;

namespace BookStoreAPI.Controllers
{
    public class BookController : ApiController
    {
        private const string BOOK_URL = "https://simple-books-api.glitch.me";

        [HttpGet]
        public IHttpActionResult GetStatus() {
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllBooks() 
        {
            var client = new RestClient(BOOK_URL);
            var request = new RestRequest("/books");

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Content);
            }
            else
            {
                // Log the error using log4net
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult postOrder(int bookId, string customerName) {
            
            return Ok();
        }
    }
}
