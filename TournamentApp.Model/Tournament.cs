using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TournamentApp.Model
{
    public class Tournament : EntityBase

    {
    public string TournamentName { get; set; }
    public DateTime Date { get; set; }
    [JsonIgnore] public List<Round> Rounds { get; set; } // ref
    }
}