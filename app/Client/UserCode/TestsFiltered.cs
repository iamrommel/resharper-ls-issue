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
    public partial class TestsFiltered
    {
        partial void TestsFiltered_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            // Write your code here.
            // Write your code here.
            StrtDate = Application.PaymentCalculationDate.FirstDay;
            EndDate = Application.PaymentCalculationDate.LastDay.AddDays(1);
        }
    }
}
