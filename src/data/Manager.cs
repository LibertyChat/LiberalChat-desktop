using System.Data.SQLite;
using Microsoft.Extensions.Logging;

namespace LiberalChat_desktop.src.data
{
    internal class Manager
    {
        //Data
        private SQLiteConnection? Connection;
        private string DefaultDBFilePath = "~/LiberalChatData/data.db";
        private string TestDBFilePath = "data.db";

        private static LoggerFactory? loggerFactory=null;
        private ErrorMessage.ErrorMessage? logger = new ErrorMessage.ErrorMessage(loggerFactory);

        public void NewDBFile(string DBPath)
        {
            try
            {
                SQLiteConnection.CreateFile(DBPath);
            }
            catch (Exception ex)
            {
                logger.SendMessageError(string.Format("Create a new database file name:" + DBPath + "\nError message：" + ex.Message));
            }
        }
        public Boolean ConnectDB(string ConnectConfig)
        {
            try
            {
                Connection = new SQLiteConnection(ConnectConfig);
                Connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void CloseDB()
        {
            Connection?.Close();
        }
    }
}
