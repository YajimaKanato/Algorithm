using UnityEngine;

public interface IDefault
{
    public CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id);
}

public interface IRuntime { }
