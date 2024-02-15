using Autodesk.AutoCAD.Runtime;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.Windows.ApplicationModel.DynamicDependency;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

[assembly: ExtensionApplication(typeof(WinUI4AutoCAD.Class1))]
[assembly: CommandClass(typeof(WinUI4AutoCAD.Class1))]

namespace WinUI4AutoCAD
{
    public class Class1 : IExtensionApplication
    {
        public void Initialize()
        {
            Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.CurrentDocument.Editor.WriteMessage("Initializing WinUI4AutoCADttt...\n");
            try
            {
                Bootstrap.Initialize(0x00010004, "", new PackageVersion(0x0FA0043A08D30000), Bootstrap.InitializeOptions.OnPackageIdentity_NOOP);
            }
            catch (System.Exception exc)
            {
                Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.CurrentDocument.Editor.WriteMessage(exc.ToString() + "\n");
            }
        }

        [CommandMethod(nameof(ShowWinUI))]
        public void ShowWinUI()
        {
            Application.Start(_ =>
            {
                WindowsXamlManager.InitializeForCurrentThread();
                try
                {
                    var w = new BlankWindow1();
                    w.Closed += (s, e) => Application.Current.Exit();
                    w.Activate();
                }
                catch (Exception exc)
                {
                    Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.CurrentDocument.Editor.WriteMessage(exc.ToString() + "\n");
                    Application.Current.Exit();
                }
            });
        }

        public void Terminate()
        {
        }
    }
}
