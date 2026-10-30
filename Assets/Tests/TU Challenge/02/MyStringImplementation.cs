using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.LightTransport;

namespace TU_Challenge
{
    public class MyStringImplementation
    {
        internal static string BazardString(string input)
        {
            string result = "";
            string remain = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result += input[i];
                }else
                {
                    remain+= input[i];
                }       
            }
            return result += remain;
        }

        internal static bool IsNullEmptyOrWhiteSpace(string input)
        {
            if (input == null)
            {
                return true;
            }else
            {
                foreach (char c in input) { 
                    if (!(c==' ')  && !(c == '\0'))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        internal static string MixString(string a, string b)
        {
            if (IsNullEmptyOrWhiteSpace(a) || IsNullEmptyOrWhiteSpace(b) || a == null || b == null) {
                throw new ArgumentException("dear dev why");
            }
            string result = "";
            for (int i=0;i<a.Length; i++) {
                result += a[i];
                if (i < b.Length)
                {
                    result += b[i];
                }
            
            }
            if (a.Length < b.Length) {
                for (int j = a.Length; j < b.Length; j++)
                {
                    result += b[j];
                }
            }
            return result;
        }

        internal static string ToCesarCode(string input, int offset)
        {
            string result = "";
            foreach (char c in input) {
                if (IsNullEmptyOrWhiteSpace(c.ToString()))
                {
                    result += c;
                }
                else
                {
                    int code = (int)c - 97;
                    char cesarChar = (char)(((code + offset) % 26) + 97);
                    result += cesarChar;
                }
            }
            return result;
            throw new NotImplementedException();
        }

        internal static string ToLowerCase(string a)
        {
            string result = "";
            foreach (char c in a)
            {
                if(((int) c >=65 && (int)c <= 90) || ((int)c >= 192 && (int)c <= 223))
                {
                    int AsciiLower = (int)c+ 32;
                    result += (char)AsciiLower;
                }else
                { 
                    result += c;
                }
            }
            return result;
            throw new NotImplementedException();
        }

        internal static string UnBazardString(string input)
        {
            string result = "";
            string remain = "";
            for (int i=input.Length/2; i<input.Length; i++)
            {
                remain += (char) input[i];
            }
            for (int i = 0; i < input.Length/2; i++)
            {
                result +=input[i] ;
                result += remain[i];
            }
            return result;

        }

        internal static string Voyelles(string a)
        {
            string result = "";
            foreach (char c in a)
            {
                if (c=='a' || c=='e' || c=='i' || c=='o' || c=='y' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'Y' || c == 'U')
                {
                    result += c;
                }
            }
            return ToLowerCase(result);
            throw new NotImplementedException();
        }

        internal static string Reverse(string a)
        {
            string result = "";
            for (int i=a.Length-1;i>=0;i--)
            {
                result += a[i];
            }
            return result;

        }
    }
}
