namespace CoreSystem
{
    public abstract class Config
    {
        public string dataPath { private set; get; }

        protected void DataPath(string path)
        {
            this.dataPath = path;
        }
    }
}