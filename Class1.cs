using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Hosting;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

[assembly:ExtensionApplication(typeof(WinUITest.Class1))]
[assembly:CommandClass(typeof(WinUITest.Class1))]

namespace WinUITest
{
    public class Class1 : IExtensionApplication
    {
        public void Initialize()
        {
        }

        [CommandMethod(nameof(ShowWinUI))]
        public void ShowWinUI()
        {
            Application.Start(_ =>
            {
                WindowsXamlManager.InitializeForCurrentThread();
                var w = new BlankWindow1();
                w.Closed += (s, e) => Application.Current.Exit();
                w.Activate();
            });
        }

        public void Terminate()
        {
        }
    }
}
