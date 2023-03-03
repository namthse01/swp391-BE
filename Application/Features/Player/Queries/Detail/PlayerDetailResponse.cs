namespace Application.Features.Player.Queries.Detail
{
    public class PlayerDetailResponse
    {
        public PlayerUserResponse User { get; set; }
    }

    public class PlayerUserResponse
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}