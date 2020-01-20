namespace Features.Input
{
    public sealed class InputSystems : Feature
    {
        public InputSystems(Contexts contexts)
        {
            Add(new InputSystem(contexts));
            Add(new InputProcessSystem(contexts));
        }
    }
}