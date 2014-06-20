using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;

namespace LightSwitchApplication
{
    public partial class VendorSubDetail
    {
        partial void VendorSub_Loaded(bool succeeded)
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.VendorSub);
        }

        partial void VendorSub_Changed()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.VendorSub);
        }

        partial void VendorSubDetail_Saved()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.VendorSub);
        }

        partial void VendorSubDetail_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            // Write your code here.

            //if (this.VendorSubId == 0)
            //{
            //    this.VendorSub.Name = TemporaryVendorSub.Name;
            //    this.VendorSub.ShortName = TemporaryVendorSub.ShortName;
            //    this.VendorSub.ProcessPeriod = TemporaryVendorSub.ProcessPeriod;
            //}

        }
    }
}