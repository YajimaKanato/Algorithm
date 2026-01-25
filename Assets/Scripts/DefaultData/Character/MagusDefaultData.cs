using UnityEngine;

[CreateAssetMenu(fileName = "MagusDefaultData", menuName = "CharacterData/MagusDefaultData")]
public class MagusDefaultData : CharacterDefaultData
{
    public override void CreateRuntimeData(RuntimeDataRepository repository, int id)
    {
        if (repository.TryGetData<MagusRuntimeData>(id, out _)) return;

        var data = new MagusRuntimeData(this);
        repository.RegisterData(id, data);
    }
}
