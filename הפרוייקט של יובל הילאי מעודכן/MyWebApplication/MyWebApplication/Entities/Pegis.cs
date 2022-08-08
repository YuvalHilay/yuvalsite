using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using ClassLibraryLibDoQuerise;
using System.Collections;
using System.Drawing;

namespace MyWebApplication.Entities
{
    public class Pegis
    {
        private int idPegi;
        private Image Pegiimage;


        public int IdPegi
        {
            get { return idPegi; }
            set { idPegi = value; }
        }
        public Image PegiImage
        {
            get { return Pegiimage; }
            set { Pegiimage = value; }
        }
        public static DataTable PegisList()
        {
            string strSqlName = "spViewPegis";
            DataTable dt = DoQueries.GetDataTableByDataReader(Connect.CONNECTION_STRING, strSqlName);
            return dt;
        }
    }
}