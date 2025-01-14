﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleApp.Extension;
using System.Collections;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp
{
    public class Programs
    {
        public static void Main(string[] args)
        {
            var res = "N";
            do
            {
                //CastingExample();
                //ConditionalStatementExample();
                //ArrayExample();
                //LoopingStatements();
                //LoopingStatementsV2();
                //LoopingStatementV3();
                //ClassesExample();
                //PropertiesExample();
                //OperatorOverloadingExample();
                //IndexerExample();
                //StaticAndNonStaticExample();
                //InheritanceExample();
                //PolymorphismExample();
                //ExtensionExample();
                //ComplexModel();
                //ShapesImplementation();
                //InterfaceExample();
                //CustomStackImplementation();
                //CustomStackImplementationV2();
                //CustomQueueImplementation();
                //TemplateImplemenation();
                //CollectionExamples();
                //LinqExamples();
                //LinqExampleV2();
                //PassByExamples();
                //DelegateExample();
                //MultiThreadedExample();
                FileIOExample();
                Console.Write("Do you want to continue more (y/n)? ");
                res = Console.ReadLine();
            } while (res.ToUpper() == "Y");

            Console.ReadLine();
        }

        private static void FileIOExample()
        {
            string FileName = "D:\\Projects\\Broadway\\430PM_Broadway\\ConsoleApp\\ConsoleApp.sln";
            //var file = File.ReadAllText(FileName);
            //Console.WriteLine(file);
            //Console.WriteLine("Enter any text");
            //var str = Console.ReadLine();
            //// File.AppendAllText(FileName, str);

            //var writeStream = new FileStream(FileName, FileMode.Append, FileAccess.Write);
            //var strBytes = System.Text.Encoding.ASCII.GetBytes(str);
            //writeStream.Write(strBytes, 0, strBytes.Length);
            //writeStream.Flush();
            //writeStream.Close();

            var dirName = "D:\\";
            var dirInfo = new DirectoryInfo(dirName);
            foreach (var item in dirInfo.GetDirectories())
            {
                Console.WriteLine($"{item.Name}\t{item.CreationTime.ToString("MM_dd_yyyy")}\t{item.Attributes}");
            }
            foreach (var item in dirInfo.GetFiles())
            {
                Console.WriteLine($"{item.Name}\t{item.CreationTime.ToString("MM_dd_yyyy")}\t{item.Attributes}\t{item.Length} bytes");
            }

            //  var path = Path.GetDirectoryName(FileName);
            Console.WriteLine($"Directory => {Path.GetDirectoryName(FileName)}");
            Console.WriteLine($"File => {Path.GetFileName(FileName)}");
            Console.WriteLine($"Extension => {Path.GetExtension(FileName)}");

            var tempFolder = Path.GetTempPath();
            var folder = Path.Combine(tempFolder, "abc");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var file = Path.Combine(folder, "abc.txt");
            if (!File.Exists(file))
            {
                File.Create(file);
            }
            File.WriteAllText(file, "This is our content");
            var picture = "C:\\Users\\Chand\\Pictures\\Network.jpg";
            var destination = "D:\\Copied";
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            var destFile = Path.Combine(destination, Path.GetFileName(picture));
            File.Copy(picture, destFile);
        }

        private static async void MultiThreadedExample()
        {
            TaskTwo();
            //Thread t1 = new Thread(FunctionA);
            //Thread t2 = new Thread(()=> {
            //});
            //t1.Start();
            //t2.Start();
            ct = new CancellationTokenSource();
            Task taskOne = new Task(() =>
           {
               TaskOne();
           }, ct.Token);

            //Task taskTwo = new Task(() =>
            //{
            //    TaskTwo();
            //}, ct.Token);

            //  taskOne.ContinueWith(async a => { await TaskTwo(); }, TaskContinuationOptions.OnlyOnCanceled);
            //  taskTwo.Start();
            // taskOne.Start().;
            //Task.Factory.StartNew(async () =>
            //{
            //    await TaskOne();
            //}, ct.Token)
            //    .ContinueWith(async p => { await TaskTwo(); }, ct.Token, TaskContinuationOptions., TaskScheduler.Current);
            var task = await TaskOne();

            ct.CancelAfter(5000);
        }

        private static CancellationTokenSource ct = new CancellationTokenSource();

        public static async Task<int> TaskOne()
        {
            for (int i = 0; i < 20; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }
                Console.WriteLine($"{DateTime.Now } => Task One =>{i}");
                await Task.Delay(500);
            }

            return 0;
        }

        public static async Task<int> TaskTwo()
        {
            for (int i = 0; i < 10; i++)
            {
                //  ct.Token.ThrowIfCancellationRequested();

                Console.WriteLine($"{DateTime.Now } => Task Two =>{i}");
                // await Task.Delay(1500);
            }

            return 1;
        }

        private static void FunctionA()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{DateTime.Now } => Function A =>{i}");
                Thread.Sleep(500);
            }
        }

        private static void FunctionB()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{DateTime.Now } => Function B =>{i}");
                Thread.Sleep(1500);
            }
        }

        private static void FunctionToRun(int x, int y)
        {
            Console.WriteLine("I am running externally");
        }

        private static void DelegateExample()
        {
            Delegs d1 = new Delegs();
            d1.MathEvent += FunctionToRun;
            d1.Implementation();
            d1.MathEvent -= FunctionToRun;
            d1.Implementation();
        }

        private static void PassByExamples()
        {
            int a = 10;
            int b = 20;
            Console.WriteLine($"a = {a}, b = {b}");
            PassBy.Increase(a, b);
            Console.WriteLine($"a = {a}, b = {b}");
            PassBy.Increase(ref a, ref b);
            PassBy.Increase(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");
            int x = 0;
            PassBy.Increase(a, b, out x);
        }

        private static void LinqExampleV2()
        {
            var data = StudentData.GenerateDummyData();
            var total = data.Subjects.Sum(p => p.Marks);

            //Console.WriteLine(total);
            var list1 = StudentData.GenerateDummySubjects();
            var list2 = StudentData.GenerateDummySubjectsV2();

            var newList = (
                from l1 in list1 join l2 in list2 on l1.Name equals l2.Name select new SubjectModelNew { Name = l1.Name, Exam1 = l1.Marks, Exam2 = l2.Marks }
                ).ToList();
            var lists = list1.Skip(2).Take(3);
            //var listnew=list1.Join(list2,p=>p.Name,x=>x.Name,y=>new SubjectModelNew { Name= p })

            foreach (var item in newList)
            {
                Console.WriteLine($"Subject : {item.Name}\tExam1 : {item.Exam1}\tExam2 : {item.Exam2}");
            }
        }

        private static void LinqExamples()
        {
            List<string> list = new List<string>();
            list.Add("January");
            list.Add("February");
            list.Add("March");
            list.Add("April");
            list.Add("May");
            list.Add("June");
            list.Add("July");
            list.Add("August");
            list.Add("September");
            list.Add("October");
            list.Add("November");
            list.Add("December");

            var newList = (
                from l in list select l.Substring(0, 3)
                ).ToList();
            var listNew = list.Where(x => x.StartsWith("J")).Select(l => l.Substring(0, 3)).ToList();

            var groupedData = list.GroupBy(p => p.Substring(0, 1));

            foreach (var item in listNew)
            {
                Console.WriteLine(item);
            }
        }

        private static void CollectionExamples()
        {
            //int i = 10;
            //object obj = i;
            //obj = "";
            //object[] a = new object[5];
            //a[0] = "";
            //a[1] = 10;

            ArrayList al = new ArrayList();
            al.Add(10);
            al.Add("Chandan");
            al.Add(new LivingThings());
            var t = al[1];

            SortedList l = new SortedList();
            l.Add(2, "Chandan");
            l.Add(1, "Chandan");
            l.Add(-1, "Chandan");

            List<int> intList = new List<int>();
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);
            intList.Add(20);
            intList.Add(50);
            intList.Add(20);

            Dictionary<int, string> dict = new Dictionary<int, string>();
        }

        private static void TemplateImplemenation()
        {
            var template = new TemplateOne<Apes, Apes>();
            template.DisplayType();
            //template.GetInput()
            NonTemplatedClass.TemplatedFunction<Square, Man>(new Square(), new Man());
        }

        private static void CustomQueueImplementation()
        {
            CustomQueue cq = new CustomQueue();
            cq.Enqueue(10);
            cq.Enqueue(15);
            cq.Enqueue(20);
            cq.Enqueue(25);
            Console.WriteLine("After enqueuing 4 items");
            cq.DisplayAll();
            cq.Dequeue();
            Console.WriteLine("After dequeuing 1 item");
            cq.DisplayAll();
            cq.Enqueue(30);
            cq.Enqueue(35);
            Console.WriteLine("After enqueuing 2 items");
            cq.DisplayAll();
            cq.Dequeue();
            Console.WriteLine("After dequeuing 1 item");
            cq.DisplayAll();
        }

        private static void TemplatedCustomStackImplementation()
        {
            CustomStackV2Templated<int> csInt = new CustomStackV2Templated<int>();
            csInt.Push(10);
            CustomStackV2Templated<string> csString = new CustomStackV2Templated<string>();
            csString.Push("Bibash");
        }

        private static void CustomStackImplementationV2()
        {
            CustomStackV2 cs = new CustomStackV2();
            cs.Push(10);
            cs.Push(4);
            Console.WriteLine("After pushing 2 items");
            cs.DisplayAll();
            cs.Pop();
            Console.WriteLine("After popping 1 item");
            cs.DisplayAll();
            cs.Push(20);
            cs.Push(24);
            cs.Push(23);
            cs.Push(54);
            cs.Push(45);
            cs.Push(20);
            cs.Push(24);
            cs.Push(23);
            cs.Push(54);
            cs.Push(45);
            cs.Push(20);
            cs.Push(24);
            cs.Push(23);
            cs.Push(54);
            cs.Push(45);
            cs.Push(20);
            cs.Push(24);
            cs.Push(23);
            cs.Push(54);
            cs.Push(45);
            Console.WriteLine("After pushing 5 items");
            cs.DisplayAll();
        }

        private static void CustomStackImplementation()
        {
            CustomStack cs = new CustomStack(10);
            cs.Push(10);
            cs.Push(4);
            Console.WriteLine("After pushing 2 items");
            cs.DisplayAll();
            cs.Pop();
            Console.WriteLine("After popping 1 item");
            cs.DisplayAll();
            cs.Push(20);
            cs.Push(24);
            cs.Push(23);
            cs.Push(54);
            cs.Push(45);
            Console.WriteLine("After pushing 5 items");
            cs.DisplayAll();
        }

        private static ShapeAbs shape;

        private static void AbstractClassExample()
        {
            //ShapeAbs shapeAbs = new ShapeAbs(); // cannot create object
            shape = GetInputOfShapesAbs();
            shape.GetInput();
            shape.Area();
            shape.Perimeter();
        }

        private static ShapeAbs GetInputOfShapesAbs()
        {
            Console.WriteLine("Enter the choice\n1 for Square\n2 for Rectangle");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 2)
                return new RectangleAbs();
            else
                return new SquareAbs();
        }

        private static IShape s;

        private static void InterfaceExample()
        {
            var chandan = new Chandan();
            var bibhas = new Bibhas();
            var sita = new Sita();
            ISOn s = bibhas;
            s = chandan;
            ITeacher t = sita;
            t = chandan;

            List<ITeacher> teachers = new List<ITeacher>();
            teachers.Add(chandan);
            teachers.Add(sita);

            if (sita as ISOn != null)
            {
                Console.WriteLine("son");
            }
            else
            {
                Console.WriteLine("Not son");
            }
        }

        private static void ShapesImplementation()
        {
            s = GetInputOfShapes();

            s.GetInput();
            s.Area();
            s.Perimeter();
        }

        private static IShape GetInputOfShapes()
        {
            Console.WriteLine("Enter the choice\n1 for Square\n2 for Rectangle");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 2)
                return new Rectangle();
            else if (choice == 3)
                return new Circle();
            else
                return new Square();
        }

        private static void ComplexModel()
        {
            var data = StudentData.GenerateDummyData();
            Console.WriteLine(data.ToString());
        }

        private static void ExtensionExample()
        {
            int i = 10;
            Console.WriteLine(i.IsNonZero());
            Guid id = Guid.Empty;
            Console.WriteLine(id);

            Console.WriteLine("Enter the name");
            string str = Console.ReadLine();
            str.IsValid();
            var newStr = str.AddSpace(10, "alpha");
            Console.WriteLine(newStr);
        }

        private static void PolymorphismExample()
        {
            LivingThings l1 = new LivingThings();
            LivingThings a1 = new Animal();
            LivingThings p1 = new Plant();
            l1.Move();
            a1.Move();
            p1.Move();
            LivingThings apes = new Apes();
            apes.Move();
            //  Console.WriteLine(apes.ToString());
            Marks m1 = new Marks(100, 50, 20);
            Console.WriteLine(m1.ToString());
        }

        private static void InheritanceExample()
        {
            LivingThings l1 = new LivingThings();
            Animal a1 = new Animal("animal");
            a1 = new Animal();
            //Plant p1 = new Plant();
            //Apes apes = new Apes();
            //Human h1 = new Human();
            //Man m1 = new Man();
            //Woman w1 = new Woman();
            l1.Eat();
            a1.Eat();
            //p1.Eat();
            //apes.Eat();
            //h1.Eat();
            //m1.Eat();
            //w1.Eat();
        }

        private static void ConstReadonlyExample()
        {
            Test t1 = new Test();
        }

        private static void StaticAndNonStaticExample()
        {
            //StaticClass staticClass = new StaticClass(); //not valid
            StaticClass.I = 10;
            StaticClass.Name = "Chandan";
            StaticClass.SomeFunction();
            StaticClass.Name.IsValid();
            NonStaticClass nonStatic = new NonStaticClass();
            nonStatic.I = 10;
            //nonStatic.Name = "Some Name";
            //nonStatic.SomeFunction();
            NonStaticClass nonStatic1 = new NonStaticClass();
            nonStatic1.I = 20;
            NonStaticClass nonStatic2 = new NonStaticClass();
            nonStatic2.I = 30;

            nonStatic.SomeFunction();
            nonStatic1.SomeFunction();
            nonStatic2.SomeFunction();
        }

        private static void IndexerExample()
        {
            OurList ol = new OurList(new string[] { "Sunday", "Monday", "Tuesday" });
            Console.WriteLine(ol[1]);
            ol[1] = "monday";
            ol.Resize(5);
            Console.WriteLine(ol[1]);
        }

        private static void OperatorOverloadingExample()
        {
            int x = 10;
            int y = 20;
            int i = x + y;
            Marks m1 = new Marks(50, 20, 20);
            Marks m2 = new Marks(20, 10, 20);
            var m3 = m1 + m2;
            var m4 = m1 + m3;
            var m5 = m1 + m2 + m3 + m4;
            m1++;
            var marks = m1 + 5;
            m1 = new Marks(10, 10, 20);
            m2 = new Marks(10, 10, 20);
            Console.WriteLine(m1 == m2);
        }

        private static void PropertiesExample()
        {
            int x = 10;
            int y = 20;
            int i = x + y;
            Marks m1 = new Marks(50, 20);
            Marks m2 = new Marks(20, 10);
            var my = new Marks(m1);
            var mx = m1 + m2;
            m1++;
            var marks = m1 + 5;
            Console.WriteLine($"M1  has \nScience => {m1.Science}\nMath => {m1.Math}\nTotal => {m1.Total}\nPercentage => {m1.Percentage}\nDivision => {m1.Division} ");
            Console.WriteLine("=======================================");
            Console.WriteLine($"M2  has \nScience => {m2.Science}\nMath => {m2.Math}\nTotal => {m2.Total}\nPercentage => {m2.Percentage}\nDivision => {m2.Division} ");
            m1.Math = 200;
            Console.WriteLine("=======================================");
            Console.WriteLine(JsonConvert.SerializeObject(m1, Formatting.Indented));
            var m3 = JsonConvert.DeserializeObject<Marks>("{\"Math\":200.0,\"Science\":75.0}");
            Console.WriteLine("=======================================");
            Console.WriteLine($"M3  has \nScience => {m3.Science}\nMath => {m3.Math}\nTotal => {m3.Total}\nPercentage => {m3.Percentage}\nDivision => {m3.Division} ");
        }

        private static void ClassesExample()
        {
            HumanBeing h1 = new HumanBeing();
            HumanBeing h2 = new HumanBeing("Bibash");
            //h2 = new HumanBeing();
            h1 = new HumanBeing("Nabin");
            //h1.RaiseHand();
            h1.RaiseHand("left");
            h1.RaiseHand("right");
            h2.RaiseHand("left");
            h2.RaiseHand("right");
            Console.WriteLine(h1._Name);
        }

        private static void LoopingStatementV3()
        {
            string str = "abc";
            string[] arr = new string[] { "Bibash", "Ashwin", "Aakash", "Chandan" };
            Console.WriteLine("using foreach loop");
            //Console.WriteLine(arr[1]);
            int counter = 0;
            foreach (var item in arr)
            {
                counter++;
                Console.WriteLine(item.Length);
            }

            Console.WriteLine("Using for loop");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i].Length);
            }

            //for (int i = 0; i < str.Length; i++)
            //{
            //    Console.WriteLine("{0} => {1}", str[i], (int)str[i]);
            //}
        }

        private static void LoopingStatementsV2()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 5 == 0)
                {
                    //TODO: Bibash will add this later
                    continue;
                }
                Console.WriteLine(i);
            }

            ////for loop infinite
            //for (; ; )
            //{
            //}
        }

        private static void LoopingStatements()
        {
            ////infinite looping
            //do
            //{
            //} while (true);
            //while (true)
            //{
            //}
            Console.WriteLine("Enter the number of which table needs to be displayed");
            var num = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= 100; i++)
            {
                var inputs = new string[] { num.ToString(), i.ToString(), (num * i).ToString() };

                var str = string.Format("{0} x {1} = {2}", inputs);
                Console.WriteLine(str);
            }
        }

        private static void ArrayExample()
        {
            int[] a = new int[5];
            a[1] = 10;
            Array.Resize(ref a, a.Length - 1);
            Array.Reverse(a);
            int[] x = new int[] { 1, 2, 23, 4, -10, 20, 19, 4 };
            int[] y = new int[5];
            Array.Copy(x, 1, y, 2, 2);
            Array.Sort(x);
        }

        private static void ConditionalStatementExample()
        {
            Console.WriteLine("Enter the number");
            var val = Convert.ToInt32(Console.ReadLine());
            string day = "";
            if (val == 1)
            {
                day = "Sunday";
            }
            else if (val == 2)
            {
                day = "Monday";
            }
            else
            {
                day = "Holiday";
            }

            if (val == 1) day = "Sunday";
            else if (val == 2) day = "Monday";
            else day = "Holiday";

            //(Condition) ? <true statement> : <false statement>
            day = (val == 1) ? "Sunday" : (val == 2) ? "Monday" : "Holiday";

            switch (val)
            {
                case 1:
                    day = "Sunday";
                    break;

                case 2:
                    day = "Monday";
                    break;

                default:
                    break;
            }

            string weekend = "";
            if (val == 1 || val == 7)
            {
                weekend = "Its weekend! enjoy";
            }
            else if (val == 2 || val == 3 || val == 4 || val == 5 || val == 6)
            {
                weekend = "Well its weekdays! lets work hard";
            }

            switch (val)
            {
                case 1:
                case 7:
                    weekend = "Its weekend! enjoy";
                    break;

                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    weekend = "Well its weekdays! lets work hard";
                    break;

                default:
                    break;
            }
        }

        private static void CastingExample()
        {
            char c = 'A';
            int i = c;
            long j = i;
            float k = j;
            double l = k;

            short h = (short)c;
            k = (float)l;
            j = (long)k;
            i = (int)j;
            c = (char)i;

            string s = "1";
            i = Convert.ToInt32(s);

            string str = "abc";
            var a = 1;
            // a = Convert.ToInt32("abc"); //not valid (input format exception)
        }
    }
}