using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewAPI.Models.VM.Common
{
    /// <summary>
    /// API回傳結果
    /// </summary>
    public class ApiResponseVM
    {
        public bool IsSuccess { get; set; }
    
        public string ErrorMsg { get; set; }
    }
}