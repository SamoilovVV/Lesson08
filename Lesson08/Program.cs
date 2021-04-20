using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Lesson08.Extensions;

namespace Lesson08
{
    class Program
    {
        static void Main(string[] args)
        {
            //CatchAllErrors();
            //CatchSpecificError();
            //CatchSpecificErrorWithCondition();
            //ExceptionProps();

            //CatchCustomExceptions();
            //try
            //{
            //    CatcherInTheRye();
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.InnerException?.Message);
            //}


            //int i =UsingLocalFunction();
            //Console.WriteLine(i);
            //int j =TestFuncDelegate();
            //Console.WriteLine(j);
            //int k = UsingStaticLocalFunction();
            //Console.WriteLine(k);
            //UsingPartialClasses();
            //UsingPartialMethods();
            //UsingExtensionMethods();

            // LifeWithoutLINQ();
            // LifeWithLINQ();
            //LifeWithLinqExtensionMethods();
            //UsingLinq();

            //UsingReflection();
            //GetMethodsViaReflection();
            //GetPropertiesAndFieldsViaReflection();
            //UsingAttributes();
            //UsingReflectionForAssemblyLoad();

            //UsingDynamic();
            //UsingDynamic2();

            //UsingGarbageCollector();
            //UsingDestructors();
            //UsingDisposables();
            //UsingDisposables2();
            //UsingDisposables3();
            //UsingDisposables4();
            WorkingWithUnsafeCode();

            Console.ReadKey();
        }

        public static void CatchAllErrors()
        {
            try
            {
                int x = 4;
                int y = 0;
                int result = x / y;
                Console.WriteLine($"Результат: {result}");
            }
            catch
            {
                Console.WriteLine("Возникло исключение!");
            }
            finally
            {
                Console.WriteLine("Блок finally");
            }

            Console.WriteLine("Конец программы");
        }

        public static void CatchSpecificError()
        {
            try
            {
                int x = 4;
                int y = 0;
                int result = x / y;
                Console.WriteLine($"Результат: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}:{ex.StackTrace}");
            }
        }

        public static void CatchSpecificErrorWithCondition()
        {
            int x = 4;
            int y = 0;
            try
            {
                int result = x / y;
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception) when (y == 0)
            {
                Console.WriteLine("y не должен быть равен 0");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void ExceptionProps()
        {
            int x = 4;
            int y = 0;
            try
            {
                int result = x / y;
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение {ex.Message}");
                Console.WriteLine($"Метод {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека {ex.StackTrace}");
                Console.WriteLine($"Источник: {ex.Source}");
            }
        }

        public static void CatchCustomExceptions()
        {
            try
            {
                Person p = new Person("Вася", -20);
            }
            catch (PersonException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static void CatcherInTheRye()
        {
            try
            {
                var person = CreatePerson("Вася", -20);
            }
            catch (PersonArgumentException ex)
            {
                Console.WriteLine(ex);
                throw; // Пробрасываем исключение выше по CallStack
                // throw new PersonException(ex.Message, ex); // Выбрасываем новое исключение
                // throw ex; // Don't do like this
            }
        }

        private static Person CreatePerson(string name, int age)
        {
            try
            {
                var person = new Person(name, age);
                return person;

            }
            catch (PersonException ex)
            {
                Console.WriteLine(ex.Message);
                throw new PersonArgumentException("Неверный аргумент!", age);
            }

        }

        static int UsingLocalFunction()
        {
            var numbers = new int[] { -3, -2, -1, 0, 1, 2, 3 };

            int limit = 0;
            // локальная функция
            bool IsMoreThan(int number)
            {
                return number > limit;
            }

            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsMoreThan(numbers[i]))
                {
                    result += numbers[i];
                }
            }

            return result;
        }

        static int TestFuncDelegate()
        {
            var numbers = new int[] { -3, -2, -1, 0, 1, 2, 3 };

            int limit = 0;
            // делегат
            Func<int, bool> IsMoreThan = delegate (int number)
             {
                 return number > limit;
             };

            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsMoreThan(numbers[i]))
                {
                    result += numbers[i];
                }
            }

            return result;
        }

        static int _limit = 0;

