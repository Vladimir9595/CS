using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACCHETTO_Vladimir_TP1
{
    public class Player
    {
        public string FirstName { get; set; } // Player's first name.
        public string LastName { get; set; } // Player's last name.
        public string Alias { get; set; } // Player's alias.
        public Spaceship DefaultSpaceship { get; set; }

        public string Name => $"{FirstName} {LastName}"; // Name property: a string containing the player's first name followed by his last name.

        public Player(string firstName, string lastName, string alias)
        {
            FirstName = FormatName(firstName);
            LastName = FormatName(lastName);
            Alias = FormatName(alias);
            DefaultSpaceship = null;
        }

        // FormatName method to format the player's name.
        private static string FormatName(string name)
        {
            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        // ToString method to return the player's nickname followed by his first and last name in brackets.
        public override string ToString()
        {
            return $"{Alias} ({Name})";
        }

        // Equals method to compare two players with their pseudo.
        public bool Equals(Player other)
        {
            if (other == null)
                return false;
            return Alias == other.Alias;
        }

    }
}
