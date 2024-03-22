namespace NftFaucet.Domain.Models.Abstraction;

public interface IToken
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime CreatedAt { get; }
    public ITokenMedia MainFile { get; }
    public ITokenMedia CoverFile { get; }
    public Guid? ImporterId { get; set; }
    public string Location { get; }
}
