using System;
using System.ComponentModel;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace slAmidaConsole.Web
{
    public sealed partial class EQ_DomainContext  
    {
        partial void OnCreated()
        {
            if (!DesignerProperties.IsInDesignTool)
            {
                ((WebDomainClient<EQ_DomainContext.IEQ_DomainServiceContract>)this.DomainClient)
                    .ChannelFactory.Endpoint.Binding.SendTimeout = new TimeSpan(0, 5, 0);
            }
        }
    }
}