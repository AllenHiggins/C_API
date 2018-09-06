using System.Collections.Generic;
using System.Linq;
using v1.Models;

namespace v1.Service
{
    public class EventService
    {

        public EventService() { }
           
        // Handels Get Request for all events or by category using query string
        public List<Event> getEvents(string category)
        {
            using (EventDBV1 entities = new EventDBV1())
            {
                switch (category.ToLower()) {
                    case "all":
                        return entities.Events.ToList();
                    case "running":
                        return byCategory(entities, category);
                    case "walking":
                        return byCategory(entities, category);
                    case "swimming":
                        return byCategory(entities, category);
                    case "cycling":
                        return byCategory(entities, category);
                    case "weight training":
                        return byCategory(entities, category);
                    default:
                        return null;
                }
            }
        }

        // Handels Get Request by ID
        public Event getEventById(int id)
        {
            using (EventDBV1 entities = new EventDBV1())
            {
                return findTheEvent(entities, id);
            }
        }

        // Handels Post Request for new event
        public void addEvent(Event eventData)
        {
            using (EventDBV1 entities = new EventDBV1())
            {
                entities.Events.Add(eventData);
                entities.SaveChanges();
            }
        }

        // Handels update Request for a event selected by ID
        public void updateEvent(int id, Event upDateData)
        {
            using (EventDBV1 entities = new EventDBV1())
            {
                // The entire Event OBJ must be updated even if only just one row is changing
                Event theEventToUpDate = findTheEvent(entities, id);
                theEventToUpDate.EndDate = upDateData.EndDate;
                theEventToUpDate.EndTime = upDateData.EndTime;
                theEventToUpDate.StartDate = upDateData.StartDate;
                theEventToUpDate.StartTime = upDateData.StartTime;
                theEventToUpDate.Category = upDateData.Category;
                theEventToUpDate.Note = upDateData.Note;
                entities.SaveChanges();
            }
        }

        // Handels deleting an event Request selected by ID:
        public void deleteEvent(int id)
        {
            using (EventDBV1 entities = new EventDBV1())
            {
                entities.Events.Remove(findTheEvent(entities, id));
                entities.SaveChanges();
            }
        }

        // For looping through the list of data entries and returning a single event selected by ID
        private Event findTheEvent(EventDBV1 entity, int id)
        {
            // Lambos... ye ha!
            return entity.Events.FirstOrDefault(x => x.Id == id);
        }

        // Return all Events relating to a Category .. ie: "Running"
        private List<Event> byCategory(EventDBV1 entity, string categoryPassedIn)
        {
            // More Lambos... ye ha, go get them Coyboy!
            return entity.Events.Where(e => e.Category.ToLower() == categoryPassedIn).ToList();
        }
        
    }
}