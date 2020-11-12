using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using A3.Models;
using MySql.Data.MySqlClient;

namespace A3.Controllers
{
    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller will access the teachers table of school database.
        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of teachers (first names and last names)
        /// </returns>
        [HttpGet]
        public IEnumerable<Teacher> ListTeachers()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Authors
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop Through Each Row of the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname= (string)ResultSet["teacherlname"];
                string EmployeeNumber = (string)ResultSet["employeenumber"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber= EmployeeNumber;

                //Add the teacher name to the list
                Teachers.Add(NewTeacher);
           
            }
            //Close the connection btw MySQL db and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Teachers;
        }

        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();
            
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers where teacherid = "+id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                string EmployeeNumber = (string)ResultSet["employeenumber"];

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
            }
            return NewTeacher;
        }
        
        //This Controller will access the teachers table of school database.
        /// <summary>
        /// Returns a list of classes a teacher teachers in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListClasses/{TeacherId}</example>
        /// <returns>
        /// A list of classes a teacher teaches
        /// </returns>
        [HttpGet]
        public IEnumerable<Course> ListCourses(int id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "select teachers.teacherid, classid, classname, classcode FROM teachers inner join classes on teachers.teacherid = classes.teacherid where teachers.teacherid =" + id;
            //Question: when I run this query, there is an alert message suggesting my syntax in search query is problematic. 
            //But when I run the query in MySQL, it seems okay. The problem should be either in line 129 or 134.
            //screenshot in 1st layer of the repository-->errormsg.jpg

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Classes
            List<Course> Courses = new List<Course> { };

            //Find courses info for a particular teacher with Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int TeacherId = (int)ResultSet["teacherid"];
                int CourseId = (int)ResultSet["classid"];
                string CourseCode = (string)ResultSet["classcode"];
                string CourseName = (string)ResultSet["classname"];
                

                Course NewCourse = new Course();
                NewCourse.TeacherId = TeacherId;
                NewCourse.CourseCode = CourseCode;
                NewCourse.CourseName = CourseName;
                NewCourse.CourseId = CourseId;

                //Add classes to the list
                Courses.Add(NewCourse);

            }
            //Close the connection btw MySQL db and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Courses;
        }
    }
}
