using Microsoft.AspNetCore.Mvc;
using Rules_Microservice.Model;
using Rules_Microservice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rules_Microservice.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/rules/")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RulesController));
        public readonly IBalanceService _balance;
        

        public RulesController(IBalanceService balance)
        {
            this._balance = balance;
            
        }

        
       
        

        [HttpGet]
        //[Route("api/Rules/EvaluateMinBal")]
        [Route("EvaluateMinBal/{AccountID}/{Balance}")]
        public RuleStatus EvaluateMinBal(int AccountID, int Balance)
        {
            _log4net.Info("Evaluating Minimum Balance");
            try
            {
                int MinBalance = _balance.GetMinBalance(AccountID);

                if (Balance >= MinBalance)
                {
                    return new RuleStatus { Status = "allowed" };
                }
                else
                {
                    return new RuleStatus { Status = "denied" };
                }
            }
            catch (NullReferenceException e)
            {
                _log4net.Error("NullReferenceException caught. Issue in calling Account API");
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
