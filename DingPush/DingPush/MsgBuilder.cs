using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingPush
{
    /// <summary>
    /// 消息构建类
    /// </summary>
    public class MsgBuilder
    {
        /// <summary>
        /// 包含At的消息
        /// </summary>
        /// <param name="content">消息内容</param>
        /// <param name="atMobiles">被@人的手机号(在text内容里要有@手机号)的数组</param>
        /// <param name="isAllAt">@所有人时：true，否则为：false</param>
        /// <returns>消息对象obj</returns>
        public static object BuildTxtMsgAt(string content, string[] atMobiles = null, bool isAllAt = false)
        {
            Object obj = new
            {
                msgtype = "text",
                text = new
                {
                    content = content
                },
                at = new
                {
                    atMobiles = atMobiles,
                    isAtAll = isAllAt
                }
            };
            return obj;
        }

        /// <summary>
        /// link类型消息，At无效
        /// </summary>
        /// <param name="title">消息标题</param>
        /// <param name="text">消息内容。如果太长只会部分展示</param>
        /// <param name="picUrl">图片URL</param>
        /// <param name="url">点击消息跳转的URL</param>
        /// <param name="atMobiles">被@人的手机号(在text内容里要有@手机号)</param>
        /// <param name="isAllAt">@所有人时：true，否则为：false</param>
        /// <returns>消息对象obj</returns>
        public static object BuildLinkMsg(string title, string text, string picUrl, string url)
        {
            Object obj = new
            {
                msgtype = "link",
                link = new
                {
                    text = text,
                    title = title,
                    picUrl = picUrl,
                    messageUrl = url
                }
            };
            return obj;
        }

        /// <summary>
        /// Markdown类型消息，At无效
        /// </summary>
        /// <param name="title">首屏会话透出的展示内容</param>
        /// <param name="text">markdown格式的消息</param>
        /// <returns>消息对象obj</returns>
        public static object BuildMarkdownMsg(string title, string text)
        {
            Object obj = new
            {
                msgtype = "markdown",
                markdown = new
                {
                    text = text,
                    title = title
                }
            };
            return obj;
        }

        /// <summary>
        /// 整体跳转和独立跳转ActionCard类型，At无效
        /// </summary>
        /// <param name="title">首屏会话透出的展示内容</param>
        /// <param name="text">markdown格式的消息</param>
        /// <param name="hideAvatar">0-正常发消息者头像，1-隐藏发消息者头像</param>
        /// <param name="btnOrientation">0-按钮竖直排列，1-按钮横向排列</param>
        /// <param name="singleTitle">单个按钮的方案。(设置此项和singleURL后btns无效)</param>
        /// <param name="singleURL">点击singleTitle按钮触发的URL</param>
        /// <param name="btns">//独立跳转:按钮的信息：title-按钮方案，actionURL-点击按钮触发的URL</param>
        /// <returns>消息对象obj</returns>
        public static object BuildActionCardMsg(string title, string text, string hideAvatar, string btnOrientation, string singleTitle, string singleURL, object[] btns = null)
        {
            Object obj = new
            {
                msgtype = "actionCard",
                actionCard = new
                {
                    title = title,
                    text = text,
                    hideAvatar = hideAvatar,
                    btnOrientation = btnOrientation,
                    btns = btns,
                    singleTitle = singleTitle,
                    singleURL = singleURL
                }
            };
            return obj;
        }

        /// <summary>
        /// 构建FeedCard类型消息
        /// </summary>
        /// <param name="title">单条信息文本</param>
        /// <param name="messageURL">点击单条信息到跳转链接</param>
        /// <param name="picURL">单条信息后面图片的URL</param>
        /// <returns>消息对象obj</returns>
        public static object BuildFeedCardMsg(object[] links)
        {
            Object obj = new
            {
                msgtype = "feedCard",
                feedCard = new
                {
                    links = links
                }

            };
            return obj;
        }

        /// <summary>
        /// 根据类型和参数构建消息对象
        /// </summary>
        /// <param name="type"></param>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <param name="picUrl"></param>
        /// <param name="url"></param>
        /// <param name="atMobiles"></param>
        /// <param name="isAllAt"></param>
        /// <param name="hideAvatar"></param>
        /// <param name="btnOrientation"></param>
        /// <param name="singleTitle"></param>
        /// <param name="singleURL"></param>
        /// <param name="btns"></param>
        /// <param name="links"></param>
        /// <returns>消息对象obj</returns>
        public static object BuildByTypeAndParams(string type, string title, string text, string picUrl = "", string url = "", string[] atMobiles = null, bool isAllAt = false, string hideAvatar = "0", string btnOrientation = "0", string singleTitle = "", string singleURL = "", object[] btns = null, object[] links = null)
        {
            Object obj = null;
            switch (type)
            {
                case "text":
                    obj = new
                    {
                        msgtype = "text",
                        text = new
                        {
                            content = title
                        },
                        at = new
                        {
                            atMobiles = atMobiles,
                            isAtAll = isAllAt
                        }
                    };
                    break;
                case "link":
                    obj = new
                    {
                        msgtype = "link",
                        link = new
                        {
                            text = text,
                            title = title,
                            picUrl = picUrl,
                            messageUrl = url
                        }
                    };
                    break;
                case "markdown":
                    obj = new
                    {
                        msgtype = "markdown",
                        markdown = new
                        {
                            text = text,
                            title = title
                        }
                    };
                    break;
                case "actionCard":
                    obj = new
                    {
                        msgtype = "actionCard",
                        actionCard = new
                        {
                            title = title,
                            text = text,
                            hideAvatar = hideAvatar,
                            btnOrientation = btnOrientation,
                            btns = btns,
                            singleTitle = singleTitle,
                            singleURL = singleURL
                        }
                    };
                    break;
                case "feedCard":
                    obj = new
                    {
                        msgtype = "feedCard",
                        feedCard = new
                        {
                            links = links
                        }

                    };
                    break;
            }
            return obj;
        }

    }
}
