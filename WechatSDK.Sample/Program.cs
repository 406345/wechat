using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WechatSDK.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WechatSDK.WXSDK sdk = new WXSDK();

            sdk.Login(OnLogin);


            sdk.OnUserMessage((UserMessage msg) => {
                Console.WriteLine(msg.User.NickName + " says: " + msg.Message);

                char[] arr = msg.Message.ToCharArray();
                Array.Reverse(arr);
                sdk.SendMessage(msg.User, new string(arr));
            });

            sdk.OnUserRequest((UserRequest req) => {
                return true;
            });

            sdk.DoJob();

            Console.ReadLine();
        }

        static void OnLogin(byte[] buffer)
        {
            new Thread((object obj) => {

                byte[] buf = obj as byte[];

                var frm = new Form();

                frm.Width = 500;
                frm.Height = 500;

                var picbox = new PictureBox();

                picbox.Parent = frm;
                picbox.Left = picbox.Top = 0;
                picbox.Width = frm.Width;
                picbox.Height = frm.Height;
                picbox.Image = new Bitmap(new MemoryStream(buf));

                frm.ShowDialog();
            }).Start(buffer);
        }
    }
}
