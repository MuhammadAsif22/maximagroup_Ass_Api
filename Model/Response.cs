namespace eServicesApi.Model
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string message { get; set; }
        public ICollection<string> Role { get; set; }
        public int code { get; set; }
    }
}
