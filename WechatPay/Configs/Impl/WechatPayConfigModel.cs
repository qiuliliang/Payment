﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WechatPay.Configs
{
    public class WechatPayConfigModel : WechatPayConfig
    {
        [Required(ErrorMessage = "名称不能为空")]
        public virtual string Name { get; set; }

    }
}
