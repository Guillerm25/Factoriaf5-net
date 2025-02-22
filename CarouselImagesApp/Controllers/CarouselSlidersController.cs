﻿using CarouselImagesApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarouselImagesApp.Controllers
{
    public class CarouselSlidersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CarouselSlidersController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        //Subir Archivo
        private string UploadedFile(CarouselSliders carouselSlider)
        {
            string fileName = null;

            if (carouselSlider.ImageFile != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                fileName = Path.GetFileNameWithoutExtension(carouselSlider.ImageFile.FileName);
                string extension = Path.GetExtension(carouselSlider.ImageFile.FileName);
                carouselSlider.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    carouselSlider.ImageFile.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        // GET: 
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carousel.ToListAsync());
        }



        // GET: /Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarouselId,Name,Description,ImageFile")] CarouselSliders carousel)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                carousel.ImageName = UploadedFile(carousel);

                //Insert record
                _context.Add(carousel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carousel);
        }

        // GET: /Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = await _context.Carousel.FindAsync(id);
            if (carousel == null)
            {
                return NotFound();
            }
            return View(carousel);
        }

        // POST: /Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarouselSliders carousel)
        {
            if (id != carousel.CarouselId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (carousel.ImageFile != null)
                    {
                        if (carousel.ImageName != null)
                        {
                            string filePath = Path.Combine(_hostEnvironment.WebRootPath, "image", carousel.ImageName);
                            System.IO.File.Delete(filePath);
                        }
                        carousel.ImageName = UploadedFile(carousel);
                    }
                    _context.Update(carousel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarouselExists(carousel.CarouselId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carousel);
        }

        // GET: /Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carousel = await _context.Carousel
                .FirstOrDefaultAsync(m => m.CarouselId == id);
            if (carousel == null)
            {
                return NotFound();
            }

            return View(carousel);
        }

        // POST: /Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carousel = await _context.Carousel.FindAsync(id);

            //Eliminar de la root
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", carousel.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            //delete
            _context.Carousel.Remove(carousel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarouselExists(int id)
        {
            return _context.Carousel.Any(e => e.CarouselId == id);
        }
    }
}
