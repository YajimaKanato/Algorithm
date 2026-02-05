using UnityEngine;

[CreateAssetMenu(fileName = "WarriorDefaultData", menuName = "CharacterData/WarriorDefaultData")]
public class WarriorDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<WarriorRuntimeData>(id, out _)) return null;

        var data = new WarriorRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }
}
