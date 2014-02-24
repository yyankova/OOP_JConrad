namespace JConradOOPProject.GameObjects.Tools.Shields
{
    public abstract class Shield : Item
    {
        public Shield()
        { }

        public Shield(string inputName, decimal inputPrice)
            : base(inputName, inputPrice)
        {
        }

        public Shield(string inputName, decimal inputPrice, string imageSource)
            : base(inputName, inputPrice, imageSource)
        {
        }
    }
}
