using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class CategoriesController : Controller
  {

    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/categories/searchbyartist")]
    public ActionResult SearchByArtist()
    {
      return View();
    }


    [HttpPost("/categories")]
    public ActionResult Create(string categoryName)
    {
      Category newCategory = new Category(categoryName);
      return RedirectToAction("Index");
    }

    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Music> categoryMusics = selectedCategory.Musics;
      model.Add("category", selectedCategory);
      model.Add("musics", categoryMusics);
      return View(model);
    }

// This one creates new Musics within a given Category, not new Categories:
    [HttpPost("/categories/{categoryId}/musics")]
    public ActionResult Create(int categoryId, string albumName, string albumYear, string discNumber, string musicCategory)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      Music newMusic = new Music(albumName, albumYear, discNumber, musicCategory);
      foundCategory.AddMusic(newMusic);
      List<Music> categoryMusics = foundCategory.Musics;
      model.Add("musics", categoryMusics);
      model.Add("category", foundCategory);
      return View("Show", model);
    }
    
  }
}