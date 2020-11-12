using DAL.Interfaces;
using ReactifyAPI.BL.Interfaces;
using ReactifyAPI.Repositories;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactifyAPI.BL.Services
{
    public class TesterUserService: ITesterUserService
    {
        private readonly TesterUserRepository _testerUserRepository;

        public TesterUserService(TesterUserRepository testerUserRepository)
        {
            _testerUserRepository = testerUserRepository;
        }
        public async Task<TesterUser> CreateTesterUser(TesterUser entity)
        {
            return await _testerUserRepository.Add(entity);
        }

        public async Task<List<TesterUser>> GetAllTesterUsers()
        {
            return await _testerUserRepository.GetAll();
        }

        public async Task<TesterUser> GetTesterUser(int id)
        {
            return await _testerUserRepository.Get(id);
        }

        public async Task<TesterUser> UpdateTesterUser(TesterUser entity)
        {
            return await _testerUserRepository.Update(entity);
        }

        public async Task<TesterUser> DeleteTesterUser(int id)
        {
            return await _testerUserRepository.Delete(id);
        }

       
        public async Task<FirstAvgIndicatorValues> GetAvgOfFirstIndicatorValues(int productId)
        {
            var firstAvgIndicatorsValue = new FirstAvgIndicatorValues();
            var users = await GetAllTesterUsers();
            var indicatorsByProductId = users.SelectMany(x=>x.Indicators.Where(x => x.Product.Id == productId && x.IndicatorsInfo.Count()>0));
            var usersCount = indicatorsByProductId.Count();
            var averageOfPulseFirstValues = 0.0;
            var averageOfTempereatureFirstValues = 0.0;
            var averageOfBloodOxygenLevelFirstValues = 0.0;
            var averageOfBloodPressureFirstValues = 0.0;
            foreach(var indicator in indicatorsByProductId)
            {
                averageOfPulseFirstValues += indicator.IndicatorsInfo.Select(x => x.Pulse).First();
                averageOfTempereatureFirstValues += indicator.IndicatorsInfo.Select(x => x.Temperature).First();
                averageOfBloodOxygenLevelFirstValues += indicator.IndicatorsInfo.Select(x => x.BloodOxygenLevel).First();
                averageOfBloodPressureFirstValues += indicator.IndicatorsInfo.Select(x => x.BloodPressure).First();
            }

            firstAvgIndicatorsValue.Pulse = averageOfPulseFirstValues / usersCount;
            firstAvgIndicatorsValue.Temperature = averageOfTempereatureFirstValues / usersCount;
            firstAvgIndicatorsValue.BloodOxygenLevel = averageOfBloodOxygenLevelFirstValues / usersCount;
            firstAvgIndicatorsValue.BloodPressure = averageOfBloodPressureFirstValues / usersCount;

            return firstAvgIndicatorsValue;
        }
    }
}
