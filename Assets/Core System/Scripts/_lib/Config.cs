namespace CoreSystem
{
    public abstract class Config
    {
        public string savePath { private set; get; }

        protected void SavePath(string path)
        {
            this.savePath = path;
        }
    }
}