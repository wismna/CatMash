using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using CatMash.Entities;
using Microsoft.Extensions.Configuration;

namespace CatMash.App.Repositories
{
    public class ImageRepository: IImageRepository
    {
        public IEnumerable<Image> Images { get; }

        public ImageRepository(IConfiguration config)
        {
            var task = Task.Run(async () => await GetImagesAsync(config["ApiUrl"]));
            Images = task.Result;
        }

        private async Task<IEnumerable<Image>> GetImagesAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var serializer = new DataContractJsonSerializer(typeof(ImageData));
                var streamTask = client.GetStreamAsync(url);
                return (serializer.ReadObject(await streamTask) as ImageData)?.Images;
            }
        }
    }
}
