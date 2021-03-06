﻿using System;
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
using System.Web.Http.Cors;

namespace ProjectSophiaService.Controllers
{
    [RoutePrefix("api/benchmarks")]
    public class BenchmarksController : ApiController
    {
        private ProjectSophiaServiceContext db = new ProjectSophiaServiceContext();

        // GET: api/benchmarks/all
        [HttpGet]
        [Route("all")]
        public IEnumerable<BenchmarkViewModels.GameDTO> GetBenchmarksDetails()
        {
            var benchmarkDetails = db.Benchmarks.Select(b => new BenchmarkViewModels.GameDTO()
                             {
                                 Id = b.Id,
                                 Username = b.Username,
                                 CPU = b.AvgFPS,
                                 GPU = b.GPU,
                                 RAM = b.RAM,
                                 AvgFPS = b.AvgFPS,
                                 MaxFPS = b.MaxFPS,
                                 MinFPS = b.MinFPS
                             });
            return benchmarkDetails;
        }
        
        [HttpGet]
        [Route("game/{gameId}")]
        public IEnumerable<BenchmarkViewModels.GameDTO> GetBenchmarksByGame(int gameId)
        {
            var benchmarks = db.Benchmarks
                .Where(x => x.GameId == gameId)
                .Select(b => new BenchmarkViewModels.GameDTO()
            {
                Id = b.Id,
                Username = b.Username,
                CPU = b.CPU,
                GPU = b.GPU,
                RAM = b.RAM,
                AvgFPS = b.AvgFPS,
                MaxFPS = b.MaxFPS,
                MinFPS = b.MinFPS
            });
            return benchmarks;
        }
        public static IEnumerable<BenchmarkViewModels.GameDTO> ConvertBenchmarkToVM(IEnumerable<Benchmark> benchmarks) {
            ///Fill Out
            return null;
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

        [HttpPost]
        [Route("add", Name="AddBenchmark")]
        // POST: api/Benchmarks
        [ResponseType(typeof(Benchmark))]
        public async Task<HttpResponseMessage> PostBenchmark(Benchmark benchmark)
        {

            db.Benchmarks.Add(benchmark);

            db.SaveChanges();

            var response = Request.CreateResponse(HttpStatusCode.Created);

            string uri = Url.Link("AddBenchmark", new { id = benchmark.Id });
            response.Headers.Location = new Uri(uri);
            return response;
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