using MovieReviewAPI.Models.BLL;
using MovieReviewAPI.Models.VM.Common;
using MovieReviewAPI.Models.VM.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MovieReviewAPI.Controllers
{
    /// <summary>
    /// 會員
    /// </summary>
    public class MemberController : ApiController
    {
        private readonly MemberBLO _memberBLO;

        /// <summary>
        /// 初始化
        /// </summary>
        public MemberController()
        {
            _memberBLO = new MemberBLO();
        }

        /// <summary>
        /// 取得最近上映的電影
        /// </summary>
        /// <param name="count">數量</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetLastMovieData(RegisterVM model)
        {
            ApiResponseVM result = await Task.Run(() => _memberBLO.Register(model));

            return this.Ok(result);
        }

        // GET: api/Member
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Member/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Member
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Member/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Member/5
        public void Delete(int id)
        {
        }
    }
}
