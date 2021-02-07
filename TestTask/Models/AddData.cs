using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Helpers;
using TestTask.Models.DataTransferObjects;
using TestTask.Models.DataTransferObjects.Interfaces;

namespace TestTask.Models
{
    public class AddData: IAddData
    {
        const int MassageCountAll = 20;
        const int MassageCountByUser = 10;

        public async Task Execute(string userName,string message,string session)
        {
            await Validation();
            var Users = Message.Messages.Select(x=>x.User).OrderBy(x=>x.UserID);
            var Messages = Message.Messages.OrderBy(x => x.MessageID);

            Message.Messages.Add(
                new DataTransferObjects.MessageDTO()
                {
                    MessageID = Messages.Count() > 0 ? Messages.Max(x=>x.MessageID) + 1 : Messages.Count() + 1,
                    Message = message,
                    User = Users.Where(x=>x.UserFullName == userName).FirstOrDefault()??
                    new DataTransferObjects.UserDTO() {
                        UserID = Users.Count() > 0 ? Users.Max(x => x.UserID) + 1 : Users.Count() + 1,
                        UserFullName = userName,
                        UserEmail = userName+"@gmail.com",
                        UserPhone = "+38066-764-50-90",
                        LastChangedOn = DateTime.UtcNow
                    },
                    Session = session,
                    LastChangedOn = DateTime.UtcNow
                }
                );
        }
        public async Task Execute(bool MessageID, bool LastChangedOn)
        {
            Message.SortByLastChangedOn = LastChangedOn;
            Message.SortByMessageID = MessageID;
        }
        public async Task<IEnumerable<MessageDTO>> Execute()
        {
            var result = Message.Messages.OrderByDescending(x => x.MessageID);
            if (Message.SortByMessageID || Message.SortByLastChangedOn)
            {
                result = Message.SortByLastChangedOn ? (Message.SortByMessageID ? result.OrderBy(x => x.MessageID) : result).OrderBy(x => x.LastChangedOn)
                    : Message.SortByMessageID ? result.OrderBy(x => x.MessageID) : result;
            }
            return result;
        }
        async Task Validation()
        {
            if(Message.Messages.Count() >= MassageCountAll)
            {
                Message.Messages = Message.Messages.OrderByDescending(x => x.MessageID).Take(MassageCountAll - 1).ToList();
            }
            var Users = Message.Messages.Select(x => x.User.UserID).Distinct();
            foreach(var i in Users)
            {
                var message = Message.Messages.Where(x => x.User.UserID == i).OrderByDescending(x=>x.MessageID);
                if(message.Count()>= MassageCountByUser)
                {
                    Message.Messages = Message.Messages.Where(x => x.User.UserID != i).ToList();

                    Message.Messages.AddRange(message.Take(MassageCountByUser - 1));
                }
            }
        }
    }
}
