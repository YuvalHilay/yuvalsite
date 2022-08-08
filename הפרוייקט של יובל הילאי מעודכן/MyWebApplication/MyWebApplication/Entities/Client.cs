﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using ClassLibraryLibDoQuerise;
using System.Collections;

namespace MyWebApplication.Entities
{
    public class Client
    {
        private int iDClient;
        private int sumOfBuying;
        private string firstName;
        private string lastName;
        private string address;
        private string email;
        private string mobilePhone;
        private string userName;
        private string password;
        private DateTime birthDate;
        public Client()
        {
        }
        public int IDClient
        {
            get { return iDClient; }
            set { iDClient = value; }
        }
        public int SumOfBuying
        {
            get { return sumOfBuying; }
            set { sumOfBuying = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string MobilePhone
        {
            get { return mobilePhone; }
            set { mobilePhone = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        public int ExistByUserNamePassword()
        {
            string strSqlName = "spClientByPassWordUserName";
            ArrayList prmList = new ArrayList();
            prmList.Add(new OleDbParameter("@UserName", this.UserName));
            prmList.Add(new OleDbParameter("@Password", this.Password));
            DataTable dt = DoQueries.GetDataTableByDataReader(Connect.CONNECTION_STRING, strSqlName, prmList);
            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0]["IdClient"].ToString());
            else
                return -1;
        }
        public DataTable GetMyOrders()
        {
            string strSqlName = "spGetMyOrders";
            ArrayList prmList = new ArrayList();
            prmList.Add(new OleDbParameter("@IdClient", this.IDClient));
            DataTable dt = DoQueries.GetDataTableByDataReader(Connect.CONNECTION_STRING, strSqlName, prmList);
            return dt;
        }
               public DataTable GetLevel()
        {
            string strSqlName = "spGetLevelNameByIdClient";
            ArrayList prmList = new ArrayList();
            prmList.Add(new OleDbParameter("@IdClient", this.IDClient));
            DataTable dt = DoQueries.GetDataTableByDataReader(Connect.CONNECTION_STRING, strSqlName, prmList);
            return dt;
        }
               public DataTable GetDiscountByIdClient()
               {
                   string strSqlName = "spGetDiscountByIdClient";
                   ArrayList prmList = new ArrayList();
                   prmList.Add(new OleDbParameter("@IdClient", this.IDClient));
                   DataTable dt = DoQueries.GetDataTableByDataReader(Connect.CONNECTION_STRING, strSqlName, prmList);
                   return dt;
               }
               public DataTable GetDetails()
        {
            string strSqlName = "spClientDetailsByIdClient";
            ArrayList prmList = new ArrayList();
            prmList.Add(new OleDbParameter("@IdClient", this.iDClient));
            DataTable dt = DoQueries.GetDataTableByDataReader(Connect.CONNECTION_STRING, strSqlName, prmList);
            return dt;
        }
        public bool ExistAnotherUserName()
        {
            string strSqlName = "spExistAnotherClientByUserName";
            ArrayList prmList = new ArrayList();
            prmList.Add(new OleDbParameter("@UserName", this.userName));
            prmList.Add(new OleDbParameter("@IdClient", this.iDClient));
            DataTable dt = DoQueries.GetDataTableByDataReader(Connect.CONNECTION_STRING, strSqlName, prmList);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void Update()
        {
            string strSQLName = "spUpdateClient";
            ArrayList prmList = new ArrayList();
            prmList.Add(new OleDbParameter("@FirstName", this.FirstName));
            prmList.Add(new OleDbParameter("@LastName", this.LastName));
            prmList.Add(new OleDbParameter("@Address", this.Address));
            prmList.Add(new OleDbParameter("@Email", this.Email));
            prmList.Add(new OleDbParameter("@MobilePhone", this.MobilePhone));
            prmList.Add(new OleDbParameter("@BirthDate", this.BirthDate));
            prmList.Add(new OleDbParameter("@UserName", this.UserName));
            prmList.Add(new OleDbParameter("@Password", this.Password));
            prmList.Add(new OleDbParameter("@IdClient", this.iDClient));
            ClassLibraryLibDoQuerise.DoQueries.ExecuteSPNonQuery(Connect.CONNECTION_STRING, strSQLName, prmList);
        }
        public bool ExistAnotherEmail()
        {
            string strSqlName = "spExistAnotherClientByEmail";
            ArrayList prmList = new ArrayList();
            prmList.Add(new OleDbParameter("@Email", this.email));
            prmList.Add(new OleDbParameter("@IdClient", this.iDClient));
            DataTable dt = DoQueries.GetDataTableByDataReader(Connect.CONNECTION_STRING, strSqlName, prmList);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool ExistUserName()
        {
            string strSqlName = "spClientExistByUsername";
            ArrayList prmList = new ArrayList();
            prmList.Add(new OleDbParameter("@Username", this.userName));
            DataTable dt = DoQueries.GetDataTableByDataReader(Connect.CONNECTION_STRING, strSqlName, prmList);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static DataTable ClientList()
        {
            string strSqlName = "spClientList";
            DataTable dt = DoQueries.GetDataTableByDataReader(Connect.CONNECTION_STRING, strSqlName);
            return dt;
        }
        public void Insert()
        {
            string strSQLName = "spInsertClient";
            ArrayList prmList = new ArrayList();
            prmList.Add(new OleDbParameter("@FirstName", this.FirstName));
            prmList.Add(new OleDbParameter("@LastName", this.LastName));
            prmList.Add(new OleDbParameter("@Address", this.Address));
            prmList.Add(new OleDbParameter("@Email", this.Email));
            prmList.Add(new OleDbParameter("@MobilePhone", this.MobilePhone));
            prmList.Add(new OleDbParameter("@BirthDate", this.BirthDate));
            prmList.Add(new OleDbParameter("@UserName", this.UserName));
            prmList.Add(new OleDbParameter("@Password", this.Password));
            ClassLibraryLibDoQuerise.DoQueries.ExecuteSPNonQuery(Connect.CONNECTION_STRING, strSQLName, prmList);
        }

    }

    }
