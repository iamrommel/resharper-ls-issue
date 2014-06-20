using System.Collections.Generic;
using Microsoft.LightSwitch;

namespace LightSwitchApplication
{
    public partial class PickupsTests
    {
        partial void PickupsTests_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            // Write your code here.
            StrtDate = Application.PaymentCalculationDate.FirstDay;
            EndDate = Application.PaymentCalculationDate.LastDay;
        }
    }
}