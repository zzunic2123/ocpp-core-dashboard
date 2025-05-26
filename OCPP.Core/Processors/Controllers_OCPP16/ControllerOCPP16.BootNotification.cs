using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerRequest;
using CPMS.Shared.Messages_OCPP16;
using JsonSerializer = Utf8Json.JsonSerializer;
using BootNotificationRequest = CPMS.Shared.Messages_OCPP16.BootNotificationRequest;
using BootNotificationResponse = CPMS.Shared.Messages_OCPP16.BootNotificationResponse;

namespace CPMS.OcppProxy.Controllers.Controllers_OCPP16
{
    public partial class BaseControllerOcpp16
    {
        public async Task<string> HandleBootNotification(OCPPMessage msgIn, OCPPMessage msgOut)
        {
            string errorCode = null;

            try
            {
                BootNotificationRequest bootNotificationRequest =
                    JsonSerializer.Deserialize<BootNotificationRequest>(msgIn.JsonPayload);
                BootNotificationResponse bootNotificationResponse = new BootNotificationResponse();
                bootNotificationResponse.CurrentTime = DateTimeOffset.UtcNow;
                bootNotificationResponse.Interval = 180;

                if (ChargePointStatus != null)
                {
                    // Known charge station => accept
                    bootNotificationResponse.Status = RegistrationStatus.Accepted;
                    // ChargePointStatus.Id
                    ChargePointStatus.Info = new Info
                    {
                        Vendor = bootNotificationRequest.ChargePointVendor,
                        Model = bootNotificationRequest.ChargePointModel,
                        ChargePointSerialNumber = bootNotificationRequest.ChargePointSerialNumber,
                        ChargeBoxSerialNumber = bootNotificationRequest.ChargeBoxSerialNumber,
                        FirmwareVersion = bootNotificationRequest.FirmwareVersion,
                        Iccid = bootNotificationRequest.Iccid,
                        Imsi = bootNotificationRequest.Imsi,
                        MeterType = bootNotificationRequest.MeterType,
                        MeterSerialNumber = bootNotificationRequest.MeterSerialNumber
                    };
                    
                    // Update charger data
                    var charger = _chargerService.GetChargerByOcppChargerIdEntity(ChargePointStatus.Id);
    
                    charger.Vendor = bootNotificationRequest.ChargePointVendor;
                    charger.Model = bootNotificationRequest.ChargePointModel;
                    charger.ChargePointSerialNumber = bootNotificationRequest.ChargePointSerialNumber;
                    charger.FirmwareVersion = bootNotificationRequest.FirmwareVersion;
                    charger.Protocol = ChargePointStatus.Protocol;

                    await _chargerService.UpdateChargerEntity(charger);
                }
                else
                {
                    // Unknown charge station => reject
                    bootNotificationResponse.Status = RegistrationStatus.Rejected;
                    msgOut.JsonPayload = JsonSerializer.ToJsonString(bootNotificationResponse);
                    return ErrorCodes.FormationViolation;
                }

                BootNotificationChargerRequest bootNotificationChargerRequest = new BootNotificationChargerRequest();
                bootNotificationChargerRequest.ChargePointVendor = bootNotificationRequest.ChargePointVendor;
                bootNotificationChargerRequest.ChargePointModel = bootNotificationRequest.ChargePointModel;
                bootNotificationChargerRequest.ChargePointSerialNumber = bootNotificationRequest.ChargePointSerialNumber;
                bootNotificationChargerRequest.ChargeBoxSerialNumber = bootNotificationRequest.ChargeBoxSerialNumber;
                bootNotificationChargerRequest.FirmwareVersion = bootNotificationRequest.FirmwareVersion;
                bootNotificationChargerRequest.Iccid = bootNotificationRequest.Iccid;
                bootNotificationChargerRequest.Imsi = bootNotificationRequest.Imsi;
                bootNotificationChargerRequest.ChargerId = ChargePointStatus.Id;
                bootNotificationChargerRequest.Protocol = ChargePointStatus.Protocol;
                bootNotificationChargerRequest.Reason = "";

                msgOut.JsonPayload = JsonSerializer.ToJsonString(bootNotificationResponse);
            }
            catch (Exception exp)
            {
                errorCode = ErrorCodes.FormationViolation;
            }
            
            return errorCode;
        }
    }
}
