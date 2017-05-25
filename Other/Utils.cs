using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Diagnostics;
using System.IO;

namespace RestaurantApp.Other
{
    public static class Utils
    {
        public static bool SaveFileFromBase64(string base64string, string name, string folder)
        {
            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(name, out contentType);

            base64string = base64string
                .Replace($"data:{contentType};base64,", "")
                .Replace('-', '+')
                .Replace('_', '/');

            byte[] base64array = Convert.FromBase64String(base64string);

            string basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", folder);

            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }

            string filePath = Path.Combine(basePath, name);

            File.WriteAllBytes(filePath, base64array);

            return true;
        }
    }
}
