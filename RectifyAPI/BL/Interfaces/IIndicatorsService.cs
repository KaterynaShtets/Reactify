using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactifyAPI.BL.Interfaces
{
    public interface IIndicatorsService
    {
        Task<List<Indicators>> GetRecordsByProductId(int productId);


        Task<List<IndicatorsInfo>> GetIndicatorsInfoList(int productId);

        Task<AverageResponse> GetAvarageValuesForEachParameter(int productId);

        Task<Deviation> GetDeviations(int productId);
        Task<EmotionModel> GetEmotionalReaction(int productId);
    }
}
