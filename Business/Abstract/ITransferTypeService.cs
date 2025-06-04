using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITransferTypeService
    {

        IDataResult<List<TransferType>> GetAll();
        IDataResult<TransferType> GetById(int id);

        IResult Add(TransferType transferType);
        IResult Update(TransferType transferType);
        IResult Delete(int id);
    }
}
