

using P07.MilitaryElite.Enumerations;

namespace P07.MilitaryElite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }
        State State { get; }
        void CompleteMission();
    }
}
