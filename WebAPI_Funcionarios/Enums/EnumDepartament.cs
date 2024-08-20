using System.Text.Json.Serialization;

namespace WebAPI_Funcionarios.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumDepartament
    {
        HR,
        Service,
        Mechanical_Workshop,
        Office
    }
}
