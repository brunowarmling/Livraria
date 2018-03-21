using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Livraria.Model.Logging
{
    /// <summary>
    /// The purpose of this class is to provide log methods
    /// </summary>
    public static class Log
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static Log()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Logs an error
        /// </summary>
        /// <param name="exception"><see cref="Exception"/> object instante</param>
        public static void AddError(Exception exception)
        {
            log.Error(exception);
        }

        /// <summary>
        /// Logs an information
        /// </summary>
        /// <param name="data">object instance to be logged</param>
        public static void AddInfo(object data)
        {
            log.Info(data);
        }

        /// <summary>
        /// Logs a debug
        /// </summary>
        /// <param name="data">object instance to be logged</param>
        public static void AddDebug(object data)
        {
            log.Debug(data);
        }

        /// <summary>
        /// Logs a warning
        /// </summary>
        /// <param name="data">object instance to be logged</param>
        public static void AddWarning(object data)
        {
            log.Warn(data);
        }

        /// <summary>
        /// Returns the inline method name
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }

    }
}
