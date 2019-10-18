using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class UsersModel : BaseModel
    {
        public int? UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte UserType { get; set; }


        public UsersModel(string firstName, string lastName, string city, string address, string phone, string email, string username, string password, byte userType)
        {
            UserID = null;
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Address = address;
            Phone = phone;
            Email = email;
            Username = username;
            Password = password;
            UserType = userType;

        }

        public UsersModel()
        {
        }

        public override string ToString()
        {
            return UserID + " " + FirstName + " " + LastName + " " + Address + " " + City + " " + Phone + " " + Email + " " + Username +" " + Password + " " + base.ToString();
        }
    }
}
