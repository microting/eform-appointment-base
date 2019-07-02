namespace Microting.AppointmentBase.Infrastructure.Data.Constants
{
    public static class Constants
    {
        public static class ProcessingState
        {
            public const string Planned = "planned";
            public const string Processed = "processed";
            public const string Created = "created";
            public const string Sent = "sent";
            public const string Retrieved = "retrieved";
            public const string Completed = "completed";
            public const string Canceled = "canceled";
            public const string Revoked = "revoked";
            public const string Exception = "exception";
            public const string FailedToIntrepid = "failed_to_intrepid";
        }
    }
}