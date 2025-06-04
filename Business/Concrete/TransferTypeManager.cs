using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TransferTypeManager : ITransferTypeService
    {
        ITransferTypeDal _transferTypeDal;

        public TransferTypeManager(ITransferTypeDal transferTypeDal)
        {
            _transferTypeDal = transferTypeDal;
        }
        public IResult Add(TransferType transferType)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<TransferType>> GetAll()
        {
            return new SuccessDataResult<List<TransferType>>(_transferTypeDal.GetAll());
        }

        public IDataResult<TransferType> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(TransferType transferType)
        {
            throw new NotImplementedException();
        }
    }
}
