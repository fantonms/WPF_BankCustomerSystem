using SqlSugar;
using System;
using System.Collections.Generic;
using WPF_BankCustomerSystem.Models;
using WPF_BankCustomerSystem.Models.DTO;
using WPF_BankCustomerSystem.Unilities;

namespace WPF_BankCustomerSystem.Repositories
{
    public class CustomerInfoRepository : IRepository<CustomerInfo, ViewCustomerInfo>
    {
        public bool Add(CustomerInfo model)
        {
            return SqlSugarHelper.Db.Insertable(model).ExecuteCommand() > 0;
        }

        public bool Delete(int primaryKey)
        {
            var model = SqlSugarHelper.Db.Queryable<CustomerInfo>().InSingle(primaryKey);
            model.Status = 1;
            model.LastUpdateUserId = LoginInfo.CurrentUser.UserId;
            model.LastUpdateTime = DateTime.Now;
            return SqlSugarHelper.Db.Updateable(model).ExecuteCommand() > 0;
        }

        public List<ViewCustomerInfo> GetList(Expressionable<ViewCustomerInfo> exp)
        {
            return SqlSugarHelper.Db.Queryable<ViewCustomerInfo>().Where(exp.ToExpression()).ToList();
        }

        public List<ViewCustomerInfo> GetListByPage(Expressionable<ViewCustomerInfo> exp, int page, int pageSize, ref int totalCount)
        {
            return SqlSugarHelper.Db.Queryable<ViewCustomerInfo>().Where(exp.ToExpression()).OrderBy("CustomerId desc").ToPageList(page, pageSize, ref totalCount);
        }

        public CustomerInfo GetModel(int primaryKey)
        {
            return SqlSugarHelper.Db.Queryable<CustomerInfo>().InSingle(primaryKey);
        }

        public bool Update(CustomerInfo model)
        {
            return SqlSugarHelper.Db.Updateable(model).ExecuteCommand() > 0;
        }
    }
}
