using Newtonsoft.Json;

namespace DingPush
{
    public static class DDRobotHelper
    {
        /// <summary>
        /// 发送机器人推送
        /// </summary>
        /// <param name="asstoken">令牌</param>
        /// <param name="msg">消息实体</param>
        /// <returns></returns>
        public static DDResponse SendMsg(string token, object msg)
        {
            string url = string.Format("https://oapi.dingtalk.com/robot/send?access_token={0}", token);
            string resp = HttpHelper.HttpPost(url, JsonConvert.SerializeObject(msg));
            DDResponse result = JsonConvert.DeserializeObject<DDResponse>(resp);
            return result;
        }



    }

}