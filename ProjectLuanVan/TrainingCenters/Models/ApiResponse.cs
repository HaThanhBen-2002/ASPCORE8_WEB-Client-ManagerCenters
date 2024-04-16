namespace TrainingCenters.Models
{
    public class ApiResponsePro<T>
    {
        public bool? IsSuccess { get; set; }
        public string? Message { get; set; }
        public int? StatusCode { get; set; }
        public T? Response { get; set; }
    }


    public class ApiResponse()
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Status{ get; set; }
    }
}
