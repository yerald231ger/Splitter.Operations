namespace Splitter.Operations.Constants;

public enum SplitterRejectionCodes
{
    InvalidEventTableName = 1,
    EventTableNotFound = 2,
    InvalidProductName = 3,
    OrderNotFound = 4,
    OrderAlreadyPaid = 5,
    InsufficientFunds = 6,
    InvalidTip = 7,
    RepositoryError = 8
}
