using MessageGenerator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageGenerator
{
    public interface IMessageRepository
    {
        Task<Message> Generate();

        List<Message> GetAll();
    }
}
