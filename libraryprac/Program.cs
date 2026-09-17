//using System;
//using Newtonsoft.Json;

//namespace NewtonsoftExample
//{
//    public class Student
//    {
//        [JsonProperty("student_id")]
//        public int Id { get; set; }

//        [JsonProperty("student_Name")]
//        public string Name { get; set; }

//        [JsonProperty("student_Dept")]
//        public string Department { get; set; }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Creating a C# object
//            Student student = new Student
//            {
//                Id = 101,
//                Name = "Yash",
//                Department = "Computer Science"
//            };

//            string json = JsonConvert.SerializeObject(student, Formatting.Indented
//);

//            Console.WriteLine("JSON:");
//            Console.WriteLine(json);

//            Student studentObject = JsonConvert.DeserializeObject<Student>(json);

//            Console.WriteLine("\nC# Object:");
//            Console.WriteLine(studentObject.Id);
//            Console.WriteLine(studentObject.Name);
//            Console.WriteLine(studentObject.Department);
//        }
//    }
//}

//Appsettings.json content check

//using System;
//using Microsoft.Extensions.Configuration;

//class Program
//{
//    static void Main()
//    {
//        IConfiguration configuration = new ConfigurationBuilder()
//            .SetBasePath(AppContext.BaseDirectory)
//            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//            .Build();

//        string applicationName = configuration["AppSettings:ApplicationName"];
//        string version = configuration["AppSettings:Version"];
//        string environment = configuration["AppSettings:Environment"];

//        string connectionString =
//            configuration.GetConnectionString("DefaultConnection");

//        Console.WriteLine("Application Name: " + applicationName);
//        Console.WriteLine("Version: " + version);
//        Console.WriteLine("Environment: " + environment);
//        Console.WriteLine("Connection String: " + connectionString);
//    }
//}


//OPERATORS DEMOSTRATION

//using System;

//class Program
//{
//    static void Main()
//    {
//        int? nullableNumber = null;

//        Console.WriteLine("Nullable number: " + nullableNumber);

//        nullableNumber = 50;

//        Console.WriteLine("Nullable number after assigning: " + nullableNumber);

//        int age = 22;

//        string result = age >= 18
//            ? "Adult"
//            : "Minor";

//        Console.WriteLine("\nTernary result: " + result);

//        string? name = null;

//        string displayName = name ?? "Guest";

//        Console.WriteLine("\nDisplay name: " + displayName);

//        name = "Yash";

//        displayName = name ?? "Guest";

//        Console.WriteLine("Display name: " + displayName);

//        string? username = null;

//        username ??= "DefaultUser";

//        Console.WriteLine("\nUsername: " + username);

//        username ??= "AnotherUser";

//        Console.WriteLine("Username: " + username);
//    }
//}

//using System;
//using NLog;
//using NLog.Config;
//using NLog.Targets;

//class Program
//{
//    static void Main()
//    {
//        var fileTarget = new FileTarget("logFile")
//        {
//            FileName = @"C:\MyLogs\MyApplication.log",
//            Layout = "${longdate} | ${level:uppercase=true} | ${message} ${exception:format=tostring}",
//            CreateDirs = true
//        };

//        var config = new LoggingConfiguration();

//        config.AddRule(LogLevel.Trace, LogLevel.Fatal, fileTarget);

//        LogManager.Configuration = config;

//        Logger logger = LogManager.GetCurrentClassLogger();

//        logger.Trace("This is a TRACE message");
//        logger.Debug("This is a DEBUG message");
//        logger.Info("This is an INFO message");
//        logger.Warn("This is a WARNING message");

//        try
//        {
//            int a = 10;
//            int b = 0;

//            int result = a / b;
//        }
//        catch (Exception ex)
//        {
//            logger.Error(ex, "An error occurred while performing division");
//        }

//        logger.Fatal("This is a FATAL message");

//        LogManager.Shutdown();

//        Console.WriteLine("Logs have been written.");
//        Console.ReadLine();
//    }
//}

// COVERSION DEMOSTRATION JARRAY JOBJECT JTOKEN JSON

//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;

//class Program
//{
//    static void Main()
//    {
//        string json = """
//        {
//            "name": "Yash",
//            "age": 22,
//            "skills": ["C#", "SQL", "React"]
//        }
//        """;

//        Console.WriteLine("1. JSON STRING:");
//        Console.WriteLine(json);


//        JObject person = JObject.Parse(json);

//        Console.WriteLine("\n2. JOBJECT:");
//        Console.WriteLine(person);


//        JToken personToken = person;

//        Console.WriteLine("\n3. JTOKEN (whole object):");
//        Console.WriteLine(personToken);


//        JArray skills = (JArray)person["skills"];

//        Console.WriteLine("\n4. JARRAY (skills):");
//        Console.WriteLine(skills);


//        JToken skillsToken = skills;

//        Console.WriteLine("\n5. JTOKEN (skills array):");
//        Console.WriteLine(skillsToken);


//        Person personObject = personToken.ToObject<Person>();

//        Console.WriteLine("\n6. C# OBJECT:");
//        Console.WriteLine($"Name: {personObject.Name}");
//        Console.WriteLine($"Age: {personObject.Age}");
//        Console.WriteLine($"Skills: {string.Join(", ", personObject.Skills)}");


//        string finalJson = JsonConvert.SerializeObject(
//            personObject,
//            Formatting.Indented
//        );

//        Console.WriteLine("\n7. JSON STRING AGAIN:");
//        Console.WriteLine(finalJson);
//    }
//}


//public class Person
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public List<string> Skills { get; set; }
//}

//MULTITHREADING

//using System;
//using System.Threading;

//class Program
//{
//    static void Main()
//    {
//        Thread thread1 = new Thread(DoWork);
//        Thread thread2 = new Thread(DoWork);
//        Thread thread3 = new Thread(DoWork);

//        thread1.Start();
//        thread2.Start();
//        thread3.Start();

//        thread1.Join();
//        thread2.Join();
//        thread3.Join();

//        Console.WriteLine("All threads completed.");
//    }

//    static void DoWork()
//    {
//        for (int i = 1; i <= 5; i++)
//        {
//            Console.WriteLine(
//                $"Thread ID: {Thread.CurrentThread.ManagedThreadId} " +
//                $"| Value: {i}"
//            );

//            Thread.Sleep(500);
//        }
//    }
//}

//PLINQ DEMONSTRATION WITH THREAD SAFE COLLECTION


using System.Collections.Concurrent;


class Program
{
    static void Main()
    {
        List<int> numbers = Enumerable.Range(1, 20).ToList();

        Console.WriteLine("Starting Parallel LINQ...\n");

        ConcurrentBag<string> results = new ConcurrentBag<string>();

        numbers
            .AsParallel()
            .Where(n => n % 2 == 0)
            .Select(n =>
            {
                int threadId = Thread.CurrentThread.ManagedThreadId;

                string result =
                    $"Number: {n} | Thread: {threadId}";

                results.Add(result);

                return n;
            })
            .ToList();

        Console.WriteLine("Results:\n");

        foreach (string result in results)
        {
            Console.WriteLine(result);
        }

        Console.WriteLine("\nCompleted.");
    }
}