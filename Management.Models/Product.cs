using System;
using System.ComponentModel.DataAnnotations; //use [Required]
using System.ComponentModel.DataAnnotations.Schema;
using Management.Commons;

namespace Management.Models
{
    //hold product info
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string StoreId { get; set; }

        private string productName;
        [Required]
        public string ProductName
        {
            get {return productName; }
            set { productName = StoreValidation.FormatName(value); }
        }

        private int price;
        [Required]
        public int Price
        {
            get {return price; }
            set { price = value; }
        }

        //navigational property
        public Store Store { get; set; }
    }
}