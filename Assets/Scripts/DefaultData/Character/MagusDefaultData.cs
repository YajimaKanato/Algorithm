using UnityEngine;

[CreateAssetMenu(fileName = "MagusDefaultData", menuName = "CharacterData/MagusDefaultData")]
public class MagusDefaultData : CharacterDefaultData
{
    public override CharacterRuntimeData CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<MagusRuntimeData>(id, out _)) return null;

        var data = new MagusRuntimeData(this);
        repository.RegisterData(id, data);
        return data;
    }
}
