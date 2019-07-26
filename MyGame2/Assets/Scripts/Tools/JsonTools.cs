using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public sealed class JsonTools  {

    /// <summary>
    /// 从Json文件中获取数据转化为对应的数据实体类对象
    /// </summary>
    public static List<T> GetJsonList<T>(string fileName)
    {
        List<T> tempList = new List<T>();
        //获取Json文本内容
        string jsonStr = Resources.Load<TextAsset>("JsonData/" + fileName).text;

        //解析Json数据
        JsonData jsonData = JsonMapper.ToObject(jsonStr);
        for (int i = 0; i < jsonData.Count; i++)
        {
            T item = JsonMapper.ToObject<T>(jsonData[i].ToJson());           
            tempList.Add(item);
        }

        return tempList;
    }

    /// <summary>
    /// 把Json对象转化为字符串
    /// </summary>
    /// <returns></returns>
    public static string TransromToJsonString(object obj)
    {
        string jsonStr = JsonMapper.ToJson(obj);
        //foreach(T item in list)
        //{
        //    string temp = JsonMapper.ToJson(list);
            
        //}
        return jsonStr;
    }

    public static T GetJsonObject<T>(string fileName)
    {
        string jsonStr = Resources.Load<TextAsset>("JsonData/" + fileName).text;
        return JsonMapper.ToObject<T>(jsonStr);
    }

}
