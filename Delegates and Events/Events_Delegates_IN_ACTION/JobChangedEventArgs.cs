using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using CommunicatingBetweenControls.Model;

namespace CommunicatingBetweenControls
{
    public class JobChangedEventArgs: EventArgs
    {
        public Job Job { get; set; }
    }
}
