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
                content
                message
                status
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

            return graphQLResponse.Data.signIn; // Retorna null si no se crea JWT y un JObtect no vacío (con el JWT) en caso contrario
        }

        /* Método para comprobar la validez del JWT */
        public JObject VerifyJWT(string jwt)
        {
            /* Query para corroborar la validez de un token */
            string query = @"mutation {
              verifyToken(jwt: {
                jwt: """ + jwt + "\"" +
              @"}) {
                content
                message
                status
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

            return graphQLResponse.Data.verifyToken; 
        }

        /* Método para comprobar la validez del JWT */
        public JObject UserByEmail(string email)
        {
            /* Query para corroborar la validez de un token */
            string query = @"mutation {
              userByEmail(email:
              {
                email: """ + email + "\"" +
              @"})
              {
                 content
                {
                  id
                  name
                  document
                  age
                  email
                  password_digest
                }
                message
                status
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

            return graphQLResponse.Data.userByEmail;
        }

        /*  */

        /* Método que responde con el JWT correspondiente al inicio de sesión */
        public string LogIn(string email, string password)
        {
            JObject response = JWTResponse(email, password); // Envía un query

            if (response == null) // Si no hay JWT
            {
                return "";
            }
            else // Si se generó JWT
            {
                return response["content"].ToString();
            }
        }

        /*  */
        public bool VerifyToken(string jwt)
        {
            JObject response = VerifyJWT(jwt); // Envía un query

            if (response == null) // Si JWT no es válido
            {
                return false;
            }
            else // Si JWT es válido
            {
                return true;
            }
        }

        public User UserEmail(string email)
        {
            JObject response = UserByEmail(email); // Envía un query
            JToken contentResponse = response["content"];

            User mappedUser = new User
            {
                Id = contentResponse.Value<long>("id"),
                Name = contentResponse.Value<string>("name"),
                Document = contentResponse.Value<string>("document"),
                Age = contentResponse.Value<int>("age"),
                Email = contentResponse.Value<string>("email")
            };

            return mappedUser;
        }
    }
}
