﻿using System;

namespace FP.Spartakiade2018.CQRS.Domain.Events
{
    public class AddConferenceEvent : EventBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public DateTime? RegistrationStart { get; set; }

        public DateTime? RegistrationEnd { get; set; }
    }
}
