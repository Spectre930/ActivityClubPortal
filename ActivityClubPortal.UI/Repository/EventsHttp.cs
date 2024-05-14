using ActivityClubPortal.API.Resources;
using ActivityClubPortal.API.Resources.Viewmodels;
using ActivityClubPortal.UI.Repository.IRepository;
using ids.core.Models;
using ids.core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ActivityClubPortal.UI.Repository
{
    public class EventsHttp : RepositoryHttp<EventResource>, IEventsHttp
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _contextAccessor;

        public EventsHttp(HttpClient client, IHttpContextAccessor contextAccessor) : base(client, contextAccessor)
        {
            _client = client;
            _contextAccessor = contextAccessor;
        }

        public async Task AddGuide(int EventId, int GuideId)
        {
            AuthorizeHeader();
            var res = await _client.PostAsync($"Event/{EventId}/guides/add?GuideId={GuideId}", null);
            res.EnsureSuccessStatusCode();

        }

        public async Task DropGuide(int EventId, int GuideId)
        {
            AuthorizeHeader();
            var req = new HttpRequestMessage(HttpMethod.Delete, $"Event/{EventId}/guides/dropGuide?GuideId={GuideId}");
            await _client.SendAsync(req);
        }

        public async Task<IEnumerable<GuideResource>> GetEventGuides(int EventId)
        {
            //AuthorizeHeader();
            var response = await _client.GetAsync($"Event/{EventId}/guides");
            if (response.IsSuccessStatusCode)
            {
                var responseStream = response.Content.ReadAsStringAsync().Result;
                var ResObject = JsonConvert.DeserializeObject<IEnumerable<GuideResource>>(responseStream);
                return ResObject;
            }
            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<IEnumerable<EventsVm>> GetEvents()
        {
            var response = await _client.GetAsync($"Event/getall");
            response.EnsureSuccessStatusCode();
            var responseStream = response.Content.ReadAsStringAsync().Result;

            var ResObject = JsonConvert.DeserializeObject<IEnumerable<EventsVm>>(responseStream);

            return ResObject;
        }

        public async Task<EventsVm> GetEvent(int EventId)
        {
            var response = await _client.GetAsync($"Event/{EventId}");
            response.EnsureSuccessStatusCode();
            var responseStream = response.Content.ReadAsStringAsync().Result;

            var ResObject = JsonConvert.DeserializeObject<EventsVm>(responseStream);

            return ResObject;
        }

        public async Task<IEnumerable<MemberResource>> GetMembers(int EventId)
        {
            //AuthorizeHeader();
            var response = await _client.GetAsync($"Event/{EventId}/Members");
            if (response.IsSuccessStatusCode)
            {
                var responseStream = response.Content.ReadAsStringAsync().Result;
                var ResObject = JsonConvert.DeserializeObject<IEnumerable<MemberResource>>(responseStream);
                return ResObject;
            }
            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        public async Task SetLookup(int EventId, int LoopupId)
        {
            AuthorizeHeader();
            var res = await _client.PostAsync($"Event/{EventId}/SetLookUp?LookUpId={LoopupId}", null);
            res.EnsureSuccessStatusCode();
        }
    }
}
