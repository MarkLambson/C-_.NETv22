public class VideoGame
{
  public string Title { get; set; }
  public string Studio { get; set; }
  public string Rating { get; set; }
  public double Price { get; set; }
  public string Platform { get; set; }

  public VideoGame(string title, string studio, string rating, double price, string platform)
  {
    Title = title;
    Studio = studio;
    Rating = rating;
    Price = price;
    Platform = platform;
  }

  public override string ToString()
  {
    return $@"
    Title:     {Title}
    Studio:    {Studio}
    Rating:    {Rating}
    Price:     {Price}
    Platform:    {Platform}";
  }
}