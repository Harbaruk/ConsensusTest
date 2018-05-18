namespace ConsensusTester.DataAccess.Entities
{
    public class BlockVerificationEntity
    {
        public int Id { get; set; }

        public string UserPublicKey { get; set; }

        public BlockEntity Block { get; set; }
    }
}