﻿using System;

namespace FP.Spartakiade2018.CQRS.Domain.Events
{
    public class NewRegistrationEvent :  EventBase
    {
        public Guid ConferenceId { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }
    }
}
