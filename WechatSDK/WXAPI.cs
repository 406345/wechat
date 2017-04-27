using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WechatSDK.API
{
    internal class WXAPI
    {
        static string APPID = "wx782c26e4c19acffb";
        private string uuid = "";
        private string ticket = "";
        private string lang = "zh_CN";
        private string scan = "";
        private string host = "";
        private string skey = "";
        private string sid = "";
        private string uin = "";
        private string tip = "1";
        private string pass_ticket = "";
        private string deviceid = "";

        private BaseRequest baserequest = new BaseRequest();
        public WebWXInit webWXInit;
        public WebWXGetContact webWXGetContact;
        public WebWXSync webWXSync;
        public bool IsLogin = false;

        private HTTP http = new HTTP();

        public bool jslogin()
        {
            string url = "https://login.weixin.qq.com/jslogin";

            string t = http.Get(Misc.MakeUrl(url, new
            {
                appid = APPID,
                fun = "new",
                lang = this.lang,
                _ = Misc.TimeStamp(),
            }));

            Regex r = new Regex("window.QRLogin.uuid = \"(\\S+?)\";");
            var m = r.Match(t);
            this.uuid = m.Groups[1].Value;

            return true;
        }

        public byte[] qrcode()
        {
            string url = "https://login.weixin.qq.com/qrcode/" + this.uuid;
            //string t = http.Get(url,new { Accept = "image/webp,image/*,*/*;q=0.8" });

            WebClient wc = new WebClient();
            wc.Headers["Accept"] = "image/webp,image/*,*/*;q=0.8";
            return wc.DownloadData(url);
            //Process.Start("qrcode.png");
        }

        public string login()
        {
            string url = "https://wx.qq.com/cgi-bin/mmwebwx-bin/login";

            var ret = http.Get(Misc.MakeUrl(url, new
            {
                loginicon = false,
                tip = tip,
                uuid = this.uuid,
                _ = Misc.TimeStamp(),
                r = ~Misc.TimeStamp(),
            }));

            if (ret.Contains("201"))
            {
                tip = "0";
                return "201";
            }
            else if (ret.Contains("200"))
            {
                string redirect = Misc.Regex("window.redirect_uri=\"(\\S+?)\"", ret, 1);

                Uri uri = new Uri(redirect);

                var ps = Misc.ParseQuery(uri.Query);
                this.ticket = ps["ticket"];
                this.uuid = ps["uuid"];
                this.scan = ps["scan"];
                this.lang = ps["lang"];
                this.host = uri.Scheme + "://" + uri.Host;
                return "200";
            }
            else if (ret.Contains("408"))
            {
                return "408";
            }

            return "0";
        }

        public bool webwxnewloginpage()
        {
            //<script>window.location.href="https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxnewloginpage?ticket=A9Od2DCcUrRpmtj5uZe7pMSo@qrticket_0&uuid=IfYV5yME6g==&lang=zh_CN&scan=1483718722&fun=old"</script>
            string url = this.host + "/cgi-bin/mmwebwx-bin/webwxnewloginpage";

            var ret = http.Get(Misc.MakeUrl(url, new
            {
                ticket = this.ticket,
                uuid = this.uuid,
                lang = this.lang,
                scan = this.scan,
                fun = "new",
                version = "v2",
            }));

            //<error><ret>0</ret><message></message><skey>@crypt_2c961b66_986049458198dde8c2298288420faf9f</skey><wxsid>BYyF/ulqwZXI+pWz</wxsid><wxuin>3152044705</wxuin><pass_ticket>gP4vasXJvVlAVgxHT44dogQX2Kyx%2FwyJ3U%2B8wmG4s7oMpHB%2FDsoYmKrXizvA68yU</pass_ticket><isgrayscale>1</isgrayscale></error>

            this.skey = Misc.Regex("<skey>(\\S+?)</skey>", ret);
            this.uin = Misc.Regex("<wxuin>(\\S+?)</wxuin>", ret);
            this.sid = Misc.Regex("<wxsid>(\\S+?)</wxsid>", ret);
            this.pass_ticket = Misc.Regex("<pass_ticket>(\\S+?)</pass_ticket>", ret);

            
            return true;
        }

        public bool webwxinit()
        {
            Random rnd = new Random((int)Misc.TimeStamp());
            this.deviceid = "e";
            for (int i = 0; i < 15; i++)
            {
                this.deviceid += rnd.Next(0, 9).ToString();
            }

            string url = this.host + "/cgi-bin/mmwebwx-bin/webwxinit";

            url = Misc.MakeUrl(url, new {
                r = ~Misc.TimeStamp(),
                lang = this.lang,
                pass_ticket = this.pass_ticket,
            });

            this.baserequest = new BaseRequest{
                Uin = this.uin,
                Sid = this.sid,
                Skey = this.skey,
                DeviceID = this.deviceid,
            };

            var hret = http.Post(url, Misc.JSON(new {
                BaseRequest = this.baserequest
            }));
             
            this.webWXInit = LitJson.JsonMapper.ToObject<WebWXInit>(hret);

            if (this.webWXInit.BaseResponse.Ret != 0)
                return false;

            this.IsLogin = true;

            return true;
        }

        public bool webwxstatusnotify(string from , string to , int code = 3)
        { 
            string url = this.host + "/cgi-bin/mmwebwx-bin/webwxstatusnotify";

            url = Misc.MakeUrl(url, new {
                lang = this.lang,
                pass_ticket = this.pass_ticket,
            });

            var hret = http.Post(url, Misc.JSON(new {
                BaseRequest = this.baserequest,
                Code = code,
                FromUserName = from ,
                ToUserName = to,
                ClientMsgId = Misc.TimeStamp(),
            }));

            return true;
        }

        public bool webwxgetcontact()
        {
            string url = this.host + "/cgi-bin/mmwebwx-bin/webwxgetcontact";
            url = Misc.MakeUrl(url, new
            {
                lang = this.lang,
                pass_ticket = this.pass_ticket,
                r = Misc.TimeStamp(),
                seq = 0,
                skey = this.skey,
            });

            var hret = http.Get(url);

            this.webWXGetContact = LitJson.JsonMapper.ToObject<WebWXGetContact>(hret);

            if (this.webWXGetContact.BaseResponse.Ret != 0)
                return false;

            return true;
        }

        public string synccheck()
        {
            string url = this.host + "/cgi-bin/mmwebwx-bin/synccheck";

            List<string> synkey = new List<string>();
            foreach (var item in this.webWXInit.SyncKey.List)
            {
                synkey.Add(item.Key + "_" + item.Val);
            }

            var hret = http.Get(Misc.MakeUrl(url, new {
                r = Misc.TimeStamp(),
                sid = this.sid,
                uin = this.uin,
                skey = this.skey,
                deviceid = this.deviceid,
                synckey = string.Join("|", synkey),
                _ = Misc.TimeStamp(),
            }));

            Regex r = new Regex ("window.synccheck={retcode:\"(\\S+?)\",selector:\"(\\S+?)\"}");
            var m = r.Match(hret);
            var retcode = m.Groups[1].Value;
            var selector = m.Groups[2].Value;

            if (retcode != "0")
                this.IsLogin = false;
             
            return selector;
        }

        public bool webwxsync()
        {
            string url = this.host + "/cgi-bin/mmwebwx-bin/webwxsync";
            url = Misc.MakeUrl(url, new {
                sid = this.sid,
                skey = this.skey,
                pass_ticket = this.pass_ticket,
            });

            var hret = http.Post(url, Misc.JSON(new
            {
                BaseRequest = this.baserequest,
                SyncKey = this.webWXInit.SyncKey,
                rr = ~Misc.TimeStamp(),
            }));

            this.webWXSync = LitJson.JsonMapper.ToObject<WebWXSync>(hret);

            if (this.webWXGetContact.BaseResponse.Ret != 0)
                return false;

            this.skey = this.webWXSync.SKey;
            this.webWXInit.SyncKey = this.webWXSync.SyncKey;

            return true;
        }

        public bool webwxverifyuser(RecommendInfo item)
        {
            string url = this.host + "/cgi-bin/mmwebwx-bin/webwxverifyuser";

            url = Misc.MakeUrl(url, new
            {
                r = Misc.TimeStamp()
            });

            List<int> SceneList = new List<int>();
            SceneList.Add(33);

            List<VerifyUser> verfiyUserList = new List<VerifyUser>();
            verfiyUserList.Add(new VerifyUser() { Value = item.UserName, VerifyUserTicket = item.Ticket });

            var hret = http.Post(url, Misc.JSON(new
            {
                BaseRequest = this.baserequest,
                Opcode = 3,
                SceneList = SceneList,
                SceneListCount = SceneList.Count,
                VerifyUserList = verfiyUserList,
                VerifyUserListSize = verfiyUserList.Count,
                VerifyContent = "",
                skey = this.skey
            }));

            return true;
        }


        public bool webwxsendmsg(string to , string message)
        {
            string url = this.host + "/cgi-bin/mmwebwx-bin/webwxsendmsg";

            url = Misc.MakeUrl(url, new
            {
            });


            string id = Misc.MessageStamp().ToString();
            var hret = http.Post(url, Misc.JSON(new
            {
                BaseRequest = this.baserequest,
                Msg = new {
                    ClientMsgId = id,
                    Content = message,
                    FromUserName = this.webWXInit.User.UserName,
                    ToUserName = to,
                    LocalID = id,
                    Type = 1,
                },
                Scene = 0,
            }));

            return true;
        }
    }
}
