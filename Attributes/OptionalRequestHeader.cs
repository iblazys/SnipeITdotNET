namespace SnipeITdotNET.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class OptionalRequestHeader : Attribute
    {
        // Needed due to SnipeIT's inconsistent naming

        private string _headerName;
        public string HeaderName { get { return _headerName; } }

        public OptionalRequestHeader(string headerName)
        {
            _headerName = headerName;
        }
    }
}
