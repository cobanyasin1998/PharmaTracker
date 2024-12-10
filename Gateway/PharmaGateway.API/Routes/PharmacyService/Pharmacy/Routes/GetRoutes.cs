using PharmaGateway.API.Routes.PharmacyService.Pharmacy.Consts;
using Yarp.ReverseProxy.Configuration;

namespace PharmaGateway.API.Routes.PharmacyService.Pharmacy.Routes
{
    public class GetRoutes
    {
        public static IReadOnlyList<RouteConfig> PharmacyGetRoutes()
        {
            return
        [
            new() {
                RouteId = "pharmacyCreate",
                ClusterId = RouteConsts.PharmacyClusterName,
                Match = new RouteMatch { Path = RouteConsts.PharmacyCreate },
                Transforms =
                [
                    new Dictionary<string, string> { { "PathPrefix", "/api/" } }
                ]
            },
            new RouteConfig
            {
                RouteId = "pharmacyUpdate",
                ClusterId = RouteConsts.PharmacyClusterName,
                Match = new RouteMatch { Path = RouteConsts.PharmacyUpdate },
                Transforms =
                [
                    new Dictionary<string, string> { { "PathPrefix", "/api/" } }
                ]
            },
            new RouteConfig
            {
                RouteId = "pharmacyGetAll",
                ClusterId = RouteConsts.PharmacyClusterName,
                Match = new RouteMatch { Path = RouteConsts.PharmacyGetAll },
                Transforms =
                [
                    new Dictionary<string, string> { { "PathPrefix", "/api/" } }
                ]
            }
        ];
        }
    }
}
