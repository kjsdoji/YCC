using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YCC.ApiIntegration;
using YCC.ViewModels.Catalog.ProductReviews;

namespace YCC.WebApp.Controllers
{
    public class ProductReviewsController : Controller
    {

        // GET: ProductReviews
        public IActionResult Index()
        {           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ProductReviewViewModel prvm)
        {
            //var product = await _productApiClient.AddReview(prvm);
            //return RedirectToAction("Detail", "Product", new { id = prvm.ProductId });
            return View();
        }
        // GET: ProductReviews/Details/5
        public IActionResult Details(int? id)
        {
            return View();
        }
        // GET: ProductReviews/Create
        public IActionResult Create()
        {
            //ViewData["ProductId"] = new SelectList(Product, "Id", "Id")
            return View();
        }
        // POST: ProductReviews/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Comments, PublishedDate, ProductId, Rating")] ProductReviewViewModel prvm)
        {
            return View();
        }
    }
}
