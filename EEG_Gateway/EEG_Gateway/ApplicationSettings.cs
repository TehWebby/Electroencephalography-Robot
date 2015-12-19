using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEG_Gateway
{
    [Serializable]
    public class ApplicationSettings
    {
        private int logging;
        public int Logging
        {
            get
            {
                return this.logging;
            }
            set
            {
                this.logging = value;
            }
        }
    }
    
}
