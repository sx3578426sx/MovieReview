using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewAPI.Models.VM.Member
{
    /// <summary>
    /// 註冊
    /// </summary>
    public class RegisterVM
    {
        public string NickName { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }
    }
}