﻿using Application.Services.OutServices.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.OutServices
{
    public  interface IPosService
    {
        bool MakePayment(PosRequest posRequest);
        
    }
}
