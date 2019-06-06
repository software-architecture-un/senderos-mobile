using GraphQL.Client;
using GraphQL.Client.Http;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SenderosMobile
{
    class ActivityResponse
    {
        public ActivityResponse()
        {

        }

        public JArray AllActivities()
        {
            string query = @"query {
                                allActivities {
                                    name
                                    description
                                    qualification
                                    visits
                                }
                           }";

            GraphQLHttpClient graphQLClient = new GraphQLHttpClient("http://35.224.133.8:5500/graphql");

            GraphQLResponse graphQLResponse = new GraphQLResponse();

            
            Task.WaitAll(Task.Run(async () => { graphQLResponse = await graphQLClient.SendQueryAsync(query); }));

            return graphQLResponse.Data.allActivities; //Value of data->hero->name
        }
    }
}
