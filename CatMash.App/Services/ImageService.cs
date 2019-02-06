using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using CatMash.App.Interfaces;
using CatMash.API.Interfaces;
using CatMash.API.Model;
using Microsoft.Extensions.Configuration;

namespace CatMash.App.Services
{
    public class ImageService: IImageService
    {
        private readonly string _apiUrl;
        private IEnumerable<IImage> _images;

        public IEnumerable<IImage> Images
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

        public ImageService(IConfiguration config)
        {
            _apiUrl = config["ApiUrl"];
        }

        private async Task<IEnumerable<IImage>> GetImagesAsync()
        {
            using (var client = new HttpClient())
            {
                var serializer = new DataContractJsonSerializer(typeof(IEnumerable<Image>));
                var streamTask = client.GetStreamAsync(_apiUrl);
                return serializer.ReadObject(await streamTask) as IEnumerable<Image>;
            }
        }
    }
}
