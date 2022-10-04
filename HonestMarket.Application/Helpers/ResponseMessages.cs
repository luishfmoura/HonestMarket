namespace HonestMarket.Application.Helpers;

public class ResponseMessages
{
    private readonly string Gender;
    private readonly string EntityName;

    public ResponseMessages(string entityName)
    {
        Gender = entityName[^1].ToString();
        EntityName = entityName;
    }

    public string UPDATED => $"{EntityName} atualizad{Gender} com sucesso";
    public string CREATED => $"{EntityName} cadastrad{Gender} com sucesso";
    public string REMOVED => $"{EntityName} removid{Gender} com sucesso";
    public static string NOTUPDATED => "Não foi possível atualizar";
    public static string NOTCREATED => "Não foi possível cadastrar";
    public static string NOTREMOVED => "Não foi possível remover";
}
