﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Howest.MagicCards.DAL.Models
{
    public class CardType
    {
        public int CardId { get; set; }
        public int TypeId { get; set; }

        public virtual Card Card { get; set; }
        public virtual Type Type { get; set; }
    }
}
