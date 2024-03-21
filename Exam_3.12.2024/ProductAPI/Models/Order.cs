using System;
using System.Collections.Generic;

namespace ProductAPI.Models
{
    public partial class Order
    {
        public string Id { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public int Amount { get; set; }
        public string Status { get; set; } = null!;
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
