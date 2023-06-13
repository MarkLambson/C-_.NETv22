public class Eruption
{
    public string Volcano { get; set; }
    public int Year { get; set; }
    public string Location { get; set; }
    public int ElevationInMeters { get; set; }
    public string Type { get; set; }
    public Eruption(string volcano, int year, string location, int elevationInMeters, string type)
    {
        Volcano = volcano;
        Year = year;
        Location = location;
        ElevationInMeters = elevationInMeters;
        Type = type;
    }

    // This method overrides the original ToString method built into C#
    // So we can get a specialized response!
    public override string ToString()
    {
        return $@"
            Name: {Volcano}
            Year: {Year}
            Location: {Location}
            Elevation: {ElevationInMeters} meters
            Type: {Type}
            ";
    }
}