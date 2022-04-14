using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Cors;
using api.Database;





namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        [EnableCors("OpenPolicy")]
        // GET: api/Songs
        [HttpGet]
        public List<Song> Get()
        {
            List<Song> mySongs = new List<Song>();
            ReadFromDatabase read = new ReadFromDatabase();
            mySongs = read.GetAll();
            return mySongs;

        }

        [EnableCors("OpenPolicy")]
        // GET: api/Songs/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [EnableCors("OpenPolicy")]
        // POST: api/Songs
        [HttpPost]
        public void Post(Song song)
        {
            CreateTable.Add(song);
        }

        [EnableCors("OpenPolicy")]
        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
            FavoriteSong favorite = new FavoriteSong();
            favorite.Favorite(id);
        }

        [EnableCors("OpenPolicy")]
        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DeleteSong delete = new DeleteSong();
            delete.Delete(id);
        }
    }
}
