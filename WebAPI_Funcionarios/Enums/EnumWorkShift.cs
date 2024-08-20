using System.Text.Json.Serialization;

namespace WebAPI_Funcionarios.Enums
{
    //To convert int to text in API
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumWorkShift
    {
        Morning,
        Afternoon,
        Night
    }
}
