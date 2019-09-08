using System;
using System.Collections.Generic;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using CatswordsTab.WebApi.Model;
using EmbedIO;

namespace CatswordsTab.WebApi
{
    public sealed class TabApiController : WebApiController, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        [Route(HttpVerbs.Get, "/appliance/all")]
        public List<ApplianceModel> GetAppliances() => RegistryService.GetInstalledApps();

        [Route(HttpVerbs.Get, "/association/all")]
        public List<AssociationModel> GetAssociations() => RegistryService.GetAssoiciations();
    }
}