using SqlSugar;
using System;
using System.Collections.Generic;
using WPF_BankCustomerSystem.Models;
using WPF_BankCustomerSystem.Models.DTO;
using WPF_BankCustomerSystem.Unilities;

namespace WPF_BankCustomerSystem.Repositories
{
    public class UserInfoRepository : IRepository<UserInfo, ViewUserInfo>
    {
        public bool Add(UserInfo model)
        {
            return SqlSugarHelper.Db.Insertable(model).ExecuteCommand() > 0;
        }

        public bool Delete(int primaryKey)
        {
            var model = SqlSugarHelper.Db.Queryable<UserInfo>().InSingle(primaryKey);
            model.Status = 1;
            model.LastUpdateUserId = LoginInfo.CurrentUser.UserId;
            model.LastUpdateTime = DateTime.Now;
            return SqlSugarHelper.Db.Updateable(model).ExecuteCommand() > 0;
        }

        public List<ViewUserInfo> GetList(Expressionable<ViewUserInfo> exp)
        {
            return SqlSugarHelper.Db.Queryable<ViewUserInfo>().Where(exp.ToExpression()).ToList();
        }

        public List<ViewUserInfo> GetListByPage(Expressionable<ViewUserInfo> exp, int page, int pageSize, ref int totalCount)
        {
            return SqlSugarHelper.Db.Queryable<ViewUserInfo>().Where(exp.ToExpression()).OrderBy("UserId desc").ToPageList(page, pageSize, ref totalCount);
        }

        public UserInfo GetModel(int primaryKey)
        {
            return SqlSugarHelper.Db.Queryable<UserInfo>().InSingle(primaryKey);
        }

        public bool Update(UserInfo model)
        {
            return SqlSugarHelper.Db.Updateable(model).ExecuteCommand() > 0;
        }
    }
}
