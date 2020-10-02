using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    public string Name { get; set; }
    public int Id { get; }
    public List<Music> Musics { get; set; }

    public Category(string categoryName)
    {
      Name = categoryName;
      _instances.Add(this);
      Id = _instances.Count;
      Musics = new List<Music>{};
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static List<Category> GetAll()
    {
      return _instances;
    }
    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public void AddMusic(Music music)
    {
      Musics.Add(music);
    }

    public static Category FindArtist(string artistName)
    {
      int index = _instances.FindIndex(p => p.name == artistName);
      return _instances[index];
    }
  }
}
