using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System.Linq;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        
        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 4)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintainceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(float min, float max) 
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(
                //CheckProductCount(product.CategoryId), 
                CheckProductName(product.ProductName));            

            if(result == null){
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
            }

            return result;
        }

        public IDataResult<Product> GetById(int productId) {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        private IResult CheckProductCount(int categoryId){
            var lengthResult = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if(lengthResult >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategory);
            }
            
            return new SuccessResult();
        }

        private IResult CheckProductName(string name){
            
            var result = _productDal.GetAll(p => p.ProductName == name).Any();
            if(result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            
            return new SuccessResult();
        }

        private IResult CheckCategoryCount() {
            var result = _categoryService.GetAll().Data.Count;
            if(result>15)
            {
                return new ErrorResult(Messages.CategoryCount);
            }

            return new SuccessResult();
        }
    }
}