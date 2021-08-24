using System.Text.Json;

namespace API.GestionErreur
{
    public class MessageErreur
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
