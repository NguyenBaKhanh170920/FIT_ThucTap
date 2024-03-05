using BasketAPI.Applications.Entities;
using BasketAPI.Applications.Repositories;
using BasketAPI.DTOs;

namespace BasketAPI.Applications.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepositories _repositories;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public BasketService(IBasketRepositories repositories, IConfiguration configuration, HttpClient httpClient)
        {
            _repositories = repositories;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<Baskets> AddBaskets(int CustomerId, int ProductID, int Quantity)
        {
            string apiGetProductId = _configuration["HttpGetProduct"] + "/" + ProductID;
            Baskets baskets = await _repositories.GetBasketByCustomerId(CustomerId);
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            responseMessage = await _httpClient.GetAsync(apiGetProductId);
            var product = await responseMessage.Content.ReadFromJsonAsync<ProductDTO>();
            //var product = new ProductDTO();

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
                if (baskets.BasketItems.Any(x => x.ProductId == ProductID))
                {
                    //co ton tai san pham trong gio
                    for (int i = 0; i < baskets.BasketItems.Count(); i++)
                    {
                        if (baskets.BasketItems[i].ProductId == ProductID)
                        {
                            baskets.BasketItems[i].Quantity = Quantity;
                            //_dbContext.Baskets.Update(baskets);
                            //await _dbContext.SaveChangesAsync();
                            var rs = await _repositories.UpdateBasket(baskets);
                            if (rs)
                            {
                                return baskets;
                            }
                        }
                    }
                }
                else
                {
                    //Trong gio chua co san pham
                    baskets.BasketItems.Add(basketItems);
                    //_dbContext.Baskets.Update(baskets);
                    //await _dbContext.SaveChangesAsync();
                    var rs = await _repositories.UpdateBasket(baskets);
                    if (rs)
                    {
                        return baskets;
                    }
                }
            }
            else
            {
                //Chua co gio hang
                //var rs = _dbContext.Baskets.Add(newBas);
                //await _dbContext.SaveChangesAsync();
                var rs = await _repositories.AddNewBasket(newBas);
                if (rs)
                {
                    return newBas;
                }
            }
            return null;
        }

        public async Task<Baskets> GetBasketsByCustomerId(int customerId)
        {
            return await _repositories.GetBasketByCustomerId(customerId);
        }
    }
}
