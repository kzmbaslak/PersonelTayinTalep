using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Core.CrossCuttingConcerns.Logging.FileLogger;
using Core.Utilities.Business;
using Core.Utilities.Mappings;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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

        [CacheRemoveAspect("ITransferRequestService.Get")]
        public IResult Add(TransferRequestDto transferRequestDto, int userId)
        {
            TransferRequest transferRequestTemp = AutoMapperHelper.Map<TransferRequest>(transferRequestDto);
            transferRequestTemp.UsertId = userId;
            transferRequestTemp.RequestDate = DateTime.UtcNow;

            IResult result = BusinessRules.Run(checkIfSameTransferRequestExists(transferRequestTemp));

            if (result != null)
            {
                _transferRequestDal.Add(transferRequestTemp);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult(Messages.TransferRequesAlredyExist);
            }
        }


        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<TransferRequest>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<TransferRequestDetailDto>> GetAllTransferRequestDetails()
        {
            return new SuccessDataResult<List<TransferRequestDetailDto>>(_transferRequestDal.GetAllTransferRequestDetails());
        }

        public IDataResult<List<TransferRequestDetailDto>> GetAllTransferRequestDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<TransferRequestDetailDto>>(_transferRequestDal.GetAllTransferRequestDetailsByUserId(userId));
        }

        public IDataResult<TransferRequest> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(TransferRequestDto transferRequestDto)
        {
            throw new NotImplementedException();
        }


        private IResult checkIfSameTransferRequestExists(TransferRequest transferRequest)
        {
            var result = _transferRequestDal.GetAll(tr => tr.UsertId == transferRequest.UsertId && tr.DestinationCourthouseId == transferRequest.DestinationCourthouseId && tr.TransferTypeId == transferRequest.TransferTypeId).Any();
            if (result)
            {
                return new SuccessResult(Messages.TransferRequesAlredyExist);
            }
            return new ErrorResult(Messages.TransferRequesNotExist);
        }
    }
}
