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
    public interface ITransferRequestService
    {

        IDataResult<List<TransferRequest>> GetAll();
        IDataResult<TransferRequest> GetById(int id);

        IResult Add(TransferRequestDto transferRequestDto, int userId);
        IResult Update(TransferRequestDto transferRequestDto);
        IResult Delete(int id);
        IDataResult<List<TransferRequestDetailDto>> GetAllTransferRequestDetails();
        IDataResult<List<TransferRequestDetailDto>> GetAllTransferRequestDetailsByUserId(int userId);
    }
}
