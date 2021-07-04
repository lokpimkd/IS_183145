using MovieTheater.Dto;
using System.Collections.Generic;

namespace MovieTheater.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(int userId, OrdersDto orderDetails);
        List<OrdersDto> GetOrderList(int userId);
    }
}
