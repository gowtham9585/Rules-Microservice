﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rules_Microservice.Model
{
    public class TransactionStatus
    {
        public string Message { get; set; }
        public int source_balance { get; set; }
        public int destination_balance { get; set; }
    }
}
