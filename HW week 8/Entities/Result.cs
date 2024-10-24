﻿namespace HW_week_8.Entities
{
    public class Result
    {
        public bool IsSucces { get; set; }
        public string? Message { get; set; }
        public Result(bool isSucces, string? message = null)
        {
            IsSucces = isSucces;
            Message = message;
        }
    }
}
