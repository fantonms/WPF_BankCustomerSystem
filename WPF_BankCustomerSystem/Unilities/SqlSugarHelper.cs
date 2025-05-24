using System;
using SqlSugar;

namespace WPF_BankCustomerSystem.Unilities
{
    public static class SqlSugarHelper
    {
        private static ConnectionConfig connectionConfig = new ConnectionConfig()
        {
            ConnectionString = "server=.;database=BankSystem;uid=sa;pwd=123456;",//连接符字串
            DbType = DbType.SqlServer,//数据库类型
            IsAutoCloseConnection = true //不设成true要手动close
        };
        private static Action<SqlSugarClient> ConfigAction()
        {
            return db =>
            {
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Console.WriteLine(UtilMethods.GetNativeSql(sql, pars));

                };
            };
        }
        public static SqlSugarClient Db = new SqlSugarClient(connectionConfig, ConfigAction());

    }
}
