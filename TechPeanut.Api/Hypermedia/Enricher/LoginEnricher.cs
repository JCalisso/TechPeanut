using Microsoft.AspNetCore.Mvc;
using System.Text;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Hypermedia.Constants;

namespace TechPeanut.Api.Hypermedia.Enricher
{
    public class LoginEnricher : ContentResponseEnricher<LoginVO>
    {
        private readonly object _locker = new object();

        protected override Task EnrichModel(LoginVO content, IUrlHelper urlHelper)
        {
            var path = "api/login/v1";
            string link = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpsActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet


            });


            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpsActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpsActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpsActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"
            });

            return null;

        }
        private string GetLink(int id, IUrlHelper urlHelper, string path)
        {
            lock (_locker)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            };
        }
    }
}