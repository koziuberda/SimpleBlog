using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Data;
using SimpleBlog.Data.UnitOfWork;
using SimpleBlog.Entities;
using SimpleBlog.Web.Models;

namespace SimpleBlog.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var posts = await _unitOfWork.PostRepository.GetAllAsync();
            var selected = posts.Select(post => new ReadablePostModel(post));
            return View(selected);
        }
        
        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var post = await _unitOfWork.PostRepository.GetWithCommentsAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            var postModel = new ReadablePostModel(post);
            var comments = post.Comments.
                Select(c => new ReadableCommentModel(c))
                .ToList();
            
            // TODO: implement evaluating correct UserId via authorisation
            var newComment = new WritableCommentModel
            {
                PostId = postModel.Id
            };
            
            return View(new PostViewModel(postModel, comments, newComment));
        }
        
        // GET: Posts/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WritablePostModel writablePost)
        {
            if (ModelState.IsValid)
            {
                var post = new Post {CreationDate = DateTime.Now, Title = writablePost.Title, Text = writablePost.Text};
                await _unitOfWork.PostRepository.AddAsync(post);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(writablePost);
        }
        
        // GET: Posts/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _unitOfWork.PostRepository.GetAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            var editViewModel = new EditPostViewModel {PostId = id, EditedPost = new WritablePostModel(post)};
            
            return View(editViewModel);
        }
        
        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditPostViewModel viewModel)
        {
            if (id != viewModel.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var post = await _unitOfWork.PostRepository.GetAsync(id);
                    post.Text = viewModel.EditedPost.Text;
                    post.Title = viewModel.EditedPost.Title;
                    _unitOfWork.PostRepository.Update(post);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(viewModel);
        }
        
        // GET: Posts/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _unitOfWork.PostRepository.GetAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _unitOfWork.PostRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
