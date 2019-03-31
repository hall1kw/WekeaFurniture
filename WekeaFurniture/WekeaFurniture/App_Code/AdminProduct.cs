using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for AdminProduct
/// </summary>
public class AdminProduct
{
    public string id { set; get; }
    public string name { set; get; }
    public string image { set; get; }
    public decimal price { set; get; }
    public string description { set; get; }
    public string idcat { set; get; }
    public string idroom { set; get; }
    public string featured { set; get; }
    public string taxable { set; get; }
}