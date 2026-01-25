using UnityEngine;

public class HealerPool : CharacterPool
{
    [SerializeField] HealerDefaultData _data;

    public override CharacterInput Instantiate(CharacterInput character)
    {
        var go = Instantiate(character, new Vector3(-1, 1, 0), Quaternion.identity);
        go.Init(_system, this);
        return go;
    }

    protected override void CreateRuntime(int id)
    {
        if (_repository.TryGetData<HealerRuntimeData>(id, out _)) return;

        var data = new HealerRuntimeData(_data);
        _repository.RegisterData(id, data);
    }
}
