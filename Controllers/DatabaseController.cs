using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using BudgetTrackingApp.Models;

namespace BudgetTrackingApp.Controllers
{
    internal static class DatabaseController
    {
        static AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();


        public static void Initialize()
        {
            clientConfig.RegionEndpoint = Amazon.RegionEndpoint.USEast1;
            clientConfig.ServiceURL = "https://dynamodb.us-east-1.amazonaws.com";
            clientConfig.AuthenticationRegion = "us-east-1";
            clientConfig.UseHttp = true;
        }


        //Change return types on all of these
        public static void GetSpent() { }

        public static void GetDeposited() {
        
        
        }

        public static List<Transaction> GetTable() 
        {
        

            return new List<Transaction>();
        }


    }
}
