namespace EVE.Commons.Response
{
    public class ClientResponse<T>
    {
        public T Data { get; set; }

        public bool IsError { get; set; }

        public string ErrorCode { get; set; }

        public string Message { get; set; }
    }
}
