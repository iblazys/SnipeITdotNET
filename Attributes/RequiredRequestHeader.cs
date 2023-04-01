namespace SnipeITdotNET.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class RequiredRequestHeader : Attribute
    {
        private string _headerName;
        public string HeaderName { get { return _headerName; } }

        public RequiredRequestHeader(string headerName)
        {
            _headerName = headerName;
        }
    }
}
