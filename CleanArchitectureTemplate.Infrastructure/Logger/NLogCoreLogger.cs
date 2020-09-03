using System;
using System.IO;
using CleanArchitectureTemplate.Core.Contracts.Logger;
using NLog;
using NLog.Layouts;
using NLog.Targets;

namespace CleanArchitectureTemplate.Infrastructure.Logger
{
    public class NLogCoreLogger : ICoreLogger
    {
        public NLogCoreLogger(string coreLogDirectory)
        {
            ////if (string.IsNullOrEmpty(coreLogDirectory))
            ////    throw new ArgumentException("Value cannot be null or empty.", nameof(coreLogDirectory));

            ////if (!Directory.Exists(coreLogDirectory))
            ////    throw new ArgumentException($"{coreLogDirectory} not exists.", nameof(coreLogDirectory));

            ////NLog.Common.InternalLogger.LogLevel = LogLevel.Fatal;
            ////NLog.Common.InternalLogger.LogToConsole = false;
            ////NLog.Common.InternalLogger.LogFile = $"{coreLogDirectory}/NLog.Internal.log";

            ////var config = new NLog.Config.LoggingConfiguration();

            ////// TODO llevar a tabla coreSetting
            ////var fileTarget = new FileTarget
            ////{
            ////    Name = nameof(NLogCoreLogger),
            ////    FileName = "${var:basedir}/${level}.log",
            ////    ArchiveFileName = "${var:basedir}/${level}.{#}.zip",
            ////    ArchiveNumbering = ArchiveNumberingMode.Date,
            ////    ArchiveEvery = FileArchivePeriod.Day,
            ////    ArchiveDateFormat = "yyyy-MM-dd",
            ////    MaxArchiveFiles = 14,
            ////    EnableArchiveFileCompression = true,
            ////    Layout = new JsonLayout()
            ////    {
            ////        Attributes =
            ////        {
            ////            new JsonAttribute("date", "${longdate}"),
            ////            new JsonAttribute("message", "${message}"),
            ////            new JsonAttribute("exception", "${exception:format=tostring}")
            ////        }
            ////    }
            ////};

            ////config.AddRule(LogLevel.Trace, LogLevel.Fatal, fileTarget);

            ////LogManager.Configuration = config;

            ////LogManager.Configuration.Variables["basedir"] = coreLogDirectory;
        }

        public void LogError(Exception exception, string message = null)
        {
            ////LogManager.GetLogger(nameof(NLogCoreLogger)).Error(exception, message);
        }
    }
}