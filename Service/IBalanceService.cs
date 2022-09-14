using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rules_Microservice.Service
{
   public interface IBalanceService
    {
        int GetMinBalance(int AccountID);
    }
}
