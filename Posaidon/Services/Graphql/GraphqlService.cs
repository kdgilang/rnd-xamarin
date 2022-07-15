using System;
using System.Net.Http;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Posaidon.Configs;
using Posaidon.Services.Graphql;

[assembly: Xamarin.Forms.Dependency(typeof(GraphqlService))]
namespace Posaidon.Services.Graphql
{
    public class GraphqlService : IGraphqlService
    {
        private readonly GraphQLHttpClient client;
        public GraphqlService()
        {
            client = new GraphQLHttpClient(AppSettings.API_BASE_URL, new NewtonsoftJsonSerializer());
            client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AppSettings.API_TOKEN}");
            client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<GraphQLResponse<T>> QueryAsync<T>(string query, string operationName, object variables)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = query,
                    OperationName = operationName,
                    Variables = variables
                };

                var result = await client.SendQueryAsync<T>(request);

                return result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }
    }
}
