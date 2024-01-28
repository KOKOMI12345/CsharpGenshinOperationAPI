using log4net;
using LoggerConfig;
using System.Threading;
using static CharacterOperation;
using System;

namespace NaviaController
{
    public class Navia
    {
        private string name = "娜维娅";
        private CharacterOperation characterOperation;
        private static readonly ILog log = LogConfig.GetLogger();

        public Navia()
        {
            characterOperation = new CharacterOperation(name);
        }

        public void Fire(string method = null, float times = 0.0f, int chance = 0, float timeWait = 0.0f)
        {
            /*
            """
            `method: 攻击方法
            `times: 每次攻击的间隔,如果攻击模式为Charged,这个就代表蓄力时间(max:5)
            `change: 攻击次数
            `timeWait: 每次攻击完成后下一次攻击的时间间隔
            """
            */
            log.Info($"{name} 开始攻击");
            log.Info($"{name} 攻击方式：{method}");
            for (int i = 0; i < chance; i++)
            {
                characterOperation.Fire(method, times);
                Thread.Sleep((int)(timeWait * 1000));
            }
            log.Info($"{name} 攻击结束");
        }
        public void Operate()
        {
            log.Info($"{name} 开始操作");
            characterOperation.CheckPrarameter(3);
            log.Info($"{name} 操作结束");
        }
        public void QuicklyShooting()
        {
            log.Info($"{name} 开始快速射击");
            characterOperation.Fire("Quickly");
            log.Info($"{name} 快速射击结束");
        }
    }
}
