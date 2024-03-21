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

        public async Task<UpsertBasket> AddBaskets(int CustomerId, int ProductID, int Quantity)
        {
            string apiGetProductId = _configuration["HttpGetProduct"] + "/" + ProductID;
            Baskets baskets = await _repositories.GetBasketByCustomerId(CustomerId);
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            responseMessage = await _httpClient.GetAsync(apiGetProductId);
            var product = await responseMessage.Content.ReadFromJsonAsync<ProductDTO>();
            UpsertBasket upsertBasket = new UpsertBasket();
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
            //kiem tra so luong
            //neu so luong =0 thi xoa khoi gio  
            if (baskets != null)
            {
                if (baskets.BasketItems.Any(x => x.ProductId == ProductID))
                {
                    //co ton tai san pham trong gio
                    for (int i = 0; i < baskets.BasketItems.Count(); i++)
                    {
                        if (baskets.BasketItems[i].ProductId == ProductID)
                        {
                            baskets.BasketItems[i].Quantity = baskets.BasketItems[i].Quantity + Quantity;
                            if (baskets.BasketItems[i].Quantity > product.AvailableQuantity)
                            {
                                upsertBasket.Data = null;
                                upsertBasket.Message = "Vuot qua so luong hang hoa";
                                return upsertBasket;
                            }
                            var rs = await _repositories.UpdateBasket(baskets);
                            if (rs)
                            {
                                if (baskets.BasketItems[i].Quantity == 0)
                                {
                                    //xoa san pham khoi gia hang
                                    var rs2 = await _repositories.DeleteProductFromBasket(ProductID, CustomerId);
                                    //neu ko co san pham trong gio, xoa gio
                                    if (baskets.BasketItems.Count == 0)
                                    {
                                        await _repositories.DeleteBasket(CustomerId);
                                    }
                                    if (!rs2)
                                    {
                                        upsertBasket.Data = null;
                                        upsertBasket.Message = "Loi xoa san pham khoi gio hang";
                                        return upsertBasket;
                                    }

                                }
                                upsertBasket.Data = baskets;
                                upsertBasket.Message = "Them vao gio hang thanh cong";
                                return upsertBasket;

                            }
                        }
                    }
                }
                else
                {
                    //Trong gio chua co san pham
                    if (Quantity < 0 || Quantity > product.AvailableQuantity)
                    {
                        upsertBasket.Data = null;
                        upsertBasket.Message = "Sai so luong";
                        return upsertBasket;
                    }
                    baskets.BasketItems.Add(basketItems);

                    var rs = await _repositories.UpdateBasket(baskets);
                    if (rs)
                    {
                        upsertBasket.Data = baskets;
                        upsertBasket.Message = "Them vao gio hang thanh cong";
                        return upsertBasket;
                    }
                }
            }
            else
            {
                if (Quantity < 0 || Quantity > product.AvailableQuantity)
                {
                    upsertBasket.Data = null;
                    upsertBasket.Message = "Sai so luong";
                    return upsertBasket;
                }
                //Chua co gio hang
                var rs = await _repositories.AddNewBasket(newBas);
                if (rs)
                {
                    upsertBasket.Data = newBas;
                    upsertBasket.Message = "Them vao gio hang thanh cong";
                    return upsertBasket;
                }
            }
            return null;
        }

        public async Task<bool> DeleteBasket(int customerId)
        {
            return await _repositories.DeleteBasket(customerId);
        }

        public async Task<Baskets> GetBasketsByCustomerId(int customerId)
        {
            return await _repositories.GetBasketByCustomerId(customerId);
        }
    }
}
