﻿using AliPay.Abstractions;
using AliPay.Configs;
using AliPay.Parameters;
using AliPay.Parameters.Requests;
using AliPay.Services.Base;
using Microsoft.Extensions.Logging;
using Payments.Exceptions;
using Payments.Extensions;

namespace AliPay.Services
{
    /// <summary>
    /// 支付宝条码支付服务
    /// </summary>
    public class AlipayBarcodePayService : AlipayServiceBase<AlipayBarcodePayRequest>, IAlipayBarcodePayService
    {
        /// <summary>
        /// 初始化支付宝条码支付服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayBarcodePayService(IAliPayConfigProvider provider, ILoggerFactory loggerFactory) : base(provider, loggerFactory)
        {
        }


        /// <summary>
        /// 获取场景
        /// </summary>
        protected override string GetScene()
        {
            return "bar_code";
        }

        /// <summary>
        /// 获取请求方法
        /// </summary>
        protected override string GetMethod()
        {
            return "alipay.trade.pay";
        }



        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">支付参数</param>
        protected override void ValidateParam(AlipayBarcodePayRequest param)
        {
            if (param.AuthCode.IsEmpty())
                throw new Warning(PayResource.AuthCodeIsEmpty);
        }
        protected override void InitContentBuilder(AlipayParameterBuilder builder, AlipayBarcodePayRequest param)
        {
            builder.Remove(AlipayConst.ReturnUrl);
        }


        /// <summary>
        /// 初始化内容生成器
        /// </summary>
        /// <param name="builder">内容参数生成器</param>
        /// <param name="param">支付参数</param>
        protected override void InitContentBuilder(AlipayContentBuilder builder, AlipayBarcodePayRequest param)
        {
            builder.OutTradeNo(param.OrderId).TotalAmount(param.Money).Subject(param.Subject)
             .Body(param.Body).TimeoutExpress(param.Timeout).NotifyUrl(param.NotifyUrl).AuthCode(param.AuthCode);
        }
    }
}
