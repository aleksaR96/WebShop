using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Model
{
    public class ImageModel : BaseModel
    {
        public int ImageID { get; set; }
        public int ProductID { get; set; }
        public string Image { get; set; }

        public ImageModel(int imageID, int productID, string image)
        {
            ImageID = imageID;
            ProductID = productID;
            Image = image;
        }

        public ImageModel(int imageID)
        {
            ImageID = imageID;
        }

        public ImageModel()
        {
        }
    }
}
