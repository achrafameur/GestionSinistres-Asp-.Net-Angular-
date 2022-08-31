using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Insurise.Infrastructure.Web.Rest.Utilities
{
    public static class PaginationUtil
    {
        private const string _XTotalCountHeaderName = "X-Total-Count";
        private const string _XPaginationHeaderName = "X-Pagination";
        public static IHeaderDictionary GeneratePaginationHttpHeaders(this PagedInfo page) 
        {
            IHeaderDictionary headers = new HeaderDictionary();
            PagedInfo _pagedInfo = new PagedInfo(page.PageNumber, page.PageSize, page.TotalPages, page.TotalRecords);

            headers.Add(_XTotalCountHeaderName, page.TotalRecords.ToString());
            headers.Add(_XPaginationHeaderName, JsonConvert.SerializeObject(_pagedInfo));
            return headers;
        }
    }
}
