using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IImageService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns> Returns a string value for the model's ImageUrl Property </returns>
        Task<string> SaveImageAsync(IFormFile file);
    }
}
