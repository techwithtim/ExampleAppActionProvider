// Program.cs

using ExampleAppActionProvider;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using System;
using System.Runtime.InteropServices;
using System.Threading;


[DllImport("ole32.dll")]

static extern int CoRegisterClassObject(
            [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
            [MarshalAs(UnmanagedType.IUnknown)] object pUnk,
            uint dwClsContext,
            uint flags,
            out uint lpdwRegister);

[DllImport("ole32.dll")] static extern int CoRevokeClassObject(uint dwRegister);

uint cookie;

Guid CLSID_Factory = Guid.Parse("0067C3DD-920A-4486-83C3-9FAD82AFFA7A");
CoRegisterClassObject(CLSID_Factory, new COM.WidgetProviderFactory<AppActionProvider>(), 0x4, 0x1, out cookie);

Application.Start((p) =>
{
    var context = new DispatcherQueueSynchronizationContext(
        DispatcherQueue.GetForCurrentThread());
    SynchronizationContext.SetSynchronizationContext(context);
    _ = new App();
});

CoRevokeClassObject(cookie);

return 0;