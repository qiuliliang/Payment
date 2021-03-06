﻿using Microsoft.Extensions.Logging;
using Payments.Core;
using Payments.Core.Response;
using Payments.Exceptions;
using Payments.Extensions;
using Payments.Util;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Results;
using WechatPay.Services.Base;
using System;
using System.Threading.Tasks;
using System.Net.Http;
namespace WechatPay.Services
{
    /// <summary>
    /// 微信小程序支付服务
    /// </summary> 
    public class WechatPayMiniProgramPayService : WechatPayServiceBase, IWechatPayMiniProgramPayService
    {
        /// <summary>
        /// 初始化微信小程序支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatPayMiniProgramPayService( IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : base( httpClientFactory, loggerFactory)
        {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public Task<WechatPayResult<WechatPayMiniProgramPayResponse>> PayAsync(WechatPayMiniProgramPayRequest request)
        {
            return base.PayAsync<WechatPayMiniProgramPayResponse>(request);
        }



        /// <summary>
        /// 获取交易类型
        /// </summary>
        protected override string GetTradeType()
        {
            return "JSAPI";
        }

 
    }
}