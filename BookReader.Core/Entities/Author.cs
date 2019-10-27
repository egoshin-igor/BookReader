namespace BookReader.Core.Entities
{
    public class Author
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        protected Author()
        {

        }
    }
}
