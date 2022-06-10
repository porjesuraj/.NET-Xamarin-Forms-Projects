using System.Threading.Tasks;

namespace moviesApp.Services
{
    public interface INetworkService
    {
        Task<TResult> GetAsync<TResult>(string url);
    }
}