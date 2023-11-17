namespace NewsCMS.Infra.Data.Sql.Query.DbSets;

using System.ComponentModel.DataAnnotations;

public class Keyword
{
    [Key]
    public Guid Code { get; set; }
    public string Title { get; set; }
    public NewsKeyword NewsKeyword { get; set; }
    //public NewsKeyword NewsKeyword { get; set; }
}