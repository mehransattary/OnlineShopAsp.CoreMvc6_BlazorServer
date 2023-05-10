using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common;

public static class Images
{
    public static string AddImage(IFormFile SliderImageFile, string folder)
    {
        int random = new Random().Next(1000, 10000);
        string imagename = $"{random}-{SliderImageFile.FileName}";

        string currentPahtProject = Directory.GetCurrentDirectory();
        string filepath = Path.Combine(currentPahtProject, "wwwroot", "images", folder, imagename);

        var filepathStream = new FileStream(filepath, FileMode.Create);
        SliderImageFile.CopyTo(filepathStream);

        string path = $"/images/{folder}/{imagename}";

        return path;
    }
}
