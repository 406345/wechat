using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WechatSDK.API
{
    internal class Misc
    {
        public static string JoinDict(Dictionary<string,string> dict , string dictJoiner = "=" , string joiner = ";")
        {
            string ret = "";
            foreach (var item in dict)
            {
                ret += item.Key + dictJoiner + item.Value + joiner;
            }


            if (ret.Length == 0)
                return "";

            return ret.Substring(0, ret.Length - joiner.Length);
        }

        public static string JSON(object obj)
        {
            return LitJson.JsonMapper.ToJson(obj);
        }

        public static long TimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        public static long MessageStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }

        public static string MakeUrl(string url , object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();


            List<string> t = new List<string>();
            foreach (var item in properties)
            {
                t.Add(item.Name + "=" + item.GetValue(obj).ToString());
            }

            return url + "?" + string.Join("&", t);
        }

        public static Dictionary<string, string> Obj2Dict(object obj)
        {
            if (obj == null)
                return new Dictionary<string, string>();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var type = obj.GetType();
            var properties = type.GetProperties();


            List<string> t = new List<string>();
            foreach (var item in properties)
            {
                dict[item.Name] = item.GetValue(obj).ToString();
            }

            return dict;
        }

        public static string Regex(string pattern,string input , int group = 1)
        {
            Regex r = new Regex(pattern);
            var m = r.Match(input);
            return m.Groups[group].Value;
        }

        public static Dictionary<string,string> ParseQuery(string q)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            q = q.Replace("?", "");

            var tmp = q.Split(new string[] {"&" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in tmp)
            {
                int pos = s.IndexOf('=');

                ret[s.Substring(0, pos)] = s.Substring(pos + 1, s.Length - pos - 1);
                //var t = s.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                //ret[t[0]] = t[1];
            }

            return ret;
        }
    }
}
