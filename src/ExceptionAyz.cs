using System;
using System.IO;

public class FatalAnalyzerAttribute : Attribute
{
    public void Analyze(Action action)
    {
        try
        {
            action.Invoke();
        }
        catch (Exception e)
        {
            string error_message = $"函数 {action.Method.Name} 发生了致命错误: \n";
            error_message += $"错误类型: {e.GetType().Name} \n";
            error_message += $"错误信息: {e.Message} \n";
            error_message += "异常追踪信息: \n";
            error_message += e.StackTrace;
            error_message += "异常追踪结束. \n";
            error_message += "===========================================\n";

            using (StreamWriter file = new StreamWriter("fatal.log", true))
            {
                file.WriteLine(error_message);
            }

            throw;  // 抛出异常，保持异常的原始行为
        }
    }
}
