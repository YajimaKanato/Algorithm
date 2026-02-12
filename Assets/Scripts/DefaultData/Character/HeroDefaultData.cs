using UnityEngine;

[CreateAssetMenu(fileName = "HeroDefaultData", menuName = "CharacterData/HeroDefaultData")]
public class HeroDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<HeroRuntimeData>(id, out var data)) return data;

        data = new HeroRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }

    public override void RemoveRuntimeData(RuntimeDataRepository repository, int id)
    {
        repository.RemoveData<HeroRuntimeData>(id);
    }
}
