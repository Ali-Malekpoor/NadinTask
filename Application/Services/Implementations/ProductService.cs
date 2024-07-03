using Nadin.Application.Services.Interfaces;
using Nadin.Domain.DTOs;
using Nadin.Domain.Entities;
using Nadin.Infrastructure.DataBaseContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly NadinDbContext _context;
        public ProductService(NadinDbContext context)
        {
            _context = context;
        }

        public bool Create(CreateProductDTO product)
        {
            var newProduct = new Product()
            {
                Name = product.Name,
                ManufactureEmail = product.ManufactureEmail,
                ManufacturePhone = product.ManufacturePhone,
                ProductDate = product.ProductDate,
                IsAvailable = product.IsAvailable,
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            
            return true;

        }

        public bool Delete(long id)
        {
            _context.Products.Remove(new Product { Id = id });
            _context.SaveChanges();

            return true;
        }

        public bool Duplicateproduct(string phone, string Email)
        {
            bool result = false;
            if (_context.Products.Any(p => p.ManufacturePhone == phone)
                || _context.Products.Any(p => p.ManufactureEmail == Email))
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }

        public List<GetProductDTO> GetAll()
        {
            var result = _context.Products.Select(p => new GetProductDTO
            {
                ManufactureEmail = p.ManufactureEmail,
                ManufacturePhone = p.ManufacturePhone,
                Name = p.Name,
                ProductDate = p.ProductDate,
                IsAvailable = p.IsAvailable,
            }).ToList();

            return result;
        }

        public GetProductDTO GetById(long id)
        {
            var find = _context.Products.SingleOrDefault(p => p.Id == id);

            var result = new GetProductDTO()
            {
                Name = find.Name,
                ProductDate = find.ProductDate,
                IsAvailable = find.IsAvailable,
                ManufactureEmail = find.ManufactureEmail,
                ManufacturePhone = find.ManufacturePhone,
            };

            return result;
        }

        public bool Update(UpdateProductDTO product)
        {
            var find = _context.Products.SingleOrDefault(p => p.Id == product.Id);

            find.Name = product.Name;
            find.IsAvailable = product.IsAvailable;
            find.ManufactureEmail = product.ManufactureEmail;
            find.ManufacturePhone = product.ManufacturePhone;

            _context.SaveChanges();

            return true;
        }
    }
}
