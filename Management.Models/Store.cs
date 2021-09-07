using System;
using System.Collections.Generic;
using Management.Commons;
using System.ComponentModel.DataAnnotations; //use [Required]
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Models
{
    //the store class will hold information about the store such as names and products
    public class Store
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserId { get; set; }

        //use encapsulation to set the details of the store
        private string storeName;
        [Required] 
        public string StoreName
        {
            get {return storeName; }
            //set the first name to equal the value of first name that is formatted
            set { storeName = StoreValidation.FormatName(value); }
        }

        private string storeNumber;
        [Required] 
        public string StoreNumber
        {
            get {return storeNumber; }
            set { storeNumber = StoreValidation.FormatStoreNumber(value); }
        }

        private string storeType;
        [Required] 
        public string StoreType 
        {
            get{return storeType;}
            set{storeType = StoreValidation.FormatName(value);}
        }

        private int storeProducts;
        [Required] 
        public int StoreProducts 
        {
            get{return storeProducts;}
            set{storeProducts = StoreValidation.ValidateProducts(value);}
        }

        //nav property (one-many)
        //store has one user
        public User User { get; set; }
        //store has many products
        public ICollection<Product> Products { get; set; }
    }
}
