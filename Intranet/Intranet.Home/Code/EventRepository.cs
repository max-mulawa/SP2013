using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Intranet.Home.EventsBySearchWebPart;
using Microsoft.Office.Server.Search.Query;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace Intranet.Home.Code
{
    public class EventRepository
    {
        public List<Event> GetEvents()
        {
            List<Event> events;
            using (new SPMonitoredScope("Boxing Events Search Retrieval"))
            {
                KeywordQuery query = new KeywordQuery(SPContext.Current.Site);
                query.SelectProperties.AddRange(new[] {"Title", "EventDate", "Path"});
                query.QueryText = "ContentType:\"CT-Event\"";
                var searchExecutor = new SearchExecutor();
                ResultTableCollection results = searchExecutor.ExecuteQuery(query);

                ResultTable resultTable = results.Filter("TableType", KnownTableTypes.RelevantResults).Single();

                events = (from DataRow row in resultTable.ResultRows
                    select new Event(
                        (string) row["Title"],
                        (DateTime) row["EventDate"],
                        (string) row["Path"])
                    ).OrderByDescending(ev => ev.EventDate)
                    .ThenBy(ev => ev.Title)
                    .ToList();
            }
            return events;
        }
    }
}