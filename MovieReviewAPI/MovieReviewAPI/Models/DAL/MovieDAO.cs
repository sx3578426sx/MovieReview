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
SELECT TOP @TakeCount mc.MovieId AS Id,
       m.MovieName,
       m.ReleaseDate,
       m.Category,
       COUNT(mc.MovieId) AS ReviewCount
FROM Movies m
LEFT JOIN MovieComments mc ON m.Id = mc.MovieId
Group BY mc.MovieId
ORDER BY COUNT(mc.MovieId)";
                object obj = new
                {
                    TakeCount = count
                };

                // TODO:驗證
                result = conn.Query<MovieDetailVM>(sql, obj).ToList();
            }

            return result;
        }
    }
}