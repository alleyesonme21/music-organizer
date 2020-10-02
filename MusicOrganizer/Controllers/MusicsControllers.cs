using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class MusicsController : Controller
  {

    [HttpPost("/musics/delete")]
    public ActionResult DeleteAll()
    {
      Music.ClearAll();
      return View();
    }
    
    [HttpGet("/categories/{categoryId}/musics/{musicId}")]
    public ActionResult Show(int categoryId, int musicId)
    {
      Music music = Music.Find(musicId);
      Category category = Category.Find(categoryId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("music", music);
      model.Add("category", category);
      return View(model);
    }

    [HttpGet("/categories/{categoryId}/musics/new")]
    public ActionResult New(int categoryId)
    {
      Category category = Category.Find(categoryId);
      return View(category);
    }
  }
}