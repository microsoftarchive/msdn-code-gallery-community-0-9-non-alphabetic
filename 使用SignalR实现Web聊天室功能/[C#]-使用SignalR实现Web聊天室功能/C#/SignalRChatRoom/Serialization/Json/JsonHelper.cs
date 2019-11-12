using Newtonsoft.Json;

namespace SignalRChatRoom.Serialization.Json
{
    /// <summary>
    /// JSON 帮助类
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// 从一个对象信息生成Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJsonString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 从Json字符串生成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T ToObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}