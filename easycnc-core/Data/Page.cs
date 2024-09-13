namespace easycnc_core.Data
{
    public class Page<T>
    {
        public int Total { get; set; }

        public List<T> Content { get; set; }

        public Page(int total,List<T> content) {
            this.Total = total;
            this.Content = content;
        }

    }
}
