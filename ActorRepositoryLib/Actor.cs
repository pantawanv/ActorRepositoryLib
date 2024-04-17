namespace ActorRepositoryLib
{
    public class Actor 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public int Rating { get; set; }

        public override string ToString() => $"{Id} {Name} {BirthYear} {Rating}";

        public void ValidateName()
        {
            if (Name is null)
            {
                throw new ArgumentNullException("Name is null");
            }
            if (Name.Length < 4)
            {
                throw new ArgumentException("Name is too short");
            }
        }
        
        public void ValidateBirthYear()
        {
            if(BirthYear < 1820)
            {
                throw new ArgumentException("Birthyear must be after 1820");
            }
        }
    }
}
