using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_command;

namespace pattern_command
{
    public class AddCustomerCommand : Command
    {
        private readonly CustomerService _customerService;

        public AddCustomerCommand(CustomerService customerService)
        {
            _customerService = customerService;
        }
        public void Execute()
        {
            _customerService.AddCustomer();
        }
    }
}