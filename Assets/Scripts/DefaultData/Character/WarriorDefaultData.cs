using UnityEngine;

[CreateAssetMenu(fileName = "WarriorDefaultData", menuName = "CharacterData/WarriorDefaultData")]
public class WarriorDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<WarriorRuntimeData>(id, out var data)) return data;

        data = new WarriorRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }

    public override void RemoveRuntimeData(RuntimeDataRepository repository, int id)
    {
        repository.RemoveData<WarriorRuntimeData>(id);
    }
}
