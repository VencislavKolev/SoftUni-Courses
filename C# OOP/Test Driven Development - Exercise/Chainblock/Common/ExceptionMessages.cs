
namespace Chainblock.Common
{
    public static class ExceptionMessages
    {
        //-----Transaction Exception Messages -----
        public static string invalidIdMessage = "IDs cannot be zero or negative.";
        public static string invalidSenderMessage = "Sender cannot be null or empty.";
        public static string invalidReceiverMessage = "Receiver cannot be null or empty.";
        public static string invalidAmountMessage = "Amount cannot be zero or negative.";

        //-----Chainblock Exception Messages -----
        public static string existingTransactionMessage = "The transaction already exists in our records.";
        public static string nonExistingTransactionMessage = "The transaction does not exists in our records.";
        public static string emptyTranscationCollection = "The collection is empty because no matched were found.";
    }
}
