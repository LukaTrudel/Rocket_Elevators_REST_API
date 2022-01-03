using System;


namespace RocketApi.Models
{
    public class Elevator
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public long ColumnId { get; set; }

        public string SerialNumber {get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public  Column Column { get; }
    }
} 
