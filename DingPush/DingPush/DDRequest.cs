﻿
namespace DingPush
{
    public class DDRequest
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string errmsg { get; set; }
    }
}
