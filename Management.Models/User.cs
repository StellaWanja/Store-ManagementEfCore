using System;
using System.Collections.Generic;
using Management.Commons;
using System.ComponentModel.DataAnnotations; //use [Required]
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Models
{
    //the user class will hold information about the user such as names and email
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        //use encapsulation to set the details of the user
        private string firstName;
        [Required] 
        public string FirstName
        {
            get {return firstName; }
            //set the first name to equal the value of first name that is formatted
            set { firstName = UserValidation.FormatName(value); }
        }

        private string lastName;
        [Required] 
        public string LastName
        {
            get {return lastName; }
            set { lastName = UserValidation.FormatName(value); }
        }

        private string email;
        [Required] 
        public string Email 
        {
            get{return email;}
            set{email = UserValidation.ValidateEmail(value);}
        }

        private string password;
        [Required] 
        public string Password 
        {
            get{return password;}
            set{password = UserValidation.ValidatePassword(value);}
        }

        //Navigational property for one-many relationship
        //a user has many stores
        public ICollection<Store> Stores { get; set; }
    }
}
