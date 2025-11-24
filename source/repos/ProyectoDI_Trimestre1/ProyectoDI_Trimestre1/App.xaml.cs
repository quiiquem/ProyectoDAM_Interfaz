using NLog;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ProyectoDI_Trimestre1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application 
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger(); //Logger de NLog

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            logger.Info("Aplicación iniciada correctamente.");
        }
        protected override void OnExit(ExitEventArgs e)
        {
            logger.Info("Aplicación cerrada");
            base.OnExit(e);
        }

        public void MyMethod1()
        {
            logger.Trace("Sample trace message");
            logger.Debug("Sample debug message");
            logger.Info("Sample informational message");
            logger.Warn("Sample warning message");
            logger.Error("Sample error message");
            logger.Fatal("Sample fatal error message");
            logger.Log(LogLevel.Info, "Sample informational message");
        }
    }
}
