﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthentication
{
    /// <summary> 使用者資訊格式 </summary>
    public class UserInfoModel
    {
        public string ID { get; set; }
        public string Account { get; set; }
        public string PWD { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
