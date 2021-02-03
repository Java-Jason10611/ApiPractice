using API_callPractice.Models;
using API_callPractice.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_callPractice.Controllers
{
    public class MemeController : Controller
    {
        private readonly IMemeClient _memeclient;

        public MemeController(IMemeClient memeclient)
        {
            _memeclient = memeclient;
        }
        public async Task<IActionResult> Images()
        {
            var response = await _memeclient.GetMemeImages();
            var tempMeme = new Meme();
            var model = new MemeViewModel();
            var listOfMemes = new List<Meme>();

            foreach (Meme memeObj in response.data.memes)
            {
                tempMeme.name = memeObj.name;
                tempMeme.url = memeObj.url;
                listOfMemes.Add(memeObj);
            }
            model.MemeList = listOfMemes;
            
            return View(model);
        }
    }
}
