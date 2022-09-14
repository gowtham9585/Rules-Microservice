using Rules_Microservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rules_Microservice.Service
{
    public class BalanceService : IBalanceService
    {
        RuleRepository _rules;
        public BalanceService()
        {
            _rules = new RuleRepository();
        }
        
        public int GetMinBalance(int AccountID)
        {
            try
            {
                return _rules.GetMinBalance(AccountID);
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
