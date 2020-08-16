using BusinessLayer.DTOs.Common;
using BusinessLayer.DTOs.Games;
using System;
using BusinessLayer.DTOs.GameParticipations;

namespace BusinessLayer.DTOs.Stats
{
    public class StatsDetailDto : BaseDto
    {
        public Guid GameParticipationId { get; set; }
        public GameParticipationListDto GameParticipation { get; set; }
        public string Name { get; set; }
        public int GameCount { get; set; }
        public int WinCount { get; set; }
        public double WinRatio { get; set; }
        public int DamageDealt { get; set; }
        public int DamageReceived { get; set; }
        public int Kills { get; set; }
    }
}