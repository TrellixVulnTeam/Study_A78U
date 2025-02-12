﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadWriteJson
{
    public partial class Form1 : Form
    {
        const string FILENAME = "Students.json";
        public List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button_read_Click(object sender, EventArgs e)
        {
            string source = File.ReadAllText(FILENAME);
            JObject jsonObjectStudent = JObject.Parse(source);

            //linq 라는 문법 활용
            //리스트에 값을 넣는 하나의 방법

            students = (from item in jsonObjectStudent["students"]["student"]
                        select new Student()
                        {
                            name = item["name"].ToString().Replace("{", "").Replace("}", ""),
                            age = int.Parse(item["age"].ToString().Replace("{", "").Replace("}", "")),
                            hakbeon = item["hakbeon"].ToString().Replace("{", "").Replace("}", "")
                        }).ToList<Student>();

          

            dataGridView1.DataSource = students;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            var jStudentArray = new JArray();

            var jStudentObject = new JObject();

            if (students.Count > 0)
            {
                foreach (var item in students)
                {
                    jStudentObject = new JObject();
                    jStudentObject.Add("name", item.name);
                    jStudentObject.Add("age", item.age);
                    jStudentObject.Add("hakbeon", item.hakbeon);
                    jStudentArray.Add(jStudentObject);
                }
            }

            jStudentObject = new JObject();
            jStudentObject.Add("name", textBox_name.Text);
            jStudentObject.Add("age", textBox_age.Text);
            jStudentObject.Add("hakbeon", textBox_hakbeon.Text);

            jStudentArray.Add(jStudentObject);


            var jStudentArray_object = new JObject();
            jStudentArray_object.Add("student", jStudentArray);

            var jStudents_object = new JObject();
            jStudents_object.Add("students", jStudentArray_object);

            // 만약 특정 폴더 안에 데이터 넣고 싶은데 그 폴더가 없는 경우
            DirectoryInfo di = new DirectoryInfo("jsonData");
            if (!di.Exists)
                di.Create();
            File.WriteAllText(@"jsonData\Students.json", jStudents_object.ToString());


            // 혹은 특정 파일만 생성하고 싶은때
            StreamWriter textfile = File.CreateText("test.txt");
            textfile.Dispose();


            //File.WriteAllText(@"./Students.json", jStudents_object.ToString());


        }
    }
}
