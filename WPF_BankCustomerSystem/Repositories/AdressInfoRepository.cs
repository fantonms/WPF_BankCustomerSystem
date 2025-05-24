using SqlSugar;
using System;
using System.Collections.Generic;
using WPF_BankCustomerSystem.Models;
using WPF_BankCustomerSystem.Models.DTO;
using WPF_BankCustomerSystem.Unilities;

namespace WPF_BankCustomerSystem.Repositories
{
    
        public class AddressInfoRepository : IRepository<AddressInfo, ViewAddressInfo>
        {
            public bool Add(AddressInfo model)
            {
                return SqlSugarHelper.Db.Insertable(model).ExecuteCommand() > 0;
            }

            public bool Delete(int primaryKey)
            {
                var model = SqlSugarHelper.Db.Queryable<AddressInfo>().InSingle(primaryKey);
                model.Status = 1;
                model.LastUpdateUserId = LoginInfo.CurrentUser.UserId;
                model.LastUpdateTime = DateTime.Now;
                return SqlSugarHelper.Db.Updateable(model).ExecuteCommand() > 0;
            }

            public List<ViewAddressInfo> GetList(Expressionable<ViewAddressInfo> exp)
            {
                return SqlSugarHelper.Db.Queryable<ViewAddressInfo>().Where(exp.ToExpression()).ToList();
            }

            public List<ViewAddressInfo> GetListByPage(Expressionable<ViewAddressInfo> exp, int page, int pageSize, ref int totalCount)
            {
                return SqlSugarHelper.Db.Queryable<ViewAddressInfo>().Where(exp.ToExpression()).OrderBy("AddressId desc").ToPageList(page, pageSize, ref totalCount);
            }

            public AddressInfo GetModel(int primaryKey)
            {
                return SqlSugarHelper.Db.Queryable<AddressInfo>().InSingle(primaryKey);
            }

            public bool Update(AddressInfo model)
            {
                return SqlSugarHelper.Db.Updateable(model).ExecuteCommand() > 0;
            }
        }
    
}
