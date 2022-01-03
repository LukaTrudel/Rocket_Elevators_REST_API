using System;
using System.Collections.Generic;
public class Address
{
    public long id { get; set; }
    public string typeAddress {get; set; }
    public string status { get; set; }
    public string entity { get; set; }
    public string numberAndStreet { get; set; }
    public string suiteOrApartment { get; set; }
    public string city { get; set; }
    public string postalCode { get; set; }
    public string country { get; set; }
    public string notes { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; } 
}