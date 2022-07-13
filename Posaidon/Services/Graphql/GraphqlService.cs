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
            client.HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer c96a077113e53d8a71147e9b118c82df76cb6223676caf57c2afeef7f84d9fad84f0c0ad5c5624253e72b34eedcf3ae0db2223621017e914245c2e837ec3648dc4d675e556c3fa5f7af4e08504fc758e0d75635bda50f89c488d91bfa15bb7c1f787549a55b5182ebacfd87e28007bff27002e0600c34ffb3ab6cfc3f5ce6469");
            client.HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<GraphQLResponse<T>> QueryAsync<T>(string query)
        {
            var request = new GraphQLRequest
            {
                Query = query
            };

            var result = await client.SendQueryAsync<T>(request);

            return result;
        }
    }
}
