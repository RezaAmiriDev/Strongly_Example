﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface ILoginRepository
    {
        bool IsExasit(string userName, string passward);
    }
}
