using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatSDK
{
    public class UserInfo
    {
        internal UserInfo(API.MemberListItem item)
        {
            this.NickName = item.NickName;
            this.City = item.City;
            this.UserName = item.UserName;
            this.Alias = item.Alias;
        }

        public string Alias { get; set; } = "";
        public string NickName { get; set; } = "";
        public string City { get; set; } = "";

        internal string UserName { get; set; } = "";
    }

    public class UserRequest
    {
        public string City { get; set; } = "";
        public string Id { get; set; } = "";
        public string NickName { get; set; } = "";
    }

    public class UserMessage
    {
        public string Message { get; set; } = "";
        public UserInfo User { get; set; } = null;
    }
}
