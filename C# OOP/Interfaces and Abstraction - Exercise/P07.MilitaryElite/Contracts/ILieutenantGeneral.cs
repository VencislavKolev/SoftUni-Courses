
using System.Collections.Generic;

namespace P07.MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }
        void AddPrivate(ISoldier @private);
    }
}
