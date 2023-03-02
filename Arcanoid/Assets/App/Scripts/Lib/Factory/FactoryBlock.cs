
using UnityEngine;

public class FactoryBlock<T> where T : Block
{
    private T _creatingObject;

    private BlocksSystem _blocksController;
    public FactoryBlock(T currentBlockType, BlocksSystem controller)
    {
        _creatingObject = currentBlockType;

        _blocksController = controller;
    }

    public  T CreateObject()
    {
        var creatingBlock = Object.Instantiate(_creatingObject, _blocksController.transform);

        creatingBlock._blocksSystem = _blocksController;

        return creatingBlock;
    }
}
    
