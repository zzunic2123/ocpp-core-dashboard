namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication;

public enum SecurityEventType
{
    FirmwareUpdated,
    FailedToAuthenticateAtCentralSystem,
    CentralSystemFailedToAuthenticate,
    SettingSystemTime,
    StartupOfTheDevice,
    ResetOrReboot,
    SecurityLogWasCleared,
    ReconfigurationOfSecurityParameters,
    MemoryExhaustion,
    InvalidMessages,
    AttemptedReplayAttacks,
    TamperDetectionActivated,
    InvalidFirmwareSignature,
    InvalidFirmwareSigningCertificate,
    InvalidCentralSystemCertificate,
    InvalidChargePointCertificate,
    InvalidTLSVersion,
    InvalidTLSCipherSuite
}