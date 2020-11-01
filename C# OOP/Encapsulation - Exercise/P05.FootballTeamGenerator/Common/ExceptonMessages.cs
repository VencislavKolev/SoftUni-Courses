

namespace P05.FootballTeamGenerator.Common
{
    public static class ExceptonMessages
    {
        public const string InvalidStatRangeMessage = "{0} should be between {1} and {2}.";
        public const string InvalidNameMessage = "A name should not be empty.";
        public const string RemovingMissingPlayerMessage = "Player {0} is not in {1} team.";
        public const string NonExistingTeamMessage = "Team {0} does not exist.";
        public const string NonExistingPlayerMessage = "Player {0} is not in {1} team.";
    }
}
