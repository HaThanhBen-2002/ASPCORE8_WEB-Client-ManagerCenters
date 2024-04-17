﻿namespace TrainingCenters.Models
{
    public class ResponseDI<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
