using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data;
using SimpleBlog.Data.UnitOfWork;
using SimpleBlog.Entities;
using SimpleBlog.Web.Models;

namespace SimpleBlog.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // GET: Comments/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WritableCommentModel writableComment)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    PostId = writableComment.PostId,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Text = writableComment.Text,
                    CreationDate = DateTime.Now
                };
                await _unitOfWork.CommentRepository.AddAsync(comment);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction("Details", "Posts", new {id = comment.PostId});
            }
            
            return View(writableComment);
        }
    }
}
