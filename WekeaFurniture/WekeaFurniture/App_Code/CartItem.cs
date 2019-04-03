using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartItem
/// </summary>
public class CartItem
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Quantity { get; set; }
    public int Inventory { get; set; }

    public CartItem()
    {
        
    }

    public CartItem(int ID, string Name, string Image, string Description, double Price, int Quantity, int Inventory)
    {
        this.ID = ID;
        this.Name = Name;
        this.Image = Image;
        this.Description = Description;
        this.Price = Price;
        this.Quantity = Quantity;
        this.Inventory = Inventory;
    }
}