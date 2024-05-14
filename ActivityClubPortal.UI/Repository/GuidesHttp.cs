using ActivityClubPortal.API.Resources;
using ActivityClubPortal.UI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ActivityClubPortal.UI.Repository
{
    public class GuidesHttp : RepositoryHttp<GuideResource>, IGuidesHttp
    {
        private readonly HttpClient _client;
        //private readonly IHttpContextAccessor _contextAccessor;
        public GuidesHttp(HttpClient client, IHttpContextAccessor contextAccessor) : base(client, contextAccessor)
        {
            _client = client;
            //_contextAccessor = contextAccessor;
        }

        public async Task<IEnumerable<EventResource>> GetEvents(int GuideId)
        {
            // AuthorizeHeader();
            var response = await _client.GetAsync($"Guide/{GuideId}/events");
            response.EnsureSuccessStatusCode();
            var responseStream = response.Content.ReadAsStringAsync().Result;

            var ResObject = JsonConvert.DeserializeObject<IEnumerable<EventResource>>(responseStream);

            return ResObject;
        }

        public async Task GuideAnEvent(int GuideId, int EventId)
        {
            AuthorizeHeader();
            await _client.PostAsync($"Guide/{GuideId}/guideEvent?EventId={EventId}", null);
        }
    }
}
