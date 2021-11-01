using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Problem
{
    public class DataAsc
    {

        public DataAsc(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        private string firstname;
        private string lastname;

        public override string ToString()
        {
            return " " + firstname + " " + lastname + "";
        }

    }


    public class DataDsc
    {
        public DataDsc(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        private string firstname;
        private string lastname;

        public override string ToString()
        {
            return " " + firstname + " " + " " + lastname + " ";
        }
    }
   

    public class DataAdress
    {
        public DataAdress(string address)
        {
            this.address = address;
        }
        private string address;


        public override string ToString()
        {
            return " " + address + " ";
        }
    }
}
