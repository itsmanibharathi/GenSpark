namespace API.Models
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; } = "Success";
        public T? Data { get; set; }
        public Response(T data,int code)
        {
            this.Data = data;
            this.StatusCode = code;
        }
    }
}
