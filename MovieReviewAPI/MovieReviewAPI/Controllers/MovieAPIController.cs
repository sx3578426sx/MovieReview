using MovieReviewAPI.Models.BLL;
using MovieReviewAPI.Models.VM.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace MovieReviewAPI.Controllers
{
    public class MovieAPIController : ApiController
    {
        private readonly MovieBLO _movieBLO;

        /// <summary>
        /// 初始化
        /// </summary>
        public MovieAPIController()
        {
            _movieBLO = new MovieBLO();
        }

        // GET: api/Movie
        /// <summary>
        /// 電影查詢
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Movie/5
        /// <summary>
        /// 取得電影明細
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var result = await Task.Run(() => _movieBLO.GetMovieDetail(id));

            return Json(result);
        }

        /// <summary>
        /// 取得最近上映的電影
        /// </summary>
        /// <param name="count">數量</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetLastMovieData(int count = 3)
        {
            List<HttpPostedFileBase> result = await Task.Run(() => _movieBLO.GetLastMovieData(count));
            
            return this.Ok(result);
        }

        /// <summary>
        /// 取得熱門討論的電影
        /// </summary>
        /// <param name="count">數量</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetHotReviewMovieData(int count = 3)
        {
            List<MovieDetailVM> result = await Task.Run(() => _movieBLO.GetHotReviewMovieData(count));

            return this.Ok(result); 
        }

        // POST: api/Movie
        /// <summary>
        /// 新增電影
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Movie/5
        /// <summary>
        /// 更新電影明細
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movie/5
        /// <summary>
        /// 刪除電影
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
}
