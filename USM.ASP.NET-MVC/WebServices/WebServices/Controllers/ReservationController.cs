using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServices.Models;

namespace WebServices.Controllers
{
    public class ReservationController : ApiController
    {
        IReservationRepository repo = ReservationRepository.getRepository();

        [HttpGet]
        public IEnumerable<Reservation> GetAllReservations()
        {
            return repo.GetAll();
        }
        [HttpGet]
        public Reservation GetReservation(int id)
        {
            return repo.Get(id);
        }
        [HttpPost]
        public Reservation PostReservation(Reservation item)
        {
            return repo.Add(item);
        }
        [HttpPut]
        public bool PutReservation(Reservation item)
        {
            return repo.Update(item);
        }
        [HttpDelete]
        public void DeleteReservation(int id)
        {
            repo.Remove(id);
        }
    }
}
