using System;
using System.Collections.Generic;
using System.Text;

using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

ProductManager productManager = new ProductManager(new EFProductDal(), new CategoryManager(new 
EFCategoryDal()));
IDataResult<List<ProductDetailDto>> result = productManager.GetProductDetails();
if(result.Success){
foreach (var product in result.Data)
{
    Console.WriteLine(product.ProductName + " - " + product.CategoryName);
}
}else{
    Console.WriteLine(result.Message);
}
