namespace Shared;

public abstract record UpdateDto
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
}