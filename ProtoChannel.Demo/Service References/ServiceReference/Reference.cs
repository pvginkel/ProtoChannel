﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProtoChannel.Demo.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SimpleMessage", Namespace="http://schemas.datacontract.org/2004/07/ProtoChannel.Demo.Shared")]
    [System.SerializableAttribute()]
    public partial class SimpleMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ComplexMessage", Namespace="http://schemas.datacontract.org/2004/07/ProtoChannel.Demo.Shared")]
    [System.SerializableAttribute()]
    public partial class ComplexMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ProtoChannel.Demo.ServiceReference.ComplexValue[] ValuesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProtoChannel.Demo.ServiceReference.ComplexValue[] Values {
            get {
                return this.ValuesField;
            }
            set {
                if ((object.ReferenceEquals(this.ValuesField, value) != true)) {
                    this.ValuesField = value;
                    this.RaisePropertyChanged("Values");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ComplexValue", Namespace="http://schemas.datacontract.org/2004/07/ProtoChannel.Demo.Shared")]
    [System.SerializableAttribute()]
    public partial class ComplexValue : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double DoubleValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IntValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double DoubleValue {
            get {
                return this.DoubleValueField;
            }
            set {
                if ((this.DoubleValueField.Equals(value) != true)) {
                    this.DoubleValueField = value;
                    this.RaisePropertyChanged("DoubleValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IntValue {
            get {
                return this.IntValueField;
            }
            set {
                if ((this.IntValueField.Equals(value) != true)) {
                    this.IntValueField = value;
                    this.RaisePropertyChanged("IntValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.ServerService")]
    public interface ServerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServerService/SimpleMessage", ReplyAction="http://tempuri.org/ServerService/SimpleMessageResponse")]
        ProtoChannel.Demo.ServiceReference.SimpleMessage SimpleMessage(ProtoChannel.Demo.ServiceReference.SimpleMessage message);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ServerService/SimpleMessage", ReplyAction="http://tempuri.org/ServerService/SimpleMessageResponse")]
        System.IAsyncResult BeginSimpleMessage(ProtoChannel.Demo.ServiceReference.SimpleMessage message, System.AsyncCallback callback, object asyncState);
        
        ProtoChannel.Demo.ServiceReference.SimpleMessage EndSimpleMessage(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServerService/ComplexMessage", ReplyAction="http://tempuri.org/ServerService/ComplexMessageResponse")]
        ProtoChannel.Demo.ServiceReference.ComplexMessage ComplexMessage(ProtoChannel.Demo.ServiceReference.ComplexMessage message);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ServerService/ComplexMessage", ReplyAction="http://tempuri.org/ServerService/ComplexMessageResponse")]
        System.IAsyncResult BeginComplexMessage(ProtoChannel.Demo.ServiceReference.ComplexMessage message, System.AsyncCallback callback, object asyncState);
        
        ProtoChannel.Demo.ServiceReference.ComplexMessage EndComplexMessage(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ServerService/ReceiveStream", ReplyAction="http://tempuri.org/ServerService/ReceiveStreamResponse")]
        void ReceiveStream(System.IO.Stream stream);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/ServerService/ReceiveStream", ReplyAction="http://tempuri.org/ServerService/ReceiveStreamResponse")]
        System.IAsyncResult BeginReceiveStream(System.IO.Stream stream, System.AsyncCallback callback, object asyncState);
        
        void EndReceiveStream(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServerServiceChannel : ProtoChannel.Demo.ServiceReference.ServerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SimpleMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SimpleMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public ProtoChannel.Demo.ServiceReference.SimpleMessage Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((ProtoChannel.Demo.ServiceReference.SimpleMessage)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ComplexMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ComplexMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public ProtoChannel.Demo.ServiceReference.ComplexMessage Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((ProtoChannel.Demo.ServiceReference.ComplexMessage)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServerServiceClient : System.ServiceModel.ClientBase<ProtoChannel.Demo.ServiceReference.ServerService>, ProtoChannel.Demo.ServiceReference.ServerService {
        
        private BeginOperationDelegate onBeginSimpleMessageDelegate;
        
        private EndOperationDelegate onEndSimpleMessageDelegate;
        
        private System.Threading.SendOrPostCallback onSimpleMessageCompletedDelegate;
        
        private BeginOperationDelegate onBeginComplexMessageDelegate;
        
        private EndOperationDelegate onEndComplexMessageDelegate;
        
        private System.Threading.SendOrPostCallback onComplexMessageCompletedDelegate;
        
        private BeginOperationDelegate onBeginReceiveStreamDelegate;
        
        private EndOperationDelegate onEndReceiveStreamDelegate;
        
        private System.Threading.SendOrPostCallback onReceiveStreamCompletedDelegate;
        
        public ServerServiceClient() {
        }
        
        public ServerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<SimpleMessageCompletedEventArgs> SimpleMessageCompleted;
        
        public event System.EventHandler<ComplexMessageCompletedEventArgs> ComplexMessageCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> ReceiveStreamCompleted;
        
        public ProtoChannel.Demo.ServiceReference.SimpleMessage SimpleMessage(ProtoChannel.Demo.ServiceReference.SimpleMessage message) {
            return base.Channel.SimpleMessage(message);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSimpleMessage(ProtoChannel.Demo.ServiceReference.SimpleMessage message, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSimpleMessage(message, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public ProtoChannel.Demo.ServiceReference.SimpleMessage EndSimpleMessage(System.IAsyncResult result) {
            return base.Channel.EndSimpleMessage(result);
        }
        
        private System.IAsyncResult OnBeginSimpleMessage(object[] inValues, System.AsyncCallback callback, object asyncState) {
            ProtoChannel.Demo.ServiceReference.SimpleMessage message = ((ProtoChannel.Demo.ServiceReference.SimpleMessage)(inValues[0]));
            return this.BeginSimpleMessage(message, callback, asyncState);
        }
        
        private object[] OnEndSimpleMessage(System.IAsyncResult result) {
            ProtoChannel.Demo.ServiceReference.SimpleMessage retVal = this.EndSimpleMessage(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSimpleMessageCompleted(object state) {
            if ((this.SimpleMessageCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SimpleMessageCompleted(this, new SimpleMessageCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SimpleMessageAsync(ProtoChannel.Demo.ServiceReference.SimpleMessage message) {
            this.SimpleMessageAsync(message, null);
        }
        
        public void SimpleMessageAsync(ProtoChannel.Demo.ServiceReference.SimpleMessage message, object userState) {
            if ((this.onBeginSimpleMessageDelegate == null)) {
                this.onBeginSimpleMessageDelegate = new BeginOperationDelegate(this.OnBeginSimpleMessage);
            }
            if ((this.onEndSimpleMessageDelegate == null)) {
                this.onEndSimpleMessageDelegate = new EndOperationDelegate(this.OnEndSimpleMessage);
            }
            if ((this.onSimpleMessageCompletedDelegate == null)) {
                this.onSimpleMessageCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSimpleMessageCompleted);
            }
            base.InvokeAsync(this.onBeginSimpleMessageDelegate, new object[] {
                        message}, this.onEndSimpleMessageDelegate, this.onSimpleMessageCompletedDelegate, userState);
        }
        
        public ProtoChannel.Demo.ServiceReference.ComplexMessage ComplexMessage(ProtoChannel.Demo.ServiceReference.ComplexMessage message) {
            return base.Channel.ComplexMessage(message);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginComplexMessage(ProtoChannel.Demo.ServiceReference.ComplexMessage message, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginComplexMessage(message, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public ProtoChannel.Demo.ServiceReference.ComplexMessage EndComplexMessage(System.IAsyncResult result) {
            return base.Channel.EndComplexMessage(result);
        }
        
        private System.IAsyncResult OnBeginComplexMessage(object[] inValues, System.AsyncCallback callback, object asyncState) {
            ProtoChannel.Demo.ServiceReference.ComplexMessage message = ((ProtoChannel.Demo.ServiceReference.ComplexMessage)(inValues[0]));
            return this.BeginComplexMessage(message, callback, asyncState);
        }
        
        private object[] OnEndComplexMessage(System.IAsyncResult result) {
            ProtoChannel.Demo.ServiceReference.ComplexMessage retVal = this.EndComplexMessage(result);
            return new object[] {
                    retVal};
        }
        
        private void OnComplexMessageCompleted(object state) {
            if ((this.ComplexMessageCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ComplexMessageCompleted(this, new ComplexMessageCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ComplexMessageAsync(ProtoChannel.Demo.ServiceReference.ComplexMessage message) {
            this.ComplexMessageAsync(message, null);
        }
        
        public void ComplexMessageAsync(ProtoChannel.Demo.ServiceReference.ComplexMessage message, object userState) {
            if ((this.onBeginComplexMessageDelegate == null)) {
                this.onBeginComplexMessageDelegate = new BeginOperationDelegate(this.OnBeginComplexMessage);
            }
            if ((this.onEndComplexMessageDelegate == null)) {
                this.onEndComplexMessageDelegate = new EndOperationDelegate(this.OnEndComplexMessage);
            }
            if ((this.onComplexMessageCompletedDelegate == null)) {
                this.onComplexMessageCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnComplexMessageCompleted);
            }
            base.InvokeAsync(this.onBeginComplexMessageDelegate, new object[] {
                        message}, this.onEndComplexMessageDelegate, this.onComplexMessageCompletedDelegate, userState);
        }
        
        public void ReceiveStream(System.IO.Stream stream) {
            base.Channel.ReceiveStream(stream);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginReceiveStream(System.IO.Stream stream, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginReceiveStream(stream, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndReceiveStream(System.IAsyncResult result) {
            base.Channel.EndReceiveStream(result);
        }
        
        private System.IAsyncResult OnBeginReceiveStream(object[] inValues, System.AsyncCallback callback, object asyncState) {
            System.IO.Stream stream = ((System.IO.Stream)(inValues[0]));
            return this.BeginReceiveStream(stream, callback, asyncState);
        }
        
        private object[] OnEndReceiveStream(System.IAsyncResult result) {
            this.EndReceiveStream(result);
            return null;
        }
        
        private void OnReceiveStreamCompleted(object state) {
            if ((this.ReceiveStreamCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ReceiveStreamCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ReceiveStreamAsync(System.IO.Stream stream) {
            this.ReceiveStreamAsync(stream, null);
        }
        
        public void ReceiveStreamAsync(System.IO.Stream stream, object userState) {
            if ((this.onBeginReceiveStreamDelegate == null)) {
                this.onBeginReceiveStreamDelegate = new BeginOperationDelegate(this.OnBeginReceiveStream);
            }
            if ((this.onEndReceiveStreamDelegate == null)) {
                this.onEndReceiveStreamDelegate = new EndOperationDelegate(this.OnEndReceiveStream);
            }
            if ((this.onReceiveStreamCompletedDelegate == null)) {
                this.onReceiveStreamCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnReceiveStreamCompleted);
            }
            base.InvokeAsync(this.onBeginReceiveStreamDelegate, new object[] {
                        stream}, this.onEndReceiveStreamDelegate, this.onReceiveStreamCompletedDelegate, userState);
        }
    }
}
