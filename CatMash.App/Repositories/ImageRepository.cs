using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using CatMash.Business;
using CatMash.Entities;
using Microsoft.Extensions.Configuration;

namespace CatMash.App.Repositories
{
    public class ImageRepository: IImageRepository
    {
        private readonly string _apiUrl;
        private IEnumerable<Image> _images;

        public IEnumerable<Image> Images
        {
            get
            {
                if (_images == null)
                {
                    var task = Task.Run(async () => await GetImagesAsync());
                    _images = task.Result;
                }

                return _images;
            }
        }

        public ImageRepository(IConfiguration config)
        {
            _apiUrl = config["ApiUrl"];
        }

        private async Task<IEnumerable<Image>> GetImagesAsync()
        {
            using (var client = new HttpClient())
            {
                var serializer = new DataContractJsonSerializer(typeof(ImageData));
                var streamTask = client.GetStreamAsync(_apiUrl);
                return (serializer.ReadObject(await streamTask) as ImageData)?.Images;
            }
        }
    }
}
