﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    internal interface IID
    {
        int ID { get; set; }
        bool DniExist(int dni);
    }
}