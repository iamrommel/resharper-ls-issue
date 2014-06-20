using System.Collections.Generic;
using Microsoft.LightSwitch;

namespace LightSwitchApplication
{
    public partial class Splash
    {
        

        partial void OpenVideoLib_Execute()
        {
            //ClientUtility.OpenWebPage("http://www.screencast.com/t/TS0CciefcLG")
            Application.ShowVideo();
        }

        partial void PCMRescue_Execute()
        {
            // Write your code here.
            //-- Actually want more here, but commented logic is just not working ......
            //-- First check if Team Viewer is installed ...  
            //Dim TeamViewerExe As String
            //TeamViewerExe = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            //TeamViewerExe = "c:\users\moakley\desktop\"
            //TeamViewerExe = TeamViewerExe & "test.pdf"
            //If File.Exists(TeamViewerExe) Then
            //  Me.ShowMessageBox("We detect Team Viewer is already installed on your desktop.  Please Double Click the Team Viewer Icon", "Team Viewer?", MessageBoxOption.Ok)
            //Else
            // -- If not, jump to download from www.totalmilk.com

            ClientUtility.Instance.OpenWebPage("http://www.totalmilk.com/PCMRescue.aspx");

            //End If
        }

        partial void PCMWeb_Execute()
        {
            // Write your code here.
            ClientUtility.Instance.OpenWebPage("http://www.totalmilk.com");
        }

        partial void PCMChat_Execute()
        {
            // Write your code here.
            ClientUtility.Instance.OpenWebPage("http://www.totalmilk.com/PCMChat.aspx");
        }

        partial void Splash_Created()
        {
            
            this.VersionNumber =  string.Format("Total Milk Management System v{0}", ClientUtility.Instance.SystemVersion).TrimEnd().TrimStart();
            

        }

      
    }
}