namespace temp_cleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            btnClean.Enabled = false;

            string tempPath = Path.GetTempPath();

            int fileDeleted = 0;
            int fileFailed = 0;
            int folderDeleted = 0;
            int folderFailed = 0;
            long bytesFreed = 0;

            string[] files;
            try
            {
                files = Directory.GetFiles(tempPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"無法讀取資料夾：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnClean.Enabled = true;
                return;
            }

            foreach (string file in files)
            {
                try
                {
                    var info = new FileInfo(file);
                    long size = info.Length;
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                    fileDeleted++;
                    bytesFreed += size;
                }
                catch
                {
                    fileFailed++;
                }
            }

            string[] dirs;
            try
            {
                dirs = Directory.GetDirectories(tempPath);
            }
            catch
            {
                dirs = Array.Empty<string>();
            }

            foreach (string dir in dirs)
            {
                try
                {
                    long size = GetDirectorySize(dir);
                    Directory.Delete(dir, true);
                    folderDeleted++;
                    bytesFreed += size;
                }
                catch
                {
                    folderFailed++;
                }
            }

            string message =
                $"清理完成！\n\n" +
                $"檔案：成功刪除 {fileDeleted} 個，跳過 {fileFailed} 個\n" +
                $"資料夾：成功刪除 {folderDeleted} 個，跳過 {folderFailed} 個\n\n" +
                $"釋放空間：約 {FormatBytes(bytesFreed)}";

            MessageBox.Show(message, "清理結果", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnClean.Enabled = true;
        }

        private long GetDirectorySize(string path)
        {
            long size = 0;
            try
            {
                foreach (string f in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
                {
                    try { size += new FileInfo(f).Length; } catch { }
                }
            }
            catch { }
            return size;
        }

        private string FormatBytes(long bytes)
        {
            string[] units = { "B", "KB", "MB", "GB" };
            double size = bytes;
            int unitIndex = 0;
            while (size >= 1024 && unitIndex < units.Length - 1)
            {
                size /= 1024;
                unitIndex++;
            }
            return $"{size:0.##} {units[unitIndex]}";
        }
    }
}