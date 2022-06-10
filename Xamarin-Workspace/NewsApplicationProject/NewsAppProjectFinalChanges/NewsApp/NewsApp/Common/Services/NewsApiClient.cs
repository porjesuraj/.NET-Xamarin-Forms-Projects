using NewsApp.Common.Constants;
using NewsApp.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Common.Services
{
    public interface INewsApiClient
    {
        ApiResponse GetEverything(EverythingRequest request);
        ApiResponse GetTopHeadlines(TopHeadlinesRequest request);
    }

    /// <summary>
    /// Use this to get results from NewsAPI.org.
    /// </summary>
    public class NewsApiClient : INewsApiClient
    {
        private readonly string BASE_URL = $"https://newsapi.org/v2/";

        private readonly string API_KEY = "e6390e80994342b789c654cb23d4e887";


        public NewsApiClient()
        {

        }


        /// <summary>
        /// Query the /v2/top-headlines endpoint for live top news headlines.
        /// </summary>
        /// <param name="request">The params and filters for the request.</param>
        /// <returns></returns>
        public ApiResponse GetTopHeadlines(TopHeadlinesRequest request)
        {
            // build the querystring
            var queryParams = new List<string>();

            // q
            if (!string.IsNullOrWhiteSpace(request.Q))
            {
                queryParams.Add("q=" + request.Q);
            }

            // sources
            if (request.Sources.Count > 0)
            {
                queryParams.Add("sources=" + string.Join(",", request.Sources));
            }

            if (request.Category.HasValue)
            {
                queryParams.Add("category=" + request.Category.Value.ToString().ToLowerInvariant());
            }

            if (request.Language.HasValue)
            {
                queryParams.Add("language=" + request.Language.Value.ToString().ToLowerInvariant());
            }

            if (request.Country.HasValue)
            {
                queryParams.Add("country=" + request.Country.Value.ToString().ToLowerInvariant());
            }

            // page
            if (request.Page > 1)
            {
                queryParams.Add("page=" + request.Page);
            }

            // page size
            if (request.PageSize > 0)
            {
                queryParams.Add("pageSize=" + request.PageSize);
            }

            // join them together
            var querystring = string.Join("&", queryParams.ToArray());

            return MakeRequest("top-headlines", querystring);
        }

        

        /// <summary>
        /// Query the /v2/everything endpoint for recent articles all over the web.
        /// </summary>
        /// <param name="request">The params and filters for the request.</param>
        /// <returns></returns>
        public ApiResponse GetEverything(EverythingRequest request)
        {
            // build the querystring
            var queryParams = new List<string>();

            // q
            if (!string.IsNullOrWhiteSpace(request.Q))
            {
                queryParams.Add("q=" + request.Q);
            }

            // sources
            if (request.Sources.Count > 0)
            {
                queryParams.Add("sources=" + string.Join(",", request.Sources));
            }

            // domains
            if (request.Domains.Count > 0)
            {
                queryParams.Add("domains=" + string.Join(",", request.Sources));
            }

            // from
            if (request.From.HasValue)
            {
                queryParams.Add("from=" + string.Format("{0:s}", request.From.Value));
            }

            // to
            if (request.To.HasValue)
            {
                queryParams.Add("to=" + string.Format("{0:s}", request.To.Value));
            }

            // language
            if (request.Language.HasValue)
            {
                queryParams.Add("language=" + request.Language.Value.ToString().ToLowerInvariant());
            }

            // sortBy
            if (request.SortBy.HasValue)
            {
                queryParams.Add("sortBy=" + request.SortBy.Value.ToString());
            }

            // page
            if (request.Page > 1)
            {
                queryParams.Add("page=" + request.Page);
            }

            // page size
            if (request.PageSize > 0)
            {
                queryParams.Add("pageSize=" + request.PageSize);
            }

            // join them together
            var querystring = string.Join("&", queryParams.ToArray());

            return MakeRequest("everything", querystring);
        }

    

        private ApiResponse MakeRequest(string endpoint, string querystring)
        {

            string url = $"{BASE_URL}{endpoint}?{querystring}&apiKey={API_KEY}";
            var json = new WebClient().DownloadString(url);

            ApiResponse apiResponse = null;



            if (!string.IsNullOrWhiteSpace(json))
            {
                // convert the json to an obj
                apiResponse = JsonConvert.DeserializeObject<ApiResponse>(json);


            }

            return apiResponse;

        }
    }
}
