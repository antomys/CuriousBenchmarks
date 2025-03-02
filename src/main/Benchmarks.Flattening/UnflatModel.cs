namespace Benchmarks.Flattening;

public sealed class UnflatModel
{ 
    public string? Email { get; init; }

    public bool? IsEmailConfirmed { get; init; }

    public bool? IsPhoneConfirmed { get; init; }

    public InternalModel? InternalModel { get; init; }

    public string? Phone { get; init; }
}