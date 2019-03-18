using System;
using System.Collections.Generic;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Ecs.Model.V20140526;

namespace EcsDemo
{
    public class InvokeCommand
    {
        public void EcsInvokeCommand()
        {
            var accessKey = Environment.GetEnvironmentVariable("ACCESS_KEY_ID") ?? "AccessKeyId";
            var accessKeySecret = Environment.GetEnvironmentVariable("ACCESS_KEY_SECRET") ?? "AccessKeySecret";
            var regionId = "cn-hangzhou";

            var profile = DefaultProfile.GetProfile(regionId, accessKey, accessKeySecret);
            var client = new DefaultAcsClient(profile);

            var request = new InvokeCommandRequest();
            request.CommandId = "commandId";

            var instanceIdList = new List<string>();
            instanceIdList.Add("instance1");
            instanceIdList.Add("instance2");

            request.InstanceIds = instanceIdList;

            try
            {
                var response = client.GetAcsResponse(request);
                Console.WriteLine(System.Text.Encoding.Default.GetString(response.HttpResponse.Content));
            }
            catch (ServerException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (ClientException ex)
            {
                Console.WriteLine("ErrorCode" + ex.ErrorCode);
                Console.WriteLine("ErrorMessage" + ex.ErrorMessage);
            }
        }
    }
}
