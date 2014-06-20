using System.Collections.Generic;
using System.Windows.Browser;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Presentation.Extensions;
using System.Collections.Specialized;
using TMMS.Common;
using TMMS.Common.Silverlight;

namespace LightSwitchApplication
{
    public partial class ProducerReview
    {
        partial void ProducerReview_InitializeDataWorkspace(List<IDataService> saveChangesTo)
        {
            // Write your code here.
            ProducerMonthlyPeriodId = Application.CurrentUser_PeriodId;
        }

      

       

        partial void Filter_Execute()
        {
            this.OpenModalWindow("FilterGroup");

        }

        partial void Export_Execute()
        {
            var url = string.Format(ExportItems.ProducerMonthlyByPeriod.ToDescription(),
                this.ProducerMonthlyPeriodId,
                HttpUtility.UrlEncode(this.FilterTerm));

            ClientUtility.Instance.DownloadExportFile(url);

        }
    }
}
