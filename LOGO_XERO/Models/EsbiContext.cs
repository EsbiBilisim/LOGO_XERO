using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Models
{
    class EsbiContext
    {
        public SqlConnection Conn = new SqlConnection();
        public EsbiContext()
        {

        }
        public void Connect()
        {
            string sorgu = $@"Data Source=10.0.54.31;uid=sa;pwd=523411246*;database=LOGO;Connect Timeout=0;";
            Conn = new SqlConnection(sorgu);
        }
    }
}
