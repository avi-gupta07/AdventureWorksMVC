using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorksMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly HttpClient _httpClient;

        public PersonController() {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44339/");
        }

        // GET: Person
        public async Task<ActionResult> Index()
        {          
            HttpResponseMessage response = await _httpClient.GetAsync("api/Person/Get?id=1");

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                // Process the response data as needed
                return View(apiResponse); 
            }
            else
            {
                // Handle error responses
                return View("Error");
            }
         
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}