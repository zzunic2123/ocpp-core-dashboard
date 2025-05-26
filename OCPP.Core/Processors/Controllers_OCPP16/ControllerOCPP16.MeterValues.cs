using System.Globalization;
using CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.ChargerRequest;
using CPMS.Shared.Messages_OCPP16;
using Utf8Json;

namespace CPMS.OcppProxy.Controllers.Controllers_OCPP16
{
    public partial class BaseControllerOcpp16
    {
        public async Task<string> HandleMeterValues(OCPPMessage msgIn, OCPPMessage msgOut)
        {
            string errorCode = null;
            MeterValuesResponse meterValuesResponse = new MeterValuesResponse();
            int connectorId = -1;
            string msgMeterValue = string.Empty;

            try
            {
               
                MeterValuesRequest meterValueRequest = JsonSerializer.Deserialize<MeterValuesRequest>(msgIn.JsonPayload);
               
                connectorId = meterValueRequest.ConnectorId;
                
                if (ChargePointStatus == null)
                {
                    errorCode = ErrorCodes.GenericError;
                    msgOut.JsonPayload = JsonSerializer.ToJsonString(new MeterValuesResponse());
                    
                    return errorCode;
                }
                
                var meterValues = ProcessMeterValues(meterValueRequest);
                meterValues.ChargerId = ChargePointStatus.Id;
                meterValues.Protocol = ChargePointStatus.Protocol;
                meterValues.TransactionId = meterValueRequest.TransactionId;
                
                msgOut.JsonPayload = JsonSerializer.ToJsonString(meterValuesResponse);
                
            }
            catch (Exception exp)
            {
                
                errorCode = ErrorCodes.InternalError;
            }

            return errorCode;
        }

        public MeterValueChargerRequest ProcessMeterValues(MeterValuesRequest meterValueRequest)
        {
            double currentChargeKW = -1;
            double meterKWH = -1;
            DateTimeOffset? meterTime = null;
            double stateOfCharge = -1;

            foreach (MeterValue meterValue in meterValueRequest.MeterValue)
            {
                foreach (SampledValue sampleValue in meterValue.SampledValue)
                {
                    
                    switch (sampleValue.Measurand)
                    {
                        case SampledValueMeasurand.Power_Active_Import:
                            currentChargeKW = ProcessPowerActiveImport(sampleValue);
                            break;
                        case SampledValueMeasurand.Energy_Active_Import_Register:
                            meterKWH = ProcessEnergyActiveImportRegister(sampleValue, meterValue.Timestamp);
                            meterTime = meterValue.Timestamp;
                            break;
                        case SampledValueMeasurand.SoC:
                            stateOfCharge = ProcessStateOfCharge(sampleValue);
                            break;
                        case null:
                            meterKWH = ProcessEnergyActiveImportRegister(sampleValue, meterValue.Timestamp);
                            meterTime = meterValue.Timestamp;
                            break;
                    }
                }
            }

            MeterValueChargerRequest meterValueProxy = new MeterValueChargerRequest();
            meterValueProxy.EnergyConsumed = meterKWH;
            meterValueProxy.CurrentPower = currentChargeKW;
            meterValueProxy.StateOfCharge = stateOfCharge;
            meterValueProxy.MeterTime = meterTime;

            return meterValueProxy;
        }

        public double ProcessPowerActiveImport(SampledValue sampleValue)
        {
            if (!double.TryParse(sampleValue.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out double currentChargeKW))
            {
                
                return -1;
            }

            if (sampleValue.Unit == SampledValueUnit.W ||
                sampleValue.Unit == SampledValueUnit.VA ||
                sampleValue.Unit == SampledValueUnit.Var ||
                sampleValue.Unit == null)
            {
                
                return currentChargeKW / 1000; // convert W => kW
            }

            if (sampleValue.Unit == SampledValueUnit.KW ||
                sampleValue.Unit == SampledValueUnit.KVA ||
                sampleValue.Unit == SampledValueUnit.Kvar)
            {
                
                return currentChargeKW; // already kW
            }

            
            return -1;
        }

        public double ProcessEnergyActiveImportRegister(SampledValue sampleValue, DateTimeOffset? timestamp)
        {
            if (!double.TryParse(sampleValue.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out double meterKWH))
            {
                
                return -1;
            }

            if (sampleValue.Unit == SampledValueUnit.Wh ||
                sampleValue.Unit == SampledValueUnit.Varh ||
                sampleValue.Unit == null)
            {
                
                return meterKWH / 1000; // convert Wh => kWh
            }

            if (sampleValue.Unit == SampledValueUnit.KWh ||
                sampleValue.Unit == SampledValueUnit.Kvarh)
            {
                
                return meterKWH; // already kWh
            }

            
            return -1;
        }

        public double ProcessStateOfCharge(SampledValue sampleValue)
        {
            if (!double.TryParse(sampleValue.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out double stateOfCharge))
            {
                
                return -1;
            }

            
            return stateOfCharge;
        }
        
    }
}
