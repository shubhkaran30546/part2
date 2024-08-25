public class PictureService
{
    private readonly string _filePath;

    public PictureService(IWebHostEnvironment env)
    {
        // Construct the file path to pictures.txt in the wwwroot/Pictures directory
        _filePath = Path.Combine(env.WebRootPath, "Pictures", "pictures.txt");
    }

    public List<Picture> GetPictures()
    {
        var pictures = new List<Picture>();
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("File not found: " + _filePath);
            return pictures;
        }

        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            var parts = line.Split('|');
            if (parts.Length == 3)
            {
                // Ensure that the image paths are relative to the wwwroot directory
                var picture = new Picture
                {
                    Name = parts[0],
                    Location = "/images/" + parts[1], // Ensure path is correct
                    Description = parts[2]
                };
                pictures.Add(picture);
            }
        }

        Console.WriteLine("Number of pictures read: " + pictures.Count);
        return pictures;
    }
}
