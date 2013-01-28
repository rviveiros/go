using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Go.Web.Services;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace Go.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
			
			// This code sets up a handler to update CloudStorageAccount instances when their corresponding
            // configuration settings change in the service configuration file.
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
            {
                // Provide the configSetter with the initial value
                configSetter(RoleEnvironment.GetConfigurationSettingValue(configName));
            });

            // Create data table from MessageDataServiceContext
            // It is recommended the data tables should be only created once. It is typically done as a 
            // provisioning step and rarely in application code.
            var account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");

            // dynamically create the tables
            CloudTableClient.CreateTablesFromModel(typeof(UrlDataServiceContext),
                                                    account.TableEndpoint.AbsoluteUri,
                                                    account.Credentials);
        }
    }
}