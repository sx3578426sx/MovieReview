using MovieReviewAPI.Models.DAL;
using MovieReviewAPI.Models.Entity;
using MovieReviewAPI.Models.Extensions;
using MovieReviewAPI.Models.VM.Common;
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
                var ReviewScoreList = _context.MovieComments.Where(x => x.MovieId == result.Id).Select(x => x.ReviewScore).ToList();
                result.ReviewScore = ReviewScoreList.Count > 0 ? ReviewScoreList.Average() : 0;
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
        public List<MovieDetailVM> GetLastMovieData(int count)
        {
            List<MovieDetailVM> result = new List<MovieDetailVM>();

            result = _movieDAO.GetLastMovieData(count);

            // 取得圖片
            foreach(var item in result)
            {
                var imgTemp = _context.MovieImageFile.FirstOrDefault(x => x.MovieId == item.Id);

                if(imgTemp != null && imgTemp.ImageFile.Length > 0)
                {
                    item.ImageFile = StreamExtension.GetFileStream(imgTemp.FileId, imgTemp.ImageFile);
                }
            }

            return result;
        }

        /// <summary>
        /// 新增電影
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ApiResponseVM Create(MovieDetailVM model)
        {
            ApiResponseVM result = new ApiResponseVM()
            {
                IsSuccess = true
            };

            #region 防呆(檢查是否必填)
            if (string.IsNullOrEmpty(model.MovieName))
            {
                result.IsSuccess = false;
                result.ErrorMsg += "電影名稱必填\n";
            }
            #endregion

            Guid movieId = Guid.NewGuid();

            Movies data = new Movies();
            data.Id = movieId;
            data.MovieName = model.MovieName;
            data.Category = model.Category;
            data.MovieDescription = model.MovieDescription;
            data.ReleaseDate = model.ReleaseDate;
            _context.Movies.Add(data);

            // 若有上傳圖片再另存圖檔
            if(model.UploadFile != null)
            {
                MovieImageFile imageFile = new MovieImageFile();
                imageFile.MovieId = movieId;
                imageFile.FileId = Guid.NewGuid();
                imageFile.ImageFile = model.UploadFile.InputStream.StreamToBytes();
                imageFile.ImageFileName = model.UploadFile.FileName;
                imageFile.FileType = model.UploadFile.ContentType;
                _context.MovieImageFile.Add(imageFile);
            }

            result.IsSuccess = _context.SaveChanges() > 0;

            if (!result.IsSuccess)
            {
                result.ErrorMsg = string.Join(",", _context.GetValidationErrors());
            }

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