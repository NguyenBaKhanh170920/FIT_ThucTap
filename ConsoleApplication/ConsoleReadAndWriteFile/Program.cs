namespace ConsoleReadAndWriteFile
{
    public class Program

    {
        public void WriteLogError(string message)
        {
            string logFolderName = "C:\\Users\\Administrator\\Documents\\PRN211\\New folder\\Training\\Backend\\ConsoleApplication\\ConsoleReadAndWriteFile";
            if (!Directory.Exists(logFolderName))
            {
                Directory.CreateDirectory(logFolderName);
            }
            string logFileName = "";
            DateTime now = DateTime.Now;
            logFileName = String.Format("data.txt",
                now.Year, now.Month, now.Day);
            string fullFileLog = Path.Combine(logFolderName, logFileName);
            using (StreamWriter sw = new StreamWriter(fullFileLog, true))
            {
                sw.WriteLine(String.Format("Thoi gian: {0}", now));
                sw.WriteLine(String.Format("Tin nhan cu the: {0}", message));
            }
        }
        public void ReadLog()
        {
            string logFolderName = "C:\\Users\\Administrator\\Documents\\PRN211\\New folder\\Training\\Backend\\ConsoleApplication\\ConsoleReadAndWriteFile";
            if (Directory.Exists(logFolderName))
            {

            }
            string logFileName = "";
            DateTime now = DateTime.Now;
            logFileName = String.Format("data.txt");
            string fullFileLog = Path.Combine(logFolderName, logFileName);
            string a = File.ReadAllText(fullFileLog);
            Console.WriteLine(a);
        }
        public static void Main(string[] args)
        {
            Program cs = new Program();
            while (true)
            {
                Console.WriteLine("Chon (Read/Write) data:");
                string choose = Console.ReadLine();
                if (String.Compare(choose, "Read", true) == 0)
                {
                    Console.WriteLine("Noi dung trong file: ");
                    cs.ReadLog();
                }
                else if (String.Compare(choose, "Write", true) == 0)
                {
                    //Console.WriteLine("Nhap vao file:");
                    //string rs = Console.ReadLine();
                    for (int i = 0; i < 5; i++)
                    {
                        string temp = DateTime.Now.ToString();
                        cs.WriteLogError(temp);
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("Unknown");
                }
            }
        }
    }
}