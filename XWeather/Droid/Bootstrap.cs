﻿using Android.App;
using Android.Content;

using SettingsStudio;

namespace XWeather.Droid
{
	public static class Bootstrap
	{
		public static void Run (Activity context, Application application)
		{
			AnalyticsManager.Shared.ConfigureHockeyApp (context, application);

			LocationProviderFactory.Create = () => new LocationProvider (context);

			XWeather.Bootstrap.Run ();

			ServiceStack.AndroidPclExportClient.Configure ();

			ServiceStack.JsonHttpClient.GlobalHttpMessageHandlerFactory = () => new ModernHttpClient.NativeMessageHandler ();

			Settings.VersionNumber = application.PackageManager.GetPackageInfo (application.PackageName, 0).VersionName;

			Settings.BuildNumber = application.PackageManager.GetPackageInfo (application.PackageName, 0).VersionCode.ToString ();

			//Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init ();
		}
	}
}