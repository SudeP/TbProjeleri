using System;
using System.IO;
using System.Windows.Forms;

namespace CheckExplorer
{
    public class LocalWriter
    {
        private static string localLogFolderName = "MyLogFolder";
        private static readonly string NowFolderType = ".txt";
        private static string MonthFolder;
        private static string DayFolder;
        private static string NowFolder;
        private static string AppPath;
        private static DateTime dateTime;

        public static string L_LocalLogFolderName
        {
            get
            {
                return LocalWriter.localLogFolderName;
            }
            set
            {
                LocalWriter.localLogFolderName = value;
            }
        }

        public static void L_LocalLog(string Log)
        {
            LocalWriter.AppPath = Application.StartupPath;
            LocalWriter.DetermineDate();
            LocalWriter.ControlFolder();
            StreamWriter streamWriter;
            if (!File.Exists(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + LocalWriter.MonthFolder + "\\" + LocalWriter.DayFolder + "\\" + LocalWriter.NowFolder + LocalWriter.NowFolderType))
                streamWriter = File.CreateText(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + LocalWriter.MonthFolder + "\\" + LocalWriter.DayFolder + "\\" + LocalWriter.NowFolder + ".txt");
            else
                streamWriter = File.AppendText(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + LocalWriter.MonthFolder + "\\" + LocalWriter.NowFolder + LocalWriter.NowFolderType);
            streamWriter.Write(Log + Environment.NewLine);
            streamWriter.Close();
        }

        public static void L_LocalLog(string Folder, string SubFolder, string FileName, string Log)
        {
            LocalWriter.AppPath = Application.StartupPath;
            LocalWriter.ControlFolder(Folder, SubFolder);
            StreamWriter streamWriter;
            if (!File.Exists(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + Folder + "\\" + SubFolder + "\\" + FileName + LocalWriter.NowFolderType))
                streamWriter = File.CreateText(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + Folder + "\\" + SubFolder + "\\" + FileName + LocalWriter.NowFolderType);
            else
                streamWriter = File.AppendText(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + Folder + "\\" + SubFolder + "\\" + FileName + LocalWriter.NowFolderType);
            streamWriter.Write(DateTime.Now.ToString() + " " + Log + Environment.NewLine);
            streamWriter.Close();
        }

        private static void DetermineDate()
        {
            LocalWriter.dateTime = DateTime.Now;
            LocalWriter.MonthFolder = LocalWriter.dateTime.ToString("MM.yyyy");
            LocalWriter.DayFolder = LocalWriter.dateTime.Day.ToString();
            LocalWriter.NowFolder = LocalWriter.dateTime.ToString("HH.mm.ss.fff");
        }

        private static void ControlFolder()
        {
            if (!Directory.Exists(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName ?? ""))
                Directory.CreateDirectory(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName ?? "");
            if (!Directory.Exists(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + LocalWriter.MonthFolder))
                Directory.CreateDirectory(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + LocalWriter.MonthFolder);
            if (Directory.Exists(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + LocalWriter.MonthFolder + "\\" + LocalWriter.DayFolder))
                return;
            Directory.CreateDirectory(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + LocalWriter.MonthFolder + "\\" + LocalWriter.DayFolder);
        }

        private static void ControlFolder(string Folder, string SubFolder)
        {
            if (!Directory.Exists(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName ?? ""))
                Directory.CreateDirectory(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName);
            if (!Directory.Exists(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + Folder))
                Directory.CreateDirectory(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + Folder);
            if (Directory.Exists(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + Folder + "\\" + SubFolder))
                return;
            Directory.CreateDirectory(LocalWriter.AppPath + "\\" + LocalWriter.localLogFolderName + "\\" + Folder + "\\" + SubFolder);
        }
    }
}
