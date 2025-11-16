using MediatorPattern.Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern.Application
{
    public record GetCustomerQuery(int customerId) : IRequest<CustomerDto>;
}
