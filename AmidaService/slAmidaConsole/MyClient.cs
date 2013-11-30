using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel;

namespace slAmidaConsole
{
   

    public class MyClient : slAmidaConsole.AmidaService.AmidaServiceClient
    {
        System.Threading.Timer tmr;
        public MyClient(InstanceContext callbackInstance, string config)
            : base(callbackInstance, config)
        {
            tmr = new System.Threading.Timer(new System.Threading.TimerCallback(Timeout), null, 1000 * 30, 1000 * 60);
            try
            {
                this.RegisterAsync(  Guid.NewGuid().ToString(), "CONSOLE");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }


        void Timeout(object sender)
        {
            try
            {
                if (this.State == CommunicationState.Opened)
                    this.SayServerHelloAsync();
                else
                {
                    tmr.Change(System.Threading.Timeout.Infinite, 0);
                    //tmr.Dispose();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ;
            }
        }
        ~MyClient()
        {
            try
            {
                tmr.Change(System.Threading.Timeout.Infinite, 0);
                tmr.Dispose();
            }
            catch { ;}
        }
    }
}
