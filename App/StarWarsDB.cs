﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public class StarWarsDB
    {
        public static IEnumerable<Jedi> GetJedis()
        {
            return new List<Jedi>() 
            {
                 new Jedi(){ Name ="Luke", Side="Light"},
                 new Jedi(){ Name ="Yoda", Side="Light"},
                 new Jedi(){ Name ="Darth Vader", Side="Dark"}
            };
        }
    }
}
