namespace bpfull_shared.Model.System;

public static class JsonExtension
{
    /// <summary>
    /// Converte um objeto do tipo <typeparamref name="T"/> em uma string no formato JSON.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto a ser convertido.</typeparam>
    /// <param name="obj">O objeto a ser serializado.</param>
    /// <returns>Uma string representando o objeto no formato JSON.</returns>
    public static string ObjectToJson<T>(this T obj) => Newtonsoft.Json.JsonConvert.SerializeObject(obj);

    /// <summary>
    /// Converte uma string no formato JSON em um objeto do tipo <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto a ser desserializado.</typeparam>
    /// <param name="json">A string JSON a ser convertida.</param>
    /// <returns>Um objeto do tipo <typeparamref name="T"/> representado pela string JSON.</returns>
    public static T JsonToObject<T>(this string json) => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
}