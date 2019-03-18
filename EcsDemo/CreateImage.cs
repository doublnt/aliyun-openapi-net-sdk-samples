using System;
using System.Collections.Generic;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Ecs.Model.V20140526;

namespace EcsDemo
{
    public class CreateImage
    {
        public void EcsCreateImage()
        {
            var accessKey = Environment.GetEnvironmentVariable("ACCESS_KEY_ID") ?? "AccessKeyId";
            var accessKeySecret = Environment.GetEnvironmentVariable("ACCESS_KEY_SECRET") ?? "AccessKeySecret";
            var regionId = "cn-hangzhou";

            var profile = DefaultProfile.GetProfile(regionId, accessKey, accessKeySecret);
            var client = new DefaultAcsClient(profile);

            var request = new CreateImageRequest();
            var diskDeviceMappings = new List<CreateImageRequest.DiskDeviceMapping>();
            var diskDeviceMappingItem = new CreateImageRequest.DiskDeviceMapping();

            diskDeviceMappingItem.Device = "device";
            diskDeviceMappingItem.DiskType = "diskType";
            diskDeviceMappingItem.Size = 5;
            diskDeviceMappingItem.SnapshotId = "snapShotId";

            diskDeviceMappings.Add(diskDeviceMappingItem);
            request.DiskDeviceMappings = diskDeviceMappings;

            var creatImageTag = new List<CreateImageRequest.Tag>();
            var createImageTagItem = new CreateImageRequest.Tag();

            createImageTagItem.Key = "key";
            createImageTagItem.Value = "value";

            creatImageTag.Add(createImageTagItem);
            request.Tags = creatImageTag;

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
