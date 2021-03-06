﻿using Payments.Util.Validations;
using System.ComponentModel.DataAnnotations;
namespace WechatPay.Parameters.Requests
{
    /// <summary>
    /// 查询企业付款
    /// </summary>
    public class WechatGetTransferInfoRequest : Validation, IWechatPayRequest, IValidation
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string PartnerTradeNo { get; set; }
    }
}
