using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WechatSDK
{
    public class WXSDK
    {
        private API.WXAPI api = new API.WXAPI();

        private Action<byte[]> CBLogin;
        private Func<UserRequest, bool> CBUserRequest;
        private Action<UserMessage> CBUserMessage;

        public WXSDK()
        {

        }

        public void DoJob()
        {
            while (api.IsLogin)
            {
                var state = api.synccheck();
                api.webwxsync();

                if (state == "2")
                {
                    foreach (var item in api.webWXSync.AddMsgList)
                    {
                        if (item.MsgType == 1)
                        {
                            var u = api.webWXGetContact.MemberList.Where(m => m.UserName == item.FromUserName).FirstOrDefault();

                            if (u != null)
                            {
                                if (this.CBUserMessage != null)
                                {
                                    this.CBUserMessage(new UserMessage() { User = new UserInfo(u), Message = item.Content });
                                }

                            }

                            api.webwxstatusnotify(api.webWXInit.User.UserName, item.FromUserName, 1);
                        }
                        else if (item.MsgType == 37)
                        {
                            if (CBUserRequest != null)
                            {
                                if (CBUserRequest(new UserRequest() { NickName = item.RecommendInfo.NickName, Id = item.RecommendInfo.UserName, City = item.RecommendInfo.City }))
                                {
                                    api.webwxverifyuser(item.RecommendInfo);
                                    api.webwxgetcontact();
                                }
                            }
                        }
                    }
                }

                Thread.Sleep(1000);
            }
        }

        public void OnUserRequest(Func<UserRequest, bool> callback)
        {
            this.CBUserRequest = callback;
        }

        public void OnUserMessage(Action<UserMessage> callback)
        {
            this.CBUserMessage = callback;
        }

        public void Login(Action<byte[]> login_callback)
        {
            CBLogin = login_callback;

            if (api.IsLogin) return;

            api.jslogin();
            var buffer = api.qrcode();

            if (CBLogin != null) this.CBLogin(buffer);

            while (true)
            {
                string p = api.login();

                if (p == "200")
                {
                    // login confirmed
                    api.webwxnewloginpage();
                    api.webwxinit();
                    api.webwxstatusnotify(api.webWXInit.User.UserName, api.webWXInit.User.UserName);
                    api.webwxgetcontact();

                    break;
                }
                else if (p == "201")
                {
                    // qrcode scaned

                }
                else if (p == "408")
                {
                    this.api.jslogin();
                    if (CBLogin != null) this.CBLogin(api.qrcode());
                }
            }
        }

        public void SendMessage(UserInfo info , string message)
        {
            if (string.IsNullOrEmpty(message)) return;

            api.webwxsendmsg(info.UserName, message);

        }
    }
}
