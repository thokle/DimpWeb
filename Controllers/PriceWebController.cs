using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dlu_persistence_api.services;
using dlu_persistence_api.daos;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using dlu_persistence_api;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DimpWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceWebController : ControllerBase
    {
        private IPricesFromWebService priceAskingService;

        public PriceWebController(IPricesFromWebService priceAskingService)
        {
            this.priceAskingService = priceAskingService;
        }
        // GET: api/<PriceWebController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PriceWebController>/email
        [HttpGet("{email}")]
        public List<PriceTilWeb> Get(string email)
        {
            return priceAskingService.ShowPapersFromStamBladId(email);
        }

        // POST api/<PriceWebController>
        [HttpPost, AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Post(PriceWebUpdate value)
        {
            try
            {
              
                priceAskingService.UpdatePrisTilWeb(value);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
         
        
        }

        // PUT api/<PriceWebController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PriceWebController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
