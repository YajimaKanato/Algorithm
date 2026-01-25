using UnityEngine;

[CreateAssetMenu(fileName = "HealerDefaultData", menuName = "CharacterData/HealerDefaultData")]
public class HealerDefaultData : CharacterDefaultData
{
    public override void CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<HealerRuntimeData>(id, out _)) return;

        var data = new HealerRuntimeData(this);
        repository.RegisterData(id, data);
    }
}
