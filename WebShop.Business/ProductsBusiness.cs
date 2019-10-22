using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Business
{
    public class ProductsBusiness
    {
        public List<ProductsModel> GetAllProducts()
        {
            IProductsData productsData = new ProductsData();
            IPropertiesData prd = new PropertiesData();
            IImagesData imgd = new ImagesData();
            IFeaturedPropertyData ifpd = new FeaturedPropertyData();
            IPropertyListData ipld = new PropertyListData();

            List<ProductsModel> products = productsData.SelectAll();

            foreach (ProductsModel product in products)
            {
                product.Properties = prd.SelectAllPropertiesByProductID(product);
                product.Images = imgd.SelectByProductID(product);
                var props = ifpd.SelectFeaturedPropertiesByCategoryID(new CategoryModel(product.CategoryID));
                product.FeaturedProperties = prd.SelectPropertyByProductIDAndPropertyID(product, props);

                foreach(var prop in product.FeaturedProperties)
                {
                    var name = ipld.SelectPropertyByPropertyID(prop);
                    product.FeaturedPropertiesName.Add(name);
                }
            }

            return products;
        }

        public ProductsModel GetProduct(ProductsModel product)
        {
            IProductsData pd = new ProductsData();
            product = pd.Select(product);
            IPropertiesData prd = new PropertiesData();
            product.Properties = prd.SelectAllPropertiesByProductID(product);
            IImagesData imgd = new ImagesData();
            product.Images = imgd.SelectByProductID(product);
            IPropertyListData pld = new PropertyListData();
            IFeaturedPropertyData fpd = new FeaturedPropertyData();

            var featuredProperties = fpd.SelectFeaturedPropertiesByCategoryID(new CategoryModel(product.CategoryID));
            product.FeaturedProperties = prd.SelectPropertyByProductIDAndPropertyID(product, featuredProperties);
            
            foreach(var property in product.FeaturedProperties)
            {
                product.FeaturedPropertiesName.Add(pld.SelectPropertyByPropertyID(property));
            }

            return product;
        }

        public List<ProductsModel> GetAllProductsByCategory(int catID)
        {
            IProductsData pd = new ProductsData();
            List<ProductsModel> products = pd.SelectProductsByCategoryID(catID);
            IPropertiesData prd = new PropertiesData();
            IImagesData imgd = new ImagesData();
            IPropertyListData pld = new PropertyListData();
            IFeaturedPropertyData fpd = new FeaturedPropertyData();

            foreach (ProductsModel product in products)
            {
                product.Properties = prd.SelectAllPropertiesByProductID(product);
                product.Images = imgd.SelectByProductID(product);

                var featuredProperties = fpd.SelectFeaturedPropertiesByCategoryID(new CategoryModel(product.CategoryID));
                product.FeaturedProperties = prd.SelectPropertyByProductIDAndPropertyID(product, featuredProperties);

                foreach (var property in product.FeaturedProperties)
                {
                    product.FeaturedPropertiesName.Add(pld.SelectPropertyByPropertyID(property));
                }
            }

            return products;
        }

        public bool RemoveProduct(ProductsModel product)
        {
            IProductsData pd = new ProductsData();
            bool result = false;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    result = pd.Delete(product);
                    scope.Complete();
                }
            }
            catch(TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public bool AddProduct(ProductsModel product)
        {
            IProductsData pd = new ProductsData();
            IPropertiesData prd = new PropertiesData();
            IImagesData imgd = new ImagesData();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    if (pd.Insert(product))
                    {
                        product = pd.SelectByName(product);
                        foreach (PropertyModel property in product.Properties)
                        {
                            property.ProductID = (int)product.ProductID;
                            if (!prd.InsertProperty(property))
                            {
                                return false;
                            }
                        }
                        foreach (ImageModel image in product.Images)
                        {
                            image.ProductID = (int)product.ProductID;
                            if (!imgd.Insert(image))
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }
            return true;

        }

        public bool EditProduct(ProductsModel product)
        {
            IProductsData pd = new ProductsData();
            IPropertiesData prd = new PropertiesData();
            IImagesData imgd = new ImagesData();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    if (pd.Update(product))
                    {
                        foreach (PropertyModel property in product.Properties)
                        {
                            if (!prd.UpdatePropertyByProductIDAndPropertyID(new PropertyModel((int)product.ProductID, property.PropertyID, property.Value)))
                            {
                                return false;
                            }
                        }
                        foreach (ImageModel image in product.Images)
                        {
                            if (!imgd.UpdateByProduct(image))
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }

                    scope.Complete();
                }
            } 

            catch(TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }

            return true;
        }

        public List<ProductsModel> GetAllPinnedDiscountProducts()
        {
            IProductsData pd = new ProductsData();
            IPropertiesData prd = new PropertiesData();
            List<ProductsModel> products = pd.SelectAllPinnedDiscountProducts();
            IImagesData imgd = new ImagesData();
            IPropertyListData pld = new PropertyListData();
            IFeaturedPropertyData fpd = new FeaturedPropertyData();

            foreach (ProductsModel product in products)
            {
                product.Properties = prd.SelectAllPropertiesByProductID(product);
                product.Images = imgd.SelectByProductID(product);

                var featuredProperties = fpd.SelectFeaturedPropertiesByCategoryID(new CategoryModel(product.CategoryID));
                product.FeaturedProperties = prd.SelectPropertyByProductIDAndPropertyID(product, featuredProperties);

                foreach (var property in product.FeaturedProperties)
                {
                    product.FeaturedPropertiesName.Add(pld.SelectPropertyByPropertyID(property));
                }
            }

            return products;
        }

        public List<ProductsModel> GetAllPinnedNewProducts()
        {
            IProductsData pd = new ProductsData();
            IPropertiesData prd = new PropertiesData();
            List<ProductsModel> products = pd.SelectAllPinnedNewProducts();
            IImagesData imgd = new ImagesData();
            IPropertyListData pld = new PropertyListData();
            IFeaturedPropertyData fpd = new FeaturedPropertyData();

            foreach (ProductsModel product in products)
            {
                product.Properties = prd.SelectAllPropertiesByProductID(product);
                product.Images = imgd.SelectByProductID(product);

                var featuredProperties = fpd.SelectFeaturedPropertiesByCategoryID(new CategoryModel(product.CategoryID));
                product.FeaturedProperties = prd.SelectPropertyByProductIDAndPropertyID(product, featuredProperties);

                foreach (var property in product.FeaturedProperties)
                {
                    product.FeaturedPropertiesName.Add(pld.SelectPropertyByPropertyID(property));
                }
            }

            return products;
        }

        public List<ProductsModel> GetAllPinnedPopularProducts()
        {
            IProductsData pd = new ProductsData();
            IPropertiesData prd = new PropertiesData();
            List<ProductsModel> products = pd.SelectAllPinnedPopularProducts();
            IImagesData imgd = new ImagesData();
            IPropertyListData pld = new PropertyListData();
            IFeaturedPropertyData fpd = new FeaturedPropertyData();

            foreach (ProductsModel product in products)
            {
                product.Properties = prd.SelectAllPropertiesByProductID(product);
                product.Images = imgd.SelectByProductID(product);

                var featuredProperties = fpd.SelectFeaturedPropertiesByCategoryID(new CategoryModel(product.CategoryID));
                product.FeaturedProperties = prd.SelectPropertyByProductIDAndPropertyID(product, featuredProperties);

                foreach (var property in product.FeaturedProperties)
                {
                    product.FeaturedPropertiesName.Add(pld.SelectPropertyByPropertyID(property));
                }
            }

            return products;
        }

        public List<ProductsModel> Get24ProductsWithOffset(int offset)
        {
            IProductsData pd = new ProductsData();
            List<ProductsModel> products = pd.Select24ProductsWithOffset(offset);
            IPropertiesData prd = new PropertiesData();
            IImagesData imgd = new ImagesData();
            IPropertyListData pld = new PropertyListData();
            IFeaturedPropertyData fpd = new FeaturedPropertyData();

            foreach (ProductsModel product in products)
            {
                product.Properties = prd.SelectAllPropertiesByProductID(product);
                product.Images = imgd.SelectByProductID(product);

                var featuredProperties = fpd.SelectFeaturedPropertiesByCategoryID(new CategoryModel(product.CategoryID));
                product.FeaturedProperties = prd.SelectPropertyByProductIDAndPropertyID(product, featuredProperties);

                foreach (var property in product.FeaturedProperties)
                {
                    product.FeaturedPropertiesName.Add(pld.SelectPropertyByPropertyID(property));
                }
            }

            return products;
        }

        public List<ProductsModel> Get10ProductsWithOffset(int offset)
        {
            IProductsData pd = new ProductsData();
            List<ProductsModel> products = pd.Select10ProductsWithOffset(offset);
            IPropertiesData prd = new PropertiesData();
            IImagesData imgd = new ImagesData();
            IPropertyListData pld = new PropertyListData();
            IFeaturedPropertyData fpd = new FeaturedPropertyData();

            foreach (ProductsModel product in products)
            {
                product.Properties = prd.SelectAllPropertiesByProductID(product);
                product.Images = imgd.SelectByProductID(product);

                var featuredProperties = fpd.SelectFeaturedPropertiesByCategoryID(new CategoryModel(product.CategoryID));
                product.FeaturedProperties = prd.SelectPropertyByProductIDAndPropertyID(product, featuredProperties);

                foreach (var property in product.FeaturedProperties)
                {
                    product.FeaturedPropertiesName.Add(pld.SelectPropertyByPropertyID(property));
                }
            }

            return products;
        }

        public List<ProductsModel> Get24ProductsByCategoryWithOffset(int categoryID, int offset)
        {
            IProductsData pd = new ProductsData();
            List<ProductsModel> products = pd.Select24ProductsByCategoryWithOffset(categoryID, offset);
            IPropertiesData prd = new PropertiesData();
            IImagesData imgd = new ImagesData();
            IPropertyListData pld = new PropertyListData();
            IFeaturedPropertyData fpd = new FeaturedPropertyData();

            foreach (ProductsModel product in products)
            {
                product.Properties = prd.SelectAllPropertiesByProductID(product);
                product.Images = imgd.SelectByProductID(product);

                var featuredProperties = fpd.SelectFeaturedPropertiesByCategoryID(new CategoryModel(product.CategoryID));
                product.FeaturedProperties = prd.SelectPropertyByProductIDAndPropertyID(product, featuredProperties);

                foreach (var property in product.FeaturedProperties)
                {
                    product.FeaturedPropertiesName.Add(pld.SelectPropertyByPropertyID(property));
                }
            }

            return products;
        }

        public List<ProductsModel> Get10ProductsByCategoryWithOffset(int categoryID, int offset)
        {
            IProductsData pd = new ProductsData();
            List<ProductsModel> products = pd.Select10ProductsByCategoryWithOffset(categoryID, offset);
            IPropertiesData prd = new PropertiesData();
            IImagesData imgd = new ImagesData();
            IPropertyListData pld = new PropertyListData();
            IFeaturedPropertyData fpd = new FeaturedPropertyData();

            foreach (ProductsModel product in products)
            {
                product.Properties = prd.SelectAllPropertiesByProductID(product);
                product.Images = imgd.SelectByProductID(product);

                var featuredProperties = fpd.SelectFeaturedPropertiesByCategoryID(new CategoryModel(product.CategoryID));
                product.FeaturedProperties = prd.SelectPropertyByProductIDAndPropertyID(product, featuredProperties);

                foreach (var property in product.FeaturedProperties)
                {
                    product.FeaturedPropertiesName.Add(pld.SelectPropertyByPropertyID(property));
                }
            }

            return products;
        }

        public string Get24JSONProductsWithOffset(int offset)
        {
            IProductsData pd = new ProductsData();
            List<ProductsModel> products = Get24ProductsWithOffset(offset);

            return JsonConvert.SerializeObject(products);
        }

        public string Get10JSONProductsWithOffset(int offset)
        {
            IProductsData pd = new ProductsData();
            List<ProductsModel> products = Get10ProductsWithOffset(offset);

            return JsonConvert.SerializeObject(products);
        }

        public string Get24JSONProductsByCategoryWithOffset(int categoryID, int offset)
        {
            IProductsData pd = new ProductsData();
            List<ProductsModel> products = Get24ProductsByCategoryWithOffset(categoryID, offset);

            return JsonConvert.SerializeObject(products);
        }

        public string Get10JSONProductsByCategoryWithOffset(int categoryID, int offset)
        {
            IProductsData pd = new ProductsData();
            List<ProductsModel> products = Get10ProductsByCategoryWithOffset(categoryID, offset);

            return JsonConvert.SerializeObject(products);
        }

        public ProductsModel GetOneProductByCategoryWithOffset(int categoryID, int offset)
        {
            //METODA NE VRACA POTPUN PRODUCT, DODATA SAMO RADI PROBE
            IProductsData pd = new ProductsData();
            return pd.SelectOneProductByCategoryWithOffset(categoryID, offset);
        }

        public int GetTotalCountOfProductsByCategory(int categoryID)
        {
            IProductsData pd = new ProductsData();
            return pd.CountProductsByCategoryID(categoryID);
        }
    }
}
