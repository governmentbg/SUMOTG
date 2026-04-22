namespace Common.Entities
{
    public class UserObhvat
    {
        public int UserId { get; set; }
        public int ObhvatId { get; set; }
        public string RaionId { get; set; }

        public virtual User User { get; set; }
        public virtual Obhvat Obhvat{ get; set; }
    }
}
