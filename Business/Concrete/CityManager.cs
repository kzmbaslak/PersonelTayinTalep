using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public IResult Add(City city)
        {
            IResult result = BusinessRules.Run(checkCityNameExists(city.Name));

            if (result == null)
            {
                _cityDal.Add(city);
                return new SuccessResult(Messages.CityAdded);
            }
            else
            {
                return result;
            }
        }

        public IResult Delete(int id)
        {
            _cityDal.Delete(new City { Id = id });
            return new SuccessResult(Messages.CityDeleted);
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(), "Courthouses listed successfully.");
        }

        public IDataResult<City> GetById(int id)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.Id == id));
        }

        public IResult Update(City city)
        {
            IResult result = BusinessRules.Run(checkCityIdExists(city.Id));
            if (result == null)
            {
                _cityDal.Update(city);
                return new SuccessResult(Messages.CityUpdated);
            }
            else
            {
                return result;
            }
        }


        private IResult checkCityNameExists(string cityName)
        {
            if (_cityDal.GetAll(c => c.Name == cityName).Any())
            {
                return new ErrorResult(Messages.CityNamAlredyExits);
            }
            return new SuccessResult();

        }

        private IResult checkCityIdExists(int id)
        {
            if (_cityDal.Get(c => c.Id == id) != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CityNotFound);
        }
    }
}
