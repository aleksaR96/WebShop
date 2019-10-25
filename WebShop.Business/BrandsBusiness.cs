using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using WebShop.Data;
using WebShop.Interfaces;
using WebShop.Model;

namespace WebShop.Business
{
    public class BrandsBusiness
    {
        public List<BrandModel> GetAllBrands()
        {
            IBrandsData bd = new BrandsData();
            List<BrandModel> outputList = null;

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    outputList = bd.SelectAll();
                    scope.Complete();
                }
            }
            catch(TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }

            return outputList;

        }
        public BrandModel GetBrand(BrandModel brand)
        {
            IBrandsData bd = new BrandsData();
            BrandModel output = null;

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    output = bd.Select(brand);
                    scope.Complete();
                }
            }
            catch(TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }

            return output;
        }
        public BrandModel AddBrand(BrandModel newBrand)
        {
            IBrandsData bd = new BrandsData();
            BrandModel output = null;

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    output = bd.Insert(newBrand);
                    scope.Complete();
                }
            }
            catch(TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }

            return output;
        }
        public BrandModel EditBrand(BrandModel brand)
        {
            IBrandsData bd = new BrandsData();
            BrandModel output = null;

            try
            {
                using(TransactionScope scope = new TransactionScope())
                {
                    output = bd.Update(brand);
                    scope.Complete();
                }
            } catch(TransactionAbortedException e)
            {
                Console.WriteLine(e.Message);
            }

            return output;
        }
    }
}
