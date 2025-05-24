using System.Collections.Generic;
using SqlSugar;

namespace WPF_BankCustomerSystem.Unilities
{
    public interface IRepository<T, K> where T : class, new() where K : class, new()
    {
        bool Add(T model);
        bool Delete(int primaryKey);
        bool Update(T model);

        List<K> GetList(Expressionable<K> exp);

        List<K> GetListByPage(Expressionable<K> exp, int page, int pageSize, ref int totalCount);

        T GetModel(int primaryKey);
    }
}
