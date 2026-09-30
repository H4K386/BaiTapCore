using System.Numerics;

namespace _0306241284_NguyenKhanhHuy.Models
{
    public enum OrderStatus {
        Pending = 0,    // Chờ xử lý
        Shipping = 1,   // Đang giao
        Completed = 2,  // Hoàn thành
        Cancelled = 3  // Hủy
    }
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Note {  get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public ICollection<OrderDetail> OrderDetail { get; set; } = new List<OrderDetail>();


    }
}
