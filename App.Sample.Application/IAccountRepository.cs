using App.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Sample.Application
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
    }
}