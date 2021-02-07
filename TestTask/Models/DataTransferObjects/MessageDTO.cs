using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models.DataTransferObjects
{
    public class MessageDTO
    {
        public int MessageID { get; set; }
        public string Message { get; set; }
        public string Session { get; set; }
        public UserDTO User { get; set; }
        public DateTime LastChangedOn { get; set; }
    }
}
