using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models.DataTransferObjects;

namespace TestTask.Helpers
{
    public static class Message
    {
        public static string About = @"Five years of development experience on ASP.Net";
        public static string Contact = @"My contacts:";
        public static List<UserDTO> Users= new List<UserDTO>();
        public static List<MessageDTO> Messages = new List<MessageDTO>();
        public static bool SortByMessageID = false;
        public static bool SortByLastChangedOn = false;
    }
}
