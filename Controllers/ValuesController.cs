using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace players.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {
            using Models.playersContext db = new Models.playersContext();
            var lst = (from d in db.Jugadores
                       select d).ToList();

            return Ok(lst);
        }
        
        //Se ha unido un nuevo integrante al equipo de ESport, lo agregare

        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.JugadoresRequest model)
        {
            using (Models.playersContext db = new Models.playersContext())
            {
                Models.Jugadore oJugadore = new Models.Jugadore();
                oJugadore.Nick = model.Nick;
                oJugadore.Edad = model.Edad;
                oJugadore.Pais = model.Pais;
                oJugadore.Wins = model.Wins;
                db.Jugadores.Add(oJugadore);
                db.SaveChanges();

                return Ok();

            }
        }

        //Un integrante del equipo ha ganado partidas y ademas ha cumplido años, editare su informacion
        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.JugadoresRequest model)
        {
            using (Models.playersContext db = new Models.playersContext())
            {
                Models.Jugadore oJugadore = db.Jugadores.Find(model.Id);
                oJugadore.Pais = model.Pais;
                oJugadore.Wins = model.Wins;
                db.Entry(oJugadore).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                return Ok();
            }
        }

        //Eliminare un integrante de mi equipo de ESport

        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.JugadoresRequest model)
        {
            using (Models.playersContext db = new Models.playersContext())
            {
                Models.Jugadore oJugadore = db.Jugadores.Find(model.Id);
                db.Jugadores.Remove(oJugadore);
                db.SaveChanges();

                return Ok();
            }
        }
    }
}