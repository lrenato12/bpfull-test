namespace bpfull_shared.Model.System;

public static class JsonExtension
{
    public static string ObjectToJson<T>(this T obj) => Newtonsoft.Json.JsonConvert.SerializeObject(obj);

    public static T JsonToObject<T>(this string json) => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
}