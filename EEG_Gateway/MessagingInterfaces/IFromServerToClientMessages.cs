//-----------------------------------------------------------------------
//  Author: Shaun Webb
//  University: Sheffield Hallam University
//  Website: shaunwebb.co.uk
//  Github: TehWebby
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace MessagingInterfaces
{
    /// <summary>
    /// Server to Client Interface
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IFromServerToClientMessages
    {
        [OperationContract(IsOneWay = true)]
        void DisplayTextInClient(string text);
    }
}
