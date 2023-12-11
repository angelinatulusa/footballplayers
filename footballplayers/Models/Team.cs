using Microsoft.AspNetCore.Mvc;
using System;

namespace footballplayers.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        // Свойство навигации для связанных игроков
        public List<Player> Players { get; set; }
    }
}
