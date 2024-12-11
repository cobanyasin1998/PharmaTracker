using Coban.Consts.GatewayConsts;
using PharmaGateway.API.Routes.PharmacyService.Pharmacy.Consts;
using Yarp.ReverseProxy.Configuration;

namespace PharmaGateway.API.Routes.PharmacyService.Pharmacy.Routes
{
    public static class GetRoutes
    {
        public static IReadOnlyList<RouteConfig> PharmacyGetRoutes()
        {
            return
        [
            new() {
                RouteId = RouteConsts.PharmacyCreatePrefix,
                ClusterId = RouteConsts.PharmacyClusterName,
                Match = new RouteMatch { Path = RouteConsts.PharmacyCreate },
                Transforms =
                [
                    new Dictionary<string, string> { { GatewayGeneralConsts.PathPrefix, GatewayGeneralConsts.ApiPrefix } }
                ]
            },
            new RouteConfig
            {
                RouteId = RouteConsts.PharmacyUpdatePrefix,
                ClusterId = RouteConsts.PharmacyClusterName,
                Match = new RouteMatch { Path = RouteConsts.PharmacyUpdate },
                Transforms =
                [
                    new Dictionary<string, string> { { GatewayGeneralConsts.PathPrefix, GatewayGeneralConsts.ApiPrefix } }
                ]
            },
            new RouteConfig
            {
                RouteId = RouteConsts.PharmacyGetAllPrefix,
                ClusterId = RouteConsts.PharmacyClusterName,
                Match = new RouteMatch { Path = RouteConsts.PharmacyGetAll },
                Transforms =
                [
                    new Dictionary<string, string> { { GatewayGeneralConsts.PathPrefix, GatewayGeneralConsts.ApiPrefix } }
                ]
            }
        ];
        }
    }
}
