using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebShop.Data;
using WebShop.Model;

namespace WebShop.UnitTest
{
    [TestClass]
    public class IDataTest
    {
        [TestMethod]
        public void IDataModelState_Changed_by_SelectAll()
        {
            IProductsData dataClass = new ProductsData();
            List<ProductsModel> resultList = (List<ProductsModel>)dataClass.SelectAll();

            foreach (ProductsModel result in resultList)
            {
                Assert.AreEqual(result.State, ModelState.Selected);
            }
        }

        [TestMethod]
        public void IDataModelState_Changed_bySelect()
        {
            IProductsData dataClass = new ProductsData();
            List<ProductsModel> resultList = (List<ProductsModel>)dataClass.SelectAll();
            ProductsModel result0 = resultList[0];
            dataClass.Select(result0);

            Assert.AreEqual(result0.State, ModelState.Selected);
        }

        [TestMethod]
        public void IDataModelState_Changed_byInsert()
        {
            IProductsData dataClass = new ProductsData();
            ProductsModel result1 = new ProductsModel("Telefon", "Nokia",100, 300,2);
            dataClass.Insert(result1);
            Assert.AreEqual(result1.State, ModelState.Inserted);
        }

        [TestMethod]
        public void IDataModelState_Changed_byUpdate()
        {
            IProductsData dataClass = new ProductsData();
            List<ProductsModel> resultList = (List<ProductsModel>)dataClass.SelectAll();
            ProductsModel updatedRecord = resultList[0];
            updatedRecord.Price = 300;
            dataClass.Update(updatedRecord);
            Assert.AreEqual(updatedRecord.State, ModelState.Updated);
        }

        [TestMethod]
        public void IDataModelState_Changed_byDelete()
        {
            IProductsData dataClass = new ProductsData();
            List<ProductsModel> resultList = (List<ProductsModel>)dataClass.SelectAll();
            ProductsModel oldRecord = resultList[resultList.Count - 1];
            dataClass.Delete(oldRecord);
            Assert.AreEqual(oldRecord.State, ModelState.Deleted);
        }

    }
}
