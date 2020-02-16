using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Landmark_Classifier
{
    public static class Program
    {
        public static void Main()
        {
            string imageFilePath = ImageCapture.fileName;
]           MakePredictionRequest(imageFilePath).Wait();

            Console.WriteLine("\n\nHit ENTER to exit...");
            Console.ReadLine();
        }

        public static async Task MakePredictionRequest(string imageFilePath)
        {
            var client = new HttpClient();

            // Request headers - replace this example key with your valid Prediction-Key.
            client.DefaultRequestHeaders.Add("Prediction-Key", "3fb07a41beac4574a186e362ea0fe1e4");

            // Prediction URL - replace this example URL with your valid Prediction URL.
            string url = "https://treehacks2020.cognitiveservices.azure.com/customvision/v3.0/Prediction/6a85fe5d-7f93-408f-a936-b41137d70392/classify/iterations/Iteration3/image";

            HttpResponseMessage response;

            // Request body. Try this sample with a locally stored image.
            byte[] byteData = GetImageAsByteArray(imageFilePath);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(url, content);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }
    }
}