using PharmaGateway.API.Routes.PharmacyService.Pharmacy.Consts;
using Yarp.ReverseProxy.Configuration;

namespace PharmaGateway.API.Routes.PharmacyService.Pharmacy.Clusters;

public class GetClusters
{
    public static IReadOnlyList<ClusterConfig> PharmacyGetCluster()
    {
        return [
            new ClusterConfig
            {
                ClusterId = RouteConsts.PharmacyClusterName,
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    {
                        RouteConsts.PharmacyPrefix,
                        new DestinationConfig
                        {
                            Address = RouteConsts.PharmacyFullAddress
                        }
                    }
                }
            }
            ];
    }
}
