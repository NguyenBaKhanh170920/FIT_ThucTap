﻿using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Repositories.CustomerRepositories
{
    public interface ICustomerRepository
    {
        Task<List<Customers>> GetCustomersAsync();
        Task<Customers> AddCustomer(Customers customer);
        Task<Customers> GetCustomerById(int id);
    }
}
