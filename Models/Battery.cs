using System;
using System.Collections.Generic;

namespace RocketApi.Models
{
    public class Battery
    {
        public long Id { get; set; }
        public long BuildingId {get; set; }
        public string Status { get; set; }

        

        [System.Text.Json.Serialization.JsonIgnore]

        public  Building Building { get; set;}
        public virtual ICollection<Column> Columns { get; set;}


        public Boolean getColumnList(List<Column> filteredColumns, List<Elevator> filteredElevators) 
        {
            var currentColumns = new List<Column>();
            foreach(Column column in filteredColumns) 
            {
                if ( column.BatteryId == this.Id && column.getElevatorList(filteredElevators)) 
                {
                    currentColumns.Add(column);
                }

            }

            if (currentColumns.Count > 0) 
            {
                return true;
            }
            return false;
        } 
    }
}

