﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test0407
{
    class Test0407
    {
        static void Main(string[] args)
        {
            //10진수를 입력받아 2진수로 출력하는 프로그램
            //1.입력받는 값의 범위는 1~65535까지
            //2.int 배열크기를 16으로 사용하여 한개의 공간에
            // 이진수 0,1 저장
            //3. 10진수값을 이진수로 변경할때 비트 범위에 맞게 출력
            //--> 8을 입력하면 00001000, 255를 입력하면 11111111
            //--> 256입력 0000000100000000
            //--> 65535입력 1111111111111111
            
            
            //Console.Write("정보입력 : ");            
            //string str = Console.ReadLine();
            //int num = Convert.ToInt32(str);


            Console.Write("숫자 입력 : ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            int b = 0;
            int d = 0;
            int[] a = new int[16];

            if (n < 256)
            {
                while (b < a.Length-8)
                {
                    a[b] = n % 2;
                    n /= 2;
                    b++;
                }
                for (int i = (a.Length-8) - 1; i >= 0; i--)
                {
                    Console.Write(a[i]);
                }
            }else if(n<=65535)
            {  
                while (d < a.Length)
                {
                   a[d] = n % 2;
                    n /= 2;
                    d++;
                }
                for (int j = a.Length - 1; j >= 0; j--)
                {
                    Console.Write(a[j]);
                }
            }           
             
        }

    }
}
