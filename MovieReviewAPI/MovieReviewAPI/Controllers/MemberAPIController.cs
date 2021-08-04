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
    public class MemberAPIController : ApiController
    {
        private readonly MemberBLO _memberBLO;

        /// <summary>
        /// 初始化
        /// </summary>
        public MemberAPIController()
        {
            _memberBLO = new MemberBLO();
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="model">資料</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Register(RegisterVM model)
        {
            try
            {
                ApiResponseVM result = await Task.Run(() => _memberBLO.Register(model));

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                // TODO: 紀錄LOG
                return this.InternalServerError(ex);
            }
        }

        //// GET: api/MemberAPI
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/MemberAPI/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/MemberAPI
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/MemberAPI/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Member/5
        //public void Delete(int id)
        //{
        //}
    }
}
