namespace vendor.domain.entities.manytomany
{
    public class UserProduct
    {
        public long ParentId { get; set; }
        public long ProductId { get; set; }
        // public DateTime AddedDate { get; set; }
        // public DateTime? BuyingDate { get; set; }

        public User Parent { get; set; }
        public Product Product { get; set; }
    }
}
