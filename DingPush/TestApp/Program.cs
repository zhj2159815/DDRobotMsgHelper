using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DingPush;
using Newtonsoft.Json;

namespace TestApp
{
    public class Program
    {
        //令牌
        public const string token = "c936b0f99fe6295f101320b0a7ce2dde561df5c98e176599aa8f49fc4bdacba1";

        static void Main(string[] args)
        {
            TestSendTxt();
            Console.ReadKey();
        }

        //测试发送Text文本消息
        public static void TestSendTxt()
        {
            DDResponse result = DDRobotHelper.SendMsg(token, MsgBuilder.BuildTxtMsgAt("锄禾日当午"));
            Console.WriteLine("Text:{0}", result.errmsg);
        }

        //测试带有Text和At的文本消息
        public static void TestSendTxtAndAt()
        {
            DDResponse result = DDRobotHelper.SendMsg(token, MsgBuilder.BuildTxtMsgAt("汗滴禾下土", new string[] { "13459015923", "18559829768" }, false));
            Console.WriteLine("Text At:{0}", result.errmsg);
        }

        //测试Link类型消息
        public static void TestSendLink()
        {
            DDResponse result = DDRobotHelper.SendMsg(token, MsgBuilder.BuildLinkMsg("发送链接", "谁知盘中餐", "", "https://www.baidu.com/"));
            Console.WriteLine("Link:{0}", result.errmsg);
        }

        //测试Markdown类型的消息
        public static void TestSendMarkdown()
        {
            DDResponse result = DDRobotHelper.SendMsg(token, MsgBuilder.BuildMarkdownMsg("发送链接", "#### 杭州天气 \n" +
                 "> 9度，西北风1级，空气良89，相对温度73%\n\n" +
                 "> ![screenshot](https://gw.alipayobjects.com/zos/skylark-tools/public/files/84111bbeba74743d2771ed4f062d1f25.png)\n" +
                 "> ###### 10点20分发布 [天气](http://www.thinkpage.cn/) \n"));
            Console.WriteLine("Markdown:{0}", result.errmsg);
        }

        //测试带有At的文本消息
        public static void TestSendActionCard()
        {
            DDResponse result = DDRobotHelper.SendMsg(token, MsgBuilder.BuildActionCardMsg("丽丽姐辛苦", "悯农", "0", "0", "点击阅读更多", "https://www.dianchu.com/"));
            Console.WriteLine("无按钮:{0}", result.errmsg);
            result = DDRobotHelper.SendMsg(token, MsgBuilder.BuildActionCardMsg("丽丽姐辛苦1", "悯农", "0", "0", "", "https://www.dianchu.com/", new Object[] {
                new {
                    title = "内容不错", 
                    actionURL= "https://www.dingtalk.com/"
                }, 
                new {
                    title="不感兴趣", 
                    actionURL= "https://www.dingtalk.com/"
                }
            }));
            Console.WriteLine("有按钮:{0}", result.errmsg);
        }

        //测试FeedCard类型的消息
        public static void TestSendFeedCard()
        {
            //https://www.dianchu.com//static/home/img/index_pic2.jpg
            DDResponse result = DDRobotHelper.SendMsg(token, MsgBuilder.BuildFeedCardMsg(new Object[] {
                new {
                    title = "点触科技", 
                    messageURL = "https://www.dianchu.com/",
                    picURL= "https://www.dianchu.com//static/home/img/index_pic2.jpg"
                }, 
                new {
                    title="DD", 
                    messageURL= "https://www.dingtalk.com/",
                    picURL= "https://www.dianchu.com//static/home/img/index_pic2.jpg"
                }
            }));
            Console.WriteLine("FeedCard:{0},{1}", result.errcode, result.errmsg);
        }

    }
}
