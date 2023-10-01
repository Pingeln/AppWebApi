using Configuration;

namespace Models

{
    public class IUser
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public List<IComment> Comments { get; set; }
    }
}