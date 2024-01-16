namespace WebApplication1.Applications.Services.LogServices
{
    public class LogService : ILogService

    {
        public void WriteLogError(string message)
        {
            string logFolderName = "logs/";
            if (!Directory.Exists(logFolderName))
            {
                Directory.CreateDirectory(logFolderName);
            }
            string logFileName = "";
            DateTime now = DateTime.Now;
            logFileName = String.Format("{0}_{1}_{2}_log.txt",
                now.Year, now.Month, now.Day);
            string fullFileLog = Path.Combine(logFolderName, logFileName);
            using (StreamWriter sw = new StreamWriter(fullFileLog, true))
            {
                sw.WriteLine(String.Format("Loi xay ra vao luc: {0}", now));
                sw.WriteLine(String.Format("Loi cu the: {0}", message));
            }
        }
    }
}
