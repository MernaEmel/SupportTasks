using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportTask2.Data;
using SupportTask2.Models;
using System.Collections.Generic;

namespace SupportTask2.Controllers.Api
{
   
    [ApiController]
    //[Route("api/[Controller]")]
    public class BlogController : ControllerBase
    {   
        private ApplicationDbContext _db;
        public BlogController(ApplicationDbContext db)
            
        {
            _db = db;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof( List < Blog >))]
        [Route("api/get")]
        public ActionResult<List<Blog>> get()
        {
            var Blog = _db.blogs.Include(c=>c.Type).ToList();
            return Ok(Blog);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/getblog/{id}")]
        
        public ActionResult get(int id)
        {
            if(id<=0)
             {
                return BadRequest();    
             }
            var Blog = _db.blogs.Include(c => c.Type).FirstOrDefault(c=>c.Id==id);
            if (Blog == null)
            {
                return NotFound();
            }
            return Ok(Blog);
        }





        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("api/addblog")]
        public IActionResult CreateBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.blogs.Add(blog);
            _db.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/deleteblog/{id}")]
        public ActionResult DeleteBlog(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var blog =_db.blogs.Include(c => c.Type).FirstOrDefault(b=>b.Id==id);
            if (blog == null)
            {
                return NotFound();
            }
            _db.blogs.Remove(blog); 
            _db.SaveChanges();
            return Ok();


        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/editblog")]
        public ActionResult UpdateBlog(Blog blog)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var blogg=_db.blogs.Include(c => c.Type).FirstOrDefault(c=>c.Id==blog.Id);
            if(blogg == null)
            {
                return NotFound();
            }
            blogg.Title = blog.Title;
            blogg.Description = blog.Description;
            blogg.TypeId = blog.TypeId;
            _db.SaveChanges();
            return Ok();

        }
        

    }
}
