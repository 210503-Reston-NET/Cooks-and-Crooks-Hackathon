﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RRModels
{
    public class Customer : IdentityUser
    {
        public Customer() { }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}
