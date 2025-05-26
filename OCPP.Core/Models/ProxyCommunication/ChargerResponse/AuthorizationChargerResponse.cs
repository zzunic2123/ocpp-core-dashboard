namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerResponse;

public class AuthorizationChargerResponse
{
    public AuthorizationStatus AuthorizationStatus { get; set; }
    public CertificateStatus CertificateStatus { get; set; }
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public enum AuthorizationStatus
{
    [System.Runtime.Serialization.EnumMember(Value = @"Accepted")]
    Accepted = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"Blocked")]
    Blocked = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"Expired")]
    Expired = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"Invalid")]
    Invalid = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"ConcurrentTx")]
    ConcurrentTx = 4,
}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
public enum CertificateStatus
{
    [System.Runtime.Serialization.EnumMember(Value = @"Accepted")]
    Accepted = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"SignatureError")]
    SignatureError = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"CertificateExpired")]
    CertificateExpired = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"CertificateRevoked")]
    CertificateRevoked = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"NoCertificateAvailable")]
    NoCertificateAvailable = 4,

    [System.Runtime.Serialization.EnumMember(Value = @"CertChainError")]
    CertChainError = 5,

    [System.Runtime.Serialization.EnumMember(Value = @"ContractCancelled")]
    ContractCancelled = 6,

}
