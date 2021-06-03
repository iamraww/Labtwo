using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SinTwo
{
    public class Sin
    {
        public static void SinValidator()
        {
            List<int> number = new List<int>();
            Console.WriteLine("\nEnter 9 digits number: ");
            do
            {
                int addNum;

                try
                {
                    addNum = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please don't enter null\n");
                    return;
                }
                // kiểm tra đủ độ dài của số SIN hay chưa
                if (0 < addNum && addNum <= 9)
                {
                    number.Add(addNum);
                }
                else
                {
                    Console.WriteLine("You exceed number from 1 - 9");
                }
            } while (number.Count <=8);
            // in số SIN
            Console.Write("Your SIN: ");
            foreach (int obj in number)
            {
                Console.Write(obj);
            }
            Console.WriteLine("");
            
            // số ở vị trí chẵn x2
            int chan1 = number[1] * 2;
            int chan2 = number[3] * 2;
            int chan3 = number[5] * 2;
            int chan4 = number[7] * 2;

            // chuyển sang dạng int[so1, so2]
            int[] digit1 = chan1.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            int[] digit2 = chan2.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            int[] digit3 = chan3.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            int[] digit4 = chan4.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            int[] storePair;
            storePair = digit1.Concat(digit2).Concat(digit3).Concat(digit4).ToArray();
            
            // in thử
            // for (int i = 0; i < storePair.Length; i++)
            // {
            //     Console.WriteLine(storePair[i]);
            // }
            // tính tổng các số trong chuỗi storePair
            int totalOfDigit = storePair.Sum();
            
            // in tổng các số ở vị trí chẵn đã nhân 2
            // Console.WriteLine(totalOfDigit);
            
            // tổng các số lẻ
            int leftOverDigits = number[0] + number[2] + number[4] + number[6];

            // chẵn x2 cộng lại + tổng lẻ
            int finalTotal = totalOfDigit + leftOverDigits;

            // tạo ra số i , nếu i x 10 < (chẵn x2 cộng lại + tổng lẻ) thì tăng tiếp, đến khi nào i > thì thôi
            // ví dụ (chẵn x2 cộng lại + tổng lẻ) = 47 thì i = 5 *10 . dừng
            int i = 1;
            int highestInteger = 10;
            while (i * 10 <= finalTotal)
            {
                i++;
            }
            // lấy số highestInteger = 10 * i tạo ra số làm tròn 
            highestInteger *= i;

            // lấy số làm tròn gần nhất trừ tổng rồi kiểm tra phải số SIN hay không
            
            if (highestInteger - finalTotal != number[8])
            {
                Console.WriteLine("This is not a valid SIN.");
            }
            else
            {
                Console.WriteLine("This is a valid SIN.");
            }
            Console.WriteLine("");
        }
    }
}