using Core.Dataaccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICourthouseDal: IEntityRepository<Courthouse>
    {

        //List<CourthouseDetailDto> GetAllTransferRequestDetails();
        //CourthouseDetailDto GetTransferRequestDetails(int CourthouseId);
    }
}
