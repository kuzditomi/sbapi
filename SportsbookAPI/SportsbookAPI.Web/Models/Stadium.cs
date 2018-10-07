namespace SportsbookAPI.Web.Models
{
    /// <summary>
    /// Description of a stadium that gives place to events
    /// </summary>
    public class Stadium : StadiumCreateModel
    {
        /// <summary>
        /// Uniq identifier of the stadium
        /// </summary>
        public int Id { get; set; }

        public Stadium()
        {
            
        }

        public Stadium(StadiumCreateModel s)
        {
            this.Name = s.Name;
        }
    }
}
