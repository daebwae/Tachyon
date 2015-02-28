namespace Tachyon
{


    class ProfileResult
    {
        public ProfileResult(bool success, long bytes, long miliseconds, int result)
        {
            Success = success; 
            Bytes = bytes;
            Miliseconds = miliseconds;
            Result = result; 
        }

        public bool Success { get; private set; }
        public long Bytes { get; private set; }
        public long Miliseconds { get; private set; }
        public long Result { get; private set; }
    }
}
