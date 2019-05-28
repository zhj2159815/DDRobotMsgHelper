"# DDRobotMsgHelper" 

#Desc：
this is a tool for DDtalk groupTalk Robot Send Msg chat.
You Can Send Msg to GroupTalk Chat, It just need you know this GroupTalk's Robot Token.
#(API地址)API Web Side : https://open-doc.dingtalk.com/microapp/serverapi2/qf2nxq  

#Using tips:
#DingPush使用说明：

#消息发送：DDRobotHelper

    //参数token群聊天机器人的token，msg消息对象实体
    SendMsg（token,msg) ：发送消息    

#消息实体构建：MsgBuilder

    /// <param name="content">消息内容</param>
 	/// <param name="atMobiles">被@人的手机号(在text内容里要有@手机号)的数组</param>
    /// <param name="isAllAt">@所有人时：true，否则为：false</param>
    ##1、BuildTxtMsgAt（string content, string[] atMobiles = null, bool isAllAt = false）

    /// <param name="title">消息标题</param>
    /// <param name="text">消息内容。如果太长只会部分展示</param>
    /// <param name="picUrl">图片URL</param>
    /// <param name="url">点击消息跳转的URL</param>
    ##2、BuildLinkMsg(string title, string text, string picUrl, string url)

    /// <param name="title">首屏会话透出的展示内容</param>
 	/// <param name="text">markdown格式的消息</param>
    ##3、BuildMarkdownMsg(string title, string text)

    /// <param name="title">首屏会话透出的展示内容</param>
    /// <param name="text">markdown格式的消息</param>
    /// <param name="hideAvatar">0-正常发消息者头像，1-隐藏发消息者头像</param>
    /// <param name="btnOrientation">0-按钮竖直排列，1-按钮横向排列</param>
    /// <param name="singleTitle">单个按钮的方案。(设置此项和singleURL后btns无效)</param>
    /// <param name="singleURL">点击singleTitle按钮触发的URL</param>
    /// <param name="btns">//独立跳转:按钮的信息：title-按钮方案，actionURL-点击按钮触发的URL</param>
    ##4、BuildActionCardMsg(string title, string text, string hideAvatar, string btnOrientation, string singleTitle, string singleURL, object[] btns = null)

  	/// <param name="title">单条信息文本</param>
    /// <param name="messageURL">点击单条信息到跳转链接</param>
    /// <param name="picURL">单条信息后面图片的URL</param>
    ##5、BuildFeedCardMsg(object[] links)

#使用步骤说明：
    1、引入DingPush.Dll。
    
    2、项目代码中using类库。
        using DingPush;
    
    3、使用MsgBuilder构建消息对象。
    
    4、调用DDRobotHelper.SendMsg方法发送消息。

        DDResponse result = DDRobotHelper.SendMsg(token, MsgBuilder.BuildTxtMsgAt("锄禾日当午"));
        Console.WriteLine("Text:{0}", result.errmsg);

#注意：

    Dll需要NetFormwork4.0版本环境才能运行。

    文本消息内容，如果需要换行显示，可以在文本中加入对应的换行符“\n”.