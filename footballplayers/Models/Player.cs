using Microsoft.AspNetCore.Mvc;
using System;

namespace footballplayers.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int TeamId { get; set; }
        public string Country { get; set; }

        // Добавлено свойство для связи с командой
        public Team Team { get; set; }
    }
}
