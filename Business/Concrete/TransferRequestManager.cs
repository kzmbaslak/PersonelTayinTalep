using Business.Abstract;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Core.CrossCuttingConcerns.Logging.FileLogger;
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
    public class TransferRequestManager : ITransferRequestService
    {
        ITransferRequestDal _transferRequestDal;
        public TransferRequestManager(ITransferRequestDal transferRequestDal)
        {
            _transferRequestDal = transferRequestDal;
        }

        public IDataResult<List<TransferRequestDetailDto>> GetAllTransferRequestDetails()
        {
            return new SuccessDataResult<List<TransferRequestDetailDto>>(_transferRequestDal.GetAllTransferRequestDetails());
        }
    }
}
