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
    /// Client to Server Interface
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IFromClientToServerMessages
    {
        [OperationContract(IsOneWay = true)]
        void Register(Guid clientID);
        
        [OperationContract(IsOneWay = true)]
        void DisplayTextOnServer(string text);

        [OperationContract(IsOneWay = true)]
        void DisplayTextOnServerAsFromThisClient(Guid clientID, string text);

        [OperationContract]
        string GetLastAnonMessage();
    }
}
