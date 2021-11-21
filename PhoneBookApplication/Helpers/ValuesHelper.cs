namespace PhoneBookApplication.Helpers
{
    public static class ValuesHelper
    {
        #region Stored Procs
        public const string  GET_PHONEBOOK_ENTRIES_SP = "usp_GetPhoneBookEntries";
        public const string ADD_CONTACT_DETAILS_SP = "usp_AddContactDetails";
        #endregion

        #region Log Info Messages
        public const string INITIALIAZE_MAIN_INFO_MESSAGE = "Initializing Main";
        public const string ENTRIES_RETRIEVED_INFO_MESSAGE = "Retrieved users phonebook entries";
        public const string NO_ENTRIES_INFO_MESSAGE = "List has no phonebook entries";
        public const string ADD_ENTRY_INFO_MESSAGE = "Added phonebook entry - Name:";
        public const string ADD_ENTRY_FAILED_INFO_MESSAGE = "Added phonebook entry failed - Name:";
        #endregion

        #region Start up Class Hardcoding
        public const string APP_SETTINGS_JSON = "appsettings.json";
        public const string SQL_CONNECTION = "SqlConnection";
        public const string ERROR_PATH = "/Home/Error";
        public const string CONTROLLER_PATTERN = "{controller=PhoneBook}/{action=Index}/{id?}";
        public const string DEFAULT = "default";
        #endregion

        #region Program Class Hardcoding
        public const string NLOG_CONFIG = "nlog.config";
        #endregion
    }
}
