namespace WorldCup.CrossCutting.Models
{
    public interface ISettings
    {
        public WorldCupSettings WorldCupSettings { get; }
    }

    public class Settings : ISettings
    {

        public required WorldCupSettings WorldCupSettings { get; set; }
    }
}
