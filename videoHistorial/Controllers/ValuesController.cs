using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace videoHistorial.Controllers
{
    public class ValuesController : ApiController
    {
        YouTubeEntities db = new YouTubeEntities();

        //GET api/values
        public List<string> Get()
        {
            return db.History.OrderByDescending(x => x.Id).Take(10).Select(x => x.VideoId).ToList();
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
        public void Post(string VideoId)
        {
            db.History.Add(new History(){IsEnabled = true, Date = DateTime.Now, VideoId = VideoId});
            db.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
