using BookShoppingCartMvcUI.Models;
using BookShoppingCartMVCUI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookShoppingCartMvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index(string sterm="", int genreId=0)
        {
             
            IEnumerable<Book> books= await _homeRepository.GetBooks(sterm, genreId);
            IEnumerable<Genre> genres = await _homeRepository.Genres();
            BookDisplayModel bookModel = new BookDisplayModel
            {
                Books = books,
                Genres = genres,
                STerm= sterm,
                GenreId= genreId
            };
            return View(bookModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View(Contact);
        }

        public IActionResult Bloggie()
        {
            return View(Bloggie);
        }

        public IActionResult Audiobooks()
        {
            return View(Audiobooks);
        }
        public IActionResult AboutUS()
        {
            return View(AboutUS);
        }
        public IActionResult Blog()
        {
            return View(Blog);
        }
        public IActionResult Manga()
        {
            return View(Manga);
        }
        public IActionResult Career()
        {
            return View(Career);
        }

        public IActionResult Publish()
        {
            return View(Publish);
        }
        public async Task<IActionResult> Fantasy(string sterm = "", int genreId = 0) 
        {
            IEnumerable<Book> books = await _homeRepository.GetBooks(sterm, genreId);
            IEnumerable<Genre> genres = await _homeRepository.Genres();
            BookDisplayModel bookModel = new BookDisplayModel
            {
                Books = books,
                Genres = genres,
                STerm = sterm,
                GenreId = genreId
            };
            return View(bookModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}