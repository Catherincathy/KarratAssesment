//7.1
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
public class Logger
{
    private static readonly Lazy<Logger> lazyInstance = new Lazy<Logger>(() => new Logger());
 
    private Logger() {}
 
    public static Logger GetInstance()
    {
        return lazyInstance.Value;
    }
}

