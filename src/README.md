
# 原神角色操作API

# 语言

Csharp

# 功能

用于操控原神中的角色，包括移动、跳跃、攻击、防御等操作。

# 示例用法

```csharp
using NaviaConntroler;

class CharacterController
{
    public static void Main(string [] args)
    {
        var navia = new Navia();
        navia.Fire(method: "Charged", times: 0.5f, chance: 3, timeWait: 7.0f);
    }
}
```

## 参数说明

-`method`: 攻击方法
-`times`: 每次攻击的间隔,如果攻击模式为Charged,这个就代表蓄力时间(max:5)
-`change`: 攻击次数
-`timeWait`: 每次攻击完成后下一次攻击的时间间隔

# 依赖

log4net 2.0.12

# 注意事项

确保游戏已经启动并处于活动状态,然后运行程序.
程序需要依赖管理员权限才能正确运行,如需运行程序,请注意下列代码
在: start.cs文件中

```csharp
using LoggerConfig;
using log4net;
using NaviaController;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;

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
```
