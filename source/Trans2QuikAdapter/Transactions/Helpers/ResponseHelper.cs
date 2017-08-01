namespace Trans2QuikAdapter.Transactions.Helpers
{
    using Trans2QuikAdapter.Transactions.Enums;

    public static class ResponseHelper
    {
        public static string ResponseCodeToString(this ResponseCode code)
        {
            switch(code)
            {
                case ResponseCode.ALREADY_CONNECTED_TO_QUIK:
                    return "Already connected to Quik";
                case ResponseCode.DLL_CONNECTED:
                    return "DLL Connected";
                case ResponseCode.DLL_DISCONNECTED:
                    return "DLL Disconnected";
                case ResponseCode.DLL_NOT_CONNECTED:
                    return "DLL not connected";
                case ResponseCode.DLL_VERSION_NOT_SUPPORTED:
                    return "DLL version not supported";
                case ResponseCode.FAILED:
                    return "Failed";
                case ResponseCode.MEMORY_ALLOCATION_ERROR:
                    return "Memory allocation error";
                case ResponseCode.QUIK_CONNECTED:
                    return "Quik connected";
                case ResponseCode.QUIK_DISCONNECTED:
                    return "Quik disconnected";
                case ResponseCode.QUIK_NOT_CONNECTED:
                    return "Quik not connected";
                case ResponseCode.QUIK_TERMINAL_NOT_FOUND:
                    return "Quik terminal not found";
                case ResponseCode.SUCCESS:
                    return "Success";
                case ResponseCode.WRONG_CONNECTION_HANDLE:
                    return "Wrong connection handle";
                case ResponseCode.WRONG_INPUT_PARAMS:
                    return "Wrong input params";
                case ResponseCode.WRONG_SYNTAX:
                    return "Wrong syntax";
            }

            return $"{code}";
        }
    }
}
