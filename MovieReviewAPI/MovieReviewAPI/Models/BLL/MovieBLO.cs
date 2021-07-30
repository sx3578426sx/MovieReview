using MovieReviewAPI.Models.DAL;
using MovieReviewAPI.Models.Entity;
using MovieReviewAPI.Models.VM.Movie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MovieReviewAPI.Models.BLL
{
    /// <summary>
    /// 電影
    /// </summary>
    public class MovieBLO
    {
        private readonly MovieReviewDB _context;
        private readonly MovieDAO _movieDAO;

        public MovieBLO()
        {
            _context = new MovieReviewDB();
            _movieDAO = new MovieDAO();
        }

        /// <summary>
        /// 取得電影明細
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieDetailVM GetMovieDetail(Guid id)
        {
            var result = _context.Movies.AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new MovieDetailVM()
                {
                    Id = x.Id,
                    MovieName = x.MovieName,
                    ReleaseDate = x.ReleaseDate,
                    Category = x.Category
                })
                .FirstOrDefault();

            // 取得圖片檔及計算推薦分數
            if(result != null)
            {
                // 圖片
                var imgFile = _context.MovieImageFile.FirstOrDefault(x => x.MovieId == result.Id);

                //TODO:圖片處理

                // 推薦分數
                result.ReviewScore = _context.MovieComments.Where(x => x.MovieId == result.Id).Select(x => x.ReviewScore).Average();
            }
            else
            {
                result = new MovieDetailVM();
            }

            return result;
        }

        /// <summary>
        /// 取得最近上映的電影
        /// </summary>
        /// <param name="count">數量</param>
        /// <returns></returns>
        public List<HttpPostedFileBase> GetLastMovieData(int count)
        {
            List<HttpPostedFileBase> result = new List<HttpPostedFileBase>();

            //TODO:檔案處理

            return result;
        }

        /// <summary>
        /// 取得熱門討論的電影
        /// </summary>
        /// <param name="count">數量</param>
        /// <returns></returns>
        public List<MovieDetailVM> GetHotReviewMovieData(int count)
        {
            var result = _movieDAO.GetHotReviewMovieData(count);

            return result;
        }
    }
}