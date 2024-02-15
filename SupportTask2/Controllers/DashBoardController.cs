using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportTask2.Data;
using SupportTask2.Models;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SupportTask2.Controllers
{
    public class DashBoardController : Controller
    {
        private static List<Blog> blogs = new List<Blog>();
        private static List<BlogType> _types = new List<BlogType>();
        private readonly ApplicationDbContext _db;
        public DashBoardController(ApplicationDbContext db)
        {
            _db = db;
            _types.Add(new BlogType { Id = 1, Name = "action" });
            _types.Add(new BlogType { Id = 2, Name = "comedy" });
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddBlog() { 
        return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            _db.blogs.Add(blog);
            _db.SaveChanges();
            blogs.Add(blog);
            return RedirectToAction("index");
        }
        #region GetData
        public IActionResult GetAllData()
        {
            var blog =_db.blogs.Include(p => p.Type).ToList();


            return View(blog);
        }
        #endregion
        #region DeleteBlog
        public IActionResult DeleteBlog(int id)
        {
            Blog? bg= _db.blogs.FirstOrDefault(x => x.Id == id);
            _db.blogs.Remove(bg);
            _db.SaveChanges();
            return RedirectToAction("GetAllData");
        }
        #endregion
        #region EditBlog
        public IActionResult EditBlog(int id)
        {
            Blog? blog= _db.blogs.FirstOrDefault(y => y.Id == id);
          

            return View(blog);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            Blog? b = _db.blogs.FirstOrDefault(z => z.Id == blog.Id);
            b.Id = blog.Id;
            b.Title = blog.Title;
            b.Description = blog.Description;
            b.TypeId= blog.TypeId;
            _db.blogs.Update(b);
            _db.SaveChanges();

            return RedirectToAction("index");
            
        }
        #endregion




    }
}
