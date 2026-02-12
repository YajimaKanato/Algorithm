using UnityEngine;

[CreateAssetMenu(fileName = "HealerDefaultData", menuName = "CharacterData/HealerDefaultData")]
public class HealerDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<HealerRuntimeData>(id, out var data)) return data;

        data = new HealerRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }

    public override void RemoveRuntimeData(RuntimeDataRepository repository, int id)
    {
        repository.RemoveData<HealerRuntimeData>(id);
    }
}
