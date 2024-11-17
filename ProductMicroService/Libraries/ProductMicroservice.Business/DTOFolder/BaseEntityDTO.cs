namespace ProductMicroservice.Business.DTOFolder
{
    public class BaseEntityDTO
    {
        public Guid? Id { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public Guid CreatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public Guid? UpdatedUserId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public string? LogMessage { get; set; }
    }
}
