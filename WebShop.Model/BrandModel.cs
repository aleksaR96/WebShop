using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class BrandModel : BaseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public BrandModel(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public BrandModel(string name)
        {
            Name = name;
        }

        public BrandModel(int iD)
        {
            ID = iD;
        }

        public BrandModel()
        {
        }

        public override string ToString()
        {
            return ID + " " + Name;
        }
    }
}
