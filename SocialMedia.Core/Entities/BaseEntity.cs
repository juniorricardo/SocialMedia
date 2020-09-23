namespace SocialMedia.Core.Entities {
    public abstract class BaseEntity {
        public int Id { get; set; }
        public int date { get; set; }

        //Puede ser usada para auditoria

    }
}