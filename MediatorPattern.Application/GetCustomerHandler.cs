using MediatorPattern.Domains;
using MediatorPattern.Repo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorPattern.Application
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerDto?>
    {
        private readonly IDomainRepo _domainRepo;

        public GetCustomerHandler(IDomainRepo domainRepo)
        {
            _domainRepo = domainRepo;
        }

        public async Task<CustomerDto?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customerDb = await _domainRepo.GetAsync<CustomerDb>(request.customerId);

            if (customerDb != null)
            {
                return new CustomerDto
                {
                    Id = customerDb.Id,
                    Name = customerDb.Name,
                    Email = customerDb.Email
                };
            }
            return null;
        }
    }
}
