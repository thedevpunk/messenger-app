using System.Threading.Tasks;
using Api.Models;

namespace Api.Hubs
{
    public interface IClient
    {
         Task ReiveiceConnected(string userId);

         Task ReceiveMessage(Message message);
    }
}