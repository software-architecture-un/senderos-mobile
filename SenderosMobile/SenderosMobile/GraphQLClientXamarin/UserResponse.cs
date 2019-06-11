using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Client;
using GraphQL.Client.Http;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using GraphQL.Types;
using Newtonsoft.Json.Linq;

namespace SenderosMobile
{
    class UserResponse
    {
        public UserResponse()
        {

        }

        public JObject JWTResponse()
        {
            string email = "dacherreragu@unal.edu.co";
            string password = "123456";

            string query = @"mutation {
              signIn(user: {
                email: """ + email + "\"" +
                @"password: """ + password + "\"" +
              @"}) {
                jwt
                message
              }
            }";

            //string query = @"query {
            //                    allActivities {
            //                        name
            //                        description
            //                        qualification
            //                        visits
            //                    }
            //               }";

            GraphQLHttpClient graphQLClient = new GraphQLHttpClient("http://34.66.249.47:5500/graphql");
            GraphQLResponse graphQLResponse = new GraphQLResponse();

            Task.WaitAll(Task.Run(async () => { graphQLResponse = await graphQLClient.SendQueryAsync(query); }));

            return graphQLResponse.Data.signIn;
        }
    }
}
