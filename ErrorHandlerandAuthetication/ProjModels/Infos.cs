namespace ErrorHandlerandAuthetication.ProjModels
{
    public class FuncInfo
    {
        public string ParentCode { get; set; }
        
        public string FuncCode { get; set; }

        public string Url { get; set; }
    }

    public class HeaderInfo
    {
        public string ParentCode { get; set; }
        public IEnumerable<FuncInfo> FuncInfos { get; set; }
    }
}
