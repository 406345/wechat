using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatSDK.API
{
    internal class VerifyUser
    {
        public string Value { get; set; } = "";
        public string VerifyUserTicket { get; set; } = "";
    }

    internal class BaseRequest
    {
        public string Uin { get; set; }
        public string Sid { get; set; }
        public string Skey { get; set; }
        public string DeviceID { get; set; }
    }

    internal class BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public long Ret { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ErrMsg { get; set; }
    }

    internal class ContactListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public long Uin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 文件传输助手
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HeadImgUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ContactFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long MemberCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> MemberList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long HideInputBarFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long VerifyFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long OwnerUin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PYInitial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PYQuanPin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkPYInitial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkPYQuanPin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long StarFriend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AppAccountFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Statues { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AttrStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long SnsFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UniFriend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ChatRoomId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EncryChatRoomId { get; set; }
    }

    internal class ListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public long Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Val { get; set; }
    }

    internal class SyncKey
    {
        /// <summary>
        /// 
        /// </summary>
        public long Count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ListItem> List { get; set; }
    }

    internal class User
    {
        /// <summary>
        /// 
        /// </summary>
        public long Uin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 心星杂货铺
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HeadImgUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PYInitial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PYQuanPin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkPYInitial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkPYQuanPin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long HideInputBarFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long StarFriend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Sex { get; set; }
        /// <summary>
        /// 韩国化妆品，荷兰奶粉。绝对正品。可面交..朋友圈有折扣信息！
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AppAccountFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long VerifyFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ContactFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long WebWxPluginSwitch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long HeadImgFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long SnsFlag { get; set; }
    }

    internal class WebWXInit
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseResponse BaseResponse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ContactListItem> ContactList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SyncKey SyncKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChatSet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ClientVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long SystemTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long GrayScale { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long InviteStartCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long MPSubscribeMsgCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> MPSubscribeMsgList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ClickReportInterval { get; set; }
    }

    internal class MemberListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public long Uin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 微信团队
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HeadImgUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ContactFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long MemberCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> MemberList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long HideInputBarFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Sex { get; set; }
        /// <summary>
        /// 微信团队官方帐号
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long VerifyFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long OwnerUin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PYInitial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PYQuanPin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkPYInitial { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkPYQuanPin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long StarFriend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AppAccountFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Statues { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AttrStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long SnsFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UniFriend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ChatRoomId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KeyWord { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EncryChatRoomId { get; set; }
    }

    internal class WebWXGetContact
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseResponse BaseResponse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long MemberCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<MemberListItem> MemberList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Seq { get; set; }
    }

    internal class RecommendInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long QQNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Scene { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long VerifyFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AttrStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Ticket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long OpCode { get; set; }
    }

    internal class AppInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string AppID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Type { get; set; }
    }

    internal class AddMsgListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string MsgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long MsgType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ImgStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long VoiceLength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long PlayLength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FileSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AppMsgType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long StatusNotifyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StatusNotifyUserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RecommendInfo RecommendInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ForwardFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AppInfo AppInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long HasProductId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Ticket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ImgHeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ImgWidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long SubMsgType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long NewMsgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OriContent { get; set; }
    }

    internal class UserName
    {
        /// <summary>
        /// 
        /// </summary>
        public string Buff { get; set; }
    }

    internal class NickName
    {
        /// <summary>
        /// 
        /// </summary>
        public string Buff { get; set; }
    }

    internal class BindEmail
    {
        /// <summary>
        /// 
        /// </summary>
        public string Buff { get; set; }
    }

    internal class BindMobile
    {
        /// <summary>
        /// 
        /// </summary>
        public string Buff { get; set; }
    }

    internal class Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public long BitFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserName UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public NickName NickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long BindUin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BindEmail BindEmail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BindMobile BindMobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long PersonalCard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long HeadImgUpdateFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HeadImgUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Signature { get; set; }
    }

    internal class SyncCheckKey
    {
        /// <summary>
        /// 
        /// </summary>
        public long Count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ListItem> List { get; set; }
    }

    internal class ModContactListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long HeadImgUpdateFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ContactType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ChatRoomOwner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HeadImgUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ContactFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long MemberCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> MemberList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long HideInputBarFlag { get; set; }
        /// <summary>
        /// 「把节省下来的时间  浪费在美好的事物上」
        /// </summary>
        public string Signature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long VerifyFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RemarkName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Statues { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AttrStatus { get; set; }
        /// <summary>
        /// 四川
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 成都
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long SnsFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KeyWord { get; set; }
    }

    internal class WebWXSync
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseResponse BaseResponse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AddMsgCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<AddMsgListItem> AddMsgList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ModContactCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ModContactListItem> ModContactList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long DelContactCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> DelContactList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ModChatRoomMemberCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> ModChatRoomMemberList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Profile Profile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ContinueFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SyncKey SyncKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SyncCheckKey SyncCheckKey { get; set; }
    }
}
