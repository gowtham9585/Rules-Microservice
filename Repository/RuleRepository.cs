using Newtonsoft.Json;
using Rules_Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rules_Microservice.Repository
{
    public class RuleRepository : IRuleRepository
    {
        private Client _client;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RuleRepository));
        public RuleRepository()
        {
            _client = new Client();
        }

        
        public List<Account> GetAccounts()
        {
            try
            {
                List<Account> acc = null;

                HttpClient client = _client.AccountClient();
                HttpResponseMessage response = client.GetAsync("api/Account/getAllCustomerAccounts").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                acc = JsonConvert.DeserializeObject<List<Account>>(result);

                return acc;
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in getting accounts from Account API");
                throw e;
            }


        }

       
        public int GetMinBalance(int AccountID)
        {
            try
            {
                HttpClient client = _client.AccountClient();
                HttpResponseMessage response = client.GetAsync("api/Account/getAccount/" + AccountID).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                Account acc = JsonConvert.DeserializeObject<Account>(result);
                return acc.minBalance;
            }
            catch (NullReferenceException e)
            {
                _log4net.Error("The account is not returned from Account API.", e);
                throw e;
            }
            catch (Exception e)
            {
                _log4net.Error("Exception occured while getting Account by ID");
                throw e;
            }
        }

        
    }
}
