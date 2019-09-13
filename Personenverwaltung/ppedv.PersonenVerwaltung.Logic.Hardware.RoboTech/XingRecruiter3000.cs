﻿using AutoFixture;
using ppedv.Personenverwaltung.Domain;
using ppedv.Personenverwaltung.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.PersonenVerwaltung.Logic.Hardware.RoboTech
{
    public class XingRecruiter3000 : IDevice
    {
        private Fixture fix = new Fixture();
        public Person RecruitPerson()
        {
            Console.Beep();
            return fix.Create<Person>();
        }
    }
}
