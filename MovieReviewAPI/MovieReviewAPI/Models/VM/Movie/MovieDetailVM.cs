using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MovieReviewAPI.Models.VM.Movie
{
    /// <summary>
    /// 電影明細
    /// </summary>
    public class MovieDetailVM
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// 電影名稱
        /// </summary>
        public string MovieName { get; set; }

        /// <summary>
        /// 分類
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 上映日期
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// 電影描述
        /// </summary>
        public string MovieDescription { get; set; }

        /// <summary>
        /// 顯示的圖片
        /// </summary>
        public FileStream ImageFile { get; set; }

        /// <summary>
        /// 上傳的圖片
        /// </summary>
        public HttpPostedFileBase UploadFile { get; set; }

        /// <summary>
        /// 推薦分數
        /// </summary>
        public double ReviewScore { get; set; }
    }
}