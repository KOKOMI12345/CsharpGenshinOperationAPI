using LoggerConfig;
using log4net;
using NaviaController;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;

public class FuncToNavia
{
    private static readonly ILog log = LogConfig.GetLogger();
    public void MainFunc(float timeWaitToRun = 5.0f)
    {
        var navia = new Navia();
        log.Warn($"警告,程序{timeWaitToRun}秒后开始运行");
        Thread.Sleep(TimeSpan.FromSeconds(timeWaitToRun));
        log.Info("开始执行");
        navia.Fire(method: "Charged", times: 0.5f, chance: 3, timeWait: 7.0f);
        log.Info("执行完成!");
    }
}

public class Admin
{
    private static readonly ILog log = LogConfig.GetLogger();
    public void RunThread(Action func)
    {
        if (new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
        {
            log.Info("当前用户是管理员权限");
            func();
        }
        else
        {
            log.Warn("当前用户不是管理员权限,尝试获取管理员权限");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
            startInfo.Verb = "runas";
            
            try
            {
                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                log.Error("无法获取管理员权限，退出程序");
                Environment.Exit(0);
            }
        }
    }
}

class Start
{
    [FatalAnalyzer]
    public static void Main(string[] args)
    {
        FuncToNavia func = new FuncToNavia();
        Admin admin = new Admin();
        admin.RunThread(() => { func.MainFunc(); });
    }
}
