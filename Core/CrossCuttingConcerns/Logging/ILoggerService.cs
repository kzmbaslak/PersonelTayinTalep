﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging
{
    public interface ILoggerService
    {
        void Log(LogDetail logDetail);
    }
}
