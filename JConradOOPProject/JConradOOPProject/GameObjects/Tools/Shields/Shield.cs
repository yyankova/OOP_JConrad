namespace JConradOOPProject.GameObjects.Tools.Shields
{
    public abstract class Shield : Item
    {
        public Shield()
        { }

        public Shield(byte id, string inputName, decimal inputPrice)
            : base(id, inputName, inputPrice)
        {
        }

        public Shield(byte id, string inputName, decimal inputPrice, string imageSource)
            : base(id, inputName, inputPrice, imageSource)
        {
        }
    }
}
