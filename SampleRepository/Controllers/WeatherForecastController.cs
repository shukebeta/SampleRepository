using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private IRepositoryWrapper _repoWrapper;
        public WeatherForecastController(IRepositoryWrapper repoWrapper, ILogger<WeatherForecastController> logger)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _repoWrapper.Owner.Create(new Entities.Models.Owner
            {
                OwnerId = new Guid(),
                Name = "Wei" + new Random().Next(1, 100000000),
                DateOfBirth = new DateTime(1972, 12, 19),
                Address = "36 Stanbury Ave"
            });
            _repoWrapper.Owner.Create(new Entities.Models.Owner
            {
                OwnerId = new Guid(),
                Name = "Wei" + new Random().Next(1, 100000000),
                DateOfBirth = new DateTime(1972, 12, 19),
                Address = "36 Stanbury Ave"
            });
            _repoWrapper.Save();
            var domesticAccounts = _repoWrapper.Account.FindByCondition(x => x.AccountType.Equals("Domestic"));
            var owners = _repoWrapper.Owner.FindAll();

            return new string[] { "Hello", "world" };
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
