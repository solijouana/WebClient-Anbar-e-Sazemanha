using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Anbare_Sazemanha.Webapi.Utilities
{
    public class BasicAuthenticationAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers.Authorization.Parameter;
                var decodeAuthToken = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                var arrUserName = decodeAuthToken.Split(':')[0];
                var arrPassword = decodeAuthToken.Split(':')[1];

                if (arrUserName.ToLower() == "mr_yaboo1@yahoo.com" && arrPassword.ToLower() == "password")
                {
                    Thread.CurrentPrincipal=new GenericPrincipal(new GenericIdentity(arrUserName),null );
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}