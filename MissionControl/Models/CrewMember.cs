using System.ComponentModel.DataAnnotations;

namespace MissionControl.Models
{
    public class CrewMember
    {
        public int CrewMemberId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Role { get; set; }

        public int ExperienceYears { get; set; }

        public int MissionId { get; set; }

        public Mission? Mission { get; set; }
    }
}