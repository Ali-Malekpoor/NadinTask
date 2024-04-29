using Nadin.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin.Application.Services.Interfaces
{
    public interface IProductService
    {
        #region CRUD Methods
        List<GetProductDTO> GetAll();
        GetProductDTO GetById(long id);
        bool Delete(long id);
        bool Update(UpdateProductDTO product);
        bool Create(CreateProductDTO product);
        #endregion

        #region General Methods

        bool Duplicateproduct(string phone, string Email);

        #endregion
    }
}
