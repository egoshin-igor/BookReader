namespace BookReader.Core.Entities
{
    public class Genre
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        protected Genre()
        {

        }
    }
}
