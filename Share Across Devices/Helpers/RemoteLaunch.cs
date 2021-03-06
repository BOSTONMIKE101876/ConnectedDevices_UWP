﻿using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;
using Windows.System.RemoteSystems;

namespace Share_Across_Devices.Helpers
{
    public static class RemoteLaunch
    {
        public static readonly string MYAPP_STORE = "ms-windows-store://pdp/?productid=9nblggh4tssg";
        public static readonly string MYTUBE_STORE = "ms-windows-store://pdp/?productid=9wzdncrcwf3l";
        public static readonly string TUBECAST_STORE = "ms-windows-store://pdp/?productid=9wzdncrdx3fs";

        public static async Task<RemoteLaunchUriStatus> TrySharetext(RemoteSystem device, string text)
        {
            RemoteSystemConnectionRequest connectionRequest = new RemoteSystemConnectionRequest(device);
            return await RemoteLauncher.LaunchUriAsync(connectionRequest, new Uri("share-app:?Text=" + Uri.EscapeDataString(text)));
        }

        public static async Task<RemoteLaunchUriStatus> TryShareURL(RemoteSystem device, string url)
        {
            RemoteSystemConnectionRequest connectionRequest = new RemoteSystemConnectionRequest(device);
            return await RemoteLauncher.LaunchUriAsync(connectionRequest, new Uri(url));
        }

        public static async Task<RemoteLaunchUriStatus> TryOpenStoreToApp(RemoteSystem device, String appTarget)
        {
            RemoteSystemConnectionRequest connectionRequest = new RemoteSystemConnectionRequest(device);
            return await RemoteLauncher.LaunchUriAsync(connectionRequest, new Uri(appTarget));
        }

        public static async Task<RemoteLaunchUriStatus> TryBeginShareFile(RemoteSystem device, string fileName, string ipAddress)
        {
            RemoteSystemConnectionRequest connectionRequest = new RemoteSystemConnectionRequest(device);
            return await RemoteLauncher.LaunchUriAsync(connectionRequest, new Uri("share-app:?FileName=" + fileName + "&IpAddress=" + ipAddress));
        }

        public static string ParseYoutubeLinkToTubeCastUri(string url)
        {
            return "tubecast:link=" + url;
        }

        public static string ParseYoutubeLinkToMyTubeUri(string url)
        {
            return "mytube:link=" + url;
        }        
    }
}
