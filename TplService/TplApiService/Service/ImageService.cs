using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TplApiService.Service
{
    public class ImageService : IImagesService
    {

        public  string SavePersonImages(IWebHostEnvironment env, byte[] imageBytes,int personid)
        {
            String path = Path.Combine(env.ContentRootPath, "images", "Person");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filename = $"{personid}.jpg";
            SaveImages(Path.Combine(path, filename), imageBytes);

            return filename;
        }

        private static void DeleteImages(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    string[] filePaths = Directory.GetFiles(path, "*.jpg");
                    foreach (string filepath in filePaths)
                    {
                        File.Delete(filepath);
                    }

                    Directory.Delete(path);
                }
                catch { }

            }
        }

        private static void SaveImages(string filename, byte[] imageBytes)
        {
            try
            {
                File.WriteAllBytes(filename, imageBytes);
            }
            catch (Exception ex)
            {
                string e = ex.Message.ToString();
            }
        }
    }
}
