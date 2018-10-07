using System.ComponentModel.DataAnnotations;

namespace SportsbookAPI.Web.Models
{
    /// <summary>
    /// Description of a stadium that gives place to events
    /// </summary>
    public class StadiumCreateModel
    {
        /// <summary>
        /// Publicly displayable name of the Stadium
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
