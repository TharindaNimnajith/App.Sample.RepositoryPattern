using App.Sample.Application;
using App.Sample.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Sample.RepositoryPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public WeatherForecastController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var domesticAccounts = await
                _repoWrapper.Account.FindByConditionAsync(x => x.AccountType.Equals("Domestic"));
            var owners = await _repoWrapper.Owner.FindAllAsync();
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public async Task<IEnumerable<string>> Post()
        {
            var ownerId = Guid.NewGuid();
            var owner = new Owner
            {
                OwnerId = ownerId,
                Name = "Saman Kumara",
                Address = "Colombo",
                DateOfBirth = DateTime.Parse("1998-05-11"),
            };

            Account account = new Account
            {
                AccountId = Guid.NewGuid(),
                DateCreated = DateTime.Now,
                OwnerId = ownerId,
                Owner = owner,
                AccountType = "Domestic"
            };

            try
            {
                await _repoWrapper.Account.CreateAsync(account);
            }
            catch (Exception)
            {
                throw;
            }

            var owners = await _repoWrapper.Owner.FindAllAsync();

            return new string[] { "value1", "value2" };
        }

        [HttpDelete]
        public async Task Delete()
        {
            try
            {
                string ownerId = "753885f7-67a4-473e-bb4f-32b26858c595";
                await _repoWrapper.Owner.DeleteAsync(new Owner { OwnerId = Guid.Parse(ownerId) });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}