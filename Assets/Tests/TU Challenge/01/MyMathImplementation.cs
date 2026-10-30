using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TU_Challenge
{
    public class MyMathImplementation
    {
        

        internal static int Add(int a, int b)
        {
            return a + b;
        }

        internal static List<int> GenericSort(List<int> toSort, Func<int, int, bool> isInOrder)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < toSort.Count; i++)
            {
                int min = int.MinValue;
                for (int j = 0; j < toSort.Count; j++)
                {
                    if (!list.Contains(toSort[j]))
                    {
                        if (min == int.MinValue || isInOrder(toSort[j],min))
                        {
                            min = toSort[j];
                        }
                    }
                }
                list.Add(min);
            }
            return list;
            throw new NotImplementedException();
        }

        internal static List<int> GetAllPrimary(int a)
        {
            if (a <= 0)
            {
                throw new ArgumentException("Dear dev WTF");
            }
            var list = new List<int>();
            for (int i = 2; i <= a; i++)
            {
                if (IsPrimary(i))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        internal static bool IsDivisible(int a, int b)
        {
            return a % b == 0;
        }

        internal static bool IsEven(int a)
        {
            return a %2 == 0;
        }

        internal static bool IsInOrder(int a, int b)
        {
            return a <= b;
        }

        internal static bool IsInOrderDesc(int arg1, int arg2)
        {
            return arg1 >= arg2;
            throw new NotImplementedException();
        }

        internal static bool IsListInOrder(List<int> list)
        {
            for(int i = 0; i < list.Count-1; i++)
            {
                if (!IsInOrder(list[i], list[i + 1])){
                    return false;
                }
            }
            return true;
        }

        internal static bool IsMajeur(int age)
        {
            if (age < 0 || age>140) throw new ArgumentException();

            //return age >= 18;
            if (age >= 18) return true; 
            else return false;
        }

        internal static bool IsPrimary(int a)
        { 
            for(int i = 2; i <= Mathf.Sqrt(a); i++)
            {
                if(a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        internal static int Power(int a, int b)
        {
            int result = 1;
            for(int i = 0; i < b; i++)
            {
                result *= a;
            }
            return result;
            throw new NotImplementedException();
        }

        internal static int Power2(int a)
        {
            return a * a;
        }

        internal static List<int> Sort(List<int> toSort)
        {
            //List<int> list = new List<int>();
            /*for (int i = 0; i < toSort.Count; i++)
            {
                int min = int.MinValue;
                for (int j = 0; j<toSort.Count; j++)
                {
                    if (!list.Contains(toSort[j])) {
                        if (min == int.MinValue || min > toSort[j])
                        {
                            min = toSort[j];
                        }
                    }
                }
                list.Add(min);
            }*/
            for(int i = 0; i < toSort.Count-1; i++)
            {
                if (toSort[i] > toSort[i+1])
                {
                    int temp = toSort[i];
                    toSort[i] = toSort[i+1];
                    toSort[i + 1] = temp;
                    for (int j = i; j >0; j--)
                    {
                        if (toSort[j] < toSort[j - 1])
                        {
                            temp = toSort[j-1];
                            toSort[j-1] = toSort[j];
                            toSort[j] = temp;
                        }else
                        {
                            break;
                        }
                    }
                }
            }
            return toSort;
        }
    }
}
