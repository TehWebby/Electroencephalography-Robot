//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Reflection.AssemblyVersionAttribute("0.0.0.0")]
[assembly: global::System.Reflection.AssemblyTitleAttribute("Simple Dashboard Service")]
[assembly: global::Microsoft.Dss.Core.Attributes.ServiceDeclarationAttribute(global::Microsoft.Dss.Core.Attributes.DssServiceDeclaration.Proxy, SourceAssemblyKey="User.SimpleDashboard.Y2006.M01, Version=0.0.0.0, Culture=neutral, PublicKeyToken=" +
    "4295554ba207a21e")]
[assembly: global::System.Security.SecurityTransparentAttribute()]
[assembly: global::System.Security.SecurityRulesAttribute(global::System.Security.SecurityRuleSet.Level1)]

namespace Microsoft.Robotics.Services.SimpleDashboard.Proxy {
    
    
    /// <summary>
    ///            SimpleDashboard StateType
    ///            </summary>
    [global::Microsoft.Dss.Core.Attributes.DataContractAttribute(Namespace="http://schemas.microsoft.com/robotics/2006/01/simpledashboard.user.html")]
    [global::System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.microsoft.com/robotics/2006/01/simpledashboard.user.html", ElementName="SimpleDashboardState")]
    [global::System.ComponentModel.DescriptionAttribute("SimpleDashboard StateType")]
    public class SimpleDashboardState : global::Microsoft.Dss.Core.IDssSerializable, global::System.ICloneable {
        
        public SimpleDashboardState() {
        }
        
        private bool _Log;
        
        /// <summary>
        ///            Log - Logging is turned on if true
        ///            </summary>
        [global::Microsoft.Dss.Core.Attributes.DataMemberAttribute(Order=-1)]
        [global::System.ComponentModel.DescriptionAttribute("Specifies whether to log messages.")]
        public bool Log {
            get {
                return this._Log;
            }
            set {
                this._Log = value;
            }
        }
        
        private string _LogFile;
        
        /// <summary>
        ///            LogFile - The name of the log file
        ///            </summary>
        [global::Microsoft.Dss.Core.Attributes.DataMemberAttribute(Order=-1)]
        [global::System.ComponentModel.DescriptionAttribute("Specifies the filename to log the data to.")]
        public string LogFile {
            get {
                return this._LogFile;
            }
            set {
                this._LogFile = value;
            }
        }
        
        private double _TranslateScaleFactor;
        
        /// <summary>
        ///            Adjusts the sensitivity for driving forwards/backwards
        ///            </summary>
        [global::Microsoft.Dss.Core.Attributes.DataMemberAttribute(Order=-1)]
        [global::System.ComponentModel.DescriptionAttribute("Specifies the a scaling factor for forward and backward motion.")]
        public double TranslateScaleFactor {
            get {
                return this._TranslateScaleFactor;
            }
            set {
                this._TranslateScaleFactor = value;
            }
        }
        
        private double _RotateScaleFactor;
        
        /// <summary>
        ///            Adjusts the sensitivity for rotating
        ///            </summary>
        [global::Microsoft.Dss.Core.Attributes.DataMemberAttribute(Order=-1)]
        [global::System.ComponentModel.DescriptionAttribute("Specifies the scaling factor for rotation.")]
        public double RotateScaleFactor {
            get {
                return this._RotateScaleFactor;
            }
            set {
                this._RotateScaleFactor = value;
            }
        }
        
        /// <summary>
        ///Copies the data member values of the current SimpleDashboardState to the specified target object
        ///</summary>
        ///<param name="target">target object (must be an instance of)</param>
        public virtual void CopyTo(Microsoft.Dss.Core.IDssSerializable target) {
            global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState typedTarget = ((global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState)(target));
            typedTarget._Log = this._Log;
            typedTarget._LogFile = this._LogFile;
            typedTarget._TranslateScaleFactor = this._TranslateScaleFactor;
            typedTarget._RotateScaleFactor = this._RotateScaleFactor;
        }
        
        /// <summary>
        ///Clones SimpleDashboardState
        ///</summary>
        ///<returns>cloned value</returns>
        public virtual object Clone() {
            global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState target0 = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState();
            this.CopyTo(target0);
            return target0;
        }
        
        /// <summary>
        ///Serializes the data member values of the current SimpleDashboardState to the specified writer
        ///</summary>
        ///<param name="writer">the writer to which to serialize</param>
        public virtual void Serialize(System.IO.BinaryWriter writer) {
            writer.Write(this._Log);
            if ((this._LogFile == null)) {
                writer.Write(((byte)(0)));
            }
            else {
                writer.Write(((byte)(1)));
                writer.Write(this._LogFile);
            }
            writer.Write(this._TranslateScaleFactor);
            writer.Write(this._RotateScaleFactor);
        }
        
        /// <summary>
        ///Deserializes SimpleDashboardState
        ///</summary>
        ///<param name="reader">the reader from which to deserialize</param>
        ///<returns>deserialized SimpleDashboardState</returns>
        public virtual object Deserialize(System.IO.BinaryReader reader) {
            this._Log = reader.ReadBoolean();
            if ((reader.ReadByte() != 0)) {
                this._LogFile = reader.ReadString();
            }
            this._TranslateScaleFactor = reader.ReadDouble();
            this._RotateScaleFactor = reader.ReadDouble();
            return this;
        }
    }
    
    /// <summary>
    ///            DSS Get Definition for SimpleDashboard
    ///            </summary>
    [global::System.ComponentModel.DescriptionAttribute("Gets the current state of the service.")]
    [global::System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema=false)]
    public class Get : global::Microsoft.Dss.ServiceModel.Dssp.Get<global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType, global:: Microsoft.Ccr.Core.PortSet<global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState, global:: W3C.Soap.Fault>> {
        
