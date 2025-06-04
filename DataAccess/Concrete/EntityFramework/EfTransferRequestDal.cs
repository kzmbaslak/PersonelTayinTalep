using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTransferRequestDal : EfEntityRepositoryBase<TransferRequest, PersonnelManagementContext>, ITransferRequestDal
    {
        public List<TransferRequestDetailDto> GetAllTransferRequestDetails()
        {
            using (PersonnelManagementContext context = new PersonnelManagementContext())
            {
                var result = from tr in context.TransferRequests
                             join c in context.Courthouses on tr.DestinationCourthouseId equals c.Id
                             join u in context.Users on tr.UsertId equals u.Id
                             join tt in context.TransferTypes on tr.TransferTypeId equals tt.Id
                             select new TransferRequestDetailDto
                             {
                                 Id = tr.Id,
                                 DestinationCourthouseName = c.Name,
                                 TransferTypeName = tt.Name,
                                 RequestDate = tr.RequestDate,
                                 User = u
                             };
                return result.ToList();
            }
        }

        public List<TransferRequestDetailDto> GetAllTransferRequestDetailsByUserId(int userId)
        {
            using (PersonnelManagementContext context = new PersonnelManagementContext())
            {
                var result = from tr in context.TransferRequests
                             join c in context.Courthouses on tr.DestinationCourthouseId equals c.Id
                             join u in context.Users on tr.UsertId equals u.Id
                             join tt in context.TransferTypes on tr.TransferTypeId equals tt.Id
                             where u.Id == userId
                             select new TransferRequestDetailDto
                             {
                                 Id = tr.Id,
                                 DestinationCourthouseName = c.Name,
                                 TransferTypeName = tt.Name,
                                 RequestDate = tr.RequestDate,
                                 User = u
                             };
                return result.ToList();
            }
        }

        public TransferRequestDetailDto GetTransferRequestDetails(int transferRequestId)
        {
            using (PersonnelManagementContext context = new PersonnelManagementContext())
            {
                var result = from tr in context.TransferRequests
                             join c in context.Courthouses on tr.DestinationCourthouseId equals c.Id
                             join u in context.Users on tr.UsertId equals u.Id
                             join tt in context.TransferTypes on tr.TransferTypeId equals tt.Id
                             where tr.Id == transferRequestId
                             select new TransferRequestDetailDto
                             {
                                 Id = tr.Id,
                                 DestinationCourthouseName = c.Name,
                                 TransferTypeName = tt.Name,
                                 RequestDate = tr.RequestDate,
                                 User = u
                             };
                return result.First();
            }
        }
    }
}
