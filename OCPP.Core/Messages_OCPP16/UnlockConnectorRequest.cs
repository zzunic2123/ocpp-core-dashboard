﻿using System.Runtime.Serialization;

namespace CPMS.Shared.Messages_OCPP16
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class UnlockConnectorRequest
    {
        [Newtonsoft.Json.JsonProperty("connectorId", Required = Newtonsoft.Json.Required.Always)]
        [DataMember (Name = "connectorId")]
        public int ConnectorId { get; set; }
    }
}