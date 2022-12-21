namespace LoanApi.Utilities
{
    public class ResponseApi<T>
    {
        public bool Status { get; set; }
        public string? Msg { get; set; }
        public T? Values { get; set; }
    }
}
