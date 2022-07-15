using System.Threading.Tasks;
using GraphQL;
namespace Posaidon.Services.Graphql
{
    public interface IGraphqlService
    {
        Task<GraphQLResponse<T>> QueryAsync<T>(string query, string operationName = null, object variables = null);
    }
}
