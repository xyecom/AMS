namespace XYECOM.Plugin.DZ
{
    using System;
    using System.Data;
    using System.Runtime.InteropServices;

    /// <summary>
    /// 数据处理接口
    /// </summary>
    internal interface IDbProvider
    {
        object vCommand(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure);
        DataSet vDataSet(string _vCommandText);
        DataSet vDataSet(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure);
        DataTable vDataTable(string _vCommandText);
        DataTable vDataTable(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure);
        int vExecuteNonQuery(string _vCommandText);
        int vExecuteNonQuery(string _vCommandText, out int id);
        int vExecuteNonQuery(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure);
        int vExecuteNonQuery(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure, out int id);
        object vExecuteScalar(string _vCommandText);
        object vExecuteScalar(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure);

        string vDataBaseConnectionString { get; set; }

        string vErrorResultString { get; }
    }
}

