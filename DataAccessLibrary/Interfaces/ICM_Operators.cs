namespace DataAccessLibrary;

public interface ICM_Operators
{
    Task<List<OperatorModel>> GetOperators();
    Task InsertOperator(OperatorModel operatorModel);
}
