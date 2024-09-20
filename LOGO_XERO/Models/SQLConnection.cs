using Microsoft.Win32;
using System.Data.SqlClient;
namespace LOGO_XERO.Models
{
    class SQLConnection
    {
        public SqlConnection Conn = new SqlConnection();
        public SQLConnection()
        {

        }
        public void Connect()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\EsbiSetting\\LOGO_XERO");
            string SqlServerName = rk.GetValue("SERVERNAME").ToString();
            string Database = rk.GetValue("DBNAME").ToString();
            string SqlKullanici = rk.GetValue("USERNAME").ToString();
            string SqlPass = rk.GetValue("PASSWORD").ToString();
            string sorgu = $@"Data Source={SqlServerName};uid={SqlKullanici};pwd={SqlPass};database={Database};Connect Timeout=0;";
            Conn = new SqlConnection(sorgu);
        }

    }
}
