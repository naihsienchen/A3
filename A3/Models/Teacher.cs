using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace A3.Models
{
    public class Teacher
    {
        //The following fields define a Teacher
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string TeacherInfo;
        public string EmployeeNumber;
    

        public bool IsValid()
        {
            bool valid = true;

            if (TeacherFname == null || TeacherLname == null || TeacherInfo == null || EmployeeNumber == null)
            {
                //Base validation to check if the fields are entered.
                valid = false;
            }
            else
            {
                //Validation for fields to make sure they meet server constraints
                if (TeacherFname.Length < 2 || TeacherFname.Length > 255) valid = false;
                if (TeacherLname.Length < 2 || TeacherLname.Length > 255) valid = false;
                //C# email regex 
                //https://stackoverflow.com/questions/5342375/regex-email-validation
                Regex ENumberVal = new Regex(@"(T|t)\d{4}");
                if (!ENumberVal.IsMatch(EmployeeNumber)) valid = false;
            }
            Debug.WriteLine("The model validity is : " + valid);

            return valid;
        }
    }
}