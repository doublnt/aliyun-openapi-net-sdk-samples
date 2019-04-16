using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliyun.Acs.alimt.Model.V20181012;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;

namespace aliyun_alimt_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var accessKey = Environment.GetEnvironmentVariable("ACCESS_KEY_ID") ?? "AccessKeyId";
            var accessKeySecret = Environment.GetEnvironmentVariable("ACCESS_KEY_SECRET") ?? "AccessKeySecret";

            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKey, accessKeySecret);
            DefaultAcsClient client = new DefaultAcsClient(profile);

            var request = new TranslateGeneralRequest();

            request.FormatType = "text";
            request.SourceLanguage = "zh";
            request.SourceText = "你好，很高兴见到你";
            request.TargetLanguage = "en";
            request.Method = MethodType.POST;

            var response = client.GetAcsResponse(request);

            Console.WriteLine(response.Data.Translated);
        }
    }
}
