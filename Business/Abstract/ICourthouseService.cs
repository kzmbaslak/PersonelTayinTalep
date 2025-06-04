using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourthouseService
    {
        IDataResult<List<Courthouse>> GetAll();

        IDataResult<CourthouseDetailDto> GetById(int courthouseId);
        IDataResult<List<Courthouse>> GetAllByCityId(int id);

        IResult Add(CourthouseDto courthouseDto);

        IResult Update(Courthouse courthouse);
        IResult Delete(int courthouseId);
    }
}
