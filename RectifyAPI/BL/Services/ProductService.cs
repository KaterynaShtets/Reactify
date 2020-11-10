using ReactifyAPI.BL.Interfaces;
using ReactifyAPI.Repositories;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ReactifyAPI.BL.Services
{
    public class ProductService: IProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly IndicatorsRepository _indicatorsRepository;
        private readonly IndicatorsInfoRepository _indicatorsInfoRepository;

        public ProductService(ProductRepository productRepository, IndicatorsRepository indicatorsRepository, IndicatorsInfoRepository indicatorsInfoRepository)
        {
            _productRepository = productRepository;
            _indicatorsRepository = indicatorsRepository;
            _indicatorsInfoRepository = indicatorsInfoRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _productRepository.Get(id);
        }

        public async Task<Product> UpdateProduct(Product entity)
        {
            return await _productRepository.Update(entity);
        }

        public async Task<Product> DeleteProduct(int id)
        {
            return await _productRepository.Delete(id);
        }

        // получаем все записи по тестированию определенного продукта
        public async Task<List<Indicators>> GetIndicatorsByProductId(int productId)
        {
            var indicators = await _indicatorsRepository.GetAll();
            //indicators
            //    .Include(x => x.IndicatorsInfo)
            //    .Include(x => x.Product)
            //    .Include(x => x.TesterUser);

            var cc = indicators.ToList();
            var f = cc.First().IndicatorsInfo;

            var res = indicators.Where(x => x.Product.Id == productId).ToList();
            return res; 
        }

        //все записи физических показателей определенного продукта
        public async Task<List<IndicatorsInfo>> GetIndicatorsInfoList(int productId)
        {
            //var indicatorsInfos = await _indicatorsInfoRepository.GetAll();
            var indicators = await GetIndicatorsByProductId(productId);

            var indicatorInfo = indicators.SelectMany(x => x.IndicatorsInfo).ToList();

            //var res = indicatorsInfos.Where(x => x.Indicators.Id == indicators.Id).ToList();


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

        //Отклонение среднего значения от стартового для прослеживания дианмики
        public async Task<Deviation> GetDeviations(int productId)
        {
            var indicatorsInfos = await GetIndicatorsInfoList(productId);

            var BpFirst = indicatorsInfos.Select(x => x.BloodPressure).First();
            var BolFirst = indicatorsInfos.Select(x => x.BloodOxygenLevel).First();
            var TemperatureFirst = indicatorsInfos.Select(x => x.Temperature).First();
            var PulseFirst = indicatorsInfos.Select(x => x.Pulse).First();

            var averageValues = await GetAvarageValuesForEachParameter(productId);


            var response = new Deviation();
            response.BloodPressure = averageValues.BloodPressure - BpFirst;
            response.BloodOxygenLevel = averageValues.BloodOxygenLevel - BolFirst;
            response.Pulse = averageValues.Pulse - BolFirst;
            response.Temperature = averageValues.Temperature - TemperatureFirst;

            return response;

        }

        //Процентный расчет эмоционального состояния человека
        public async Task<EmotionModel> GetEmotionalReaction(int productId)
        {
            //получаем отклонения от начального значения
            var deviations = await GetDeviations(productId);
            var emotionModel = new EmotionModel();

            if (deviations.Pulse < 0)
            {
               if(deviations.Pulse >= -10 && deviations.Pulse < 0)
                {
                    emotionModel.Happy += 20;
                    emotionModel.Relaxed += 10;
                }
                else if (deviations.Pulse >= -20 && deviations.Pulse < 0)
                {
                    emotionModel.Happy += 15;
                    emotionModel.Relaxed += 30;
                }
                else if(deviations.Pulse >= -30 && deviations.Pulse < 0)
                {
                    emotionModel.Happy += 10;
                    emotionModel.Relaxed += 50;
                }
                else if(deviations.Pulse >= -40 && deviations.Pulse < 0)
                {
                    emotionModel.Happy += 5;
                    emotionModel.Relaxed += 60;
                }
                else if (deviations.Pulse >= -50 && deviations.Pulse < 0)
                {
                    emotionModel.Happy += 5;
                    emotionModel.Relaxed += 70;
                }
                else if (deviations.Pulse >= -60 && deviations.Pulse < 0)
                {
                    emotionModel.Happy += 5;
                    emotionModel.Relaxed += 80;
                }
                else if (deviations.Pulse >= -70 && deviations.Pulse < 0)
                {
                    emotionModel.Happy += 5;
                    emotionModel.Relaxed += 90;
                }
            }
            if (deviations.Pulse > 0)
            {
                if (deviations.Pulse >= 10)
                {
                    emotionModel.Happy += 20;
                    emotionModel.Strassed += 5;
                }
                else if (deviations.Pulse >= 20)
                {
                    emotionModel.Happy += 30;
                    emotionModel.Strassed += 10;
                }
                else if(deviations.Pulse >= 30)
                {
                    emotionModel.Happy += 25;
                    emotionModel.Strassed += 20;
                }
                else if (deviations.Pulse >= 40)
                {
                    emotionModel.Happy += 20;
                    emotionModel.Strassed += 30;
                }
                else if (deviations.Pulse >= 50)
                {
                    emotionModel.Happy += 15;
                    emotionModel.Strassed += 40;
                }
            }

            if(deviations.Temperature > 0)
            {
                if(deviations.Temperature <= 1)
                {
                    emotionModel.Angry += 10;
                    emotionModel.Strassed += 10;
                }
                else if(deviations.Temperature <= 2)
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
            if(deviations.Temperature < 0)
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
                else if (deviations.Temperature>= -4)
                {
                    emotionModel.Relaxed += 40;
                }
            }

            if(deviations.BloodPressure < 0)
            {
                if(deviations.BloodPressure >= -10)
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
            if(deviations.BloodPressure > 0)
            {
                if(deviations.BloodPressure < 10)
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
            return emotionModel;

        }

    }
}
