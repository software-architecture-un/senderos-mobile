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
        GlobalVariables Variables = new GlobalVariables();

        public UserResponse()
        {

        }

        /* Método que envía un query y retorna la respuesta asociada a JWT */
        public JObject JWTResponse(string email, string password)
        {
            /* Query que solicita JWT a partir de un usuario y una contraseña */
            string query = @"mutation {
              signIn(user: {
                email: """ + email + "\"" +
                @"password: """ + password + "\"" +
              @"}) {
                jwt
                message
              }
            }";

            GraphQLHttpClient graphQLClient = new GraphQLHttpClient(Variables.CloudIP + "graphql"); // GraphQL en Cloud
            GraphQLResponse graphQLResponse = new GraphQLResponse(); // Respuesta que se obtendrá

            Task.WaitAll( // Espera que se ejecuten todas las tareas asíncronas en su interior para continuar
                Task.Run( // Ejecuta una tarea
                    async () => // Expresión Lambda para ejecutar una tarea asíncrona dentro de un método síncrono
                    {
                        graphQLResponse = await graphQLClient.SendQueryAsync(query); // Envía el query a GraphQL y obtiene una respuesta
                    }));

            return graphQLResponse.Data.signIn; // Retorna null si no se crea WJT y un JObtect no vacío (con el JWT) en caso contrario
        }

        public string IsLogged(string email, string password)
        {
            JObject response = JWTResponse(email, password); // Envía un query

            if (response == null) // Si no hay JWT
            {
                return "";
            }
            else // Si se generó JWT
            {
                return response["jwt"].ToString();
            }
        }
    }
}
