namespace CPMS.OcppProxy.Shared.Models.ProxyModels.ProxyCommunication.CPMSRequest;

public class IntegerIdRequest
{
    public int Id { get; set; }
}

public class ListOfIntegerIdRequest
{
    public IList<int> Ids { get; set; }
}

