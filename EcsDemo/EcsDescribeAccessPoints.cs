using System;
using System.Collections.Generic;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Ecs.Model.V20140526;

namespace EcsDemo
{
    public class EcsDescribeAccessPoints
    {
        public void GetDescribeAccessPointsResponse()
        {
            var accessKey = Environment.GetEnvironmentVariable("ACCESS_KEY_ID") ?? "AccessKeyId";
            var accessKeySecret = Environment.GetEnvironmentVariable("ACCESS_KEY_SECRET") ?? "AccessKeySecret";
            var regionId = "cn-hangzhou";

            var profile = DefaultProfile.GetProfile(regionId, accessKey, accessKeySecret);
            var client = new DefaultAcsClient(profile);

            var request = new DescribeAccessPointsRequest();
            request.PageSize = 10;
            request.PageNumber = 20;
            request.Type = "type";

            var filter1 = new List<DescribeAccessPointsRequest.Filter>();
            var filterItem1 = new DescribeAccessPointsRequest.Filter();
            filterItem1.Key = "key";
            filterItem1.Values = new List<string> { "value" };
            filter1.Add(filterItem1);

            request.Filters = filter1;

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
