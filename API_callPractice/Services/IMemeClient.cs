using System.Threading.Tasks;

namespace API_callPractice.Services
{
     public interface IMemeClient
    {
        Task<MemeResponse> GetMemeImages(string theEnd = "get_memes");
    }
}