        public Get() {
        }
        
        public Get(global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body) : 
                base(body) {
        }
        
        public Get(global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body, global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState, global:: W3C.Soap.Fault> responsePort) : 
                base(body, responsePort) {
        }
    }
    
    /// <summary>
    ///            DSS Replace Definition for SimpleDashboard
    ///            </summary>
    [global::System.ComponentModel.DescriptionAttribute("Changes (or indicates a change to) the entire state of the service.")]
    [global::System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema=false)]
    public class Replace : global::Microsoft.Dss.ServiceModel.Dssp.Replace<global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState, global:: Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.DefaultReplaceResponseType, global:: W3C.Soap.Fault>> {
        
        public Replace() {
        }
        
        public Replace(global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState body) : 
                base(body) {
        }
        
        public Replace(global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState body, global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.DefaultReplaceResponseType, global:: W3C.Soap.Fault> responsePort) : 
                base(body, responsePort) {
        }
    }
    
    /// <summary>
    ///            The SimpleDashboard Operations Port
    ///            </summary>
    [global::System.ComponentModel.DescriptionAttribute("The SimpleDashboard Operations Port")]
    [global::System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema=false)]
    public class SimpleDashboardOperations : global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup, global:: Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop, global:: Microsoft.Robotics.Services.SimpleDashboard.Proxy.Get, global:: Microsoft.Robotics.Services.SimpleDashboard.Proxy.Replace> {
        
        public SimpleDashboardOperations() {
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.LookupResponse, global::W3C.Soap.Fault> DsspDefaultLookup() {
            global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType();
            global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice DsspDefaultLookup(out global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup operation) {
            global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType();
            operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.LookupResponse, global::W3C.Soap.Fault> DsspDefaultLookup(global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType body) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType();
            }
            global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice DsspDefaultLookup(global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType body, out global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup operation) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.LookupRequestType();
            }
            operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultLookup(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.DefaultDropResponseType, global::W3C.Soap.Fault> DsspDefaultDrop() {
            global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType();
            global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice DsspDefaultDrop(out global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop operation) {
            global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType();
            operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.DefaultDropResponseType, global::W3C.Soap.Fault> DsspDefaultDrop(global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType body) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType();
            }
            global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice DsspDefaultDrop(global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType body, out global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop operation) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.DropRequestType();
            }
            operation = new global::Microsoft.Dss.ServiceModel.Dssp.DsspDefaultDrop(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState, global:: W3C.Soap.Fault> Get() {
            global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType();
            global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Get operation = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Get(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Get(out global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Get operation) {
            global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body = new global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType();
            operation = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Get(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState, global:: W3C.Soap.Fault> Get(global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType();
            }
            global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Get operation = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Get(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Get(global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType body, out global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Get operation) {
            if ((body == null)) {
                body = new global::Microsoft.Dss.ServiceModel.Dssp.GetRequestType();
            }
            operation = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Get(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.DefaultReplaceResponseType, global:: W3C.Soap.Fault> Replace() {
            global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState body = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState();
            global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Replace operation = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Replace(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Replace(out global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Replace operation) {
            global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState body = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState();
            operation = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Replace(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.PortSet<global::Microsoft.Dss.ServiceModel.Dssp.DefaultReplaceResponseType, global:: W3C.Soap.Fault> Replace(global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState body) {
            if ((body == null)) {
                body = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState();
            }
            global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Replace operation = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Replace(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
        
        public virtual global::Microsoft.Ccr.Core.Choice Replace(global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState body, out global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Replace operation) {
            if ((body == null)) {
                body = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardState();
            }
            operation = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.Replace(body);
            this.Post(operation);
            return operation.ResponsePort;
        }
    }
    
    /// <summary>
    ///            Simple Dashboard Service
    ///            </summary>
    [global::System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema=false)]
    [global::System.ComponentModel.DescriptionAttribute("Provides access to a simple Windows UI for interacting with sensor and actuator s" +
        "ervices.\n(Partner with the \'Game Controller\' service.)")]
    [global::System.ComponentModel.DisplayNameAttribute("(User) Simple Dashboard")]
    public class Contract {
        
        public const string Identifier = "http://schemas.microsoft.com/robotics/2006/01/simpledashboard.user.html";
        
        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="constructorServicePort">Service constructor port</param>
        /// <param name="service">service path</param>
        /// <param name="partners">the partners of the service instance</param>
        /// <returns>create service response port</returns>
        public static global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse> CreateService(global::Microsoft.Dss.Services.Constructor.ConstructorPort constructorServicePort, string service, params Microsoft.Dss.ServiceModel.Dssp.PartnerType[] partners) {
            global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse> result = new global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse>();
            global::Microsoft.Dss.ServiceModel.Dssp.ServiceInfoType serviceInfo = new global::Microsoft.Dss.ServiceModel.Dssp.ServiceInfoType("http://schemas.microsoft.com/robotics/2006/01/simpledashboard.user.html", service);
            if ((partners != null)) {
                serviceInfo.PartnerList = new System.Collections.Generic.List<Microsoft.Dss.ServiceModel.Dssp.PartnerType>(partners);
            }
            global::Microsoft.Dss.Services.Constructor.Create create = new global::Microsoft.Dss.Services.Constructor.Create(serviceInfo, result);
            constructorServicePort.Post(create);
            return result;
        }
        
        /// <summary>Creates a new instance of the service.</summary>
        /// <param name="constructorServicePort">Service constructor port</param>
        /// <param name="partners">the partners of the service instance</param>
        /// <returns>create service response port</returns>
        public static global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse> CreateService(global::Microsoft.Dss.Services.Constructor.ConstructorPort constructorServicePort, params Microsoft.Dss.ServiceModel.Dssp.PartnerType[] partners) {
            global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse> result = new global::Microsoft.Dss.ServiceModel.Dssp.DsspResponsePort<Microsoft.Dss.ServiceModel.Dssp.CreateResponse>();
            global::Microsoft.Dss.ServiceModel.Dssp.ServiceInfoType serviceInfo = new global::Microsoft.Dss.ServiceModel.Dssp.ServiceInfoType("http://schemas.microsoft.com/robotics/2006/01/simpledashboard.user.html", null);
            if ((partners != null)) {
                serviceInfo.PartnerList = new System.Collections.Generic.List<Microsoft.Dss.ServiceModel.Dssp.PartnerType>(partners);
            }
            global::Microsoft.Dss.Services.Constructor.Create create = new global::Microsoft.Dss.Services.Constructor.Create(serviceInfo, result);
            constructorServicePort.Post(create);
            return result;
        }
    }
    
    public class CombinedOperationsPort : global::Microsoft.Dss.Core.DssCombinedOperationsPort {
        
        public CombinedOperationsPort() {
            this.SimpleDashboardOperations = new global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardOperations();
            base.Initialize(new global::Microsoft.Dss.Core.DssOperationsPortMetadata(this.SimpleDashboardOperations, "http://schemas.microsoft.com/robotics/2006/01/simpledashboard.user.html", "SimpleDashboardOperations", ""));
        }
        
        public global::Microsoft.Robotics.Services.SimpleDashboard.Proxy.SimpleDashboardOperations SimpleDashboardOperations;
    }
}
