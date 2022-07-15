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
