
namespace com.gt.assets
{
    

    /// <summary>
    /// 
    /// </summary>
    public interface IAssetBundle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        T Load<T>(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T MainAsset<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object Load(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object MainAsset();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        void Unload(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unloadAssetManager"></param>
        void Unload(bool unloadAssetManager);

        /// <summary>
        /// 
        /// </summary>
        AssetParameter Parameter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Name { get; }
    }
}
