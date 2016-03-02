using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;

namespace ForJenkins.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {

        public IHttpActionResult GetText()
        {
            int result = 0;
            for (int i = 0; i < 100000; i++)
            {
                result += i;
            }

            return Ok("result ok : " + result);
        }

        public async System.Threading.Tasks.Task<IHttpActionResult> PostUpload(string folder, string filekey)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var root = HttpContext.Current.Server.MapPath("~/App_Data/Temp/FileUploads");
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                var result = await Request.Content.ReadAsMultipartAsync(provider);
            }
            catch (Exception ex)
            {

            }

            try
            {
                string bucketName = "aws-yeon-test-fims-support";
                var credentials = new StoredProfileAWSCredentials("s3");
                IAmazonS3 client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.APNortheast2);

                foreach (var file in provider.FileData)
                {
                    PutObjectRequest putRequest = new PutObjectRequest
                    {
                        BucketName = bucketName,
                        Key = file.Headers.ContentDisposition.FileName.Substring(1, file.Headers.ContentDisposition.FileName.Length - 2),
                        FilePath = file.LocalFileName
                        //ContentType = "text/plain"
                    };
                    putRequest.Headers.ContentLength = 168059;
                    PutObjectResponse response = client.PutObject(putRequest);

                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                return InternalServerError(amazonS3Exception);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            finally
            {

            }
            return Ok();
        }
    }

}
