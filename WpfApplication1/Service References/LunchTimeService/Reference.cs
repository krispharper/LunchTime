﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApplication1.LunchTimeService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ArrivalTime", Namespace="http://schemas.datacontract.org/2004/07/LunchTime.Service")]
    [System.SerializableAttribute()]
    public partial class ArrivalTime : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ArrivalTimesIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WpfApplication1.LunchTimeService.Restaurant RestaurantField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RestaurantIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.TimeSpan> TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeArriedField;
        
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
        public int ArrivalTimesId {
            get {
                return this.ArrivalTimesIdField;
            }
            set {
                if ((this.ArrivalTimesIdField.Equals(value) != true)) {
                    this.ArrivalTimesIdField = value;
                    this.RaisePropertyChanged("ArrivalTimesId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WpfApplication1.LunchTimeService.Restaurant Restaurant {
            get {
                return this.RestaurantField;
            }
            set {
                if ((object.ReferenceEquals(this.RestaurantField, value) != true)) {
                    this.RestaurantField = value;
                    this.RaisePropertyChanged("Restaurant");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RestaurantId {
            get {
                return this.RestaurantIdField;
            }
            set {
                if ((this.RestaurantIdField.Equals(value) != true)) {
                    this.RestaurantIdField = value;
                    this.RaisePropertyChanged("RestaurantId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.TimeSpan> Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TimeArried {
            get {
                return this.TimeArriedField;
            }
            set {
                if ((this.TimeArriedField.Equals(value) != true)) {
                    this.TimeArriedField = value;
                    this.RaisePropertyChanged("TimeArried");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Restaurant", Namespace="http://schemas.datacontract.org/2004/07/LunchTime.Service")]
    [System.SerializableAttribute()]
    public partial class Restaurant : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WpfApplication1.LunchTimeService.ArrivalTime[] ArrivalTimesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RestaurantIdField;
        
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
        public WpfApplication1.LunchTimeService.ArrivalTime[] ArrivalTimes {
            get {
                return this.ArrivalTimesField;
            }
            set {
                if ((object.ReferenceEquals(this.ArrivalTimesField, value) != true)) {
                    this.ArrivalTimesField = value;
                    this.RaisePropertyChanged("ArrivalTimes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RestaurantId {
            get {
                return this.RestaurantIdField;
            }
            set {
                if ((this.RestaurantIdField.Equals(value) != true)) {
                    this.RestaurantIdField = value;
                    this.RaisePropertyChanged("RestaurantId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LunchTimeService.ILunchTime")]
    public interface ILunchTime {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILunchTime/GetArrivalTimes", ReplyAction="http://tempuri.org/ILunchTime/GetArrivalTimesResponse")]
        WpfApplication1.LunchTimeService.ArrivalTime[] GetArrivalTimes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILunchTime/GetArrivalTimes", ReplyAction="http://tempuri.org/ILunchTime/GetArrivalTimesResponse")]
        System.Threading.Tasks.Task<WpfApplication1.LunchTimeService.ArrivalTime[]> GetArrivalTimesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILunchTime/InsertArrivalTime", ReplyAction="http://tempuri.org/ILunchTime/InsertArrivalTimeResponse")]
        void InsertArrivalTime(string name, System.DateTime time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILunchTime/InsertArrivalTime", ReplyAction="http://tempuri.org/ILunchTime/InsertArrivalTimeResponse")]
        System.Threading.Tasks.Task InsertArrivalTimeAsync(string name, System.DateTime time);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILunchTimeChannel : WpfApplication1.LunchTimeService.ILunchTime, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LunchTimeClient : System.ServiceModel.ClientBase<WpfApplication1.LunchTimeService.ILunchTime>, WpfApplication1.LunchTimeService.ILunchTime {
        
        public LunchTimeClient() {
        }
        
        public LunchTimeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LunchTimeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LunchTimeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LunchTimeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WpfApplication1.LunchTimeService.ArrivalTime[] GetArrivalTimes() {
            return base.Channel.GetArrivalTimes();
        }
        
        public System.Threading.Tasks.Task<WpfApplication1.LunchTimeService.ArrivalTime[]> GetArrivalTimesAsync() {
            return base.Channel.GetArrivalTimesAsync();
        }
        
        public void InsertArrivalTime(string name, System.DateTime time) {
            base.Channel.InsertArrivalTime(name, time);
        }
        
        public System.Threading.Tasks.Task InsertArrivalTimeAsync(string name, System.DateTime time) {
            return base.Channel.InsertArrivalTimeAsync(name, time);
        }
    }
}
