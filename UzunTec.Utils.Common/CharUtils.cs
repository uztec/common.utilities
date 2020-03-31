namespace UzunTec.Utils.Common
{
    public static class CharUtils
    {
        public static char ToUpper(this char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                c -= (char)('a' - 'A');
            }
            return c;
        }

        public static char ToLower(this char c)
        {
            if (c >= 'A' && c <= 'Z')
            {
                c += (char)('a' - 'A');
            }
            return c;
        }
    }
}
