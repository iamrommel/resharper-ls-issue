using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.Automation;
using System.Windows.Browser;
using DevExpress.Xpf.Extensions;
using Microsoft.LightSwitch.Client;
using Microsoft.LightSwitch.Presentation.Extensions;
using Microsoft.LightSwitch.Threading;

namespace LightSwitchApplication
{
    public class ClientUtility
    {
        #region Singleton

        private static readonly ClientUtility _instance = null;

        /// <summary>
        ///     Prevents a default instance of the <see cref="ClientUtility" /> class from being created.
        /// </summary>
        private ClientUtility()
        {
            // Initialize members, etc. here.
        }

        /// <summary>
        ///     This single instance when calling the ClientUtility
        /// </summary>
        /// <value>
        ///     The instance.
        /// </value>
        public static ClientUtility Instance
        {
            get { return _instance ?? new ClientUtility(); }
        }

        #endregion

        #region Properties
        private Assembly _assembly;
        /// <summary>
        /// Gets the current assembly.
        /// </summary>
        /// <value>
        /// The current assembly.
        /// </value>
        public Assembly CurrentAssembly
        {
            get { return _assembly ?? (_assembly = Assembly.GetExecutingAssembly()); }
        }

        private Version _sytemVersion;
        /// <summary>
        /// Gets the system version.
        /// </summary>
        /// <value>
        /// The system version.
        /// </value>
        public Version SystemVersion
        {
            get
            {
                if (_sytemVersion == null)
                {
                    string version = CurrentAssembly.FullName;
                    int start = version.IndexOf("Version=", StringComparison.Ordinal) + 8;
                    int length = version.IndexOf(",", start, StringComparison.Ordinal) - start;
                    _sytemVersion = new Version(version.Substring(start, length));
                }

                return _sytemVersion;
            }
        }


        #endregion

        #region Method

        /// <summary>
        ///     Opens the web page.
        ///     This will work only if the silverlight client Runs with OutOfBrowser or set the InBrowser setting for Silverlight group policy
        /// </summary>
        /// <param name="url">The URL.</param>
        public void OpenWebPage(string url)
        {
            Dispatchers.Main.Invoke(() =>
                {
                    try
                    {
                        if (AutomationFactory.IsAvailable)
                        {
                            //desktop variant of LS app
                            dynamic shell = AutomationFactory.CreateObject("Shell.Application");
                            shell.ShellExecute(url);
                        }
                        else
                        {
                            //Web variant of LS app
                            HtmlPage.Window.Navigate(new Uri(url), "_blank");
                        }
                    }
                    catch
                    {
                        // Throw ex
                    }
                });
        }



        /// <summary>
        /// Gets the name of the image by.
        /// The image is embedded in the executing assembly
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public byte[] GetImageByName(string fileName)
        {

            using (Stream stream = CurrentAssembly.GetManifestResourceStream(string.Format("LightSwitchApplication.Resources.{0}", fileName)))
            {
                if (stream != null)
                {
                    int streamLength = Convert.ToInt32(stream.Length);
                    byte[] fileData = new byte[streamLength];
                    stream.Read(fileData, 0, streamLength);
                    stream.Close();
                    return fileData;
                }
                else
                {
                    return null;
                }
            }

        }



        /// <summary>
        /// Shows the filter.
        /// </summary>
        /// <param name="screenObject">The screen object.</param>
        /// <param name="filterControlerNames">The filter controler names.</param>
        /// <param name="controlToShow">The control to show.</param>
        public void ShowFilter(IScreenObject screenObject, IEnumerable<string> filterControlerNames, string controlToShow, string modalWindowName = "FilterGroup")
        {
            //set all controller to be invisible
            foreach (var filterControlerName in filterControlerNames)
            {
                var filterControl = screenObject.FindControl(filterControlerName);

                //but show only if it's the control to show
                if (controlToShow.Equals(filterControlerName, StringComparison.InvariantCultureIgnoreCase))
                {
                    filterControl.IsVisible = true;
                    screenObject.FindControl(modalWindowName).DisplayName = filterControl.DisplayName;
                }
                else
                {
                    filterControl.IsVisible = false;
                }

            }

            screenObject.OpenModalWindow(modalWindowName);
        }

        /// <summary>
        /// Shows the filter.
        /// Over load with type safe parameters
        /// </summary>
        /// <param name="screenObject">The screen object.</param>
        /// <param name="enumType">Type of the enum.</param>
        /// <param name="controlToShowEnum">The control to show enum.</param>
        /// <param name="modalWindowName">Name of the modal window.</param>
        public void ShowFilter(IScreenObject screenObject, System.Type enumType,
            Enum controlToShowEnum, string modalWindowName = "FilterGroup")
        {
            IEnumerable<string> filterControlerNames = 
                        Enum.GetNames(enumType)
                        .Select(m => m.ToString());

            var controlToShow = controlToShowEnum.ToString();

            ShowFilter(screenObject, filterControlerNames, controlToShow, modalWindowName);

        }

        /// <summary>
        /// Downloads the export file.
        /// </summary>
        /// <param name="exportUrl">The export URL.</param>
        public void DownloadExportFile(string exportUrl)
        {
            Dispatchers.Main.Invoke(() =>
            {


                var baseAddress = new Uri(new Uri(System.Windows.Application.Current.Host.Source.AbsoluteUri), "../../");
                string url =
                    string.Format(
                        @"{0}api/Export/{1}",
                        baseAddress.AbsoluteUri, exportUrl);


                try
                {
                    if (AutomationFactory.IsAvailable)
                    {
                        //desktop variant of LS app
                        dynamic shell = AutomationFactory.CreateObject("Shell.Application");
                        shell.ShellExecute(url);
                    }
                    else
                    {
                        //Web variant of LS app
                        HtmlPage.Window.Navigate(new Uri(url), "_blank");
                    }
                }
                catch
                {
                    // Throw ex
                }
            });



        }

        #endregion

    }
}