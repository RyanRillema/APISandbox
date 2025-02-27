using APISandbox.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static APISandbox.Models.OrderEnums;

namespace APISandbox.Services
{
    public class AccountFactory
    {
        private const string _AccountFileAndPath = "C:\\Users\\Ryan\\Desktop\\Test.txt";
        public void writeAccounts(List<Account> AccountList)
        {
            string writeText = JsonConvert.SerializeObject(AccountList);
            writeToFile(writeText);
        }

        public List<Account> ReadAccountList()
        {
            string result = readFromFile();
            List<Account> AccountList = JsonConvert.DeserializeObject<List<Account>>(result);

            return AccountList;
        }

        private void writeToFile(string writeText)
        {
            File.WriteAllText(_AccountFileAndPath, writeText);
        }

        private string readFromFile()
        {
            string readText = File.ReadAllText(_AccountFileAndPath);

            return readText;
        }

        public void HardCodeAccounts()
        {
            List<Account> AccountList = new List<Account>();
            Account temp = new Account();
            temp.Name = "Test";
            temp.Exchange = Exchange.BitMex;
            temp.Key = "ZSbLa4SnZk5zh4r08wnPw7RM";
            temp.Secret = "rMeqAzEGaGSLJGphWsUjou-_49-uyzK5wmxnoqnzoAAczeCD";

            AccountList.Add(temp);

            temp = new Account();
            temp.Name = "Test2";
            temp.Exchange = Exchange.Bybit;
            temp.Key = "BqvWkuqyIrWRosPqO6";
            temp.Secret = "sqsi3jSERbvMifgZ6ViB28Suyt3Qj7A9dLiv";

            AccountList.Add(temp);


            writeAccounts(AccountList);
        }

    }

}
