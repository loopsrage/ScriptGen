﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSG
{
    interface IApiCall
    {
        string JSONExample { get; }
        string[] Response { get; }
        
    }
}
