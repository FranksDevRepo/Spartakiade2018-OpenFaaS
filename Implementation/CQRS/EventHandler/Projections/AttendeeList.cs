﻿using System.Linq;
using System.Threading.Tasks;
using FP.Spartakiade2018.CQRS.Data;
using FP.Spartakiade2018.CQRS.Data.ReadModels;
using FP.Spartakiade2018.CQRS.Domain.Events;

namespace FP.Spartakiade2018.CQRS.EventHandler.Projections
{
    public class AttendeeList
    {
        public static async Task Handle(NewRegistrationEvent newRegistrationEvent)
        {
            var dl = new HandlerDataLayer();
            var item = await dl.GetAttendeeListItemByEmail(newRegistrationEvent.Email);
            if (item == null)
            {
                item = new AttendeeListItem
                {
                    Email = newRegistrationEvent.Email,
                    Count = 0
                };
            }

            item.Name = newRegistrationEvent.Name;
            item.FirstName = newRegistrationEvent.FirstName;
            item.Company = newRegistrationEvent.Company;
            item.Count++;
            await dl.SaveAttendeeListItem(item);
        }

        public static async Task Handle(CancelRegistrationEvent cancelRegistrationEvent)
        {
            var dl = new HandlerDataLayer();
            var conference = await dl.GetConferenceItemById(cancelRegistrationEvent.ConferenceId);
            var registration = conference.Attendees.First(x => x.RegistrationId == cancelRegistrationEvent.RegistrationId);
            var item = await dl.GetAttendeeListItemByEmail(registration.Email);
            item.Count--;
            await dl.SaveAttendeeListItem(item);
        }
    }
}
