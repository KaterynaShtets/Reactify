using ReactifyAPI.BL.Interfaces;
using ReactifyAPI.Repositories;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactifyAPI.BL.Services
{
    public class IndicatorsService: IIndicatorsService
    {
        private readonly IndicatorsRepository _indicatorsRepository;
        private readonly ITesterUserService _testerUserService;

        public IndicatorsService(IndicatorsRepository indicatorsRepository, ITesterUserService testerUserService)
        {
            _indicatorsRepository = indicatorsRepository;
            _testerUserService = testerUserService;
        }

        // получаем все записи по тестированию определенного продукта
        public async Task<List<Indicators>> GetRecordsByProductId(int productId)
        {
            var indicators = await _indicatorsRepository.GetAll();
            var cc = indicators.ToList();
            var f = cc.First().IndicatorsInfo;

            var res = indicators.Where(x => x.Product.Id == productId).ToList();
            return res;
        }

        //все записи физических показателей определенного продукта
        public async Task<List<IndicatorsInfo>> GetIndicatorsInfoList(int productId)
        {
            var indicators = await GetRecordsByProductId(productId);

            var indicatorInfo = indicators.SelectMany(x => x.IndicatorsInfo).ToList();

            return indicatorInfo;
        }


        // средние значения всех физическх показателей определенного продукта
        public async Task<AverageResponse> GetAvarageValuesForEachParameter(int productId)
        {
            var indicatorsInfos = await GetIndicatorsInfoList(productId);

            var BpAvg = indicatorsInfos.Select(x => x.BloodPressure).Average();
            var BolAvg = indicatorsInfos.Select(x => x.BloodOxygenLevel).Average();
            var TemperatureAvg = indicatorsInfos.Select(x => x.Temperature).Average();
            var PulseAvg = indicatorsInfos.Select(x => x.Pulse).Average();

            var response = new AverageResponse();
            response.BloodPressure = BpAvg;
            response.BloodOxygenLevel = BolAvg;
            response.Pulse = PulseAvg;
            response.Temperature = TemperatureAvg;

            return response;
        }

        //Отклонение среднего значения от стартового среднего для прослеживания дианмики
        public async Task<Deviation> GetDeviations(int productId)
        {
            var firstAvgValues = await _testerUserService.GetAvgOfFirstIndicatorValues(productId);

            var averageValues = await GetAvarageValuesForEachParameter(productId);

            var response = new Deviation();
            response.BloodPressure = averageValues.BloodPressure - firstAvgValues.BloodPressure;
            response.BloodOxygenLevel = averageValues.BloodOxygenLevel - firstAvgValues.BloodOxygenLevel;
            response.Pulse = averageValues.Pulse - firstAvgValues.Pulse;
            response.Temperature = averageValues.Temperature - firstAvgValues.Temperature;

            return response;

        }

        //Процентный расчет эмоционального состояния человека
        public async Task<EmotionModel> GetEmotionalReaction(int productId)
        {
            //получаем отклонения от начального значения
            var deviations = await GetDeviations(productId);
            var emotionModel = new EmotionModel();

            // если пульс меньше нула берем промежутки в 10 единиц. При уменьшении на 10  счастье -5, расслабление +20
            if (deviations.Pulse < 0)
            {
                if (deviations.Pulse >= -10)
                {
                    emotionModel.Happy += 20;
                    emotionModel.Relaxed += 10;
                }
                else if (deviations.Pulse >= -20)
                {
                    emotionModel.Happy += 15;
                    emotionModel.Relaxed += 30;
                }
                else if (deviations.Pulse >= -30)
                {
                    emotionModel.Happy += 10;
                    emotionModel.Relaxed += 50;
                }
                else if (deviations.Pulse >= -40)
                {
                    emotionModel.Happy += 5;
                    emotionModel.Relaxed += 60;
                }
            }
            // если пульс больше 0 берем промежутки по 10 единиц. При увеличении на 10  счастье -5, стресс +10
            if (deviations.Pulse > 0)
            {
                if (deviations.Pulse >= 10)
                {
                    emotionModel.Happy += 20;
                    emotionModel.Strassed += 10;
                }
                else if (deviations.Pulse >= 20)
                {
                    emotionModel.Happy += 15;
                    emotionModel.Strassed += 20;
                }
                else if (deviations.Pulse >= 30)
                {
                    emotionModel.Happy += 10;
                    emotionModel.Strassed += 30;
                }
                else if (deviations.Pulse >= 40)
                {
                    emotionModel.Happy += 5;
                    emotionModel.Strassed += 40;
                }
            }
            // если температура больше 0, при увеличении на 1 , злость и стресс + 10
            if (deviations.Temperature > 0)
            {
                if (deviations.Temperature <= 1)
                {
                    emotionModel.Angry += 10;
                    emotionModel.Strassed += 10;
                }
                else if (deviations.Temperature <= 2)
                {
                    emotionModel.Angry += 20;
                    emotionModel.Strassed += 20;
                }
                else if (deviations.Temperature <= 3)
                {
                    emotionModel.Angry += 30;
                    emotionModel.Strassed += 30;
                }
                else if (deviations.Temperature <= 4)
                {
                    emotionModel.Angry += 40;
                    emotionModel.Strassed += 40;
                }
            }
            // если тепература <0, каждый 1 градус понжения +10 к расслаблению
            if (deviations.Temperature < 0)
            {

                if (deviations.Temperature >= -1)
                {
                    emotionModel.Relaxed += 10;
                }
                else if (deviations.Temperature >= -2)
                {
                    emotionModel.Relaxed += 20;
                }
                else if (deviations.Temperature >= -3)
                {
                    emotionModel.Relaxed += 30;
                }
                else if (deviations.Temperature >= -4)
                {
                    emotionModel.Relaxed += 40;
                }
            }

            if (deviations.BloodPressure < 0)
            {
                if (deviations.BloodPressure >= -10)
                {
                    emotionModel.Relaxed += 10;
                    emotionModel.Happy += 30;
                }
                else if (deviations.BloodPressure >= -20)
                {
                    emotionModel.Relaxed += 20;
                    emotionModel.Happy += 25;
                }
                else if (deviations.BloodPressure >= -30)
                {
                    emotionModel.Relaxed += 30;
                    emotionModel.Happy += 20;
                }
                else if (deviations.BloodPressure >= -40)
                {
                    emotionModel.Relaxed += 40;
                    emotionModel.Happy += 15;
                }
                else if (deviations.BloodPressure >= -50)
                {
                    emotionModel.Relaxed += 50;
                    emotionModel.Happy += 10;
                }
            }
            if (deviations.BloodPressure > 0)
            {
                if (deviations.BloodPressure < 10)
                {
                    emotionModel.Strassed += 15;
                    emotionModel.Happy += 30;
                }
                else if (deviations.BloodPressure < 20)
                {
                    emotionModel.Strassed += 30;
                    emotionModel.Happy += 25;
                }
                else if (deviations.BloodPressure < 30)
                {
                    emotionModel.Strassed += 45;
                    emotionModel.Happy += 20;
                }
                else if (deviations.BloodPressure < 40)
                {
                    emotionModel.Strassed += 60;
                    emotionModel.Happy += 15;
                }
                else if (deviations.BloodPressure < 50)
                {
                    emotionModel.Strassed += 70;
                    emotionModel.Happy += 10;
                }
            }

            if (deviations.BloodOxygenLevel < 0)
            {
                if (deviations.BloodOxygenLevel >= -1)
                {
                    emotionModel.Relaxed += 10;
                }
                else if (deviations.BloodOxygenLevel >= -2)
                {
                    emotionModel.Relaxed += 20;
                }
                else if (deviations.BloodOxygenLevel >= -3)
                {
                    emotionModel.Relaxed += 30;
                }
                else if (deviations.BloodOxygenLevel >= -4)
                {
                    emotionModel.Relaxed += 40;
                }
            }
            if (deviations.BloodOxygenLevel > 0)
            {
                if (deviations.BloodOxygenLevel < 1)
                {
                    emotionModel.Strassed += 15;
                    emotionModel.Angry += 10;
                }
                else if (deviations.BloodOxygenLevel < 2)
                {
                    emotionModel.Strassed += 30;
                    emotionModel.Angry += 15;
                }
                else if (deviations.BloodOxygenLevel < 3)
                {
                    emotionModel.Strassed += 45;
                    emotionModel.Angry += 20;
                }
                else if (deviations.BloodOxygenLevel < 4)
                {
                    emotionModel.Strassed += 60;
                    emotionModel.Angry += 25;
                }
                else if (deviations.BloodOxygenLevel < 5)
                {
                    emotionModel.Strassed += 70;
                    emotionModel.Angry += 30;
                }
            }
            return emotionModel;

        }

    }
}

