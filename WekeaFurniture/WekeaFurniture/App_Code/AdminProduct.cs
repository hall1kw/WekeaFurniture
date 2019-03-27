using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for AdminProduct
/// </summary>
public class AdminProduct
{
    public string ID { set; get; }
    public string NAME { set; get; }
    public string IMAGEURL { set; get; }
    public decimal PRICE { set; get; }
    public string DESCRIPTION { set; get; }
    public string IDCAT { set; get; }
    public string IDROOM { set; get; }
    public string FEATURED { set; get; }
    public string TAXABLE { set; get; }
}