using System;
using System.Collections.Generic;
using System.Web.Http;
using v1.Service;
using System.Net.Http;
using System.Net;
using System.Linq;
using v1.Models;

namespace v1.Controllers
{
    public class EventsController : ApiController
    {
        // API EventController only handles request reponse
        // Create an OBJ of the eventService Class that handles all event data as a layer of abstranction
        EventService eventService = new EventService();

        // GET: 
        // api/v1/Events
        // api/v1/Events?Category=swimming
        // api/v1/Events?Category=walking
        // api/v1/Events?Category=cycling
        // api/v1/Events?Category=running
        // api/v1/Events?Category=weight training
        [HttpGet]
        public HttpResponseMessage getAllEvents(string category="All")
        {
            List<Event> eventList = eventService.getEvents(category);
            return eventList != null 
            ? Request.CreateResponse(HttpStatusCode.OK, eventList)
            : Request.CreateResponse(HttpStatusCode.BadRequest, 
                $"Value for Category must be Running, Walking, Cycling, Swimming or Weight Training: {category} is invalid.");
        }

        // GET: api/v1/Events/5
        [HttpGet]
        public HttpResponseMessage getASingleEvent(int id)
        {
            Event singleEvent = eventService.getEventById(id);

            return singleEvent != null
               ? Request.CreateResponse(HttpStatusCode.OK, singleEvent)
               : Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event could not be found");
        }

        // POST: api/v1/Events
        [HttpPost]
        public HttpResponseMessage createEvent([FromBody]Event value)
        {
            try
            {
                eventService.addEvent(value);
                var msg = Request.CreateResponse(HttpStatusCode.Created, value);
                msg.Headers.Location = new Uri($"{Request.RequestUri}/{value.Id.ToString()}");
                return msg;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/v1/Events/5
        [HttpPut]
        public HttpResponseMessage updateEvent(int id, [FromBody]Event value)
        {
            try
            {
                eventService.updateEvent(id, value);
                return Request.CreateResponse(HttpStatusCode.OK, "Event Updated");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cannot Update this item at this time.");
            }
        }

        // DELETE: api/v1/Events/5
        [HttpDelete]
        public HttpResponseMessage deleteEvent(int id)
        {
            try
            {
                eventService.deleteEvent(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Event Deleted");
            }
            catch(Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cannot Remove this item at this time.");
            }
        }
    }
}
