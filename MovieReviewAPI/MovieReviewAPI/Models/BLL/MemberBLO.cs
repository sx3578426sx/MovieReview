using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieReviewAPI.Models.Entity;
using MovieReviewAPI.Models.VM.Common;
using MovieReviewAPI.Models.VM.Member;

namespace MovieReviewAPI.Models.BLL
{
    /// <summary>
    /// 會員
    /// </summary>
    public class MemberBLO
    {
        private readonly MovieReviewDB _context;

        public MemberBLO()
        {
            _context = new MovieReviewDB();
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="model">註冊資料</param>
        /// <returns></returns>
        public ApiResponseVM Register(RegisterVM model)
        {
            ApiResponseVM result = new ApiResponseVM()
            {
                IsSuccess = true
            };

            #region 防呆(檢查是否必填、有重複)
            if (string.IsNullOrEmpty(model.Account))
            {
                result.IsSuccess = false;
                result.ErrorMsg += "帳號必填\n";
            }

            if (string.IsNullOrEmpty(model.NickName))
            {
                result.IsSuccess = false;
                result.ErrorMsg += "暱稱必填\n";
            }

            var isExist = _context.Members.Any(x => x.Account == model.Account || x.NickName == model.NickName);
            if (isExist)
            {
                result.IsSuccess = false;
                result.ErrorMsg = "帳號或暱稱已存在，重新輸入\n";
            }

            if (!result.IsSuccess)
            {
                return result;
            }
            #endregion

            Members member = new Members();
            member.Account = model.Account;
            member.Password = model.Password;
            member.NickName = model.NickName;

            _context.Members.Add(member);
            result.IsSuccess = _context.SaveChanges() > 0;

            if (!result.IsSuccess)
            {
                result.ErrorMsg = string.Join(",", _context.GetValidationErrors());
            }

            return result;
        }
    }
}