        static int UsingStaticLocalFunction()
        {
            var numbers = new int[] { -3, -2, -1, 0, 1, 2, 3 };

            int n = 0;
            // статическая локальная функция
            static bool IsMoreThan(int number)
            {
                return number > _limit;
            }

            int result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsMoreThan(numbers[i]))
                    result += numbers[i];
            }
            return result;
        }

        public static void UsingExtensionMethods()
        {
            string s = "Привет мир!";
            int vowelsCount = s.NumberOfVowels();
            //int vowelsCount = StringExtension.NumberOfVowels(s);

            Console.WriteLine($"Колическтво гласных в {s}: {vowelsCount}");

            char c = 'и';
            int iCount = s.CharCount(c);
            Console.WriteLine($"Количество символов {c} в строке {s}: {iCount}");

            //StringExtension.IndexOf(s, c);
        }

        public static void UsingPartialClasses()
        {
            Account account = new Account(100);

            account.Put(50);
            Console.WriteLine(account.CurrentSum);

            account.Take(25);
            Console.WriteLine(account.CurrentSum);
        }

        public static void UsingPartialMethods()
        {
            Account account = new Account(100);

            account.DoSomething();
        }

        public static void LifeWithoutLINQ()
        {
            var names = new List<string> { "Вася", "Петя", "Маша", "Гена", "Юля", "Вадим" };

            var selectedNames = new List<string>();
            foreach (string s in names)
            {
                if (s.ToUpper().StartsWith("В"))
                    selectedNames.Add(s);
            }
            selectedNames.Sort();

            foreach (string s in selectedNames)
            {
                Console.WriteLine(s);
            }
        }

        public static void LifeWithLINQ()
        {
            var names = new List<string> { "Вася", "Петя", "Маша", "Гена", "Юля", "Вадим" };
            //SELECT Name FROM TABLE WHERE N > 1
            var selectedNames = from n in names // определяем каждый объект из names как n
                                where n.ToUpper().StartsWith("В") //фильтрация по критерию
                                orderby n  // упорядочиваем по возрастанию
                                select n; // выбираем объект
            
            foreach (string s in selectedNames)
            {
                Console.WriteLine(s);
            }
        }

        public static void LifeWithLinqExtensionMethods()
        {
            var names = new List<string> { "Вася", "Петя", "Маша", "Гена", "Юля", "Вадим" };

            IEnumerable<string> selectedNames = names
                .Where(n => n.ToUpper().StartsWith("В")).OrderBy(n => n);

            foreach (string s in selectedNames)
            {
                Console.WriteLine(s);
            }
        }

        public static void UsingLinq()
        {
            var names = new List<string> { "Вася", "Петя", "Маша", "Гена", "Юля", "Вадим" };

            //if (names.Count == 0)
            //{ }
            //if (names.Any())
            //{ }

            //if (names.Any(n => n.StartsWith("П"))) // Проверка наличия имён на П
            //{
            //    foreach (string s in names)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}


            //var name = names.First(n => n.StartsWith("П"));
            //Console.WriteLine(name);
            //var lastName = names.Last();
            //Console.WriteLine(lastName);

            //var teams = new List<string>();

            //var team = teams.FirstOrDefault();
            //var lastTeam = teams.LastOrDefault();
            //if (string.IsNullOrEmpty(team) && lastTeam == null)
            //{
            //    Console.WriteLine("Мы за безопасные методы");
            //}

            //var persons = new List<User>
            //{
            //    new User("Вася", 21),
            //    new User("Петя", 23),
            //    new User("Вадим", 22),
            //    new User("Вася", 18),
            //    new User("Петя", 22),
            //    new User("Маша", 23),
            //    new User("Настя", 23),
            //};

            //// Метод Select преобразует коллекцию одного типа в другой:

            //foreach (var p in persons)
            //{
            //    Console.WriteLine($"{p.Name}: {p.Age}");
            //}

            //IEnumerable<string> userNames = persons.Select(p => p.Name);
            //foreach (string s in userNames)
            //{
            //    Console.WriteLine(s);
            //}

            //var sortedPersons = persons.OrderBy(p => p.Name).ThenBy(p => p.Age);
            //foreach (var p in sortedPersons)
            //{
            //    Console.WriteLine($"{p.Name}: {p.Age}");
            //}

            var ints = new int[] { 3, 5, 2, 1, 4, 3, 5, 2, 1, 6, 9 };
            var distinctInts = ints.Distinct();
            foreach (int i in distinctInts)
            {
                Console.Write(i);
                Console.Write(", ");
            }
            Console.Write("\n");

            int maxValue = ints.Max();
            Console.WriteLine(maxValue);

            double averageValue = ints.Average();
            Console.WriteLine(averageValue);
        }

        public static void UsingDynamic()
        {
            dynamic x = 3; // здесь x - int
            Console.WriteLine(x);

            x = "Привет мир"; // x - строка
            Console.WriteLine(x);

            x = new Person() { Name = "Вася", Age = 23 }; // x - объект Person
            Console.WriteLine(x);
        }

        public static void UsingDynamic2()
        {
            dynamic person1 = new DynamicPerson() { Name = "Вася", Age = 27 };
            Console.WriteLine(person1);
            Console.WriteLine(person1.GetSalary(28.09, "int"));

            dynamic person2 = new DynamicPerson() { Name = "Петя", Age = "Двадцать два года" };
            Console.WriteLine(person2);
            Console.WriteLine(person2.GetSalary(30, "string"));
        }

        public static void UsingReflection()
        {
 
            Type userType = typeof(User);
            Console.WriteLine(userType);

            User user = new User("Вася", 20);
            Type userType2 = user.GetType();
            Console.WriteLine(userType2);

            Type myType = Type.GetType("Lesson08.User", throwOnError:false, ignoreCase:true);
            Console.WriteLine(myType);

            string nameofUser = nameof(User);
            Console.WriteLine(nameofUser);
        }

        public static void GetMethodsViaReflection()
        {
            Type myType = typeof(User);

            Console.WriteLine("Методы:");
            foreach (MethodInfo method in myType.GetMethods())
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual";
                Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");
                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }

        public static void GetPropertiesAndFieldsViaReflection()
        {
            Type myType = typeof(User);

            Console.WriteLine("Поля:");
            foreach (FieldInfo field in myType.GetFields())
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
            }

            Console.WriteLine("Свойства:");
            foreach (PropertyInfo prop in myType.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }
        }

        public static void UsingReflectionForAssemblyLoad()
        {
            Assembly asm = Assembly.LoadFrom(@"C:\Users\samoi\Documents\Dropbox\Public\C_sharp_courses_2021\Lesson07\Lesson07\bin\Debug\net5.0\UsingDelegates.dll");

            Console.WriteLine(asm.FullName);

            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t.Name);
            }
        }

        public static void UsingAttributes()
        {
            User user1 = new User("Вася", 35);
            bool isUser1Valid = ValidateUser(user1);
            Console.WriteLine($"Результат валидации {user1.Name}: {isUser1Valid}");

            User user2 = new User("Петя", 16);
            bool isUser2Valid = ValidateUser(user2);
            Console.WriteLine($"Результат валидации {user2.Name}: {isUser2Valid}");

            User user3 = new User("Маша", 17);
            bool isUserAgeValid = ValidateUserAge(user3);
            Console.WriteLine($"Результат валидации возраста {user3.Name}: {isUserAgeValid}");
        }

        private static bool ValidateUser(User user)
        {
            Type t = typeof(User);
            object[] attrs = t.GetCustomAttributes(false);
            foreach (AgeValidationAttribute attr in attrs)
            {
                if (attr != null)
                return (user.Age >= attr.Age); 
            }
            return true;
        }

        private static bool ValidateUserAge(User user)
        {
            Type t = typeof(User);
            var ageProp = t.GetProperty(nameof(User.Age));
            var attrs = ageProp.GetCustomAttributes(typeof(AgeValidationAttribute), false);
            foreach(AgeValidationAttribute att in attrs)
            {
                int age = (int)ageProp.GetValue(user);
                return age >= att.Age;
            }

            return true;
        }

        public static void UsingGarbageCollector()
        {
            long totalMemory = GC.GetTotalMemory(false);
            Console.WriteLine($"Сборщик мусора использует {totalMemory} байт");

            // Принудительная сборка мусора
            GC.Collect(); 

            totalMemory = GC.GetTotalMemory(false);
            Console.WriteLine($"Сборщик мусора использует {totalMemory} байт");

            // Приостановка текущего потока до окончания сборки мусора
            GC.WaitForPendingFinalizers();
        }

        public static void UsingDestructors()
        {
            CreatePerson();
            GC.Collect();
        }

        private static void CreatePerson()
        {
            var person = new FinalizingPerson("Вася", 22);
            Console.WriteLine(person.Name);
        }

        public static void UsingDisposables()
        {
            DisposablePerson person = null;
            try
            {
                person = new DisposablePerson { Name = "Вася", Age = 22 };
                Console.WriteLine(person);
            }
            finally
            {
                if (person != null)
                {
                    person.Dispose();
                }
            }
        }

        public static void UsingDisposables2()
        {
            using (DisposablePerson person = new DisposablePerson { Name="Вася", Age=22})
            {
                Console.WriteLine(person);
            };

        }

        public static void UsingDisposables3()
        {
            using (DisposablePerson person = new DisposablePerson { Name = "Вася", Age = 22 })
            {
                Console.WriteLine(person);
                using (DisposablePerson anotherPerson = new DisposablePerson { Name = "Петя", Age = 22 })
                {
                    Console.WriteLine(anotherPerson);//

                };
            };
        }

        public static void UsingDisposables4()
        {
            using var person = new DisposablePerson { Name = "Вася", Age = 22 };

            Console.WriteLine(person);
        }

        unsafe static void WorkingWithUnsafeCode()
        {
            int* x; // определение указателя
            int y = 10; // определяем переменную

            x = &y; // указатель x теперь указывает на адрес переменной y
            Console.WriteLine(*x); // 10

            y = y + 20;
            Console.WriteLine(*x);// 30

            *x = 50;
            Console.WriteLine(y); // переменная y=50
        }

    }
}
