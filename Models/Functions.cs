using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MedicalStore.Models
{
    
    public class Functions
    {
        private SqlConnection Con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConString;

        public Functions() {
            ConString = @"Data Source=LAPTOP-HETCHLOR;Initial Catalog=PHARMA;Integrated Security=True";
            Con = new SqlConnection(ConString);
            cmd = new SqlCommand();
            cmd.Connection = Con;
        }

        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConString);
            sda.Fill(dt);
            return dt;
        }

        public int SetData(string Query)
        {
            int cnt=0;
            if(Con.State == ConnectionState.Closed)
                Con.Open();

            cmd.CommandText = Query;
            cnt = cmd.ExecuteNonQuery();
            Con.Close();
            return cnt;

        }

    }
}