using MovieReviewAPI.Models.BLL;
using MovieReviewAPI.Models.VM.Common;
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

        // GET: api/Movie/5
        /// <summary>
        /// 取得電影明細
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get(Guid id)
        {
            try
            {
                var result = await Task.Run(() => _movieBLO.GetMovieDetail(id));

                return Json(result);
            }
            catch (Exception ex)
            {
                // TODO: 紀錄LOG
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// 取得最近上映的電影
        /// </summary>
        /// <param name="count">數量</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetLastMovieData(int count = 3)
        {
            try
            {
                List<MovieDetailVM> result = await Task.Run(() => _movieBLO.GetLastMovieData(count));

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                // TODO: 紀錄LOG
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// 取得熱門討論的電影
        /// </summary>
        /// <param name="count">數量</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetHotReviewMovieData(int count = 3)
        {
            try
            {
                List<MovieDetailVM> result = await Task.Run(() => _movieBLO.GetHotReviewMovieData(count));

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                // TODO: 紀錄LOG
                return this.InternalServerError(ex);
            }
        }

        // POST: api/Movie
        /// <summary>
        /// 新增電影
        /// </summary>
        /// <param name="model">新增資料</param>
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]MovieDetailVM model)
        {
            try
            {
                ApiResponseVM result = await Task.Run(() => _movieBLO.Create(model));

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                // TODO: 紀錄LOG
                return this.InternalServerError(ex);
            }
        }

        //// GET: api/Movie
        ///// <summary>
        ///// 電影查詢
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// PUT: api/Movie/5
        ///// <summary>
        ///// 更新電影明細
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="value"></param>
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Movie/5
        ///// <summary>
        ///// 刪除電影
        ///// </summary>
        ///// <param name="id"></param>
        //public void Delete(int id)
        //{
        //}
    }
}
