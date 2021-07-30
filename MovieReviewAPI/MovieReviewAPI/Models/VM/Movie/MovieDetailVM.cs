using System;
using System.Collections.Generic;
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
        /// 圖片
        /// </summary>
        public HttpPostedFileBase ImageFile { get; set; }

        /// <summary>
        /// 推薦分數
        /// </summary>
        public double ReviewScore { get; set; }
    }
}