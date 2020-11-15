using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TplApiService.Service
{
  public  interface IImagesService
    {
        public string SavePersonImages(IWebHostEnvironment env, byte[] imageBytes, int personid);
    }
}
