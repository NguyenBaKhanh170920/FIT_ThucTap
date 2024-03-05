using OrderAPI.Applications.Entities;
using OrderAPI.Applications.Repositories.OrderRepositories;
using OrderAPI.DTOs;

namespace OrderAPI.Applications.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public OrderService(IOrderRepository orderRepository, IConfiguration configuration
            , HttpClient httpClient)
        {
            _orderRepository = orderRepository;
            _configuration = configuration;
            _httpClient = httpClient;
        }
        public async Task<Orders> AddOrders(OrderAddDTO orderAddDTO)
        {
            string apiGetBasket = _configuration["HttpGetBasket"] + "/" + orderAddDTO.CustomerId;
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            responseMessage = await _httpClient.GetAsync(apiGetBasket);
            var baskets = await responseMessage.Content.ReadFromJsonAsync<BasketDTO>();
            var rs = await _orderRepository.AddOrders(orderAddDTO, baskets);
            if (rs != null)
            {
                return rs;
            }
            return null;
        }

        public async Task<List<Orders>> GetOrdersByCustomerId(int customerId)
        {
            return await _orderRepository.GetOrdersByCustomerId(customerId);
        }
    }
}
