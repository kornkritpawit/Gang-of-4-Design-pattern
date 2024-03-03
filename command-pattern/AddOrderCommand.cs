using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_command;

namespace pattern_command
{
    public class AddOrderCommand : Command
    {

        private readonly OrderService _orderService; //readonly  คือ ตัวแปรจะสามารถสร้างได้เฉพาะใน constructor เท่านั้น

        public AddOrderCommand(OrderService orderService)
        {
            _orderService = orderService;
        }

        public void Execute()
        {
            _orderService.AddOrder();
        }
    }
}