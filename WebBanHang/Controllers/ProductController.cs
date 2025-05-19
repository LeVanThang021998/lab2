using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebBanHang.Models;
    
namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext _db;
        private readonly IWebHostEnvironment _hosting;

        public ProductController(ApplicationContext db, IWebHostEnvironment hosting)
        {
            _db = db;
            _hosting = hosting;
        }

        #region Hiển thị danh sách sản phẩm
        public IActionResult Index()
        {
            var dsSanPham = _db.products.ToList();
            return View(dsSanPham);
        }
        #endregion

        #region Thêm sản phẩm
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.CategoryList = _db.Categogies.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Product p, IFormFile ImageUrl)
        {
            if (ModelState.IsValid)
            {
                if (ImageUrl != null)
                {
                    p.ImageUrl = SaveImage(ImageUrl);
                }

                _db.products.Add(p);
                _db.SaveChanges();
                TempData["success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction("Index");
            }

            ViewBag.CategoryList = _db.Categogies.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View(p);
        }
        #endregion

        #region Sửa sản phẩm
        [HttpGet]
        public IActionResult Update(int id)
        {
            var sp = _db.products.Find(id);
            if (sp == null) return NotFound();

            ViewBag.CategoryList = _db.Categogies.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View(sp);
        }

        [HttpPost]
        public IActionResult Update(Product product, IFormFile ImageUrl)
        {
            var existingProduct = _db.products.Find(product.Id);
            if (existingProduct == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                // Nếu có upload ảnh mới
                if (ImageUrl != null)
                {
                    // Xoá ảnh cũ nếu tồn tại
                    if (!string.IsNullOrEmpty(existingProduct.ImageUrl))
                    {
                        var oldFilePath = Path.Combine(_hosting.WebRootPath, existingProduct.ImageUrl);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Lưu ảnh mới
                    existingProduct.ImageUrl = SaveImage(ImageUrl);
                }

                // Cập nhật các trường còn lại
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.CategoryId = product.CategoryId;

                _db.SaveChanges();
                TempData["success"] = "Product updated successfully!";
                return RedirectToAction("Index");
            }

            // Nếu dữ liệu không hợp lệ, trả lại view với dữ liệu cũ
            ViewBag.CategoryList = _db.Categogies
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();

            return View(product);
        }
        #endregion

        #region Xoá sản phẩm
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sp = _db.products.Find(id);
            if (sp == null) return NotFound();

            return View(sp);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _db.products.Find(id);
            if (product == null) return NotFound();

            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                var oldFilePath = Path.Combine(_hosting.WebRootPath, product.ImageUrl);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            _db.products.Remove(product);
            _db.SaveChanges();
            TempData["success"] = "Xoá sản phẩm thành công!";
            return RedirectToAction("Index");
        }
        #endregion

        #region Upload ảnh
        private string SaveImage(IFormFile image)
        {
            var filename = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var path = Path.Combine(_hosting.WebRootPath, "images/products");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fullPath = Path.Combine(path, filename);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return "images/products/" + filename;
        }
        #endregion
    }
}