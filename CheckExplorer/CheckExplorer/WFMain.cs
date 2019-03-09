#pragma warning disable CS0618 // Type or member is obsolete
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace CheckExplorer
{
    public partial class WFMain : Form
    {
        public WFMain()
        {
            InitializeComponent();
        }
        string localPath = ConfigurationSettings.AppSettings["localPath"];
        string remotePath = ConfigurationSettings.AppSettings["remotePath"];
        int n = int.Parse(ConfigurationSettings.AppSettings["N"]);
        string userName = ConfigurationSettings.AppSettings["userName"];
        string password = ConfigurationSettings.AppSettings["password"];
        SortedList<string, string> thereIsNo = new SortedList<string, string>();
        SortedList<string, string> thereIs = new SortedList<string, string>();
        List<string> targetAllFile = new List<string>();
        NetworkConnection connection;
        DirectoryInfo source;
        DirectoryInfo target;
        private void WFMain_Load(object sender, EventArgs e)
        {
            Work();
        }
        private void Work()
        {
            connection = new NetworkConnection(remotePath, new NetworkCredential(userName, password));
            source = new DirectoryInfo(localPath);
            target = new DirectoryInfo(remotePath);
            ControlFile(source, target);
            CopyFile();
            ChangeFile();
            NFile(target);
            Application.Exit();
        }
        private void ControlFile(DirectoryInfo Psource, DirectoryInfo Ptarget)
        {
            foreach (DirectoryInfo dir in Psource.GetDirectories())
                ControlFile(dir, Psource.CreateSubdirectory(dir.Name));

            if (!Directory.Exists(Psource.FullName.Replace(localPath, remotePath)))
                Directory.CreateDirectory(Psource.FullName.Replace(localPath, remotePath));

            foreach (FileInfo file in Psource.GetFiles())
                if (!File.Exists(Path.Combine(Ptarget.FullName, file.Name).Replace(localPath, remotePath)))
                    thereIsNo.Add(Path.Combine(Psource.FullName, file.Name), Path.Combine(Psource.FullName, file.Name).Replace(localPath, remotePath));
                else
                    thereIs.Add(file.FullName, Path.Combine(Ptarget.FullName, file.Name).Replace(localPath, remotePath));
        }
        private void CopyFile()
        {
            foreach (KeyValuePair<string, string> file in thereIsNo)
                File.Copy(file.Key, file.Value);
        }
        private void ChangeFile()
        {
            foreach (KeyValuePair<string, string> item in thereIs)
            {
                if (File.GetLastWriteTime(item.Key) > File.GetLastWriteTime(item.Value))
                    File.Copy(item.Key, item.Value, true);
            }
        }
        private void NFile(DirectoryInfo remote)
        {
            foreach (FileInfo file in remote.GetFiles())
                targetAllFile.Add(file.FullName);

            foreach (DirectoryInfo file in remote.GetDirectories())
                targetAllFile.Add(file.FullName);

            if (targetAllFile.Count > n)
            {
                while (targetAllFile.Count != n)
                {
                    string fullName = targetAllFile[0];
                    DateTime dateTime = File.GetLastWriteTime(targetAllFile[0]);
                    for (int b = 0; b < targetAllFile.Count; b++)
                    {
                        if (dateTime > File.GetLastWriteTime(targetAllFile[b]))
                        {
                            fullName = targetAllFile[b];
                            dateTime = File.GetLastWriteTime(targetAllFile[b]);
                        }
                    }
                    if (File.Exists(fullName))
                        File.Delete(fullName);
                    if (Directory.Exists(fullName))
                        Directory.Delete(fullName);
                    targetAllFile.Remove(fullName);
                }
            }
        }
        public void T_Log(string @string)
        {
            if (TbxLog.Text.Length > 5000)
                TbxLog.Text = string.Empty;
            TextBox tbxLog = TbxLog;
            tbxLog.Text = tbxLog.Text + DateTime.Now.ToString("HH:mm:ss") + "  --  " + @string + Environment.NewLine;
            TbxLog.SelectionStart = TbxLog.TextLength;
            TbxLog.ScrollToCaret();
        }
    }
}
#pragma warning restore CS0618 // Type or member is obsolete