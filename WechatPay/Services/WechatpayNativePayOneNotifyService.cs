﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Payments.Exceptions;
using Payments.Extensions;
using Payments.Util.Validations;
using WechatPay.Abstractions;
using WechatPay.Configs;
using WechatPay.Parameters;
using WechatPay.Parameters.Requests;
using WechatPay.Parameters.Response;
using WechatPay.Services.Base;
using System.Net.Http;
using System.Threading.Tasks;

namespace WechatPay.Services
{
    /// <summary>
    /// 微信扫码支付异步回调
    /// </summary>
    public class WechatPayNativePayOneNotifyService : WechatPayNotifyServiceBase<WechatPayNativePayOneNotifyResponse>, IWechatPayNativePayOneNotifyService
    {

        protected IWechatPayNativePayService NativePayService { get; }
        public WechatPayNativePayOneNotifyService( IWechatPayNativePayService nativePayService, ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor) : base( httpContextAccessor)
        {
            NativePayService = nativePayService;
        }

        public async Task<HttpResponseMessage> ReturnMessage(WechatPayNativePayRequest request)
        {
            HttpResponseMessage response = null;
            var validationResultCollection = await ValidateAsync();
            if (validationResultCollection.IsValid)
            {
                var result = await NativePayService.PayAsync(request);

                WechatPayParameterBuilder paramBuilder = new WechatPayParameterBuilder(Config);
                paramBuilder.Init();
                paramBuilder.PrepayId(result.Data?.PrepayId);
                paramBuilder.ReturnCode(result.Data?.ReturnCode);
                paramBuilder.ResultCode(result.Data?.ResultCode);
                paramBuilder.Add(WechatPayConst.ErrorCodeDescription, result.Data?.ReturnMsg);
                string xmlContent = paramBuilder.ToXml();
                response = xmlContent.XmlToHttpResponseMessage();
            }
            else
            {
                throw new PayException(validationResultCollection);
            }
            return response;
        }
    }
}
