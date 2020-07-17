﻿namespace Devon4Net.Infrastructure.SmaxHcm.Common
{
    public static class SmaxHcmEndpointConst
    {

        #region Auth

        public const string Logon = "/auth/authentication-endpoint/authenticate/login";
        public const string Authenticate = "/idm-service/idm/v0/api/public/authenticate";
        public const string BoLogin = "/bo/boLogin";
        public const string LoginTenant = "/idm-service/idm/v0/login?tenant={0}&local=true"; //tenantId
        public const string BoLoginToken = "/idm-service/idm/v0/api/public/token";
        public const string BoTenant = "/idm-service/idm/v0/api/public/tenant?id={0}";
        public const string UserLogin= "/idm-service/idm/v0/api/public/authenticate/localUser";
        #endregion

        public const string AuthorizationHeaderTokenkey = "LWSSO_COOKIE_KEY";
        public const string Users = "/bo/rest/entities/user";
        public const string User = "/bo/rest/entities/user/{0}?timeStamp={1}"; //UserId, time stamp
        public const string UserTenants = "/bo/rest/entities/tenant?timeStamp={0}&filter=(user+eq+\"{1}\")";
        public const string Offerings = "/rest/{0}/ems/Offering/?layout=Id,DisplayLabel,OfferingType,Service,Status,Service.DisplayLabel,Service.IsDeleted&meta=totalCount&skip=0"; //tenant Id
        public const string OfferingDetail = "/rest/{0}/entity-page/initializationData/Offering/{1}"; //tenant ID, offering Id
        public const string Providers= "/{0}/dnd/api/resource/provider"; //tenant ID

        #region Design
        public const string GetDesign = "{0}/dnd/api/service/design/{1}"; //tenantId, designId

        #endregion
    }
}
