using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace SyndicateSolver
{
    public class Settings : ISettings
    {
        public ToggleNode Enable { get; set; } = new ToggleNode(true);
    }
}