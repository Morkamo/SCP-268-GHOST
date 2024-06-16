using Exiled.API.Interfaces;

namespace SCP_268_GHOST
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        public item268g Item268G { get; set; } = new();
    }
}