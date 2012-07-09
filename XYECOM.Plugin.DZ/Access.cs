namespace XYECOM.Plugin.DZ
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Access 数据库处理类
    /// </summary>
    internal class Access : IDbProvider
    {
        private string _connectionString;
        private string _errorString;

        internal Access()
        {
            this._connectionString = string.Empty;
            this._errorString = string.Empty;
        }

        internal Access(string vDBaseConnectionString)
        {
            this._connectionString = string.Empty;
            this._errorString = string.Empty;
            this._connectionString = vDBaseConnectionString;
        }

        public object vCommand(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure)
        {
            OleDbCommand command = new OleDbCommand();
            command.Connection = new OleDbConnection(this.vDataBaseConnectionString);
            command.CommandText = _vCommandText;
            command.CommandType = _vStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            if ((!object.Equals(_vParameters, null) && (_vParameters.GetUpperBound(0) == 1)) && (_vParameters.Rank == 2))
            {
                for (int i = 0; i <= _vParameters.GetUpperBound(1); i++)
                {
                    if (!object.Equals(_vParameters[0, i], null))
                    {
                        command.Parameters.AddWithValue(_vParameters[0, i].ToString(), _vParameters[1, i]);
                    }
                }
            }
            return command;
        }

        public DataSet vDataSet(string _vCommandText)
        {
            return this.vDataSet(null, _vCommandText, false);
        }

        public DataSet vDataSet(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure)
        {
            DataSet dataSet = new DataSet();
            try
            {
                OleDbCommand selectCommand = (OleDbCommand) this.vCommand(_vParameters, _vCommandText, _vStoredProcedure);
                selectCommand.Connection.Open();
                try
                {
                    new OleDbDataAdapter(selectCommand).Fill(dataSet);
                    this._errorString = string.Empty;
                }
                catch (Exception exception)
                {
                    dataSet = null;
                    this._errorString = exception.Message;
                }
                try
                {
                    selectCommand.Connection.Close();
                    selectCommand.Parameters.Clear();
                    return dataSet;
                }
                catch
                {
                    return dataSet;
                }
            }
            catch (Exception exception2)
            {
                dataSet = null;
                this._errorString = exception2.Message;
            }
            return dataSet;
        }

        public DataTable vDataTable(string _vCommandText)
        {
            return this.vDataTable(null, _vCommandText, false);
        }

        public DataTable vDataTable(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure)
        {
            DataSet objA = this.vDataSet(_vParameters, _vCommandText, _vStoredProcedure);
            if (!object.Equals(objA, null) && (objA.Tables.Count > 0))
            {
                return objA.Tables[0].Copy();
            }
            return null;
        }

        public int vExecuteNonQuery(string _vCommandText)
        {
            return this.vExecuteNonQuery(null, _vCommandText, false);
        }

        public int vExecuteNonQuery(string _vCommandText, out int id)
        {
            return this.vExecuteNonQuery(null, _vCommandText, false, out id);
        }

        public int vExecuteNonQuery(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure)
        {
            int num;
            try
            {
                OleDbCommand command = (OleDbCommand) this.vCommand(_vParameters, _vCommandText, _vStoredProcedure);
                command.Connection.Open();
                try
                {
                    num = command.ExecuteNonQuery();
                    this._errorString = string.Empty;
                }
                catch (Exception exception)
                {
                    num = -1;
                    this._errorString = exception.Message;
                }
                try
                {
                    command.Connection.Close();
                    command.Parameters.Clear();
                    return num;
                }
                catch
                {
                    return num;
                }
            }
            catch (Exception exception2)
            {
                num = -1;
                this._errorString = exception2.Message;
            }
            return num;
        }

        public int vExecuteNonQuery(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure, out int id)
        {
            int num;
            try
            {
                OleDbCommand command = (OleDbCommand) this.vCommand(_vParameters, _vCommandText, _vStoredProcedure);
                command.Connection.Open();
                try
                {
                    this._errorString = string.Empty;
                    num = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT @@IDENTITY;";
                    int.TryParse(command.ExecuteScalar().ToString(), out id);
                }
                catch (Exception exception)
                {
                    num = id = -1;
                    this._errorString = exception.Message;
                }
                command.Connection.Close();
            }
            catch (Exception exception2)
            {
                num = id = -1;
                this._errorString = exception2.Message;
            }
            return num;
        }

        public object vExecuteScalar(string _vCommandText)
        {
            return this.vExecuteScalar(null, _vCommandText, false);
        }

        public object vExecuteScalar(object[,] _vParameters, string _vCommandText, bool _vStoredProcedure)
        {
            object obj2;
            try
            {
                OleDbCommand command = (OleDbCommand) this.vCommand(_vParameters, _vCommandText, _vStoredProcedure);
                command.Connection.Open();
                try
                {
                    obj2 = command.ExecuteScalar();
                    this._errorString = string.Empty;
                }
                catch (Exception exception)
                {
                    obj2 = null;
                    this._errorString = exception.Message;
                }
                try
                {
                    command.Connection.Close();
                    command.Parameters.Clear();
                    return obj2;
                }
                catch
                {
                    return obj2;
                }
            }
            catch (Exception exception2)
            {
                obj2 = null;
                this._errorString = exception2.Message;
            }
            return obj2;
        }

        public string vDataBaseConnectionString
        {
            get
            {
                return this._connectionString;
            }
            set
            {
                this._connectionString = value;
            }
        }

        public string vErrorResultString
        {
            get
            {
                return this._errorString;
            }
        }
    }
}

