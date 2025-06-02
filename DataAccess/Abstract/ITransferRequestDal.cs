using Core.Dataaccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITransferRequestDal : IEntityRepository<TransferRequest>
    {

        List<TransferRequestDetailDto> GetAllTransferRequestDetails();
        TransferRequestDetailDto GetTransferRequestDetails(int transferRequestId);
    }
}
