using System.Collections.Generic;

namespace WebApi.Models
{
    public class Storage
    {
        public List<MessageInfo> Messages = new List<MessageInfo>();
        public List<UserInfo> Users = new List<UserInfo>();
    }
}
