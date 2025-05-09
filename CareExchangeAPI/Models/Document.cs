namespace CareExchangeAPI.Models;

public class Document
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool Required { get; set; }

    public int? ExpiryDays { get; set; }

    public bool ClientVisible { get; set; }

    public bool CandidateVisible { get; set; }

    public List<CandidateDocument> CandidateDocuments { get; set; } = [];
}