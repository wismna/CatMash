using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatMash.API.Interfaces;
using CatMash.API.Repositories;

namespace CatMash.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public async Task<IEnumerable<IImage>> GetImages()
        {
            using (var client = new HttpClient())
            {
                var serializer = new DataContractJsonSerializer(typeof(ImageRepository));
                var streamTask = client.GetStreamAsync("https://latelier.co/data/cats.json");
                var images = serializer.ReadObject(await streamTask) as ImageRepository;
                return images?.Images;
            }
        }
    }
}