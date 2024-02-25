using AutoMapper;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.Products;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.Helpers.Images;
using EcommerceProject.ENTITIES.Dtos.Images;
using EcommerceProject.ENTITIES.Dtos.Categories;
using EcommerceProject.ENTITIES.Dtos.ProductColors;
using EcommerceProject.ENTITIES.Dtos.ProductSizes;
using System.Drawing;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IImageHelper _imageHelper;
        private readonly ClaimsPrincipal _user;
        private readonly IProductColorManager _colorManager;
        private readonly IImageManager _imageManager;
        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper, IProductColorManager colorManager, IImageManager imageManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _imageHelper = imageHelper;
            _user = _httpContextAccessor.HttpContext.User;
            _colorManager = colorManager;
            _imageManager = imageManager;
        }

        public async Task<ProductDetailDto> GetByIdProductDetail(int id)
        {
            var product = await _unitOfWork.GetRepository<Product>().GetAsync(x => x.ID == id, x => x.Category, x => x.CustomerType, x => x.ImageDetails);

            var productSizeList = _unitOfWork.GetRepository<Product>().Where(x => x.ProductCode == product.ProductCode && x.ProductColorID == product.ProductColorID).Select(x => x.ProductSize).ToList();

            var productSizeByProductIdList = _unitOfWork.GetRepository<Product>().Where(x => x.ProductCode == product.ProductCode && x.ProductColorID == product.ProductColorID).ToList();

            var productColorList = _unitOfWork.GetRepository<Product>().Where(x => x.ProductCode == product.ProductCode && x.ProductColorID != product.ProductColorID).Select(x => x.ProductColor).ToList();
            var productColorDistinctList = productColorList.Select(x => x.ID).Distinct().ToList();
            var productSizeListMap = _mapper.Map<List<ProductSizeDto>>(productSizeList);
            List<ProductSizeByProductIdDto> productSizeByProductIdDto = new List<ProductSizeByProductIdDto>();
            foreach (var productSize in productSizeListMap)
            {
                foreach (var productBySize in productSizeByProductIdList)
                {
                    if (productBySize.ProductSizeID == productSize.ID)
                    {
                        ProductSizeByProductIdDto productSizeByProductId = new ProductSizeByProductIdDto
                        {
                            ID = productSize.ID,
                            ProductId = productBySize.ID,
                            Size = productSize.Size
                        };
                        productSizeByProductIdDto.Add(productSizeByProductId);
                    }
                }
            }

            List<ProductColorByProductIdDto> productColorByProductIdDto = new List<ProductColorByProductIdDto>();
            foreach (var colorId in productColorDistinctList)
            {
                var productResult = _unitOfWork.GetRepository<Product>().Where(x => x.ProductCode == product.ProductCode && x.ProductColorID == colorId).First();

                var colorResult = _unitOfWork.GetRepository<ProductColor>().Where(x => x.ID == colorId).First();

                var productColorNewName = _colorManager.ReplaceColorName(colorResult.Color);

                ProductColorByProductIdDto productColorByProductId = new ProductColorByProductIdDto
                {
                    ID = colorResult.ID,
                    Color = colorResult.Color,
                    ColorReplaceName = productColorNewName,
                    ProductId = productResult.ID
                };

                productColorByProductIdDto.Add(productColorByProductId);
            }

            var imageDetails = _mapper.Map<List<ImageDetailDto>>(product.ImageDetails);
            var images = _imageManager.GetImageByImageDetailsAndSortImage(imageDetails);

            ProductDetailDto productDetailDto = new ProductDetailDto
            {
                ID = product.ID,
                ProductName = product.ProductName,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                SalePrice = product.SalePrice,
                ProductColorID = product.ProductColorID,
                ProductSizeID = product.ProductSizeID,
                UnitsInStock = product.UnitsInStock,
                CustomerTypeName = product.CustomerType.CustomerTypeName,
                CategoryName = product.Category.CategoryName,
                ProductSizes = productSizeByProductIdDto,
                ProductColors = productColorByProductIdDto,
                Images = images
            };

            return productDetailDto;
        }
        public async Task<List<ProductListByCustomerTypeIdDto>> FilterProduct(FilterProductDto filterProductDto)
        {
            var imageDetails = await _unitOfWork.GetRepository<ImageDetail>().GetAllAsync(null, x => x.Product, x => x.Image);

            List<ProductListByCustomerTypeIdDto> productListByCustomerTypeIdDto = new List<ProductListByCustomerTypeIdDto>();
            List<ProductListByCustomerTypeIdDto> productListOutsideDtos = new List<ProductListByCustomerTypeIdDto>();
            List<ProductListByCustomerTypeIdDto> productListFilterPriceDtos = new List<ProductListByCustomerTypeIdDto>();
            List<ProductListByCustomerTypeIdDto> productListFilterColorDtos = new List<ProductListByCustomerTypeIdDto>();
            List<ProductListByCustomerTypeIdDto> productListFilterSizeDtos = new List<ProductListByCustomerTypeIdDto>();

            var colorID = 0;
            var productCode = 0;
            var outsideProductID = 0;

            foreach (var image in imageDetails)
            {
                if (image.Product.CustomerTypeID == filterProductDto.CustomerTypeID)
                {
                    if (image.Product.ProductCode != productCode || image.Product.ProductColorID != colorID)
                    {
                        if (filterProductDto.SelectedCategories != null && filterProductDto.SelectedCategories.Count() > 0)
                        {
                            foreach (var category in filterProductDto.SelectedCategories)
                            {
                                if (category == image.Product.CategoryID)
                                {
                                    colorID = image.Product.ProductColorID;
                                    productCode = image.Product.ProductCode;

                                    ProductListByCustomerTypeIdDto productListWithCategoryDto = new ProductListByCustomerTypeIdDto();
                                    productListWithCategoryDto.ID = image.Product.ID;
                                    productListWithCategoryDto.ProductName = image.Product.ProductName;
                                    productListWithCategoryDto.SalePrice = image.Product.SalePrice;
                                    productListWithCategoryDto.ImageFileName = image.Image.FileName;
                                    productListWithCategoryDto.ProductColorID = image.Product.ProductColorID;
                                    productListWithCategoryDto.ProductSizeID = image.Product.ProductSizeID;
                                    productListWithCategoryDto.ProductCode = image.Product.ProductCode;
                                    productListWithCategoryDto.Description = image.Product.Description;
                                    productListWithCategoryDto.UnitPrice = image.Product.UnitPrice;

                                    productListByCustomerTypeIdDto.Add(productListWithCategoryDto);
                                }
                            }
                        }
                        else
                        {
                            colorID = image.Product.ProductColorID;
                            productCode = image.Product.ProductCode;

                            ProductListByCustomerTypeIdDto productListDto = new ProductListByCustomerTypeIdDto();
                            productListDto.ID = image.Product.ID;
                            productListDto.ProductName = image.Product.ProductName;
                            productListDto.SalePrice = image.Product.SalePrice;
                            productListDto.ImageFileName = image.Image.FileName;
                            productListDto.ProductColorID = image.Product.ProductColorID;
                            productListDto.ProductSizeID = image.Product.ProductSizeID;
                            productListDto.ProductCode = image.Product.ProductCode;
                            productListDto.Description = image.Product.Description;
                            productListDto.UnitPrice = image.Product.UnitPrice;

                            productListByCustomerTypeIdDto.Add(productListDto);
                        }
                    }
                    else
                    {
                        if (image.Product.ID != outsideProductID)
                        {
                            outsideProductID = image.Product.ID;

                            ProductListByCustomerTypeIdDto productListOutsideDto = new ProductListByCustomerTypeIdDto();
                            productListOutsideDto.ID = image.Product.ID;
                            productListOutsideDto.ProductName = image.Product.ProductName;
                            productListOutsideDto.SalePrice = image.Product.SalePrice;
                            productListOutsideDto.ImageFileName = image.Image.FileName;
                            productListOutsideDto.ProductColorID = image.Product.ProductColorID;
                            productListOutsideDto.ProductSizeID = image.Product.ProductSizeID;
                            productListOutsideDto.ProductCode = image.Product.ProductCode;
                            productListOutsideDto.Description = image.Product.Description;
                            productListOutsideDto.UnitPrice = image.Product.UnitPrice;

                            productListOutsideDtos.Add(productListOutsideDto);
                        }
                    }
                }
            }

            if (filterProductDto.SelectedProductSizes != null)
            {
                var colorIDResult = 0;
                var productCodeResult = 0;

                foreach (var item in productListOutsideDtos)
                {
                    if (item.ProductCode != productCodeResult || item.ProductColorID != colorIDResult)
                    {
                        foreach (var productSize in filterProductDto.SelectedProductSizes)
                        {
                            if (productSize == item.ProductSizeID)
                            {
                                colorIDResult = item.ProductColorID;
                                productCodeResult = item.ProductCode;

                                ProductListByCustomerTypeIdDto productListDto = new ProductListByCustomerTypeIdDto();
                                productListDto.ID = item.ID;
                                productListDto.ProductName = item.ProductName;
                                productListDto.SalePrice = item.SalePrice;
                                productListDto.ImageFileName = item.ImageFileName;
                                productListDto.ProductColorID = item.ProductColorID;
                                productListDto.ProductSizeID = item.ProductSizeID;
                                productListDto.ProductCode = item.ProductCode;
                                productListDto.Description = item.Description;
                                productListDto.UnitPrice = item.UnitPrice;

                                productListFilterSizeDtos.Add(productListDto);
                            }
                        }
                    }
                }
                productListByCustomerTypeIdDto = productListFilterSizeDtos;
            }

            var priceValueSplit = filterProductDto.PriceFilter.Split("₺");
            var maxPrice = priceValueSplit[2];
            var minSplit = priceValueSplit[1].Split(" ");
            var minPrice = minSplit[0];

            var minPriceResult = Convert.ToInt32(minPrice);
            var maxPriceResult = Convert.ToInt32(maxPrice);

            if (minPriceResult != 0 || maxPriceResult != 5000)
            {
                foreach (var item in productListByCustomerTypeIdDto)
                {
                    if (item.SalePrice > minPriceResult && item.SalePrice < maxPriceResult)
                    {
                        ProductListByCustomerTypeIdDto productListDto = new ProductListByCustomerTypeIdDto();
                        productListDto.ID = item.ID;
                        productListDto.ProductName = item.ProductName;
                        productListDto.SalePrice = item.SalePrice;
                        productListDto.ImageFileName = item.ImageFileName;
                        productListDto.ProductColorID = item.ProductColorID;
                        productListDto.ProductCode = item.ProductCode;
                        productListDto.Description = item.Description;
                        productListDto.UnitPrice = item.UnitPrice;

                        productListFilterPriceDtos.Add(productListDto);
                    }
                }
                productListByCustomerTypeIdDto = productListFilterPriceDtos;
            }


            if (filterProductDto.SelectedProductColors != null)
            {
                foreach (var item in productListByCustomerTypeIdDto)
                {
                    foreach (var productColor in filterProductDto.SelectedProductColors)
                    {
                        if (productColor == item.ProductColorID)
                        {
                            ProductListByCustomerTypeIdDto productListDto = new ProductListByCustomerTypeIdDto();
                            productListDto.ID = item.ID;
                            productListDto.ProductName = item.ProductName;
                            productListDto.SalePrice = item.SalePrice;
                            productListDto.ImageFileName = item.ImageFileName;
                            productListDto.ProductColorID = item.ProductColorID;
                            productListDto.ProductCode = item.ProductCode;
                            productListDto.Description = item.Description;
                            productListDto.UnitPrice = item.UnitPrice;

                            productListFilterColorDtos.Add(productListDto);
                        }
                    }
                }
                productListByCustomerTypeIdDto = productListFilterColorDtos;
            }

            return productListByCustomerTypeIdDto;
        }

        public async Task<ProductListDto> GetProductsAllDetail(int id)
        {
            var products = await _unitOfWork.GetRepository<Product>().GetAllAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted && x.CustomerTypeID == id, x => x.Category, x => x.ProductColor, x => x.ProductSize);

            List<Category> categories = new List<Category>();
            List<ProductColor> productColor = new List<ProductColor>();
            List<ProductSize> productSize = new List<ProductSize>();

            foreach (var item in products)
            {
                categories.Add(item.Category);
                productColor.Add(item.ProductColor);
                productSize.Add(item.ProductSize);
            }
            var newCategoryList = categories.Distinct().ToList();
            var categoryMap = _mapper.Map<List<CategoryDto>>(newCategoryList);

            var newProductColorList = productColor.Distinct().ToList();
            var productColorMap = _mapper.Map<List<ProductColorDto>>(newProductColorList);

            var newProductSizeList = productSize.Distinct().ToList();
            var productSizeMap = _mapper.Map<List<ProductSizeDto>>(newProductSizeList);

            foreach (var color in productColorMap)
            {
                var productColorNewName = _colorManager.ReplaceColorName(color.Color);
                color.ColorReplaceName = productColorNewName;
            }

            var menlist = await GetAllProductList(null,id);

            ProductListDto productListDto = new ProductListDto
            {
                Products = menlist,
                Categories = categoryMap,
                ProductColors = productColorMap,
                ProductSizes = productSizeMap
            };

			productListDto.CustomerTypeID = id;
            return productListDto;
        }

        public List<CategoryDto> GetCategoriesByCustomerTypeId(int customerTypeId)
        {
            var result = _unitOfWork.GetRepository<Product>().Where(x => x.CustomerTypeID == customerTypeId).Select(x => x.Category).Distinct().ToList();
            var map = _mapper.Map<List<CategoryDto>>(result);
            return map;
        }

        public async Task<List<ProductListByCustomerTypeIdDto>> GetAllProductList(int[]? categoryID,int CustomerTypeId)
        {
            var imageDetails = await _unitOfWork.GetRepository<ImageDetail>().GetAllAsync(null, x => x.Product, x => x.Image);

            List<ProductListByCustomerTypeIdDto> productListDto = new List<ProductListByCustomerTypeIdDto>();
            var colorID = 0;
            var productCode = 0;
            foreach (var image in imageDetails)
            {
                if (image.Product.CustomerTypeID == CustomerTypeId)
                {
                    if (image.Product.ProductCode != productCode || image.Product.ProductColorID != colorID)
                    {
                        if (categoryID != null && categoryID.Count() > 0)
                        {
                            foreach (var category in categoryID)
                            {
                                if (category == image.Product.CategoryID)
                                {
                                    colorID = image.Product.ProductColorID;
                                    productCode = image.Product.ProductCode;

                                    ProductListByCustomerTypeIdDto productListWithCategoryDto = new ProductListByCustomerTypeIdDto();
                                    productListWithCategoryDto.ID = image.Product.ID;
                                    productListWithCategoryDto.ProductName = image.Product.ProductName;
                                    productListWithCategoryDto.SalePrice = image.Product.SalePrice;
                                    productListWithCategoryDto.ImageFileName = image.Image.FileName;
                                    productListWithCategoryDto.UnitPrice = image.Product.UnitPrice;
                                    productListWithCategoryDto.Description = image.Product.Description;

                                    productListDto.Add(productListWithCategoryDto);
                                }
                            }
                        }
                        else
                        {
                            colorID = image.Product.ProductColorID;
                            productCode = image.Product.ProductCode;

                            ProductListByCustomerTypeIdDto productDto = new ProductListByCustomerTypeIdDto();
                            productDto.ID = image.Product.ID;
                            productDto.ProductName = image.Product.ProductName;
                            productDto.SalePrice = image.Product.SalePrice;
                            productDto.ImageFileName = image.Image.FileName;
                            productDto.UnitPrice = image.Product.UnitPrice;
                            productDto.Description = image.Product.Description;

                            productListDto.Add(productDto);
                        }
                    }
                }
            }

            return productListDto;
        }

        public async Task<List<ProductDto>> GetAllProductsWithCategoryNonDeletedAsync()
        {
            var products = await _unitOfWork.GetRepository<Product>().GetAllAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted, x => x.Category);
            var map = _mapper.Map<List<ProductDto>>(products);
            return map;
        }

        public async Task<ProductDto> GetProductWithCategoryNonDeletedAsync(int productID)
        {
            var product = await _unitOfWork.GetRepository<Product>().GetAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted && x.ID == productID, x => x.Category, i => i.ImageDetails);
            var map = _mapper.Map<ProductDto>(product);
            return map;
        }

        public async Task<string> UpdateProductAsync(ProductUpdateDto productUpdateDto)
        {
            var product = await _unitOfWork.GetRepository<Product>().GetAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted && x.ID == productUpdateDto.ID, x => x.Category);
            var user = _user.GetLoggedInUserEmail();
            var productName = product.ProductName;
            product.ModifiedDate = DateTime.Now;
            product.ModifiedBy = user;

            _mapper.Map<ProductUpdateDto, Product>(productUpdateDto, product);

            await _unitOfWork.GetRepository<Product>().Update(product);
            await _unitOfWork.SaveAsync();

            return productName;
        }

        public async Task<string> SafeDeleteProductAsync(int productID)
        {
            var product = await _unitOfWork.GetRepository<Product>().FindAsync(productID);
            var user = _user.GetLoggedInUserEmail();
            var productName = product.ProductName;
            product.DeletedBy = user;
            product.DeletedDate = DateTime.Now;
            _unitOfWork.GetRepository<Product>().Delete(product);
            await _unitOfWork.SaveAsync();

            return productName;
        }

        public async Task<List<Product>> ProductsWithCode(int productID)
        {
            var product = await _unitOfWork.GetRepository<Product>().FindAsync(productID);
            var productsWithCode = _unitOfWork.GetRepository<Product>().Where(x => x.ProductCode == product.ProductCode).ToList();
            return productsWithCode;
        }

        public void Add(Product item)
        {
            _unitOfWork.GetRepository<Product>().Add(item);
            _unitOfWork.Save();
        }

        public async Task AddAsync(Product item)
        {
            await _unitOfWork.GetRepository<Product>().AddAsync(item);
            await _unitOfWork.SaveAsync();
        }

        public void AddRange(List<Product> list)
        {
            _unitOfWork.GetRepository<Product>().AddRange(list);
            _unitOfWork.Save();
        }

        public async Task AddRangeAsync(List<Product> list)
        {
            await _unitOfWork.GetRepository<Product>().AddRangeAsync(list);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> exp)
        {
            return await _unitOfWork.GetRepository<Product>().AnyAsync(exp);
        }

        public void Delete(Product item)
        {
            _unitOfWork.GetRepository<Product>().Delete(item);
            _unitOfWork.Save();
        }

        public void DeleteRange(List<Product> list)
        {
            _unitOfWork.GetRepository<Product>().DeleteRange(list);
            _unitOfWork.Save();
        }

        public void Destroy(Product item)
        {
            _unitOfWork.GetRepository<Product>().Destroy(item);
            _unitOfWork.Save();
        }

        public void DestroyRange(List<Product> list)
        {
            _unitOfWork.GetRepository<Product>().DestroyRange(list);
            _unitOfWork.Save();
        }

        public async Task<Product> FindAsync(int id)
        {
            return await _unitOfWork.GetRepository<Product>().FindAsync(id);
        }

        public async Task<Product> FirstOrDefaultAsync(Expression<Func<Product, bool>> exp)
        {
            return await _unitOfWork.GetRepository<Product>().FirstOrDefaultAsync(exp);
        }

        public IQueryable<Product> GetActives()
        {
            return _unitOfWork.GetRepository<Product>().GetActives();
        }

        public IQueryable<ProductDto> GetAll()
        {
            var products = _unitOfWork.GetRepository<Product>().GetAll().ProjectTo<ProductDto>(_mapper.ConfigurationProvider);
            return products;
        }

        public IQueryable<Product> GetModifieds()
        {
            return _unitOfWork.GetRepository<Product>().GetModifieds();
        }

        public IQueryable<Product> GetPassives()
        {
            return _unitOfWork.GetRepository<Product>().GetPassives();
        }

        public IQueryable<X> Select<X>(Expression<Func<Product, X>> exp)
        {
            return _unitOfWork.GetRepository<Product>().Select(exp);
        }

        public async Task Update(Product item)
        {
            await _unitOfWork.GetRepository<Product>().Update(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateRange(List<Product> list)
        {
            await _unitOfWork.GetRepository<Product>().UpdateRange(list);
            await _unitOfWork.SaveAsync();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> exp)
        {
            return _unitOfWork.GetRepository<Product>().Where(exp);
        }

        public async Task CreateProductAsync(ProductAddDto productAddDto)
        {
            var user = _user.GetLoggedInUserEmail();

            var product = new Product();
            _mapper.Map<ProductAddDto, Product>(productAddDto, product);
            product.CreatedBy = user;

            await _unitOfWork.GetRepository<Product>().AddAsync(product);

            await _unitOfWork.SaveAsync();
        }

        public async Task ProductImageUpload(ImagesOperationsDto imagesOperationsDto)
        {
            var user = _user.GetLoggedInUserEmail();

            var imageUpload = await _imageHelper.Upload(imagesOperationsDto.ProductName, imagesOperationsDto.Image);
            Image image = new(imageUpload.FullName, imagesOperationsDto.Image.ContentType, user);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);
            var product = await _unitOfWork.GetRepository<Product>().GetAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted && x.ID == imagesOperationsDto.ID);
            var resultProduct = _unitOfWork.GetRepository<Product>().Where(x => x.ProductCode == product.ProductCode && x.ProductColorID == product.ProductColorID).FirstOrDefault();
            var resultProductList = _unitOfWork.GetRepository<Product>().Where(x => x.ProductCode == product.ProductCode && x.ProductColorID == product.ProductColorID).ToList();

            if (resultProduct != null)
            {
                if (resultProduct.ID != product.ID)
                {
                    product = resultProduct;
                }
            }

            var sortImageValue = _unitOfWork.GetRepository<ImageDetail>().Where(x => x.ProductID == product.ID).OrderByDescending(x => x.SortImage).FirstOrDefault();
            var sortImageMaxValue = 0;

            if (sortImageValue != null)
            {
                sortImageMaxValue = sortImageValue.SortImage;
            }

            ImageDetail imageDetail = new ImageDetail
            {
                Image = image,
                Product = product,
                CreatedBy = user,
                SortImage = sortImageMaxValue + 1
            };

            await _unitOfWork.GetRepository<ImageDetail>().AddAsync(imageDetail);
            await _unitOfWork.SaveAsync();

            if (resultProductList.Count > 1)
            {
                foreach (var item in resultProductList)
                {
                    if (item.ID != product.ID)
                    {
                        ImageDetail imageDetailAffected = new ImageDetail
                        {
                            Image = image,
                            Product = item,
                            CreatedBy = user,
                            SortImage = sortImageMaxValue + 1
                        };
                        await _unitOfWork.GetRepository<ImageDetail>().AddAsync(imageDetailAffected);
                        await _unitOfWork.SaveAsync();
                    }
                }
            }
        }

        public async Task ProductImageUpdate(ImagesOperationsDto imagesOperationsDto)
        {
            var user = _user.GetLoggedInUserEmail();
            var product = await _unitOfWork.GetRepository<Product>().GetAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted && x.ID == imagesOperationsDto.ID);
            var resultProduct = _unitOfWork.GetRepository<Product>().Where(x => x.ProductCode == product.ProductCode && x.ProductColorID == product.ProductColorID).FirstOrDefault();

            if (resultProduct != null)
            {
                if (resultProduct.ID != product.ID)
                {
                    product = resultProduct;
                }
            }

            var selectImage = await _unitOfWork.GetRepository<Image>().GetAsync(x => x.ID == imagesOperationsDto.SelectedImageID);
            var affectedImageDetail = _unitOfWork.GetRepository<ImageDetail>().Where(x => x.ImageID == selectImage.ID).ToList();

            if (imagesOperationsDto.Image != null)
            {
                _imageHelper.Delete(selectImage.FileName);
                var imageDetail = _unitOfWork.GetRepository<ImageDetail>().Where(x => x.ProductID == product.ID).Where(i => i.ImageID == selectImage.ID).First();
                _unitOfWork.GetRepository<Image>().Destroy(selectImage);
                _unitOfWork.GetRepository<ImageDetail>().Destroy(imageDetail);

                var imageUpload = await _imageHelper.Upload(imagesOperationsDto.ProductName, imagesOperationsDto.Image);
                Image image = new(imageUpload.FullName, imagesOperationsDto.Image.ContentType, user);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);
                await _unitOfWork.SaveAsync();

                ImageDetail newImageDetail = new ImageDetail
                {
                    Image = image,
                    Product = product,
                    CreatedBy = user,
                    SortImage = imageDetail.SortImage
                };

                await _unitOfWork.GetRepository<ImageDetail>().AddAsync(newImageDetail);
                await _unitOfWork.SaveAsync();

                foreach (var item in affectedImageDetail)
                {
                    if (item.ProductID != product.ID)
                    {
                        ImageDetail imageDetailAffected = new ImageDetail
                        {
                            Image = image,
                            ProductID = item.ProductID,
                            CreatedBy = user,
                            SortImage = item.SortImage
                        };
                        await _unitOfWork.GetRepository<ImageDetail>().AddAsync(imageDetailAffected);
                        await _unitOfWork.SaveAsync();
                    }
                }
            }
        }

        public async Task<List<ProductDto>> GetAllProductsWithCategoryDeletedAsync()
        {
            var products = await _unitOfWork.GetRepository<Product>().GetAllAsync(x => x.Status == ENTITIES.Enums.DataStatus.Deleted, x => x.Category);
            var map = _mapper.Map<List<ProductDto>>(products);
            return map;
        }

        public async Task<string> UndoDeleteProductAsync(int productID)
        {
            var product = await _unitOfWork.GetRepository<Product>().FindAsync(productID);
            var user = _user.GetLoggedInUserEmail();

            product.DeletedBy = null;
            product.DeletedDate = null;
            product.ModifiedBy = user;

            _unitOfWork.GetRepository<Product>().Update(product);
            await _unitOfWork.SaveAsync();

            return product.ProductName;
        }
    }
}
