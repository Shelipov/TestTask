using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models.DataTransferObjects.Interfaces
{
    public interface IAddData
    {
        Task Execute(string userName, string message, string session);
        Task Execute(bool MessageID, bool LastChangedOn);
        Task<IEnumerable<MessageDTO>> Execute();
    }
}
