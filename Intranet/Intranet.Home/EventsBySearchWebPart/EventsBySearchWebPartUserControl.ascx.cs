using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Intranet.Home.Code;
using Microsoft.Office.Server.Search.Query;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using SortDirection = Microsoft.Office.Server.Search.Query.SortDirection;

namespace Intranet.Home.EventsBySearchWebPart
{
    public partial class EventsBySearchWebPartUserControl : UserControl
    {
        private readonly EventRepository _eventRepository = new EventRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            var events = _eventRepository.GetEvents();
            gvEvents.DataSource = events;
            gvEvents.DataBind();
        }

        protected void gvEvents_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem != null)
                {
                    string path = ((Event)e.Row.DataItem).Path;
                    if (path.Contains("pro"))
                    {
                        e.Row.BackColor = Color.HotPink;
                    }
                }
            }
        }
    }
}
