using HW5._25._21WebScraper.Scraper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW5._25._21WebScraper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        [HttpGet]
        [Route("scrape")]
        public List<ScoopPost> Scrape()
        {
            return Scraper.ScrapeLakewoodScoop();
        }
    }
}
