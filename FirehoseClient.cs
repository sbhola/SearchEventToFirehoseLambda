using System.IO;
using System.Text;
using Newtonsoft.Json;
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;
using Amazon.Runtime;
using Models;
using Newtonsoft.Json.Serialization;
using Amazon;
using System;
using System.Threading.Tasks;

namespace SearchLambdaFunction
{
    public class FirehoseClient
    {

        private static BasicAWSCredentials _credentials = new BasicAWSCredentials(KeyStore.FirehoseAccessKey, KeyStore.FirehoseSecretKey);
        private static AmazonKinesisFirehoseClient _client = new AmazonKinesisFirehoseClient(_credentials, RegionEndpoint.USEast1);
        public async Task InsertSearchRequestDetails(HotelSearchRequestDetails request)
        {
            var jsonSettings = new JsonSerializerSettings { ContractResolver = new LowercaseContractResolver() };
            jsonSettings.DateFormatString = "yyyy-MM-dd";
            var jsonRequest = JsonConvert.SerializeObject(request, jsonSettings) + "\n";
            var requestByteCount = Encoding.UTF8.GetByteCount(jsonRequest);
            //Console.WriteLine($"Size of request in bytes : {requestByteCount}");
            //Console.WriteLine(jsonRequest);
            Record record = new Record();
            record.Data = new MemoryStream(Encoding.UTF8.GetBytes(jsonRequest));
            PutRecordRequest putRecordRequest = new PutRecordRequest();
            putRecordRequest.DeliveryStreamName = KeyStore.FirehoseRequestDetailsStream;
            putRecordRequest.Record = record;
            var response = await _client.PutRecordAsync(putRecordRequest);
            Console.WriteLine($"{response.RecordId} , {response.HttpStatusCode}");
        }

        public async Task InsertSearchResultDetails(HotelSearchResult request)
        {
            var jsonSettings = new JsonSerializerSettings { ContractResolver = new LowercaseContractResolver() };
            jsonSettings.DateFormatString = "yyyy-MM-dd";
            var jsonRequest = JsonConvert.SerializeObject(request, jsonSettings) + "\n";
            var requestByteCount = Encoding.UTF8.GetByteCount(jsonRequest);
            //Console.WriteLine($"Size of RESPONSE in bytes : {requestByteCount}");
            //Console.WriteLine(jsonRequest);
            Record record = new Record();
            record.Data = new MemoryStream(Encoding.UTF8.GetBytes(jsonRequest));
            PutRecordRequest putRecordRequest = new PutRecordRequest();
            putRecordRequest.DeliveryStreamName = KeyStore.FirehoseResultDetailsStream;
            putRecordRequest.Record = record;
            var response = await _client.PutRecordAsync(putRecordRequest);
            Console.WriteLine($"{response.RecordId} , {response.HttpStatusCode}");
        }
    }

    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
