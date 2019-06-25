using GraphQL.Client.Http;
using GraphQL.Common.Response;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SenderosMobile
{
    class TrailResponse
    {
        GlobalVariables Variables = new GlobalVariables();

        public TrailResponse()
        {

        }

        /* Método que envía un query y retorna la respuesta asociada a JWT */
        public JArray AllTrails(long id)
        {
            /* Query que solicita JWT a partir de un usuario y una contraseña */
            string query = @"query {
          findTrailsByUser(id: " + id.ToString() + @"){
            nametrail
            origintrail
            destinytrail
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

            return graphQLResponse.Data.findTrailsByUser; // Retorna null si no se crea JWT y un JObtect no vacío (con el JWT) en caso contrario
        }

        public List<Trail> AllTrailsMapped(long id)
        {
            JArray response = AllTrails(id); // Envía un query

            List<Trail> trails = new List<Trail>();

            for(int i = 0; i < response.Count; i++)
            {
                Trail trail = new Trail
                {
                    Id = response[i].Value<string>("id"),
                    Name = response[i].Value<string>("nametrail"),
                    InitialPlace = response[i].Value<int>("origintrail"),
                    FinalPlace = response[i].Value<int>("destinytrail")
                };

                trails.Add(trail);
            }

            return trails;
        }
    }
}
