
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomeTask25
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Lesson Tasks
            string[] fullnames = { "Hikmet    Abbas", "Tofiq Qulamov", "Nermin Abbasova", "Hakim Abdullayev" };
            var names = MakeNames(fullnames);
            //{"Hikmet", "Tofiq","Nermin","Hakim"}

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            string[] arr = { "alma", "armud", "Hikmet", "alma", "Abbas", "Hikmet" };

            var newArr = MakeUniqueArr(arr);

            for (int i = 0; i < newArr.Length; i++)
            {
                Console.WriteLine(newArr[i]);
            }
            //{"alma","armud","Hikmet","Abbas"}

            //Verilmis yazini bas herfi boyuk digerleri kicik halda qaytaran metod
            string name = "HIKmeT";
            Capitalize(ref name);//Hikmet
            Console.WriteLine(name);

            string nameInput;
            do
            {
                Console.WriteLine("Adinizi daxil edin:");
                nameInput = Console.ReadLine();

            } while (IsName(nameInput) == false);


            //cosole-da email deyeri istenilsin. Eger deyerde @ xarakteri yoxdursa yeniden istenilsin
            string email;
            do
            {
                Console.WriteLine("Emailinizi daxil edin:");
                email = Console.ReadLine();

            } while (!email.Contains('@'));

            Console.WriteLine(GetDomain(email));

            #endregion

            #region Task 1: Verilmiş yazıda rəqəm olub olmadığını tapan metod
            string txt = "ahagbsjkd1fbdcn jnckjcsnlas";
            Console.WriteLine(IsDigit(txt));
            #endregion

            #region Task 2: Verilmiş yazının fullname olub olmadığını tapan metod(fullname olması üçün iki sozdən ibarət olmalıdır 
            //və hər bir söz böyük hərflə başlayıb kiçik hərflərlə davam etməlidir)
            Console.WriteLine(IsName("Rahim"));
            #endregion

            #region Task 3:  Verilmiş ədədlər siyahısından yeni bir array düzəldib qaytaran metod.Yeni arrayə elementlər 
            //təkrarlanmamaq şərti ilə yerləşdirilsin.
            int[] arr1 = { 1, 5, 3, 6, 4, 6, 8, 45};
            var result = DifArray(arr1);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine((result[i]));
            }
            #endregion

            #region Task 4: Verilmiş email-lər siyahısından domainlər siyahısı düzəldən metod.Domainlər arrayondə təkrar olmamalidir.

            string[] emails = { "Rehim@code.edu.az", "Behruz@Code.az", "Elvin@com.az" };
            var result1 = DomainGmail(emails);
            for(int i = 0; i < result1.Length; i++)
            {
                Console.WriteLine((result1[i]));
            }

            #endregion

            #region Task 5: Verilmiş yazının içindəki cümlələrin sayını tapan metod.

            string txt2 = "Salam. Sabahin xeyir Baku. Baki gozel seherdir. Bakinin gozel menzereleri var. Baki boyuk seherdir.";
            var result4 = CountOfSent(txt2);
            Console.WriteLine(result4);

            #endregion

            
        }



        #region Lesson Tasks

        static string GetDomain(string email)
        {
            //hiko@gmail.com
            var atIndex = email.IndexOf('@');
            var domain = email.Substring(email.IndexOf('@') + 1);

            return domain;
        }

        static void Capitalize(ref string str)
        {
            str = char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        static string[] MakeUniqueArr(string[] arr)
        {
            string[] newArr = new string[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (Array.IndexOf(newArr, arr[i]) == -1)
                {
                    Array.Resize(ref newArr, newArr.Length + 1);
                    newArr[newArr.Length - 1] = arr[i];
                }
            }

            return newArr;
        }

        static string[] MakeNames(string[] arr)
        {
            string[] names = new string[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                var fullname = arr[i].TrimStart();
                var name = arr[i].TrimStart().Substring(0, fullname.IndexOf(' '));
                names[i] = name;
            }

            return names;
        }


        static bool IsName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            if (!char.IsUpper(name[0]))
                return false;

            for (var i = 1; i < name.Length; i++)
            {
                if (!char.IsLower(name[i]))
                    return false;
            }
            return true;
        }
        #endregion

        #region Task 1: Verilmiş yazıda rəqəm olub olmadığını tapan metod
        static bool IsDigit(string txt)
        {

            int[] digit = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < txt.Length; i++)
            {
                for (int j = 0; j < digit.Length; j++)
                {
                    if (txt[i] == digit[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Task 2: Verilmiş yazının fullname olub olmadığını tapan metod(fullname olması üçün iki sozdən ibarət olmalıdır 
        //və hər bir söz böyük hərflə başlayıb kiçik hərflərlə davam etməlidir)
        static bool FullName(string str)
        {
            str = str.Trim();
            var arr = str.Split(' ');
            if (IsName(arr[0]) && IsName(arr[1]))
            {
                return true;

            }
            return false;

        }
        #endregion

        #region Task 3:  Verilmiş ədədlər siyahısından yeni bir array düzəldib qaytaran metod.Yeni arrayə elementlər 
        //təkrarlanmamaq şərti ilə yerləşdirilsin.
        static int[] DifArray(int[] arr)
        {

            int[] newArray = new int[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (Array.IndexOf(newArray, arr[i]) == -1)
                {
                    Array.Resize(ref newArray, newArray.Length + 1);
                    newArray[newArray.Length - 1] = arr[i];
                }
            }

            return newArray;

        }
        #endregion

        #region Task 4: Verilmiş email-lər siyahısından domainlər siyahısı düzəldən metod.Domainlər arrayində təkrar olmamalidir.
        static string[] DomainGmail(string[] emails)
        {

            for (int i = 0; i < emails.Length; i++)
            {
                emails[i] = emails[i].Substring(emails[i].IndexOf('@') + 1);
            }
            var result = new string[0];
            for (int i = 0; i < emails.Length; i++)
            {
                if (Array.IndexOf(result, emails[i]) == -1)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = emails[i];
                }
            }
            return result;

        }
        #endregion

        #region Task 5: Verilmiş yazının içindəki cümlələrin sayını tapan metod.


        static int CountOfSent(string txt2)
        {
            int count = 0; 
            
            for(int i = 0; i < txt2.Length;i++)
            {
                if (txt2[i] == '.' || txt2[i] == '!' || txt2[i] == '?')
                {
                    count++;
                }
            }
            return count;
        }





        #endregion
    }
}
