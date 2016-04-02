//-----------------------------------------------------------------------
//  Author: Shaun Webb
//  University: Sheffield Hallam University
//  Website: shaunwebb.co.uk
//  Github: TehWebby
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEG_Gateway
{
    /// <summary>
    /// Configure settings for the Gateway Application
    /// </summary>
    [Serializable]
    public class ApplicationSettings
    {
        private bool logging;

        /// <summary>
        /// Logging Getter and Setter
        /// </summary>
        public bool Logging
        {
            get{return logging;}
            set{logging = value;}
        }
    }
    
}
