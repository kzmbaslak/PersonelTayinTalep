using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Core.CrossCuttingConcerns.Logging.FileLogger;
using Core.CrossCuttingConcerns.Validate.FluteValidation;
using Core.Utilities.Business;
using Core.Utilities.Mappings;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    public class CourthouseManager : ICourthouseService
    {
        ICourthouseDal _courthouseDal;
        public CourthouseManager(ICourthouseDal courthouseDal)
        {
            _courthouseDal = courthouseDal;
        }

        [CacheRemoveAspect("ICourthouseService.Get")]
        [ValidationAspect(typeof(CourthouseValidator))]
        [SecuredOperation("admin,courthouse.add")]
        public IResult Add(CourthouseDto courthouseDto)
        {

            var courthouseTemp = AutoMapperHelper.Map<Courthouse>(courthouseDto);

            //ValidationTool.Validate(new CourthouseValidator(), courthouseTemp);
            IResult result = BusinessRules.Run(checkIfCourthousNameNotExists(courthouseDto.Name));

            if (result == null)
            {
                _courthouseDal.Add(courthouseTemp);
                return new SuccessResult();
            }
            else
            {
                return result;
            }
        }

        [CacheAspect]
        public IDataResult<List<Courthouse>> GetAll()
        {
            return new SuccessDataResult<List<Courthouse>>(_courthouseDal.GetAll(), Messages.CourthouseListed);
        }
        public IDataResult<CourthouseDetailDto> GetById(int courthouseId)
        {
            Courthouse courthouse = _courthouseDal.Get(c => c.Id == courthouseId, c => c.City);
            
            return new SuccessDataResult<CourthouseDetailDto>(AutoMapperHelper.Map<CourthouseDetailDto>(courthouse), Messages.CourthouseFinded);
        }


        [CacheAspect]
        public IDataResult<List<Courthouse>> GetAllByCityId(int id)
        {
            return new SuccessDataResult<List<Courthouse>>(_courthouseDal.GetAll(c => c.CityId == id));
        }

        [PerformanceAspect(5)]//5 saniye içinde çalışmazsa uyarı ver
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICourthouseService.Get")]//içerisinde ICourthouseService.Get geçen tüm cash leri sil
        public IResult Update(Courthouse courthouse)
        {
            IResult result = BusinessRules.Run(checkIfCourthouseIdExists(courthouse.Id));
            if (result == null)
            {
                _courthouseDal.Update(courthouse);
                return new SuccessResult(Messages.CourthouseUpdated);
            }
            else
            {
                return result;
            }
        }

        [SecuredOperation("admin,courthouse.delete")]
        public IResult Delete(int courthouseId)
        {
            _courthouseDal.Delete(new Courthouse() { Id = courthouseId });
            return new SuccessResult();
        }

        private IResult checkIfCourthousNameExists(string name)
        {
            if (_courthouseDal.Get(c => c.Name == name) != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CourthouseNameNotFound);
        }
        private IResult checkIfCourthousNameNotExists(string name)
        {
            if (_courthouseDal.Get(c => c.Name == name) == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CourthouseNameAlredyExists);
        }
        private IResult checkIfCourthouseIdExists(int id)
        {
            if (_courthouseDal.Get(c => c.Id == id) != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CourthouseNotFound);
        }
    }
}
