﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        // Kullanıcı bilgileri ve operasyon claim'lerini (rollerini) alarak bir token oluşturur.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
