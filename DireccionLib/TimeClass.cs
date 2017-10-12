using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DireccionLib;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DireccionLib
{
    public class TimeClass
    {
        private string hour;
        private string date;
        private int hourint;
        private int yearint;
        private int age;

        public TimeClass() { }

        public int AutomaticAgeReturn(int yearoutside)
        {
            int now = DateTime.Now.Year;
            age = now - yearoutside;
            return age; 
        }
        
        public string clockshape() {
            hour = Convert.ToString(DateTime.Now.ToLongTimeString());
            return hour;
        }

        public string clockshapeshort()
        {
            hour = Convert.ToString(DateTime.Now.ToShortTimeString());
            return hour;
        }


        public string dateshape() {
            date = Convert.ToString(DateTime.Now.ToShortDateString());
            return date;
        }

        public int inthour() {
            hourint = Convert.ToInt32(DateTime.Now.Hour);
            return hourint;
        }

        public int intyear() {
            yearint = Convert.ToInt32(DateTime.Now.Year);
            return yearint;
        }

        
    }
}
