using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectSophiaService.Models;
using ProjectSophia.ViewModels;

namespace ProjectSophiaService.Controllers
{
    [RoutePrefix("api/games")]
    public class GamesController : ApiController
    {
        private ProjectSophiaServiceContext db = new ProjectSophiaServiceContext();

        // GET: api/Games
        [HttpGet]
        [Route("all")]
        public IEnumerable<GameViewModels.GameDTO> GetGamesDetails()
        {
            var gameDetails = db.Games.Select(b => new GameViewModels.GameDTO()
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                Year = b.Year,
                ShortLink = b.ShortLink,
                Publisher = b.Publisher,
                ImageUrl = b.ImageUrl,
                MarkCount = db.Benchmarks.Where(x => x.GameId == b.Id).Count()
            });
            return gameDetails;
        }

        // GET: api/Games/5
        [HttpGet]
        [Route("{gameId}")]
        public IEnumerable<GameViewModels.GameDTO> getGameById(int gameId)
        {
            var game = db.Games
                .Where(x => x.Id == gameId)
                .Select(b => new GameViewModels.GameDTO()
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                Year = b.Year,
                ShortLink = b.ShortLink,
                Publisher = b.Publisher,
                ImageUrl = b.ImageUrl,
            });
            return game;
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGame(int id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.Id)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Games
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> PostGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(game);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Game))]
        public async Task<IHttpActionResult> DeleteGame(int id)
        {
            Game game = await db.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            await db.SaveChangesAsync();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Games.Count(e => e.Id == id) > 0;
        }
    }
}