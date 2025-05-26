﻿using System.Runtime.Serialization;

namespace CPMS.Shared.Messages_OCPP16
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ClearChargingProfileRequest
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [DataMember (Name = "id")]
        public int? Id { get; set; }


        [Newtonsoft.Json.JsonProperty("connectorId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [DataMember (Name = "connectorId")]
        public int? ConnectorId { get; set; }


        [Newtonsoft.Json.JsonProperty("chargingProfilePurpose", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        [DataMember (Name = "chargingProfilePurpose")]
        public ChargingProfilePurposeType? ChargingProfilePurpose { get; set; }


        [Newtonsoft.Json.JsonProperty("stackLevel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [DataMember (Name = "stackLevel")]
        public int? StackLevel { get; set; }


    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    
    public enum ChargingProfilePurposeType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"ChargePointMaxProfile")]
        ChargePointMaxProfile = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"TxDefaultProfile")]
        TxDefaultProfile = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"TxProfile")]
        TxProfile = 2,
    }
}