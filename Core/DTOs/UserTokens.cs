﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public class UserTokens
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}
