﻿using System;

namespace FP.Spartakiade2018.CQRS.Domain.Commands
{
    public class AddConference
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public DateTime? RegistrationStart { get; set; }

        public DateTime? RegistrationEnd { get; set; }
    }
}
