using Operation;
using LoggerConfig;
using log4net;
using UserComputer;
using System;
using System.Threading;
public class CharacterOperation
{
    private string name;
    private bool noWarning;
    private static readonly ILog log = LogConfig.GetLogger();
    Operate operate = new Operate();
    public CharacterOperation(string name = null, bool noWarning = false)
    {
        this.name = name ?? this.name;
        this.noWarning = noWarning || this.noWarning;
        log.Info($"角色操作类初始化成功, 角色 {this.name} 正在使用此操控器");
    }
    public void Jump(int chance = 1)
    {
        //角色跳跃逻辑
        for(int i = 1; i <= chance; i++)
        {
            operate.PressKey(Keyboard.ENTER);
            operate.ReleaseKey(Keyboard.ENTER);
            Thread.Sleep(1000);
        }
        log.Info("角色跳跃成功");
    }
    public void MoveMouseToPosition(int x, int y)
    {
        operate.Mouse(1,x,y);
        log.Info($"鼠标已移动到坐标{x},{y}");
    }
    public void Forward(float timer = 1)
    {
        //角色向前移动逻辑
        operate.PressKey(Keyboard.W);
        Thread.Sleep((int)(timer * 1000));
        operate.ReleaseKey(Keyboard.W);
        log.Info($"角色向前移动{timer}秒");
    }
    public void Backward(float timer = 1)
    {
        operate.PressKey(Keyboard.S);
        Thread.Sleep((int)(timer * 1000));
        operate.ReleaseKey(Keyboard.S);
        log.Info($"角色向后移动{timer}秒");
    }
    public void Left(float timer = 1)
    {
        operate.PressKey(Keyboard.A);
        Thread.Sleep((int)(timer * 1000));
        operate.ReleaseKey(Keyboard.A);
        log.Info($"角色向左移动{timer}秒");
    }
    public void Right(float timer = 1)
    {
        operate.PressKey(Keyboard.D);
        Thread.Sleep((int)(timer * 1000));
        operate.ReleaseKey(Keyboard.D);
        log.Info($"角色向右移动{timer}秒");
    }
    public void CheckPrarameter(float timer = 1)
    {
        if(noWarning == false)
        {
            log.Warn("可能有问题的方法");
        }
        operate.Mouse(Mouse.MOUSECENTERKEY_UP,0,0);
        Thread.Sleep((int)(timer * 1000));
        operate.Mouse(Mouse.MOUSECENTERKEY_DOWN,0,0);
    }
    public void Fire(string method, float timer = 0.0f)
    {
        switch (method)
        {
            case "Normal":
                operate.Mouse(Mouse.MOUSEEVENT_LEFTUP);
                if (timer == 0.0f)
                {
                    timer = 0.5f;
                    System.Threading.Thread.Sleep((int)(timer * 1000));
                }
                operate.Mouse(Mouse.MOUSEEVENT_LEFTDOWN);
                log.Info($"普通攻击,间隔{timer}秒");
                break;

            case "Charged":
                if (timer == 0.0f)
                {
                    timer = 0.5f;
                }
                operate.PressKey(Keyboard.E);
                System.Threading.Thread.Sleep((int)(timer * 1000));
                operate.ReleaseKey(Keyboard.E);
                log.Info($"蓄力攻击,蓄力{timer}秒");
                break;

            case "Skill":
                operate.PressKey(Keyboard.Q);
                System.Threading.Thread.Sleep(500);
                operate.ReleaseKey(Keyboard.Q);
                log.Info($"{name}发动大招");
                break;

            case "Quickly":
                if ((name != "娜维娅" || name != "navia" || name != "Navia") && !noWarning)
                {
                    log.Warn("警告:该角色不是纳维娅,这个攻击方法是专门为娜维娅设计的,可能体验不佳,如果你不想接收到类似警告,请把noWarning改为False");
                }
                for (int a = 0; a < 3; a++)
                {
                    operate.PressKey(Keyboard.E);
                    operate.ReleaseKey(Keyboard.E);
                    System.Threading.Thread.Sleep(800);
                }
                break;

            case "TurnedATK":
                operate.Mouse(Mouse.MOUSEEVENT_LEFTDOWN);
                System.Threading.Thread.Sleep((int)(timer * 1000));
                operate.Mouse(Mouse.MOUSEEVENT_LEFTUP);
                break;

            case "Drop":
                operate.Mouse(Mouse.MOUSEEVENT_LEFTDOWN);
                operate.Mouse(Mouse.MOUSEEVENT_LEFTUP);
                break;

            default:
                // 处理未知方法的情况
                log.Error($"{name}的攻击方法{method}未找到");
                break;
        }
    }

    public void PickItem()
    {
        operate.PressKey(Keyboard.F);
        operate.ReleaseKey(Keyboard.F);
    }
}