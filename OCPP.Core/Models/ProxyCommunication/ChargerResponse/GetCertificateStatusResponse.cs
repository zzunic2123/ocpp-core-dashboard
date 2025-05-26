namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerResponse;
public class GetCertificateChargerResponse
{
    public GetCertificateStatusEnumType CertificateStatus { get; set; }
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public enum GetCertificateStatusEnumType
{
    [System.Runtime.Serialization.EnumMember(Value = @"Accepted")]
    Accepted = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"Failed")]
    Failed = 1,
}