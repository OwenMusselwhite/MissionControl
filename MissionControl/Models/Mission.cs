using System.ComponentModel.DataAnnotations;

namespace MissionControl.Models
{
    public class Mission
    {
        public int MissionId { get; set; }

        [Required]
        public string MissionName { get; set; }

        [Required]
        public string DestinationPlanet { get; set; }

        public DateTime LaunchDate { get; set; }

        public string MissionStatus { get; set; }

        public List<CrewMember>? CrewMembers { get; set; }
    }
}