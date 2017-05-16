namespace Batonezas.WebApi.Models.UserModels
{
    public class UserProfileEditModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string ImageUri { get; set; }

        public int RoleId { get; set; }
    }
}