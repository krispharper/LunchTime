﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LunchTime.AddIn.LunchTimeService {
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
        private LunchTime.AddIn.LunchTimeService.Restaurant RestaurantField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RestaurantIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.TimeSpan> TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeArrivedField;
        
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
        public LunchTime.AddIn.LunchTimeService.Restaurant Restaurant {
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
        public System.DateTime TimeArrived {
            get {
                return this.TimeArrivedField;
            }
            set {
                if ((this.TimeArrivedField.Equals(value) != true)) {
                    this.TimeArrivedField = value;
                    this.RaisePropertyChanged("TimeArrived");
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
        private LunchTime.AddIn.LunchTimeService.ArrivalTime[] ArrivalTimesField;
        
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
        public LunchTime.AddIn.LunchTimeService.ArrivalTime[] ArrivalTimes {
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
        LunchTime.AddIn.LunchTimeService.ArrivalTime[] GetArrivalTimes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILunchTime/GetRestaurants", ReplyAction="http://tempuri.org/ILunchTime/GetRestaurantsResponse")]
        LunchTime.AddIn.LunchTimeService.Restaurant[] GetRestaurants();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILunchTime/InsertArrivalTimes", ReplyAction="http://tempuri.org/ILunchTime/InsertArrivalTimesResponse")]
        void InsertArrivalTimes(LunchTime.AddIn.LunchTimeService.ArrivalTime[] arrivalTimes);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILunchTimeChannel : LunchTime.AddIn.LunchTimeService.ILunchTime, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LunchTimeClient : System.ServiceModel.ClientBase<LunchTime.AddIn.LunchTimeService.ILunchTime>, LunchTime.AddIn.LunchTimeService.ILunchTime {
        
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
        
        public LunchTime.AddIn.LunchTimeService.ArrivalTime[] GetArrivalTimes() {
            return base.Channel.GetArrivalTimes();
        }
        
        public LunchTime.AddIn.LunchTimeService.Restaurant[] GetRestaurants() {
            return base.Channel.GetRestaurants();
        }
        
        public void InsertArrivalTimes(LunchTime.AddIn.LunchTimeService.ArrivalTime[] arrivalTimes) {
            base.Channel.InsertArrivalTimes(arrivalTimes);
        }
    }
}
