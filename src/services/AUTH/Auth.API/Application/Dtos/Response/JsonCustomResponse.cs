namespace Auth.API.Application.Dtos.Response
{
    public class JsonCustomResponse
    {
        public bool Success { get; set; }
        public int ServerCode { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public object Data { get; set; }

        public JsonCustomResponse(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public JsonCustomResponse()
        {

        }
    }
}
