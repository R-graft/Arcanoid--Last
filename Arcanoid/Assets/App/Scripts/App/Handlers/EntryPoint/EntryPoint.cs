using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] protected UIWindow sceneWindow;

    protected ProjectContext context;

    protected const string ProjectContextFilePath = "Context/ProjectContext";

    protected void Awake()
    {
        EntryInit();
    }

    protected virtual void EntryInit()
    {
        context = Instantiate(Resources.Load<ProjectContext>(ProjectContextFilePath));

        context.InitContext();

        InitSceneWindow();
    }
    protected void InitSceneWindow()
    {
        sceneWindow.Construct(context.GetService<UIPopUpController>());
    }
}
