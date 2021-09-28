using TelephoneDirectory.Debugging;

namespace TelephoneDirectory
{
    public class TelephoneDirectoryConsts
    {
        public const string LocalizationSourceName = "TelephoneDirectory";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "d02192d00275425f99304d544d77d693";
    }
}
