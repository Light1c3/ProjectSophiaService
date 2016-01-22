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
    public class BenchmarksController : ApiController
    {
        private ProjectSophiaServiceContext db = new ProjectSophiaServiceContext();

        // GET: api/Benchmarks
        public IEnumerable<BenchmarkViewModels.BenchmarkDTO> GetBenchmarks()
        {            
            var benchmarks = from b in db.Benchmarks select new BenchmarkViewModels.BenchmarkDTO()
            {
                Id = b.Id,
                Username = b.Username,
                GameName = b.Game.Title,
                AvgFPS = b.AvgFPS
            };
            return benchmarks;
        }

        // GET: api/Benchmarks/5
        [ResponseType(typeof(Benchmark))]
        public async Task<IHttpActionResult> GetBenchmark(int id)
        {
            Benchmark benchmark = await db.Benchmarks.FindAsync(id);
            if (benchmark == null)
            {
                return NotFound();
            }

            return Ok(benchmark);
        }

        // PUT: api/Benchmarks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBenchmark(int id, Benchmark benchmark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != benchmark.Id)
            {
                return BadRequest();
            }

            db.Entry(benchmark).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenchmarkExists(id))
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

        // POST: api/Benchmarks
        [ResponseType(typeof(Benchmark))]
        public async Task<IHttpActionResult> PostBenchmark(Benchmark benchmark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Benchmarks.Add(benchmark);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = benchmark.Id }, benchmark);
        }

        // DELETE: api/Benchmarks/5
        [ResponseType(typeof(Benchmark))]
        public async Task<IHttpActionResult> DeleteBenchmark(int id)
        {
            Benchmark benchmark = await db.Benchmarks.FindAsync(id);
            if (benchmark == null)
            {
                return NotFound();
            }

            db.Benchmarks.Remove(benchmark);
            await db.SaveChangesAsync();

            return Ok(benchmark);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BenchmarkExists(int id)
        {
            return db.Benchmarks.Count(e => e.Id == id) > 0;
        }
    }
}