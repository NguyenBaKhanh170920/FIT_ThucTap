using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.Database;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Repositories.BasketRepositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly Bai4DbContext _dbContext;
        private readonly ILogger<BasketRepository> _logger;
        public BasketRepository(Bai4DbContext dbContext, ILogger<BasketRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Baskets> AddBasket(int CustomerId, int ProductID, int Quantity)
        {
            try
            {
                Customers customers = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == CustomerId);
                Baskets baskets = await _dbContext.Baskets.FirstOrDefaultAsync(x => x.CustomerId == CustomerId);
                var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == ProductID);
                BasketItems basketItems = new BasketItems
                {
                    ProductId = ProductID,
                    ProductName = product.Name,
                    Quantity = Quantity,
                    Status = "Ok"
                };
                Baskets newBas = new Baskets();
                newBas.CustomerId = CustomerId;
                newBas.BasketItems.Add(basketItems);
                if (baskets != null)
                {
                    await _dbContext.Entry(baskets).Collection(i => i.BasketItems).LoadAsync();
                    if (baskets.BasketItems.Any(x => x.ProductId == ProductID))
                    {
                        //co ton tai san pham trong gio
                        for (int i = 0; i < baskets.BasketItems.Count(); i++)
                        {
                            if (baskets.BasketItems[i].ProductId == ProductID)
                            {
                                baskets.BasketItems[i].Quantity = Quantity;
                                _dbContext.Baskets.Update(baskets);
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                    }
                    else
                    {
                        //Trong gio chua co san pham
                        baskets.BasketItems.Add(basketItems);
                        _dbContext.Baskets.Update(baskets);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    //Chua co gio hang
                    var rs = _dbContext.Baskets.Add(newBas);
                    await _dbContext.SaveChangesAsync();
                }
                return newBas;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Baskets> GetBasketByCustomerId(int customerId)
        {
            try
            {
                var rs = await _dbContext.Baskets.FirstOrDefaultAsync(x => x.CustomerId == customerId);
                if (rs != null)
                {
                    await _dbContext.Entry(rs).Collection(i => i.BasketItems).LoadAsync();
                }
                return rs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<BasketItems> UpdateBasketItemQuantity(int id, int productId, int quantity)
        {
            try
            {
                if (quantity >= 0)
                {
                    BasketItems basketItems = _dbContext.BasketItems.FirstOrDefault(x => x.ProductId == productId);
                    if (basketItems != null)
                    {
                        basketItems.Quantity = quantity;
                        var rs = _dbContext.Update(basketItems);
                        if (rs != null)
                        {
                            await _dbContext.SaveChangesAsync();
                            return basketItems;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
