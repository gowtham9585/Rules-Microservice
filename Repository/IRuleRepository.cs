using Rules_Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rules_Microservice.Repository
{
    public interface IRuleRepository
    {
        int GetMinBalance(int AccountID);
        List<Account> GetAccounts();
    }
}
