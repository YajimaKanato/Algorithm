using UnityEngine;

[CreateAssetMenu(fileName = "HeroDefaultData", menuName = "CharacterData/HeroDefaultData")]
public class HeroDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<HeroRuntimeData>(id, out _)) return null;

        var data = new HeroRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }
}
