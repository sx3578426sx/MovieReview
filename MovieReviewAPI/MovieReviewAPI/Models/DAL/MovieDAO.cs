using Dapper;
using MovieReviewAPI.Models.VM.Movie;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MovieReviewAPI.Models.DAL
{
    /// <summary>
    /// 電影
    /// </summary>
    public class MovieDAO
    {
        private readonly string connextionString = ConfigurationManager.ConnectionStrings["MovieReviewDB"].ToString();
        
        /// <summary>
        /// 取得熱門討論的電影
        /// </summary>
        /// <param name="count">數量</param>
        /// <returns></returns>
        public List<MovieDetailVM> GetHotReviewMovieData(int count)
        {
            var result = new List<MovieDetailVM>();

            using (var conn = new SqlConnection(connextionString))
            {
                string sql = @"
SELECT m.Id,
       m.MovieName,
       m.ReleaseDate,
       m.Category,
       (SELECT COUNT(MovieId) FROM MovieComments mc WHERE m.Id = mc.MovieId) AS ReviewCount
FROM Movies m
ORDER BY ReviewCount";

                result = conn.Query<MovieDetailVM>(sql).Take(count).ToList();
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
            var result = new List<MovieDetailVM>();

            using (var conn = new SqlConnection(connextionString))
            {
                string sql = @"
SELECT m.Id,
       m.MovieName,
       m.ReleaseDate,
       m.Category
FROM Movies m
ORDER BY ReleaseDate DESC";

                result = conn.Query<MovieDetailVM>(sql).Take(count).ToList();
            }

            return result;
        }
    }
}