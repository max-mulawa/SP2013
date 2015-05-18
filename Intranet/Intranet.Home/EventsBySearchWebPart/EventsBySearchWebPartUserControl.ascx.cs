using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Office.Server.Search.Query;
using Microsoft.SharePoint;

namespace Intranet.Home.EventsBySearchWebPart
{
    public partial class EventsBySearchWebPartUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            KeywordQuery query = new KeywordQuery(SPContext.Current.Site);
            query.SelectProperties.Add("Title");
            //query.SelectProperties.Add("Title");
        }
    }
}
