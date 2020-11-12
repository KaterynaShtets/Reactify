using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactifyAPI.BL.Interfaces
{
    public interface ITesterUserService
    {
        Task<TesterUser> CreateTesterUser(TesterUser entity);


        Task<List<TesterUser>> GetAllTesterUsers();


        Task<TesterUser> GetTesterUser(int id);


        Task<TesterUser> UpdateTesterUser(TesterUser entity);


        Task<TesterUser> DeleteTesterUser(int id);

        //все записи физических показателей определенного продукта
        Task<FirstAvgIndicatorValues> GetAvgOfFirstIndicatorValues(int productId);

    }
}
