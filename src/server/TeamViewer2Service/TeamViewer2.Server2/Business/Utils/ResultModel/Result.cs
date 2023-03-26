namespace TeamViewer2.Server2.Business.Utils.ResultModel
{
        public class Result<T>
        {
                public int code { get; set; }
                public T data { get; set; }
        }
}
