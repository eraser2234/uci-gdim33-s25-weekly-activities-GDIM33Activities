using UnityEngine;
using Unity.VisualScripting;

public class MyCustomScript : MonoBehaviour
{
    public DialogueNode dialogueNode;
    public static class EventNames
    {
        public const string MyCustomEvent = "MyCustomEvent";
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventBus.Trigger(EventNames.MyCustomEvent, dialogueNode);
        }
    }
}

[UnitTitle("On My Custom Event")]
[UnitCategory("Events\\MyEvents")]
public class MyCustomEvent : EventUnit<DialogueNode>
{
    [DoNotSerialize]
    public ValueOutput result;
    protected override bool register => true;
    public override EventHook GetHook(GraphReference reference)
    {
        return new EventHook(MyCustomScript.EventNames.MyCustomEvent);
    }

    protected override void Definition()
    {
        base.Definition();
        result = ValueOutput<DialogueNode>("result");
    }

    protected override void AssignArguments(Flow flow, DialogueNode data)
    {
        flow.SetValue(result, data);
    }
}