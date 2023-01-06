using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadBlob
{
    internal class Program
    {
        static string connectionString = "DefaultEndpointsProtocol=https;AccountName=kazim;AccountKey=DfEs97+i1z9xD5o9+ne3ED0os7KgSXlYhMsxy2X7Q2SdddNj/3KhhpUZioTiiAwcyHPCLiAoOOZn+AStA9aKVA==;EndpointSuffix=core.windows.net";
        static string containerName = "filecontainer";

        static void Main(string[] args)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.CreateBlobContainer(containerName);
            var files = Directory.GetFiles(@"C:\Users\kazim.hussain\Desktop\New folder");
            foreach(var file in files)
            {
                using (MemoryStream stream = new MemoryStream(File.ReadAllBytes(file)))
                {
                    containerClient.UploadBlob(Path.GetFileName(file), stream);
                }
                Console.WriteLine(file + "Uploaded");
            }
            Console.Read();
        }
    }
}
