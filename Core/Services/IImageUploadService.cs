﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IFormFile file);

        Task DeleteImageAsync(string publicId);
    }
}
