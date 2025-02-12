﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test0408
{
    class Car
    {
        public const string JIJUM = "동대구영업소";
        private string model;
        private string color;
        private string company;
        private string price;

        public Car() { }

        public Car(string model, string color, 
            string company, string price)
        {
            this.model = model;
            this.color = color;
            this.company = company;
            this.price = price;
        }
        
        
        //public void setModel(string model)
        //{
        //    this.model = model;
        //}
        //public string getModel()
        //{
        //    return model;
        //}
        public string Model { get => model; set => model = value; }
        public string Color { get => color; set => color = value; }
        public string Company { get => company; set => company = value; }
        public string Price { get => price; set => price = value; }

        public void printInfoCar()
        {
            Console.WriteLine("모델 : " + Model);
            Console.WriteLine("제조사 : " + company);
            Console.WriteLine("색상 : " + color);
            Console.WriteLine("가격 : " + price);
            Console.WriteLine("--------------------");
        }

        public override string ToString()
        {
            string str = "모델 : " + model + "\n";
            str += "제조사 : " + company + "\n";
            str += "색상 : " + color + "\n";
            str += "가격 : " + price + "\n";
            return str;
        }
    }
}
