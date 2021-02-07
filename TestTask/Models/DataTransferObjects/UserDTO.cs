using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models.DataTransferObjects
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public DateTime LastChangedOn { get; set; }
    }
}
